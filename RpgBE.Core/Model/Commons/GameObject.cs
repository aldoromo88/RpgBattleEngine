namespace RpgBE.Core.Model.Commons
{
    public abstract class GameObject
    {
        protected GameObject(object initProperties)
        {
            if (initProperties == null) return;

            AutoMapper.Mapper.DynamicMap(initProperties, this, initProperties.GetType(), GetType());
        }
    }

    public class GameObjectMetadata
    {
        public string Type { get; set; }
        public object InitProperties { get; set; }
    }

    public static class GameObjectFactory
    {
        public static T CreateObject<T>(string json)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
        }
    }
}
