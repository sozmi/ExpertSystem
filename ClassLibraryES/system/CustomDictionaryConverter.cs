using Newtonsoft.Json;

namespace ClassLibraryES.system
{
    public class CustomDictionaryConverter<TKey, TValue> : JsonConverter 
        where TKey: notnull
        where TValue: notnull 
    {
        public override bool CanConvert(Type objectType) => objectType == typeof(Dictionary<TKey, TValue>);

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            if(value == null)
                return;
            serializer.Serialize(writer, ((Dictionary<TKey, TValue>)value).ToList());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            if (existingValue == null)
                return new();
            var readObjs = serializer.Deserialize<KeyValuePair<TKey, TValue>[]>(reader);
            if (readObjs == null)
                return new();
            return readObjs.ToDictionary(kv => kv.Key, kv => kv.Value);
        }
    }
}