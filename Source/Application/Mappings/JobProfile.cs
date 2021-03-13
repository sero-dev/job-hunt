using System;
using System.Collections.Generic;
using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class JobProfile : Profile
    {
        public JobProfile()
        {
            CreateMap<CreateJobRequest, Job>()
                .ForMember(dest => dest.Id, src => src.MapFrom(job => Guid.Empty))
                .ForMember(dest => dest.DateSubmitted, src => src.MapFrom(job => job.DateSubmitted ?? DateTime.Now))
                .AfterMap((src, dest) =>
                {
                    if(src.DateLastUpdated == null)
                        dest.DateLastUpdated = dest.DateSubmitted;
                });

            CreateMap<List<Job>, ListResponse<Job>>()
                .ForMember(dest => dest.Count, src => src.MapFrom(list => list.Count))
                .ForMember(dest => dest.Data, src => src.MapFrom(list => list));
        }
    }
}