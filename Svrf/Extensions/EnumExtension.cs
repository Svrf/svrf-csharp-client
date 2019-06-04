using System;
using System.ComponentModel;
using System.Linq;

namespace Svrf.Extensions
{
    internal static class EnumExtension
    {
        internal static string GetDescription(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = field.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault();
            var descriptionAttribute = attribute as DescriptionAttribute;
            return descriptionAttribute == null ? value.ToString() : descriptionAttribute.Description;
        }
    }
}
