using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Application.Transfer.Commands.Request.DataTransferObjects;

namespace Transfer.Application.Transfer.Validator.FluentValidation.RequestValidator
{
    public class CreateBookRequestDtoValidator : AbstractValidator<CreateBookRequestDto>
    {
        public CreateBookRequestDtoValidator()
        {
            RuleFor(x => x.Adults).NotNull().WithMessage($"{nameof(CreateBookRequestDto.Adults)} alani boş geçilemez.");
            RuleFor(x => x.Children).NotNull().WithMessage($"{nameof(CreateBookRequestDto.Children)} alani boş geçilemez.");
            RuleFor(x => x.Tags).NotNull().WithMessage($"{nameof(CreateBookRequestDto.Tags)} alani boş geçilemez.");
            RuleFor(x => x.UserId).NotNull().WithMessage($"{nameof(CreateBookRequestDto.UserId)} alani boş geçilemez.");
        }
    }
}
