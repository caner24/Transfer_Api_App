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
        public static string ToQueryStringLower(this object obj)
        {
            var list = new List<string>();

            var objType = obj.GetType();

            var props = objType.GetProperties().Where(p => p.GetValue(obj) != null).ToArray();

            foreach (var p in props)
            {
                var query = $"{p.Name.ToLower()}={Uri.EscapeDataString(p.GetValue(obj).ToString())}";
                list.Add(query);
            }
            return string.Join("&", list);
        }
        public static string TransferServiceGetBookRequestQueryString(TransferSerivceGetBookRequest transferServiceGetBookRequest)
        {
            return
                    $"transfers/reservations/{transferServiceGetBookRequest.Pnr}?LastName={transferServiceGetBookRequest.LastName}";
        }
    }
}
