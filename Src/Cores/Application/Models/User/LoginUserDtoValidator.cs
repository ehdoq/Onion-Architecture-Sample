using FluentValidation;

namespace Application.Models.User
{
    public class LoginUserDtoValidator : AbstractValidator<LoginUserDto>
    {
        public LoginUserDtoValidator()
        {
            RuleFor(c => c.Mobile).NotEmpty().WithMessage("{PropertyName} boş olamaz!")
                                  .Length(11).WithMessage("{PropertyName} 11 karakterden fazla olamaz!");

            RuleFor(c => c.Password).NotEmpty().WithMessage("{PropertyName} boş olamaz!");
        }
    }
}