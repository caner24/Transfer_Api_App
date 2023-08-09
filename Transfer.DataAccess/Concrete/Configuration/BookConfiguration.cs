using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Entity;

namespace Transfer.DataAccess.Concrete.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Books>
    {
        public void Configure(EntityTypeBuilder<Books> builder)
        {
            builder.HasKey(x => x.Pnr);
            builder.Property(x => x.Pnr).ValueGeneratedOnAdd().HasValueGenerator<GuidGenerator>();
            builder.OwnsOne(x => x.Transfers);
            builder.HasOne(x => x.User).WithMany(x => x.Books);
           
        }
    }
}
