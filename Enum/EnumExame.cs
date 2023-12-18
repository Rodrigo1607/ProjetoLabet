

using System.Text.Json.Serialization;

namespace WebApi.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EnumExame
    {
        HemogramaCompleto,
        HemogramacomVHS,
        HemogramaPlaquetas
    }
}
