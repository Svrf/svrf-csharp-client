using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Svrf.Extensions;

namespace Svrf.Services
{
    internal class QueryService
    {
        internal static string Build(IDictionary<string, object> requestParams)
        {
            var properties = requestParams.Select(keyValue =>
            {
                var name = FirstCharToLower(keyValue.Key);
                var value = GetParamValue(keyValue.Value);
                return $"{name}={value}";
            });

            var queryString = string.Join("&", properties.ToArray());

            return Uri.EscapeUriString(queryString);
        }

        private static string FirstCharToLower(string input) => input.First().ToString().ToLower() + input.Substring(1);

        private static string GetParamValue(object param)
        {
            if (param == null)
            {
                return null;
            }

            var paramAsEnum = param as Enum;
            if (paramAsEnum != null)
            {
                return paramAsEnum.GetDescription();
            }

            if (param is bool)
            {
                return FirstCharToLower(param.ToString());
            }

            var paramAsEnumerable = param as IEnumerable;
            if (paramAsEnumerable != null && !(param is string))
            {
                var values = paramAsEnumerable.Cast<object>().Select(GetParamValue);
                return string.Join(",", values);
            }

            return param.ToString();
        }
    }
}
