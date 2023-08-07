using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Core.Entity;

namespace Transfer.Entity
{
    public class GenericData : IEntity
    {
        public string SearchCode { get; set; }
        public string ResultKey { get; set; }
    }
}
