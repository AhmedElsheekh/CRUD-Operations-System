using AutoMapper;
using Demo.DAL.Entities;
using Demo.PL.Models.Department_DTO;

namespace Demo.PL.Mapper
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<DepartmentViewModel, Department>().ReverseMap();
        }
    }
}
