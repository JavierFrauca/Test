using FluentValidation;
using TEST.Dtos;

namespace TEST.Validations
{
    public class Tabla3Validation : AbstractValidator<Tabla3Dto>
    {
        public Tabla3Validation()
        {
            RuleFor(X => X.Campo1).NotEmpty().WithMessage("El campo1 es obligatorio");
            RuleFor(X => X.Campo2).NotEmpty().EmailAddress().WithMessage("El campo2 tiene que ser un email");
            RuleFor(X => X.Campo3).NotEmpty().WithMessage("El campo1 es obligatorio");
        }
    }
}
