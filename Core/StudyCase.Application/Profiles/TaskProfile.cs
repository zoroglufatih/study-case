using AutoMapper;
using StudyCase.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCase.Application.Profiles
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<Dto.Task, Domain.Entities.Task>()
                .ForMember(x=> x.Id, y=> y.Ignore())
                .ForMember(x=> x.ApiId, y=> y.Ignore())
                .ForMember(x=> x.CreatedDate, y=> y.Ignore())
                .ReverseMap();
        }
    }
}
