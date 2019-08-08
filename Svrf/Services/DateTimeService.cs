using System;
using Svrf.Services.Interfaces;

namespace Svrf.Services
{
    internal class DateTimeService : IDateTimeService
    {
        public DateTime Now => DateTime.Now;

        public static int Compare(DateTime t1, DateTime t2) => DateTime.Compare(t1, t2);
    }
}
