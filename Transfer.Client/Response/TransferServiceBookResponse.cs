using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Client.Response;

namespace Transfer.Client.ResponseAlt
{
    public class Contact
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string GenderType { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
    }

    public  class Point
    {
        public string CountryCode { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Name { get; set; }
        public string PlaceId { get; set; }
        public MeetingDetailPoint MeetingDetailPoint { get; set; }
    }

    public class MeetingDetailPoint
    {
        public string MeetingPointType { get; set; }
        public string Description { get; set; }
        public string HotpointName { get; set; }
        public string HotpointCode { get; set; }
        public string ArrivalTime { get; set; }
        public string DepartureTime { get; set; }
        public string FlightNumber { get; set; }
    }
    public class TransferServiceBookResponse
    {
        public string Pnr { get; set; }
        public Contact Contact { get; set; }
        public string BookingStatusType { get; set; }
        public Transfers Transfers { get; set; }
    }

    public class Transfers
    {
        public double TotalAmount { get; set; }
        public string BookingStatusType { get; set; }
        public Vehicle Vehicle { get; set; }
    }

    public class Vehicle
    {
        public string Id { get; set; }
        public string ProviderId { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string MaxBaggage { get; set; }
        public string MaxPassenger { get; set; }
        public double TotalAmount { get; set; }
        public string TransferType { get; set; }
        public Point PickUpPoint { get; set; }
        public Point DropOffPoint { get; set; }
        public DateTime Date { get; set; }
        public DateTime RetunrDate { get; set; }
        public List<ExtraService> ExtraServices { get; set; }
    }
}
