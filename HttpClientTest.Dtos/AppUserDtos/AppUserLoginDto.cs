namespace HttpClientTest.Dtos.AppUserDtos;

public class AppUserLoginDto : IBaseDto
{
    public string Email { get; set; }
    public string Password { get; set; }
}
