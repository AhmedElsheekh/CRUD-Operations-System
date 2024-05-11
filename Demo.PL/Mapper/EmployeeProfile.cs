using AutoMapper;
using Demo.DAL.Entities;
using Demo.PL.Models;
using Demo.PL.Models.Employee_DTO;

namespace Demo.PL.Mapper
{
	public class EmployeeProfile : Profile
	{
		public EmployeeProfile()
		{
			CreateMap<EmployeeViewModel, Employee>().ReverseMap();
		}
	}
}
