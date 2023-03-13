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
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System;
using Hangfire;

namespace OneAppHNI.Log
{
    public class LOGUPLOADFILEAppService : ApplicationService, ILOGUPLOADFILEAppService
    {
        private readonly IRepository<LOGUPLOADFILE, long> _repository;
        private readonly IAbpSession _abpSession;
        private IHostingEnvironment _environment;
        private readonly IBackgroundJobClient _backgroundJobClient;
        public LOGUPLOADFILEAppService(IRepository<LOGUPLOADFILE, long> initRepository, IAbpSession abpSession,
            IHostingEnvironment environment, IBackgroundJobClient backgroundJobClient)
        {
            _repository = initRepository;
            _abpSession = abpSession;
            _environment = environment;
            _backgroundJobClient = backgroundJobClient;
        }      
        public async Task<PagedResultDto<LOGUPLOADFILEDto>> Getall(GetLOGUPLOADFILEs input)
        {
            //Total Record
            var countQuery = _repository.GetAll()
                            .WhereIf(!string.IsNullOrEmpty(input.Filter), p => p.FILENAME.Contains(input.Filter) || p.LOAIFILE.Contains(input.Filter));
            var totalRecord = countQuery.Count();
            //Record with filter & pager
            var result = _repository
                            .GetAll()
                            .WhereIf(!string.IsNullOrEmpty(input.Filter), p => p.FILENAME.Contains(input.Filter) || p.LOAIFILE.Contains(input.Filter))
                            .OrderByDescending(p => p.CreationTime)                            
                            .PageBy(input).ToList();
            return new PagedResultDto<LOGUPLOADFILEDto>(
                totalRecord, 
                result.MapTo<List<LOGUPLOADFILEDto>>()
                );
        }
        public async Task<LOGUPLOADFILEDto> Get(GetLOGUPLOADFILE input)
        {
            LOGUPLOADFILE nhomVT =  await _repository.GetAsync(input.Id);
            return nhomVT.MapTo<LOGUPLOADFILEDto>();
        }
        public void Create(CreateOrEditLOGUPLOADFILE input)
        {
            
            string rootPath = Path.Combine(_environment.WebRootPath, "Uploads");
            string path = Path.Combine(rootPath, input.FILEPATH);
            IFormFile file = input.file;
            string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + file.FileName;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var filePath = Path.Combine(path, fileName);
            using (FileStream fs = System.IO.File.Create(filePath))
            {
                file.CopyTo(fs);
            }
            input.FILENAME = fileName;
            input.FILEPATH = path;
            input.TenantId = AbpSession.TenantId;
            input.IDUSER = AbpSession.UserId;
            var item = ObjectMapper.Map<LOGUPLOADFILE>(input);
             _repository.Insert(item);
        }
        
        public void Update(CreateOrEditLOGUPLOADFILE input)
        {   
            var item = _repository.Get(input.Id);                  
            ObjectMapper.Map(input, item);  
        }
        public void Delete(long id)
        {
            _repository.Delete(id);    
        }

    }
}
