namespace HttpClientTest.Service.ValidationRules.CategoryValidators;

public class CategoryUpdateDtoValidator : AbstractValidator<CategoryUpdateDto>
{
    public CategoryUpdateDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id boş olamaz");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Kategori adı boş olamaz")
            .MinimumLength(3).WithMessage("Kategori adı en az 3 karakter olmalıdır")
            .MaximumLength(64).WithMessage("Kategori adı en fazla 64 karakter olmalıdır");
    }
}
