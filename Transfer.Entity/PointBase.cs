using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Core.Entity;

namespace Transfer.Entity
{
    public abstract  class PointBase:IEntity
    {
        public Guid Id { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public int Latitude { get; set; }
        public int LongiTude { get; set; }
        public string Name { get; set; }
    }
}
