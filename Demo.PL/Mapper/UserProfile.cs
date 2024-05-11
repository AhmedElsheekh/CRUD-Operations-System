using AutoMapper;
using Demo.DAL.Entities;
using Demo.PL.Models.User_DTO;

namespace Demo.PL.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<ApplicationUser, UserViewModel>().ReverseMap();
        }
    }
}
