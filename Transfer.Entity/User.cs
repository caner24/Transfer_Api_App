using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Core.Entity;

namespace Transfer.Entity
{
    public class User:IEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string GenderType { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public List<Books> Books { get; set; }
    }
}
