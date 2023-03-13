using System.Linq;
using Abp.Domain.Repositories;
using Abp.Application.Services;
using OneAppHNI.Log;
using OneAppHNI.Log.Dtos;
using System.Collections.Generic;
using AutoMapper;
using Abp.Linq.Extensions;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.Threading.Tasks;
using Abp.Runtime.Session;
using Abp.UI;
using System.Net.Mail;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections;

namespace OneAppHNI.Log
{
    [Authorize]
    public class LOGSENDEMAILAppService : ApplicationService, ILOGSENDEMAILAppService
    {
        private readonly IRepository<LOGSENDEMAIL, long> _repository;
		private readonly IAbpSession _abpSession;
        public LOGSENDEMAILAppService(IRepository<LOGSENDEMAIL, long> initRepository, IAbpSession abpSession)
        {
            _repository = initRepository;
			 _abpSession = abpSession;
        }      
        public async Task<PagedResultDto<LOGSENDEMAILDto>> Getall(GetLOGSENDEMAILs input)
        {
            //Total Record
            var countQuery = _repository.GetAll()
                            .WhereIf(!string.IsNullOrEmpty(input.Filter), 
                                p => p.SUBJECT.Contains(input.Filter));
            var totalRecord = countQuery.Count();
            //Record with filter & pager
            var result = _repository
                            .GetAll()
                            .WhereIf(!string.IsNullOrEmpty(input.Filter), p => p.SUBJECT.Contains(input.Filter))
                            .OrderBy(p => p.SUBJECT)                            
                            .PageBy(input).ToList();
            return new PagedResultDto<LOGSENDEMAILDto>(
                totalRecord, 
                result.MapTo<List<LOGSENDEMAILDto>>()
                );
        }
        public async Task<LOGSENDEMAILDto> Get(GetLOGSENDEMAIL input)
        {
            LOGSENDEMAIL nhomVT =  await _repository.GetAsync(input.Id);
            return nhomVT.MapTo<LOGSENDEMAILDto>();
        }
        public void Create(CreateOrEditLOGSENDEMAIL input)
        {
            input.TenantId = AbpSession.TenantId;           
            var item = ObjectMapper.Map<LOGSENDEMAIL>(input);
            _repository.Insert(item);
        }
        public void Update(CreateOrEditLOGSENDEMAIL input)
        {   
            var item = _repository.Get(input.Id);                  
            ObjectMapper.Map(input, item);  
        }
        public void Delete(long id)
        {
            _repository.Delete(id);    
        }
        public void SendEmailVNPT(string yourEmail, string passWord, List<string> lsToEmail, string subjectEmail, string bodyEmail, List<string> lsFilePath)
        {
            CreateOrEditLOGSENDEMAIL log = new CreateOrEditLOGSENDEMAIL();
            log.EMAILSEND = yourEmail;
            log.SUBJECT = subjectEmail;
            //log.BODY = bodyEmail;
            log.EMAILNHAN = string.Join(";", lsToEmail); 
            log.FILEDINHKEM = string.Join(";", lsFilePath);
            log.NGAYGUI = DateTime.Now;
            log.NGUOIGUI = AbpSession.UserId;


            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.vnpt.vn");
            mail.From = new MailAddress(yourEmail);
            foreach (var item in lsToEmail)
            {
                mail.To.Add(item);
            }
            mail.IsBodyHtml = true;
            mail.Subject = subjectEmail;
            mail.Body = bodyEmail;
            foreach (var item in lsFilePath)
            {
                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(item);
                mail.Attachments.Add(attachment);
            }

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(yourEmail, passWord);
            SmtpServer.EnableSsl = true;
            try
            {
                SmtpServer.Send(mail);
                log.KETQUA = "THANH CONG";
            }catch(Exception ex)
            {
                log.KETQUA = ex.Message;
            }
            Create(log);
        }
    }
}
