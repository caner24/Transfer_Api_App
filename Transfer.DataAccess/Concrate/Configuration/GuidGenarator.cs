using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transfer.DataAccess.Concrate.Configuration
{
    public class GuidGenarator : ValueGenerator<Guid>
    {
        public override bool GeneratesTemporaryValues => false;

        public override Guid Next(EntityEntry entry)
        {
            return Guid.NewGuid();
        }
    }
}
