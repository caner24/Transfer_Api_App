using System;
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
        public string Desciption { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public PickUpPoint PickUpPoint { get; set; }
        public DropOffPoint DropOffPoint { get; set; }
        public GenericData GenericData { get; set; }
        public ExtraServices ExtraServices { get; set; }

    }
}
