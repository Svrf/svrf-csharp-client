using System;

namespace Svrf.Services
{
    internal class DateTimeProvider
    {
        public virtual DateTime Now => DateTime.Now;

        public static int Compare(DateTime t1, DateTime t2) => DateTime.Compare(t1, t2);
    }
}
