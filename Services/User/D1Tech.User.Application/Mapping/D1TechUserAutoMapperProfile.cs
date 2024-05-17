using AutoMapper;
using D1Tech.User.Application.Responses;
using D1Tech.User.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D1Tech.User.Application.Mapping
{
	public class D1TechUserAutoMapperProfile : Profile
	{
		public D1TechUserAutoMapperProfile() 
		{
            CreateMap<Users, UserResponse>().ReverseMap();
		}
	}
}
