using Transfer.Client.ResponseAlt;


namespace Transfer.Server.CQRS.Commands.Response
{
    public class CreateBookResponse
    {
        public string Pnr { get; set; }
        public Contact Contact { get; set; }
        public string BookingStatusType { get; set; }
        public Transfers Transfers { get; set; }
    }
}
