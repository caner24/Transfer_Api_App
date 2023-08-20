using FluentValidation;
using Transfer.Entity.DataTransferObjects.Book;

namespace Transfer.Application.Campaign.Validator.FluentValidation.EntityValidator
{
    public class BooksValidator : AbstractValidator<BookDtoValidation>
    {
        public BooksValidator()
        {
            RuleFor(x => x.Pnr).NotNull().WithMessage("pnr boş olamaz");
            RuleFor(x => x.TotalAmount).NotNull().WithMessage("TotalAmount boş olamaz");
            RuleFor(x => x.UserId).NotNull().WithMessage("UserId boş olamaz");
            RuleFor(x => x.User).NotNull().WithMessage("User boş olamaz");

        }
    }
}
