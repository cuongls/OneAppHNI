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
using ExcelDataReader;
using OneAppHNI.Log.Dtos;
using OneAppHNI.Log;
using System;
using Abp.Authorization;
using OneAppHNI.Authorization;

namespace OneAppHNI.VoTuyen
{
    [AbpAuthorize(PermissionNames.Pages_TramLoaiTru)]
    public class TRAMLOAITRUAppService : ApplicationService, ITRAMLOAITRUAppService
    {
        private readonly IRepository<TRAMLOAITRU, long> _repository;
		private readonly IAbpSession _abpSession;
        private readonly ILOGUPLOADFILEAppService _uploadFileService;
        public TRAMLOAITRUAppService(IRepository<TRAMLOAITRU, long> initRepository, IAbpSession abpSession,
            ILOGUPLOADFILEAppService uploadFileService)
        {
            _repository = initRepository;
			 _abpSession = abpSession;
            _uploadFileService = uploadFileService;
        }      
        public async Task<PagedResultDto<TRAMLOAITRUDto>> Getall(GetTRAMLOAITRUs input)
        {
            //Total Record
            var countQuery = _repository.GetAll()
                            .WhereIf(!string.IsNullOrEmpty(input.Filter), 
                                p => p.SITENAME.Contains(input.Filter));
            var totalRecord = countQuery.Count();
            //Record with filter & pager
            var result = _repository
                            .GetAll()
                            .WhereIf(!string.IsNullOrEmpty(input.Filter), p => p.SITENAME.Contains(input.Filter))
                            .OrderBy(p => p.SITENAME)                            
                            .PageBy(input).ToList();
            return new PagedResultDto<TRAMLOAITRUDto>(
                totalRecord, 
                result.MapTo<List<TRAMLOAITRUDto>>()
                );
        }
        public async Task<TRAMLOAITRUDto> Get(GetTRAMLOAITRU input)
        {
            TRAMLOAITRU nhomVT =  await _repository.GetAsync(input.Id);
            return nhomVT.MapTo<TRAMLOAITRUDto>();
        }
        public void Create(CreateOrEditTRAMLOAITRU input)
        {
            input.TenantId = AbpSession.TenantId;
            var checkitem = _repository.GetAll().Where(x => x.SITENAME == input.SITENAME
            && x.CELLNAME == input.CELLNAME 
            && x.TenantId == input.TenantId
            ).ToList();
            var item = ObjectMapper.Map<TRAMLOAITRU>(input);
            _repository.Insert(item);
            foreach (var check in checkitem)
            {
                item.ISACTIVE = false;
                _repository.Update(check);
            }
        }
        public void Update(CreateOrEditTRAMLOAITRU input)
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
            CreateOrEditLOGUPLOADFILE logfile = new CreateOrEditLOGUPLOADFILE();
            logfile.LOAIFILE = "TRAMLOAITRU";
            logfile.FILEPATH = "TramLoaiTru";
            logfile.file = file;
            _uploadFileService.Create(logfile);
            SaveDataFromFile(file);
        }
        public async Task SaveDataFromFile(IFormFile file)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);
                stream.Position = 0;
                int row = 0;


                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        if (row > 0)
                        {
                            CreateOrEditTRAMLOAITRU data = new CreateOrEditTRAMLOAITRU
                            {
                                QUANHUYEN = reader.GetValue(0) == null ? "" : reader.GetValue(0).ToString(),
                                LATITUDE = reader.GetValue(1) == null ? 0 : double.Parse(reader.GetValue(1).ToString()),
                                LONGITUDE = reader.GetValue(2) == null ? 0 : double.Parse(reader.GetValue(2).ToString()),
                                LOAITRAM = reader.GetValue(3) == null ? "" : reader.GetValue(3).ToString(),
                                SITENAME = reader.GetValue(4) == null ? "" : reader.GetValue(4).ToString(),
                                CELLNAME = reader.GetValue(5) == null ? "" : reader.GetValue(5).ToString(),
                                CELLNAMEALIAS = reader.GetValue(6) == null ? "" : reader.GetValue(6).ToString(),
                                TRANGTHAI = reader.GetValue(7) == null ? "" : reader.GetValue(7).ToString(),
                                THOIGIAN = reader.GetValue(8) == null ? null : Convert.ToDateTime(reader.GetValue(8).ToString()),
                                GHICHU = reader.GetValue(9) == null ? "" : reader.GetValue(9).ToString(),
                                ISACTIVE = true
                            };
                            Create(data);
                        }
                        row++;

                    }
                }
            }
        }
    }
}
