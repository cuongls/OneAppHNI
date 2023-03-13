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


namespace OneAppHNI.Log
{
    public class LOGCALLAPIAppService : ApplicationService, ILOGCALLAPIAppService
    {
        private readonly IRepository<LOGCALLAPI, long> _repository;
		private readonly IAbpSession _abpSession;
        public LOGCALLAPIAppService(IRepository<LOGCALLAPI, long> initRepository, IAbpSession abpSession)
        {
            _repository = initRepository;
			 _abpSession = abpSession;
        }      
        public async Task<PagedResultDto<LOGCALLAPIDto>> Getall(GetLOGCALLAPIs input)
        {
            //Total Record
            var countQuery = _repository.GetAll()
                            .WhereIf(!string.IsNullOrEmpty(input.Filter), 
                                p => p.URL.Contains(input.Filter));
            var totalRecord = countQuery.Count();
            //Record with filter & pager
            var result = _repository
                            .GetAll()
                            .WhereIf(!string.IsNullOrEmpty(input.Filter), p => p.URL.Contains(input.Filter))
                            .OrderBy(p => p.URL)                            
                            .PageBy(input).ToList();
            return new PagedResultDto<LOGCALLAPIDto>(
                totalRecord, 
                result.MapTo<List<LOGCALLAPIDto>>()
                );
        }
        public async Task<LOGCALLAPIDto> Get(GetLOGCALLAPI input)
        {
            LOGCALLAPI nhomVT =  await _repository.GetAsync(input.Id);
            return nhomVT.MapTo<LOGCALLAPIDto>();
        }
        public void Create(CreateOrEditLOGCALLAPI input)
        {
            input.TenantId = AbpSession.TenantId;           
            var item = ObjectMapper.Map<LOGCALLAPI>(input);
            _repository.Insert(item);
        }
        public void Update(CreateOrEditLOGCALLAPI input)
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
