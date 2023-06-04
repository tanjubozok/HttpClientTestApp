namespace HttpClientTest.Service.ValidationRules.CategoryValidators;

public class CategoryAddDtoValidator : AbstractValidator<CategoryAddDto>
{
    public CategoryAddDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Kategori adı boş olamaz")
            .MinimumLength(3).WithMessage("Kategori adı en az 3 karakter olmalıdır")
            .MaximumLength(64).WithMessage("Kategori adı en fazla 64 karakter olmalıdır");
    }
}
