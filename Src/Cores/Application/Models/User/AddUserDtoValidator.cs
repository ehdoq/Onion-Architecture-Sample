using FluentValidation;

namespace Application.Models.User
{
    public class AddUserDtoValidator : AbstractValidator<AddUserDto>
    {
        public AddUserDtoValidator()
        {
            RuleFor(c => c.Mobile).NotEmpty().WithMessage("{PropertyName} boş olamaz!")
                                  .Length(11).WithMessage("{PropertyName} 11 karakterden fazla olamaz!");

            RuleFor(c => c.Name).NotEmpty().WithMessage("{PropertyName} boş olamaz!");

            RuleFor(c => c.Password).NotEmpty().WithMessage("{PropertyName} boş olamaz!");
        }
    }
}