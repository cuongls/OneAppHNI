using System.Linq;
using Abp.Domain.Repositories;
using Abp.Application.Services;
using OneAppHNI.DienNang;
using OneAppHNI.DienNang.Dtos;
using System.Collections.Generic;
using AutoMapper;
using Abp.Linq.Extensions;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.Threading.Tasks;
using Abp.Runtime.Session;
using Abp.UI;
using Microsoft.AspNetCore.Http;
using OneAppHNI.Log.Dtos;
using OneAppHNI.Log;
using System.IO;
using ExcelDataReader;
using System;
using Abp.Extensions;
using Abp.Authorization;
using OneAppHNI.Authorization;
using System.Text.RegularExpressions;
using Abp.Configuration;
using System.Text;
using Castle.Core.Internal;
using Hangfire;

namespace OneAppHNI.DienNang
{
    [AbpAuthorize(PermissionNames.Pages_DienNang)]
    public class DIENNANGAppService : ApplicationService, IDIENNANGAppService
    {
        private readonly IRepository<DIENNANG, long> _repository;
		private readonly IAbpSession _abpSession;
		private readonly ILOGUPLOADFILEAppService _uploadFileService;
		private readonly ILOGSENDEMAILAppService _logSendEmailService;
        private readonly SettingManager _settingManager;
        //private readonly IBackgroundJobClient _backgroundJobClient;


        public DIENNANGAppService(IRepository<DIENNANG, long> initRepository, IAbpSession abpSession,
            ILOGUPLOADFILEAppService uploadFileService, ILOGSENDEMAILAppService logSendEmailService,
            SettingManager settingManager//, IBackgroundJobClient backgroundJobClient
            )
        {
            _repository = initRepository;
			 _abpSession = abpSession;
            _uploadFileService = uploadFileService;
            _logSendEmailService = logSendEmailService;
            _settingManager = settingManager;
            //_backgroundJobClient = backgroundJobClient;
        }      
        public async Task<PagedResultDto<DIENNANGDto>> Getall(GetDIENNANGs input)
        {
            //Total Record
            var countQuery = _repository.GetAll()
                            .WhereIf(!string.IsNullOrEmpty(input.Filter), 
                                p => p.TENTRAM.Contains(input.Filter));
            var totalRecord = countQuery.Count();
            //Record with filter & pager
            var result = _repository
                            .GetAll()
                            .WhereIf(!string.IsNullOrEmpty(input.Filter), p => p.TENTRAM.Contains(input.Filter))
                            .OrderBy(p => p.TENTRAM)                            
                            .PageBy(input).ToList();
            return new PagedResultDto<DIENNANGDto>(
                totalRecord, 
                result.MapTo<List<DIENNANGDto>>()
                );
        }
        public async Task<DIENNANGDto> Get(GetDIENNANG input)
        {
            DIENNANG nhomVT =  await _repository.GetAsync(input.Id);
            return nhomVT.MapTo<DIENNANGDto>();
        }
        public void Create(CreateOrEditDIENNANG input)
        {
            try
            {
                input.TenantId = AbpSession.TenantId;
                var checkitem = _repository.GetAll().Where(x => x.THANGBAOCAO == input.THANGBAOCAO
                && x.NAMBAOCAO == input.NAMBAOCAO
                && x.MACSHT == input.MACSHT && x.TENTRAM == input.TENTRAM
                && x.TenantId == AbpSession.TenantId
                ).FirstOrDefault();
                if (checkitem == null)
                {
                    var item = ObjectMapper.Map<DIENNANG>(input);
                    
                    _repository.Insert(item);
                }
                else
                {
                    input.Id = checkitem.Id;
                    Update(input);
                }
                
            }catch(Exception ex)
            {

            }
            
        }
        //sdfasf
        public void Update(CreateOrEditDIENNANG input)
        {   
            var item = _repository.Get(input.Id);                  
            ObjectMapper.Map(input, item);  
        }
        public void Delete(long id)
        {
            _repository.Delete(id);    
        }
        public void Upload(IFormFile file)
        {
            try
            {
                CreateOrEditLOGUPLOADFILE logfile = new CreateOrEditLOGUPLOADFILE();
                logfile.LOAIFILE = "DIENNANG";
                logfile.FILEPATH = "DienNang";
                logfile.file = file;
                _uploadFileService.Create(logfile);
                SaveDataFromFile(file);
            }catch(Exception ex)
            {

            }
            
        }
        public void SaveDataFromFile( IFormFile file)
        {
            try
            {
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                var now = DateTime.Now;
                int row = 0;
                string filename = file.FileName;
                var splitFileName = filename.Split("_");
                var ngaybaocao = now.Day;
                var thangbaocao = now.Month + 1;
                var nambaocao = now.Year;
                if (splitFileName.Length > 3)
                {
                    try
                    {
                        thangbaocao = Int32.Parse(splitFileName[1].ToString());
                    }
                    catch (Exception ex) { };
                    try
                    {
                        nambaocao = Int32.Parse(splitFileName[2].ToString().Left(4));
                    }
                    catch (Exception ex) { };
                }
                using (var stream = new MemoryStream())
                {
                    file.CopyTo(stream);
                    stream.Position = 0;
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        while (reader.Read())
                        {
                            if (row > 1)
                            {
                                CreateOrEditDIENNANG data = new CreateOrEditDIENNANG
                                {
                                    MACSHT = reader.GetValue(0) == null ? "" : reader.GetValue(0).ToString(),
                                    TTVT = reader.GetValue(1) == null ? "" : reader.GetValue(1).ToString(),
                                    DOIVT = reader.GetValue(2) == null ? "" : reader.GetValue(2).ToString(),
                                    MUCDICHSD = reader.GetValue(3) == null ? "" : reader.GetValue(3).ToString(),
                                    TENTRAM = reader.GetValue(4) == null ? "" : reader.GetValue(4).ToString(),
                                    LOAIHINHTH = reader.GetValue(5) == null ? "" : reader.GetValue(5).ToString(),
                                    SODIEN = reader.GetValue(6) == null ? 0 : double.Parse(reader.GetValue(6).ToString()),
                                    TIENDIEN = reader.GetValue(7) == null ? 0 : double.Parse(reader.GetValue(7).ToString()),
                                    CPVANHANH = reader.GetValue(8) == null ? 0 : double.Parse(reader.GetValue(8).ToString()),
                                    CPTHUEHATANG = reader.GetValue(9) == null ? 0 : double.Parse(reader.GetValue(9).ToString()),
                                    CPLAODONG = reader.GetValue(10) == null ? 0 : double.Parse(reader.GetValue(10).ToString()),
                                    CPSUACHUA = reader.GetValue(11) == null ? 0 : double.Parse(reader.GetValue(11).ToString()),
                                    CPKHAC = reader.GetValue(12) == null ? 0 : double.Parse(reader.GetValue(12).ToString()),
                                    MAHOADON = reader.GetValue(13) == null ? "" : reader.GetValue(13).ToString(),
                                    CHUNGCSHT = reader.GetValue(14) == null ? "" : reader.GetValue(14).ToString(),
                                    GHICHU = reader.GetValue(15) == null ? "" : reader.GetValue(15).ToString(),
                                    TRANGTHAI = reader.GetValue(16) == null ? "" : reader.GetValue(16).ToString(),
                                    NETXXACNHAN = reader.GetValue(17) == null ? "" : reader.GetValue(17).ToString(),
                                    NGAYBAOCAO = ngaybaocao,
                                    THANGBAOCAO = thangbaocao,
                                    NAMBAOCAO = nambaocao
                                };
                                Create(data);
                            }
                            row++;

                        }
                    }
                }
            }catch(Exception ex)
            {

            }
            
        }
        public static string GetMyTable<T>(IEnumerable<T> list, params string[] columns)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("<TABLE style='font-size: 10pt; border: 1pt solid black; border-collapse: collapse;'>\n");
            sb.Append("<TR style='font-weight: bold; border: 1pt solid black; border-collapse: collapse; background-color: #96D4D4;'>\n");
            foreach (var column in columns)
            {
                sb.Append("<TD style=' border: 1pt solid black; border-collapse: collapse;'>");
                sb.Append(column);
                sb.Append("</TD>");
            }
            sb.Append("</TR> <!-- HEADER -->\n");


