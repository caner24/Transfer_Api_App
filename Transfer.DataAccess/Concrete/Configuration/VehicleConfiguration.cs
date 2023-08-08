using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Transfer.DataAccess.Concrete.Configuration;
using Transfer.Entity;

namespace Transfer.DataAccess.Concrete.Configuration
{
    internal class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            //builder.HasOne(x => x.DropOffPoint).WithOne(x => x.Vehicle).HasForeignKey<DropOffPoint>(x => x.VehicleId);
            //builder.HasOne(x => x.PickUpPoint).WithOne(x => x.Vehicle).HasForeignKey<PickUpPoint>(x => x.VehicleId);
            builder.Property(x => x.ProviderId).HasValueGenerator<GuidGenerator>();
            builder.Property(x => x.Date).HasDefaultValueSql("GETDATE()");
            builder.OwnsOne(x => x.GenericData);
            builder.OwnsOne(x => x.ExtraServices);

            //var guid= Guid.NewGuid();
            //builder.HasData(new Vehicle()
            //{
            //    Id = guid,
            //    ProviderId = Guid.NewGuid(),
            //    Description = "Mercedes Vito R",
            //    ImageUrl = @"http:/panel.cars2world.com/AlbumMedia/RentACar/Logo/0c4f6727-ca25-49de-9946-4976fa7d6089.jpg",
            //    MaxBaggage = 6,
            //    MaxPassenger = 6,
            //    TotalPrice = 647.96,
            //    TransferType = "Private",
            //    PickUpPoint = new PickUpPoint()
            //    {
            //        Id = guid,
            //        CountryCode = "TR",
            //        CountryName = "Türkiye",
            //        Latitude = 16,
            //        LongiTude = 8,
            //        Name = "Test DropOffPoint Adress",
            //    },
            //    DropOffPoint = new DropOffPoint()
            //    {
            //        Id = guid,
            //        CountryCode = "TR",
            //        CountryName = "Türkiye",
            //        Latitude = 16,
            //        LongiTude = 8,
            //        Name = "Test DropOffPoint Adress"
            //    },
            //    GenericData = new GenericData()
            //    {
            //        SearchCode = "{{$body 'adults' '0'}}|{{$body 'children' '0'}}|{{$body 'pickUpPointLatitude'}}|{{$body 'PickUpPointLongitude'}}|{{$body 'DropOffPointLatitude'}}|{{$body 'DropOffPointLongitude'}}|{{$body 'date'}}|{{$body 'returnDate'}}",
            //        ResultKey = "2|202111260200_ChIJQ5 xVme3yhQRTCDmLnk4mgg*Kalyoncu Kulluğu, Akkiraz Sk. No 12, 34435 Beyoğlu/İstanbul, Turkey*TR*Turkey*41.0370014*28.9763369_GhIJ9J5vsNygREARX7LxYIu9PEA*7P4R+M5 Arnavutköy/İstanbul, Turkey*TR*Turkey*41.2567349*28.740408:202111300200_GhIJ9J5vsNygREARX7LxYIu9PEA*7P4R+M5 Arnavutköy/İstanbul, Turkey*TR*Turkey*41.2567349*28.740408_ChIJQ5 xVme3yhQRTCDmLnk4mgg*Kalyoncu Kulluğu, Akkiraz Sk. No 12, 34435 Beyoğlu/İstanbul, Turkey*TR*Turkey*41.0370014*28.9763369|1ADT_0CHD_|99|0|0|0||||7311ed86-e930-4194-ba07-d6432b9de423||@bb648843-ea0d-4043-b4a2-07ab76ad47ee"
            //    },
            //    ExtraServices = new ExtraServices()
            //    {
            //        ExtraServiceType = "Greeting",
            //        TotalPrice = 0
            //    }


            //});
        }
    }
}
