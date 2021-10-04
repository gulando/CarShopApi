using System;
using System.Net;

namespace CarShopApi.Application.Core.Common.Exceptions
{
    public class CarShopException : Exception
    {
        public HttpStatusCode StatusCode { get; }

        public override string Message { get; }

        public CarShopException(HttpStatusCode status, string message = default)
        {
            StatusCode = status;
            Message = message;
        }
    }
}