﻿
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;


using LumenWorks.Framework.IO.Csv;


namespace HaProxyApi.Services
{
    internal static class HaProxyServiceExtensions
    {

        /// <summary>
        /// Parses the response.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="raw">The raw.</param>
        /// <param name="delimeter">The delimeter.</param>
        /// <returns></returns>
        /// <autogeneratedoc />
        public static IEnumerable<T> ParseResponse<T>(this string raw, char delimeter = ' ')
        {
            if (string.IsNullOrWhiteSpace(raw))
            {
                return Enumerable.Empty<T>();
            }
            var indexOfSharp = raw.IndexOf("#", StringComparison.Ordinal);

            if (indexOfSharp == 0 && raw.Length == 1)
            {
                return Enumerable.Empty<T>();
            }

            if (indexOfSharp >= 0)
            {
                raw = raw.Substring(indexOfSharp + 1);
            }

            raw = raw.Trim();
            // https://www.joelverhagen.com/blog/2020/12/fastest-net-csv-parsers

            var dr = new CsvReader(new StringReader(raw), true, delimeter);

            var list = new List<T>();
            T obj;
            while (dr.ReadNextRecord())
            {
                obj = Activator.CreateInstance<T>();
                foreach (var prop in obj.GetType().GetProperties())
                {
                    var attr = prop.GetCustomAttribute<ColumnAttribute>();
                    if (attr != null)
                    {
                        if (!object.Equals(dr[attr.Name], null))
                        {
                            SetValue(prop, obj, dr[attr.Name]);
                        }
                    }
                    else
                    if (!object.Equals(dr[prop.Name], null))
                    {
                        SetValue(prop, obj, dr[prop.Name]);
                    }
                }
                list.Add(obj);
            }
            return list;

        }




        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="property">The property.</param>
        /// <param name="target">The target.</param>
        /// <param name="val">The value.</param>
        public static void SetValue(this PropertyInfo property, object target, string val)
        {
            if (property.PropertyType.IsEnum)
            {
                property.SetValue(target, Int32.Parse(val));
                return;
            }
            property.SetValue(target, System.Convert.ChangeType(val, property.PropertyType));
            return;
        }


    }
}
