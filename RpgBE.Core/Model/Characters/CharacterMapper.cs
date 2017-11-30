using Newtonsoft.Json;
using RpgBE.Core.Model.Commons;

namespace RpgBE.Core.Model.Characters
{
    public static class CharacterMapper
    {
        public static CharacterDto ToDto(this Character character)
        {
            return AutoMapper.Mapper.DynamicMap<CharacterDto>(character);
        }

        public static string ToJson(this GameObject gameObject)
        {
            return JsonConvert.SerializeObject(gameObject, new GameObjectJsonConverter());
        }

        public static object ToGameObject(this string serializedObject)
        {
            return JsonConvert.DeserializeObject(serializedObject);
        }
        
    }
}