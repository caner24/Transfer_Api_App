using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Application.Transfer.Commands.Request.DataTransferObjects;

namespace Transfer.Application.Transfer.Validator.FluentValidation.RequestValidator
{
    public class CreateUserRequestDtoValidator : AbstractValidator<CreateUserRequestDto>
    {
        public CreateUserRequestDtoValidator()
        {
            RuleFor(x => x.Email).NotNull().WithMessage($"{nameof(CreateUserRequestDto.Email)} alani boş geçilemez.");
            RuleFor(x => x.Phone).NotNull().WithMessage($"{nameof(CreateUserRequestDto.Phone)} alani boş geçilemez.");
            RuleFor(x => x.FirstName).NotNull().WithMessage($"{nameof(CreateUserRequestDto.FirstName)} alani boş geçilemez.");
            RuleFor(x => x.GenderType).NotNull().WithMessage($"{nameof(CreateUserRequestDto.GenderType)} alani boş geçilemez.");
            RuleFor(x => x.LastName).NotNull().WithMessage($"{nameof(CreateUserRequestDto.LastName)} alani boş geçilemez.");
        }

    }
}
