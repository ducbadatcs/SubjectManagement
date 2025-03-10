using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace SubjectManagement
{
    public static class ObjectFunctions
    {
        /// <summary>
        /// why
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dict"></param>
        /// <returns></returns>
        public static T DictToObject<T>(Dictionary<string, object> dict)
            where T : class, new()
        {

            // get the type
            var resultObject = new T();
            var type = resultObject.GetType();


            foreach (var item in dict)
            {
                foreach (var propertyName in 
                    ObjectFunctions.ObjectToDict<T>(new T()).Keys)
                {
                    if (UtilityFunctions.IR(propertyName) 
                        == UtilityFunctions.IR(item.Key))
                    {
                        type
                            .GetProperty(propertyName)
                            .SetValue(resultObject, item.Value, null);
                    }
                }
            }
            return resultObject;
        }

        public static Dictionary<string, object> ObjectToDict<T>(
            T t, 
            BindingFlags bindingAttributes = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
            where T : class, new()
        {
            return t.GetType().GetProperties(bindingAttributes).ToDictionary
            (
                propInfo => propInfo.Name,
                propInfo => propInfo.GetValue(t, null)
            );
        }

        public static List<string> ObjectPropertyNames<T>(T t) 
            where T : class, new()
        {
            return ObjectFunctions.ObjectToDict(t).Keys.ToList();
        }

        public static List<object> ObjectPropertyValues<T>(T t) 
            where T : class, new()
        {
            return ObjectFunctions.ObjectToDict(t).Values.ToList();
        }

        public static List<List<object>> ObjectPropertyValuesList<T>(List<T> values) 
            where T : class, new()
        {
            var result = new List<List<object>>();
            foreach (T value in values)
            {
                result.Add(
                    ObjectFunctions.ObjectPropertyValues<T>(value)
                    );
            }
            return result;
        }

        public static Dictionary<string, object> AutoConvert(
            Dictionary<string, string> source,
            List<Type> typeList = null)
        {
            // elementary types
            typeList = typeList ?? new List<Type>() { typeof(bool), typeof(int), typeof(double), typeof(string) };
            Dictionary<string, object> result = new Dictionary<string, object>();
            foreach (KeyValuePair<string, string> pair in source)
            {
                object convertedObject = null;
                foreach (var type in typeList)
                {
                    try
                    {
                        convertedObject = Convert.ChangeType(pair.Value, type);
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
                // it can be null, who tf cares
                result[pair.Key] = convertedObject;
            }
            return result;
        }
    }
}