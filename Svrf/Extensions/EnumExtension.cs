using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Svrf.Extensions
{
    internal static class EnumExtension
    {
        internal static string GetDescription(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = field.GetCustomAttributes(typeof(EnumMemberAttribute), false).FirstOrDefault();
            var descriptionAttribute = attribute as EnumMemberAttribute;
            return descriptionAttribute == null ? value.ToString() : descriptionAttribute.Value;
        }
    }
}
