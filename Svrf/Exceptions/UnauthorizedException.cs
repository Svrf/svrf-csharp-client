using System;

namespace Svrf.Exceptions
{
    public class UnauthorizedException : Exception
    {
        internal UnauthorizedException(string message) : base(message) { }
    }
}
