﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Entity;

namespace Transfer.Business.CrosCuttingConcerns.FluentValidation
{
    public class BooksValidator : AbstractValidator<Books>
    {
        public BooksValidator()
        {
            RuleFor(x => x.Pnr).NotNull().WithMessage("pnr boş olamaz");
            RuleFor(x => x.VehicleId).NotNull().WithMessage("VehicleId boş olamaz");
            RuleFor(x => x.TotalAmount).NotNull().WithMessage("TotalAmount boş olamaz");
            RuleFor(x => x.BookingStatusTytpe).NotNull().WithMessage("BookingStatusType boş olamaz");
            RuleFor(x => x.User).NotNull().WithMessage("User boş olamaz");
            RuleFor(x => x.Transfers).NotNull().WithMessage("Transfer boş olamaz");

        }
    }
}