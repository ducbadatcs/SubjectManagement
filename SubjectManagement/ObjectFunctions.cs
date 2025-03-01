using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SubjectManagement
{
    public static class ObjectFunctions
    {
        public static T DictToObject<T>(Dictionary<string, object> dict)
            where T : class, new()
        {
            // get the type
            var resultObject = new T();
            var type = resultObject.GetType();
            foreach (var item in dict)
            {
                var property = type.GetProperty(item.Key);
                if (!(property is null) && property.CanWrite)
                {
                    var convertedValue = Convert.ChangeType(item.Value, property.PropertyType);
                    property.SetValue(resultObject, convertedValue, null);
                }
            }
            return resultObject;
        }

        public static Dictionary<string, object> ObjectToDict(object obj, BindingFlags bindingAttributes = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
        {
            return obj.GetType().GetProperties(bindingAttributes).ToDictionary
            (
                propInfo => propInfo.Name,
                propInfo => propInfo.GetValue(obj, null)
            );
        }

        public static List<string> ObjectPropertyNames(object obj)
        {
            return ObjectFunctions.ObjectToDict(obj).Keys.ToList();
        }

        public static List<object> ObjectPropertyValues(object obj)
        {
            return ObjectFunctions.ObjectToDict(obj).Values.ToList();
        }

        public static Dictionary<string, object> AutoConvert(
            Dictionary<string, string> source,
            List<Type> typeList = null)
        {
            // elementary types
            typeList = typeList ?? new List<Type>() { typeof(bool), typeof(int), typeof(double), typeof(DateTime), typeof(string) };
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