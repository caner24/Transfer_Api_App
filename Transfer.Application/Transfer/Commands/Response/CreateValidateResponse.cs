using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transfer.Server.CQRS.Commands.Response
{
    public class DropOffPoint
    {
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Name { get; set; }
        public string PlaceId { get; set; }
    }

    public class ExtraService
    {
        public string ExtraServiceType { get; set; }
        public int TotalPrice { get; set; }
    }

    public class GenericData
    {
        public string SearchCode { get; set; }
        public string ResultKey { get; set; }
    }

    public class PickUpPoint
    {
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Name { get; set; }
        public string PlaceId { get; set; }
    }

    public class CreateValidateResponse
    {
        public string Id { get; set; }
        public string ProviderId { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string MaxBaggage { get; set; }
        public string MaxPassenger { get; set; }
        public double TotalPrice { get; set; }
        public string TransferType { get; set; }
        public PickUpPoint PickUpPoint { get; set; }
        public DropOffPoint DropOffPoint { get; set; }
        public string Date { get; set; }
        public GenericData GenericData { get; set; }
        public List<ExtraService> ExtraServices { get; set; }
    }

}
