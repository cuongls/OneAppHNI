using System.Linq;
using Abp.Domain.Repositories;
using Abp.Application.Services;
using OneAppHNI.VoTuyen;
using OneAppHNI.VoTuyen.Dtos;
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
using System;
using OneAppHNI.Log.Dtos;
using OneAppHNI.Log;
using Abp.Extensions;
using ExcelDataReader;
using System.Globalization;
using OneAppHNI.DienNang;
using Abp.Authorization;
using OneAppHNI.Authorization;
using OneAppHNI.Api;
using Abp.Collections.Extensions;
using OneAppHNI.Authorization.Users;
using Abp.Configuration;
using Newtonsoft.Json;

namespace OneAppHNI.VoTuyen
{
    [AbpAuthorize(PermissionNames.Pages_Badcell)]
    public class BADCELLAppService : ApplicationService, IBADCELLAppService
    {
        private readonly IRepository<BADCELL, long> _repository;
        private readonly IRepository<User, long> _user;
		private readonly IAbpSession _abpSession;
        private readonly ILOGUPLOADFILEAppService _uploadFileService;
        private readonly IApiDHTT _apiDHTT;
        private readonly SettingManager _settingManager;
        public BADCELLAppService(IRepository<BADCELL, long> initRepository, IAbpSession abpSession,
            ILOGUPLOADFILEAppService uploadFileService,
            IApiDHTT apiDHTT, IRepository<User, long> user, SettingManager settingManager)
        {
            _repository = initRepository;
			 _abpSession = abpSession;
            _uploadFileService = uploadFileService;
            _apiDHTT = apiDHTT;
            _user = user;
            _settingManager = settingManager;
        }      
        public async Task<PagedResultDto<BADCELLDto>> Getall(GetBADCELLs input)
        {
            //Total Record
            var countQuery = _repository.GetAll()
                            .Where(x => x.TRANGTHAI == input.TRANGTHAI)
                            .Where(x => x.TUANBAOCAO == input.TUAN)
                            .Where(x => x.NAMBAOCAO == input.NAM)
                            .WhereIf(!string.IsNullOrEmpty(input.CELL), x => x.LOAICELL == input.CELL)
                            .WhereIf(!string.IsNullOrEmpty(input.Filter), 
                                p => p.TENCELL.Contains(input.Filter));
            var totalRecord = countQuery.Count();
            //Record with filter & pager
            var result = _repository
                            .GetAll()
                            .Where(x => x.TRANGTHAI == input.TRANGTHAI)
                            .Where(x => x.TUANBAOCAO == input.TUAN)
                            .Where(x => x.NAMBAOCAO == input.NAM)
                            .WhereIf(!string.IsNullOrEmpty(input.CELL), x => x.LOAICELL == input.CELL)
                            .WhereIf(!string.IsNullOrEmpty(input.Filter), p => p.TENCELL.Contains(input.Filter))
                            .OrderBy(p => p.TENCELL)                            
                            .PageBy(input).ToList();
            return new PagedResultDto<BADCELLDto>(
                totalRecord, 
                result.MapTo<List<BADCELLDto>>()
                );
        }
        public async Task<BADCELLDto> Get(GetBADCELL input)
        {
            BADCELL nhomVT =  await _repository.GetAsync(input.Id);
            return nhomVT.MapTo<BADCELLDto>();
        }
        public void Create(CreateOrEditBADCELL input)
        {
            input.TenantId = AbpSession.TenantId;
            var checkitem = _repository.GetAll().Where(x => x.TUANBAOCAO == input.TUANBAOCAO
            && x.NAMBAOCAO == input.NAMBAOCAO
            && x.TENCELL == input.TENCELL && x.TENTRAM == input.TENTRAM && x.LOAICELL == input.LOAICELL
            && x.TenantId == input.TenantId
            ).FirstOrDefault();
            if (checkitem == null)
            {
                var item = ObjectMapper.Map<BADCELL>(input);
                _repository.Insert(item);
            }
            else
            {
                input.Id = checkitem.Id;
                Update(input);
            }
            
        }
        public void Update(CreateOrEditBADCELL input)
        {   
            var item = _repository.Get(input.Id);                  
            ObjectMapper.Map(input, item);  
        }
        public void Delete(long id)
        {
            _repository.Delete(id);    
        }
        public void Upload(IFormFile file, int tuanbaocao, int nambaocao, string loaicell)
        {
            CreateOrEditLOGUPLOADFILE logfile = new CreateOrEditLOGUPLOADFILE();
            logfile.LOAIFILE = "BADCELL";
            logfile.FILEPATH = "BadCell";
            logfile.file = file;
            _uploadFileService.Create(logfile);
            SaveDataFromFile(file, tuanbaocao, nambaocao, loaicell);
        }
        public void SaveDataFromFile(IFormFile file, int tuanbaocao, int nambaocao, string loaicell)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);
                stream.Position = 0;
                var now = DateTime.Now;
                int row = 0;
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        if (row > 8)
                        {
                            CreateOrEditBADCELL data = new CreateOrEditBADCELL
                            {
                                MATINH = reader.GetValue(0) == null ? "" : reader.GetValue(0).ToString(),
                                DONVI = reader.GetValue(1) == null ? "" : reader.GetValue(1).ToString(),
                                QUANHUYEN = reader.GetValue(2) == null ? "" : reader.GetValue(2).ToString(),
                                TENTRAM = reader.GetValue(3) == null ? "" : reader.GetValue(3).ToString(),
                                TENCELL = reader.GetValue(4) == null ? "" : reader.GetValue(4).ToString(),
                                CELLID = reader.GetValue(5) == null ? 0 : long.Parse(reader.GetValue(5).ToString()),
                                QOSDIEM = reader.GetValue(6) == null ? 0 : double.Parse(reader.GetValue(6).ToString()),
                                QOSTYLE = reader.GetValue(7) == null ? 0 : double.Parse(reader.GetValue(7).ToString()),
                                SQICHUANHOA1 = reader.GetValue(8) == null ? 0 : double.Parse(reader.GetValue(8).ToString()),
                                SQICHUANHOA2 = reader.GetValue(9) == null ? 0 : double.Parse(reader.GetValue(9).ToString()),
                                SQICHUANHOA3 = reader.GetValue(10) == null ? 0 : double.Parse(reader.GetValue(10).ToString()),
                                SQICHUANHOA4 = reader.GetValue(11) == null ? 0 : double.Parse(reader.GetValue(11).ToString()),
                                SQICHUANHOA5 = reader.GetValue(12) == null ? 0 : double.Parse(reader.GetValue(12).ToString()),
                                SQIDIEM1 = reader.GetValue(13) == null ? 0 : double.Parse(reader.GetValue(13).ToString()),
                                SQIDIEM2 = reader.GetValue(14) == null ? 0 : double.Parse(reader.GetValue(14).ToString()),
                                SQIDIEM3 = reader.GetValue(15) == null ? 0 : double.Parse(reader.GetValue(15).ToString()),
                                SQIDIEM4 = reader.GetValue(16) == null ? 0 : double.Parse(reader.GetValue(16).ToString()),
                                SQIDIEM5 = reader.GetValue(17) == null ? 0 : double.Parse(reader.GetValue(17).ToString()),
                                KPIDAURASQI1 = reader.GetValue(18) == null ? 0 : double.Parse(reader.GetValue(18).ToString()),
                                KPIDAURASQI2 = reader.GetValue(19) == null ? 0 : double.Parse(reader.GetValue(19).ToString()),
                                KPIDAURASQI3 = reader.GetValue(20) == null ? 0 : double.Parse(reader.GetValue(20).ToString()),
                                KPIDAURASQI4 = reader.GetValue(21) == null ? 0 : double.Parse(reader.GetValue(21).ToString()),
                                KPIDAURASQI5 = reader.GetValue(22) == null ? 0 : double.Parse(reader.GetValue(22).ToString()),
                                KPIDAUVAOSQI1 = reader.GetValue(23) == null ? 0 : double.Parse(reader.GetValue(23).ToString()),
                                KPIDAUVAOSQI2 = reader.GetValue(24) == null ? 0 : double.Parse(reader.GetValue(24).ToString()),
                                KPIDAUVAOSQI3 = reader.GetValue(25) == null ? 0 : double.Parse(reader.GetValue(25).ToString()),
                                KPIDAUVAOSQI4 = reader.GetValue(26) == null ? 0 : double.Parse(reader.GetValue(26).ToString()),
                                KPIDAUVAOSQI5 = reader.GetValue(27) == null ? 0 : double.Parse(reader.GetValue(27).ToString()),
                                KPIDAUVAOOUTDOR = reader.GetValue(28) == null ? 0 : double.Parse(reader.GetValue(28).ToString()),
                                TRAFFIC = reader.GetValue(29) == null ? 0 : double.Parse(reader.GetValue(29).ToString()),
                                LOAICELL = loaicell,
                                TUANBAOCAO = tuanbaocao,
                                NAMBAOCAO = nambaocao
                            };
                            Create(data);
                        }
                        row++;
                    }
                }
            }
        }
        public async Task<string> XuatPhieuBadCell(BADCELLDto input)
        {

            //string url = "http://10.10.117.177:8000/api/XPNB_InsertNewAlarm";
            string url = _settingManager.GetSettingValue("CAUHINH.BADCELL.URLXPDHTT") + "/api/XPNB_InsertNewAlarm";
            string method = "POST";
            string data = String.Format("\"magui\": 0," +
                "\"LoaiTin\": \"{0}\"," +
                "\"TieuDe\":\"{1}\"," +
                "\"NoiDung\":\"{2}\"," +
                "\"NoiDungUpdate\": \"\"," +
                "\"NoiDungtraphieu\": \"\"," +
                "\"NguoiNhan\": \"\"," +
                "\"NgayGui\": \"{3}\"," +
                "\"UserXuatPhieu\": \"{4}\"," +
                "\"NguoiGui\": \"{5}\"," +
                "\"PhoiHop\": \"\"," +
                "\"ChuTri\": \"\"," +
                "\"TapTin\": \"\"," +
                "\"TrangThaiXuLy\": false," +
                "\"DsSendSMS\": \"\"," +
                "\"CotCao\": true," +
                "\"TimeUpdate\": \"\"," +
                "\"UserKhoaPhieu\": \"\"," +
                "\"UserKhoaTraPhieu\": \"\"," +
                "\"TimeTraPhieu\": \"\"," +
                "\"DiaChiTram\": \"{6}\"," +
                "\"TenQuanLy\": \"{7}\"," +
                "\"ViTriPhieu\": \"\"," +
                "\"NhapThoiHanXL\": \"48\"" ,
                    "Bad Cell", 
                    input.TENTRAM, 
                    "Xuất phiếu xử lý Bad Cell tuần " + input.TUANBAOCAO + " năm " + input.NAMBAOCAO , 
                    DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"), 
                    _user.Get(_abpSession.UserId.Value).UserName,
                    "GIAIPHAP_VOTUYEN",
                    input.QUANHUYEN,
                    input.TENCELL
                    );

            var result =  _apiDHTT.CallApi(url, method, "", "{" + data + "}" );
            var id = input.Id;
            var item = _repository.Get(id);
            item.TRANGTHAI = 1;
            _repository.Update(item);
            return result;
        }
        public List<ThongTinPhieu> GetPhieuBadCell(BADCELLDto input)
        {

            string url = _settingManager.GetSettingValue("CAUHINH.BADCELL.URLXPDHTT") + "/api/XPNB_GetAlarm/";
            string method = "GET";
            string data = String.Format("?Email={0}&LoaiAlarm={1}&MaTram={2}&TrangThaiXL=&DonViXL=",
                    _user.Get(_abpSession.UserId.Value).UserName,
                    "Bad Cell",
                    input.TENCELL
                    );

            var json = _apiDHTT.CallApi(url, method, "",  data);
            var result = JsonConvert.DeserializeObject<List<ThongTinPhieu>>(json);
            return result;
        }
    }
}
