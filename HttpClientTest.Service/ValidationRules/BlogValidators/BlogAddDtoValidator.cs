namespace HttpClientTest.Service.ValidationRules.BlogValidators;

public class BlogAddDtoValidator : AbstractValidator<BlogAddDto>
{
    public BlogAddDtoValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Blog başlığı boş olamaz")
            .MinimumLength(3).WithMessage("Blog başlığı en az 3 karakter olmalıdır")
            .MaximumLength(128).WithMessage("Blog başlığı en fazla 128 karakter olmalıdır");

        RuleFor(x => x.ShortDescription)
            .NotEmpty().WithMessage("Blog kısa açıklama boş olamaz")
            .MinimumLength(3).WithMessage("Blog kısa açıklama en az 3 karakter olmalıdır")
            .MaximumLength(1024).WithMessage("Blog kısa açıklama en fazla 1024 karakter olmalıdır");

        RuleFor(x => x.Description)
            .MinimumLength(3).WithMessage("Blog açıklama en az 3 karakter olmalıdır");
    }
}
