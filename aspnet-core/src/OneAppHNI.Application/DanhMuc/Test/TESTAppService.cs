using System.Linq;
using Abp.Domain.Repositories;
using Abp.Application.Services;
using OneAppHNI.DanhMuc;
using DigitalMap.DanhMuc.Dtos;
using System.Collections.Generic;
using AutoMapper;
using Abp.Linq.Extensions;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.Threading.Tasks;
using Abp.Runtime.Session;
using Abp.UI;
using Abp.Authorization;
using OneAppHNI.Authorization;

namespace DigitalMap.DanhMuc
{
    [AbpAuthorize()]
    public class TESTAppService : ApplicationService, ITESTAppService
    {
        private readonly IRepository<TEST, long> _repository;
        private readonly IAbpSession _abpSession;
        public TESTAppService(IRepository<TEST, long> initRepository, IAbpSession abpSession)
        {
            _repository = initRepository;
            _abpSession = abpSession;
        }
        public async Task<PagedResultDto<TESTDto>> Getall(GetTESTs input)
        {
            //Total Record
            var countQuery = _repository.GetAll()
                            .WhereIf(!string.IsNullOrEmpty(input.Filter),
                                p => p.CODE.Contains(input.Filter));
            var totalRecord = countQuery.Count();
            //Record with filter & pager
            var result = _repository
                            .GetAll()
                            .WhereIf(!string.IsNullOrEmpty(input.Filter), p => p.CODE.Contains(input.Filter))
                            .OrderBy(p => p.CODE)
                            .PageBy(input).ToList();
            return new PagedResultDto<TESTDto>(
                totalRecord,
                result.MapTo<List<TESTDto>>()
                );
        }
        public async Task<TESTDto> Get(long id)
        {
            TEST nhomVT = await _repository.GetAsync(id);
            return nhomVT.MapTo<TESTDto>();
        }
        public void Create(CreateOrEditTEST input)
        {
            input.TenantId = AbpSession.TenantId;
            var item = ObjectMapper.Map<TEST>(input);
            _repository.Insert(item);
        }
        public void Update(CreateOrEditTEST input)
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
