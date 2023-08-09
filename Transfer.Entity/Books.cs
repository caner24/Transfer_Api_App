﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Core.Entity;

namespace Transfer.Entity
{
    public class Books:IEntity
    {

        public Guid Pnr { get; set; }
        public string VehicleId { get; set; }
        public double TotalAmount { get; set; }
        public string BookingStatusType { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}