            foreach (var item in list)
            {
                sb.Append("<TR style=' border: 1pt solid black; border-collapse: collapse;'>\n");
                foreach (var column in columns)
                {
                    sb.Append("<TD style=' border: 1pt solid black; border-collapse: collapse;'>");
                    sb.Append(item.GetType().GetProperty(column).GetValue(item, null));
                    sb.Append("</TD>");
                }
                sb.Append("</TR>\n");
            }
            sb.Append("</TABLE>");

            return sb.ToString();
        }

        public List<CanhBaoDto> SendEmail(int thang, int nam, int muccanhbaothuong, int muccanhbaokhan)
        {
            var lsdata = GetDienNangBatThuongThang(thang, nam, muccanhbaothuong, muccanhbaokhan);
            if(lsdata.Count > 0)
            {
                string yourEmail = _settingManager.GetSettingValue("CAUHINH.EMAILSEND.ACOUNT");
                string passWord = _settingManager.GetSettingValue("CAUHINH.EMAILSEND.PASSWORD");
                string toEmail = _settingManager.GetSettingValue("CAUHINH.DIENNANG.EMAILNHANCANHBAO");
                string subjectEmail = "Cảnh báo tiêu thụ điện năng bất thường";
                string tieude = "TT ĐHTT - VNPT HNI gửi danh sách cảnh báo tiêu thụ điện năng bất thường tháng" + thang + "/" + nam + " <br />Cảnh báo khẩn( vượt ngưỡng " + muccanhbaokhan + "%) cảnh báo thường( vượt ngưỡng " + muccanhbaothuong + "%)" + " < br /> ";
                string chuky = "Chi tiết liên hệ:<br />Lê Sỹ Cường - ĐT: 0941.282.000 - Email: cuongls.bgg@vnpt.vn<br />Phòng kỹ thuật - Trung tâm Điều hành thông tin<br />Đây là email gửi tự động xin vui lòng không trả lời email này.<br />Thanks & Best Regards ";
                string body = GetMyTable(lsdata, "MACSHT", "TTVT", "TENTRAM", "MUCCANHBAO", "SODIEN", "SODIENTHANGTRUOC", "SODIENCUNGKYNAMTRUOC", "GHICHU");
                List<string> lsFilePath = new List<string>();
                //lsFilePath.Add(pdfExportFile);

                List<string> lsToEmail = new List<string>();
                Regex emailRegex = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
                RegexOptions.IgnoreCase);
                MatchCollection emailMatches = emailRegex.Matches(toEmail);
                foreach (Match emailMatch in emailMatches)
                {
                    lsToEmail.Add(emailMatch.Value);
                }
                string bodyEmail = tieude + body + chuky;
                _logSendEmailService.SendEmailVNPT(yourEmail, passWord, lsToEmail, subjectEmail, bodyEmail, lsFilePath);
            }
            return lsdata;
        }
        public List<CanhBaoDto> GetDienNangBatThuongThang(int thang, int nam, int muccanhbaothuong, int muccanhbaokhan)
        {
            var thangtruoc = thang == 1 ? 12 : thang - 1;
            var namtruoc = thang == 1 ? nam - 1 : nam;
            List<CanhBaoDto> lsCanhbao = new List<CanhBaoDto>();
            var lsdiennang = _repository
                .GetAll()
                .Where(x => x.THANGBAOCAO == thang && x.NAMBAOCAO == nam)
                .ToList();
            
            foreach( var item in lsdiennang)
            {
                var diennangthangtruoc = _repository
                .GetAll()
                .Where(x => x.THANGBAOCAO == thangtruoc && x.NAMBAOCAO == namtruoc && x.TENTRAM == item.TENTRAM)
                .FirstOrDefault();
                var diennangnamtruoc = _repository
                .GetAll()
                .Where(x => x.THANGBAOCAO == thang && x.NAMBAOCAO == nam - 1 && x.TENTRAM == item.TENTRAM)
                .FirstOrDefault();
                if (diennangthangtruoc != null)
                {
                    CanhBaoDto canhbao = new CanhBaoDto();
                    if (item.SODIEN > (diennangthangtruoc.SODIEN + diennangthangtruoc.SODIEN * muccanhbaothuong / 100))
                    {
                        if (item.SODIEN > (diennangthangtruoc.SODIEN + diennangthangtruoc.SODIEN * muccanhbaokhan / 100))
                        {
                            canhbao.MACSHT = item.MACSHT;
                            canhbao.TTVT = item.TTVT;
                            canhbao.DOIVT = item.DOIVT;
                            canhbao.MUCDICHSD = item.MUCDICHSD;
                            canhbao.TENTRAM = item.TENTRAM;
                            canhbao.LOAIHINHTH = item.LOAIHINHTH;
                            canhbao.MUCCANHBAO = "KHAN";
                            canhbao.SODIEN = item.SODIEN;
                            canhbao.SODIENTHANGTRUOC = diennangthangtruoc.SODIEN;
                            canhbao.GHICHU = "Vượt " + Math.Round(((item.SODIEN - diennangthangtruoc.SODIEN) / diennangthangtruoc.SODIEN * 100), 2).ToString() + "%";
                            canhbao.SODIENCUNGKYNAMTRUOC = diennangnamtruoc == null ? 0 : diennangnamtruoc.SODIEN;
                        }
                        else
                        {
                            canhbao.MACSHT = item.MACSHT;
                            canhbao.TTVT = item.TTVT;
                            canhbao.DOIVT = item.DOIVT;
                            canhbao.MUCDICHSD = item.MUCDICHSD;
                            canhbao.TENTRAM = item.TENTRAM;
                            canhbao.LOAIHINHTH = item.LOAIHINHTH;
                            canhbao.MUCCANHBAO = "THUONG";
                            canhbao.SODIEN = item.SODIEN;
                            canhbao.SODIENTHANGTRUOC = diennangthangtruoc.SODIEN;
                            canhbao.GHICHU = "Vượt " + Math.Round(((item.SODIEN - diennangthangtruoc.SODIEN) / diennangthangtruoc.SODIEN * 100),2).ToString() + "%";
                            canhbao.SODIENCUNGKYNAMTRUOC = diennangnamtruoc == null ? 0 : diennangnamtruoc.SODIEN;
                        }
                        lsCanhbao.Add(canhbao);
                    }
                }
                
            }
            return lsCanhbao;
        }
        
    }
}
