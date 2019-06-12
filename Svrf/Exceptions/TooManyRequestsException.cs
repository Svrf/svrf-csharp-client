using System;

namespace Svrf.Exceptions
{
    public class TooManyRequestsException : Exception
    {
        internal TooManyRequestsException(string message) : base(message) { }
    }
}
