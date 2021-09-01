using AutoMapper;
using DevCa.Api.ViewModels;
using DevCA.Business.Model;

namespace DevCa.Api.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Book, BookViewModel>().ReverseMap();
            CreateMap<BookGender, BookGenderViewModel>().ReverseMap();
            CreateMap<Reserve, ReserveViewModel>().ReverseMap();
            CreateMap<User, UserViewModel>().ReverseMap();
        }
    }
}