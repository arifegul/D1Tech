using AutoMapper;
using D1Tech.Travel.Application.Responses;
using D1Tech.Travel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D1Tech.Travel.Application.Mapping
{
	public class D1TechTravelAutoMapperProfile : Profile
	{
		public D1TechTravelAutoMapperProfile() 
		{
            CreateMap<Travels, TravelResponse>().ReverseMap();
            CreateMap<TravelDetails, TravelDetailResponse>().ReverseMap();
		}
	}
}
