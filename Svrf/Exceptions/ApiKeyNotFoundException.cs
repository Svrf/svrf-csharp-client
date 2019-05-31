using System;

namespace Svrf.Exceptions
{
    public class ApiKeyNotFoundException : Exception
    {
        internal ApiKeyNotFoundException(string message) : base(message) { }
    }
}
