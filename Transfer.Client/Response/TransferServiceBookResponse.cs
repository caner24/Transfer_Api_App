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
        public string email { get; set; }
        public string firstName { get; set; }
        public string genderType { get; set; }
        public string lastName { get; set; }
        public string phone { get; set; }
    }

    public  class Point
    {
        public string countryCode { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string name { get; set; }
        public string placeId { get; set; }
        public MeetingDetailPoint meetingDetailPoint { get; set; }
    }

    public class MeetingDetailPoint
    {
        public string meetingPointType { get; set; }
        public string description { get; set; }
        public string hotpointName { get; set; }
        public string hotpointCode { get; set; }
        public string arrivalTime { get; set; }
        public string departureTime { get; set; }
        public string flightNumber { get; set; }
    }
    public class Root
    {
        public string pnr { get; set; }
        public Contact contact { get; set; }
        public string bookingStatusType { get; set; }
        public Transfers transfers { get; set; }
    }

    public class Transfers
    {
        public int totalAmount { get; set; }
        public string bookingStatusType { get; set; }
        public Vehicle vehicle { get; set; }
    }

    public class Vehicle
    {
        public string id { get; set; }
        public string providerId { get; set; }
        public string description { get; set; }
        public string imageUrl { get; set; }
        public string maxBaggage { get; set; }
        public string maxPassenger { get; set; }
        public double totalAmount { get; set; }
        public string transferType { get; set; }
        public Point pickUpPoint { get; set; }
        public Point dropOffPoint { get; set; }
        public DateTime date { get; set; }
        public DateTime retunrDate { get; set; }
        public List<ExtraService> extraServices { get; set; }
    }
}
