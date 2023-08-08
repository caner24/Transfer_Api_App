using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Transfer.Entity;

namespace Transfer.DataAccess.Concrete.Configuration
{
    public class PointBaseConfiguration : IEntityTypeConfiguration<PointBase>
    {
        public void Configure(EntityTypeBuilder<PointBase> builder)
        {
            builder.UseTpcMappingStrategy();
        }
    }
}
