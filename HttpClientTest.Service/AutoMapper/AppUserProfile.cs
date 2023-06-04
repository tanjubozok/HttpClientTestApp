namespace HttpClientTest.Service.AutoMapper;

public class AppUserProfile : Profile
{
    public AppUserProfile()
    {
        CreateMap<AppUser, AppUserLoginDto>().ReverseMap();
        CreateMap<AppUser, AppUserRegisterDto>().ReverseMap();
    }
}
