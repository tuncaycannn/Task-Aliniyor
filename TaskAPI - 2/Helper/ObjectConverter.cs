using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;

namespace TaskAPI.Helper
{


    //Değerler boş gelmiyorsa json içinde arama yapıp sıralanması için oluşturulan method.
    public static class ObjectConverter
    {
        public static T Deserialize<T>(string json)
        {
            T obj = Activator.CreateInstance<T>();
            MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(json));
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            obj = (T)serializer.ReadObject(ms);
            ms.Close();
            return obj;
        }

        public static T XmlToModel<T>(this string xmlResult) where T : class, new()
        {
            if (string.IsNullOrEmpty(xmlResult.Trim())) return new T();
            var xmlSerializer = new XmlSerializer(typeof(T));
            var stringReader = new StringReader(xmlResult);
            var model = (T)xmlSerializer.Deserialize(stringReader);
            stringReader.Dispose();
            return model;
        }


    }
}
