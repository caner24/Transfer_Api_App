using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Validators;
using Transfer.Entity;

namespace Transfer.Business.CrosCuttingConcerns.FluentValidation
{
    public class VehicleValidator : AbstractValidator<Vehicle>
    {
        public VehicleValidator() 
        {
            RuleFor(x => x.Id).NotNull().WithMessage("ID boş olamaz");
            RuleFor(x => x.ProviderId).NotNull().WithMessage("Provider ID boş olamaz");
            RuleFor(x => x.Description).MaximumLength(300).WithMessage("Description boş olamaz");
            RuleFor(x => x.Date).NotNull().WithMessage("Date boş olamaz");
            RuleFor(x => x.ReturnDate).NotNull().WithMessage("Return Date boş olamaz");
            RuleFor(x => x.ImageUrl).NotNull().WithMessage("ImageUrl boş olamaz");
            RuleFor(x => x.MaxBaggage).NotNull().WithMessage("MaxBagage boş olamaz");
            RuleFor(x => x.MaxPassenger).NotNull().WithMessage("MaxPassenger boş olamaz");
            RuleFor(x => x.TotalPrice).NotNull().WithMessage("TotalPrice boş olamaz");
            RuleFor(x => x.TransferType).NotNull().WithMessage("TransferType boş olamaz");
            RuleFor(x => x.PickUpPoint).NotNull().WithMessage("PickUpPoint boş olamaz");
            RuleFor(x => x.DropOffPoint).NotNull().WithMessage("DropOffPoint boş olamaz");
            RuleFor(x => x.GenericData).NotNull().WithMessage("GenericData boş olamaz");
            RuleFor(x => x.ExtraServices).NotNull().WithMessage("ExtraService boş olamaz");


        }
    }
}
