using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Transfer.Entity;

namespace Transfer.DataAccess.Concrate.Configuration
{
    internal class PickUpPointConfiguration : IEntityTypeConfiguration<PickUpPoint>
    {
        public void Configure(EntityTypeBuilder<PickUpPoint> builder)
        {
            builder.ToTable("PickUpPoint");
        }
    }
}
