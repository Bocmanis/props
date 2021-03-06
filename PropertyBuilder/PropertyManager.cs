﻿using StorageAccess;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PropertyBuilder
{
    public class PropertyManager
    {
        public void SaveProperties(object objectToSave, object identifier, string prefix = null)
        {
            if (objectToSave == null)
            {
                return;
            }
            var type = objectToSave.GetType();
            prefix = prefix ?? GetTypeName(type);
            var key = $"{identifier}{prefix}";

            if (type.IsPrimitive || type == typeof(string) || type == typeof(decimal) || objectToSave is IEnumerable)
            {
                var propertyTypeDictionary = PropertyPatternDictionary.Instance();
                if (!propertyTypeDictionary.ContainsKey(prefix))
                {
                    propertyTypeDictionary.Add(prefix, type.Name);
                }
                var propertyDictionary = PropertyDictionary.Instance();
                if (propertyDictionary.ContainsKey(key))
                {
                    propertyDictionary[key] = GetValue(objectToSave);
                }
                else
                {
                    propertyDictionary.Add(key, GetValue(objectToSave));
                }
            }
            else
            {
                foreach (var property in type.GetProperties())
                {
                    var immediatePrefix = $"{prefix}{property.Name}";
                    SaveProperties(property.GetValue(objectToSave), identifier, immediatePrefix);
                }
            }
        }

        private static string GetValue(object objectToSave)
        {
            if (!(objectToSave is string) && objectToSave is IEnumerable)
            {
                return JsonConvert.SerializeObject(objectToSave);
            }
            return objectToSave.ToString();
        }

        private static string GetTypeName(Type type)
        {
            return type.BaseType?.Name ?? type.Name;
        }

        public string GetValue(string key)
        {
            return PropertyDictionary.Instance()[key];
        }

        public T GetKnownTypeValue<T>(string key)
        {
            var value = GetValue(key);
            return JsonConvert.DeserializeObject<T>(value);
        }

        public List<string> GetPropertyPatternKeys()
        {
            return PropertyPatternDictionary.Instance().Keys.ToList();
        }
        public List<string> GetPropertyKeys()
        {
            return PropertyDictionary.Instance().Keys.ToList();
        }
    }
}
