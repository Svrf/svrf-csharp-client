using System;
using System.Net;

namespace Svrf.Exceptions
{
    internal class HttpException : Exception
    {
        internal HttpStatusCode Code { get; }

        internal HttpException(HttpStatusCode code)
        {
            Code = code;
        }
    }
}
