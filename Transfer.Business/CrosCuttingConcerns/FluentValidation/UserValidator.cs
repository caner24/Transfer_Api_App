using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Entity;

namespace Transfer.Business.CrosCuttingConcerns.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id boş olamaz");
            RuleFor(x => x.PhoneNumber).NotNull().WithMessage("Phone number  boş olamaz");


        }
    }
    
}
