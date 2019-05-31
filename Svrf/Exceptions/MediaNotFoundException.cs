using System;

namespace Svrf.Exceptions
{
    public class MediaNotFoundException : Exception
    {
        internal MediaNotFoundException(string message) : base(message) { }
    }
}
