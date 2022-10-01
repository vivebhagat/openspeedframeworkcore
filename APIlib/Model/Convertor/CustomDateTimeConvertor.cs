using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace SpeedFramework.APILib.Models.Convertors
{
    public class CustomDateTimeConvertor : DateTimeConverterBase
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value != null)
            {
                return DateTime.Parse(reader.Value.ToString());
            }
            return reader.Value;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((DateTime)value).ToString("dd/MM/yyyy hh:mm tt"));
        }
    }
}
