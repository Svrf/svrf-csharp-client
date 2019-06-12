using System;

namespace Svrf.Exceptions
{
    public class ServerErrorException : Exception
    {
        internal ServerErrorException(string message) : base(message) { }
    }
}
