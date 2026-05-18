using System;
using System.IO;
using System.Xml.Serialization;

namespace MotorcycleStore.Common
{
    public static class ClassSerialize
    {
        public static void SerializationToXml<T>(ref T inObject, string inFileName)
        {
            var writer = new XmlSerializer(typeof(T));
            using var file = new StreamWriter(inFileName);
            writer.Serialize(file, inObject);
        }

        public static void DeserializationFromXml<T>(ref T inObject, string inFileName)
        {
            if (!File.Exists(inFileName))
                return;

            var reader = new XmlSerializer(typeof(T));
            using var file = new StreamReader(inFileName);
            inObject = (T)reader.Deserialize(file)!;
        }
    }
}
