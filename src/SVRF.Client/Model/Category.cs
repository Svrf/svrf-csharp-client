/*
 * SVRF API
 *
 * OpenAPI spec version: 1.0.0
 * Contact: api@svrf.com
 *
 * NOTE: This class is auto generated by the swagger code generator program.
 * https://github.com/swagger-api/swagger-codegen.git
 * Do not edit the class manually.
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using SwaggerDateConverter = SVRF.Client.Client.SwaggerDateConverter;

namespace SVRF.Client.Model
{
    /// <summary>
    /// Defines Category
    /// </summary>
    
    [JsonConverter(typeof(StringEnumConverter))]
    
    public enum Category
    {
        
        /// <summary>
        /// Enum Filters for value: Face Filters
        /// </summary>
        [EnumMember(Value = "Face Filters")]
        Filters = 1
    }

}