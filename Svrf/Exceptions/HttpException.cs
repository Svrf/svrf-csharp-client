using System;
using System.Net;

namespace Svrf.Exceptions
{
    internal class HttpException : Exception
    {
        internal HttpStatusCode Code { get; }

        internal HttpException(string message, HttpStatusCode code) : base(message)
        {
            Code = code;
        }
    }
}
