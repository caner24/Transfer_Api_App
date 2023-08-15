using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Transfer.Client
{
    public class ResponseExtensions
    {
        public static async Task<string> ProcessResponse(HttpResponseMessage responseMessage)
        {
            var byteArray = await responseMessage.Content.ReadAsByteArrayAsync();
            var result = Encoding.UTF8.GetString(byteArray, 0, byteArray.Length);
            if (responseMessage.IsSuccessStatusCode)
                return result;

            if (!string.IsNullOrWhiteSpace(result))
            {
                //if (result.Contains("validation"))
                    //throw result.GetBusinessValidationException();

                    //var exception = result.GetBusinessException();
                    //var isNoAccessibleError = exception.ProblemDetails.Type.Equals("search106");
                    //if (!isNoAccessibleError)
                    //    throw exception;

                    //throw NotImplementedException();
            }
            return result;
        }

        public static async Task<string> ProcessResponse(HttpResponseMessage responseMessage, Action<HttpResponseHeaders> headerFunc = null)
        {
            var byteArray = await responseMessage.Content.ReadAsByteArrayAsync();
            var result = Encoding.UTF8.GetString(byteArray, 0, byteArray.Length);
            if (responseMessage.IsSuccessStatusCode)
            {
                headerFunc?.Invoke(responseMessage.Headers);
                return result;
            }

            if (!string.IsNullOrWhiteSpace(result))
            {
                //if (result.Contains("validation"))
                    //throw result.GetBusinessValidationException();

                //throw result.GetBusinessException();
            }

            if (responseMessage.StatusCode <= 0) return result;
            var statusCode = (int)responseMessage.StatusCode;
            return "";
            //throw new BusinessException(responseMessage.ReasonPhrase, statusCode.ToString(), responseMessage.ReasonPhrase, $"{statusCode} {responseMessage.ReasonPhrase}");
        }
    }
}
