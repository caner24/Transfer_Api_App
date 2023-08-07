﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Core.Entity;

namespace Transfer.Entity
{
    public class Vehicle : IEntity
    {

        public Guid  Id { get; set; }
        public Guid ProviderId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public DateTime ReturnDate { get; set; }
        public string ImageUrl { get; set; }
        public int MaxBaggage { get; set; }
        public int MaxPassenger { get; set; }
        public double TotalPrice { get; set; }
        public string TransferType { get; set; }
        public PickUpPoint PickUpPoint { get; set; }
        public DropOffPoint DropOffPoint { get; set; }
        public GenericData GenericData { get; set; }
        public ExtraServices ExtraServices { get; set; }

    }
}