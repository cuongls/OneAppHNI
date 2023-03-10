using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace OneAppHNI.VoTuyen.Dtos
{
    public class GetBADCELLs : IPagedResultRequest
    {      
        public  string Filter { get; set; }    
        public int TRANGTHAI { get; set; }
        public int TUAN { get; set; }
        public int NAM { get; set; }
        public string CELL { get; set; }

        public const int DefaultPageSize = 10;

        [Range(1, int.MaxValue)]
        public int MaxResultCount { get; set; }

        [Range(0, int.MaxValue)]
        public int SkipCount { get; set; }

        public GetBADCELLs()
        {
            MaxResultCount = DefaultPageSize;
        }

    }
}
