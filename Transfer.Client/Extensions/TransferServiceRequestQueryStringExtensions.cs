using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Client.Request;
using Transfer.Client.Response;

namespace Transfer.Client.Extensions
{
    public static class TransferServiceRequestQueryStringExtensions
    {
        public static string TransferServiceOneWayRequesttQueryString(TransferServiceSearchOneWayRequest transferServiceSearchOneWayRequest)
        {
            return
                     $"transfer/search?adults={transferServiceSearchOneWayRequest.Adults}" +
                     $"&children={transferServiceSearchOneWayRequest.Children}&" +
                     $"pickUpPointLatitude={transferServiceSearchOneWayRequest.PickUpPointLatitude}" +
                     $"&pickUpPointLongitude={transferServiceSearchOneWayRequest.PickUpPointLongitude}&" +
                     $"dropOffPointLatitude={transferServiceSearchOneWayRequest.DropOffPointLatitude}" +
                     $"&dropOffPointLongitude={transferServiceSearchOneWayRequest.DropOffPointLongitude}" +
                     $"&date={transferServiceSearchOneWayRequest.Date}";
        }
        public static string TransferServiceRoundWayRequestQueryString(TransferServiceSerachRoundWayRequest transferServiceSearchRoundWayRequest)
        {
            return
                   $"transfer/search?adults={transferServiceSearchRoundWayRequest.Adults}" +
                   $"&children={transferServiceSearchRoundWayRequest.Children}&" +
                   $"pickUpPointLatitude={transferServiceSearchRoundWayRequest.PickUpPointLatitude}" +
                   $"&pickUpPointLongitude={transferServiceSearchRoundWayRequest.PickUpPointLongitude}&" +
                   $"dropOffPointLatitude={transferServiceSearchRoundWayRequest.DropOffPointLatitude}" +
                   $"&dropOffPointLongitude={transferServiceSearchRoundWayRequest.DropOffPointLongitude}" +
                   $"&date={transferServiceSearchRoundWayRequest.Date}" +
                   $"&returnDate={transferServiceSearchRoundWayRequest.ReturnDate}";
        }

        public static string TransferServiceGetBookRequestQueryString(TransferSerivceGetBookRequest transferServiceGetBookRequest)
        {
            return
                    $"transfers/reservations/{transferServiceGetBookRequest.Pnr}?LastName={transferServiceGetBookRequest.LastName}";
        }

    }
}
