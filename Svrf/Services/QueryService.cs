using System;
using System.Collections.Generic;
using System.Linq;
using Svrf.Extensions;
using Svrf.Models.Media;

namespace Svrf.Services
{
    internal class QueryService
    {
        public static string Build(IDictionary<string, object> requestParams)
        {
            var properties = requestParams.Select(keyValue =>
            {
                var name = FirstCharToLower(keyValue.Key);
                var value = keyValue.Value;

                var valueAsEnum = value as Enum;
                var isValueInstanceOfEnum = valueAsEnum != null;
                value = isValueInstanceOfEnum ? valueAsEnum.GetDescription() : value;

                var valueAsMediaTypeList = value as List<MediaType>;
                var isValueInstanceOfEnumList = valueAsMediaTypeList != null;

                value = isValueInstanceOfEnumList
                    ? string.Join(",", valueAsMediaTypeList.Select(v => v.GetDescription()))
                    : value;

                var isValueInstanceOfBool = (value is bool);
                value = isValueInstanceOfBool ? FirstCharToLower(value.ToString()) : value;

                return $"{name}={value}";
            });

            var queryString = string.Join("&", properties.ToArray());

            return Uri.EscapeUriString(queryString);
        }

        private static string FirstCharToLower(string input) => input.First().ToString().ToLower() + input.Substring(1);
    }
}
