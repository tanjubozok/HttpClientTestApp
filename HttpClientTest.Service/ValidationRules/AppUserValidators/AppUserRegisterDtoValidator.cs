namespace HttpClientTest.Service.ValidationRules.AppUserValidators;

public class AppUserRegisterDtoValidator : AbstractValidator<AppUserRegisterDto>
{
    public AppUserRegisterDtoValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Kullanıcı adı boş olamaz")
            .MinimumLength(3).WithMessage("Kullanıcı adı en az 3 karakter olmalıdır")
            .MaximumLength(64).WithMessage("Kullanıcı adı en fazla 64 karakter olmalıdır");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email adresi boş olamaz")
            .MaximumLength(128).WithMessage("Email en fazla 128 karakter olmalıdır")
            .EmailAddress().WithMessage("Email adresi doğru formatta değildir");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Şifre boş olamaz")
            .MinimumLength(6).WithMessage("Şifre en az 6 karakter olmalıdır")
            .MaximumLength(20).WithMessage("Şifre en fazla 20 karakter olmalıdır");
    }
}
