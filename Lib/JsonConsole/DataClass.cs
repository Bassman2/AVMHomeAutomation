using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JsonConsole
{
    public class DataClass
    {
        [JsonPropertyName("number")]
        public int Number { get; set; }

        public DateTime? DateTime { get; set; }

        public SubDataClass? SubData { get; set; }
    }

    public class SubDataClass
    {
        public string? Name { get; set; }
    }

    //[JsonSourceGenerationOptions(WriteIndented = true)]
    //[JsonSerializable(typeof(Data))]
    //internal partial class SourceGenerationContext : JsonSerializerContext
    //{
    //}

    [JsonSourceGenerationOptions(WriteIndented = true, GenerationMode = JsonSourceGenerationMode.Default )]
    [JsonSerializable(typeof(DataClass))]
    [JsonSerializable(typeof(SubDataClass))]
    
    internal partial class SourceGenerationContext : JsonSerializerContext
    {
    }
}
