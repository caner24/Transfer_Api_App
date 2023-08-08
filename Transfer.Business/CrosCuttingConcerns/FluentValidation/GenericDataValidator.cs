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
    public class GenericDataValidator : AbstractValidator<GenericData>
    {
        public GenericDataValidator()
        {
            RuleFor(x => x.SearchCode).NotNull();
            RuleFor(x => x.ResultKey).NotNull();
           
        }
    }
}
