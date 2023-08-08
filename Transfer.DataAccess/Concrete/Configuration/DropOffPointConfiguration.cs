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
    public class DropOffPointConfiguration : IEntityTypeConfiguration<DropOffPoint>
    {
        public void Configure(EntityTypeBuilder<DropOffPoint> builder)
        {
            builder.ToTable("DropOffPoint");
        }


    }
}
