using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RpgBE.Core.Model.Commons
{
    public class GameObjectJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JObject jObject = new JObject();
            jObject.AddFirst(new JProperty("$type", string.Format("{0}, {1}", value.GetType().FullName, value.GetType().Assembly)));
            jObject.Add(new JProperty("initProperties", JObject.FromObject(value)));
            jObject.WriteTo(writer);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return serializer.Deserialize(reader, objectType);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType.IsSubclassOf(typeof(GameObject));
        }
    }
}