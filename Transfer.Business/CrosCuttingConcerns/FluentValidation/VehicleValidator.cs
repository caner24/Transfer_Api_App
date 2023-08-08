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
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.ProviderId).NotNull();
            RuleFor(x => x.Description).NotNull();
            RuleFor(x => x.Date).NotNull();
            RuleFor(x => x.ReturnDate).NotNull();
            RuleFor(x => x.ImageUrl).NotNull();
            RuleFor(x => x.MaxBaggage).NotNull();
            RuleFor(x => x.MaxPassenger).NotNull();
            RuleFor(x => x.TotalPrice).NotNull();
            RuleFor(x => x.TransferType).NotNull();
            RuleFor(x => x.PickUpPoint).NotNull();
            RuleFor(x => x.DropOffPoint).NotNull();
            RuleFor(x => x.GenericData).NotNull();
            RuleFor(x => x.ExtraServices).NotNull();


        }
    }
}
