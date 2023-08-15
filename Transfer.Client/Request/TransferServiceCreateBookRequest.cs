using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transfer.Client.Request
{
   
    public class Root
    {
        public List<string> VehicleIds { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public List<Tag> Tags { get; set; }
    }

    public class Tag
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }



}
