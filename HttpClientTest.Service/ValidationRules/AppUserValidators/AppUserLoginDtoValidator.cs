namespace HttpClientTest.Service.ValidationRules.AppUserValidators;

public class AppUserLoginDtoValidator : AbstractValidator<AppUserLoginDto>
{
    public AppUserLoginDtoValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email adresi boş olamaz")
            .EmailAddress().WithMessage("Email adresi doğru formatta değildir");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Şifre boş olamaz")
            .MinimumLength(6).WithMessage("Şifre en az 6 karakter olmalıdır")
            .MaximumLength(20).WithMessage("Şifre en fazla 20 karakter olmalıdır");
    }
}
