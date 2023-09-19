using System.Text.Json;

namespace JsonConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {

            DataClass data = new DataClass();
            string jsonString = JsonSerializer.Serialize(data, SourceGenerationContext.Default.DataClass);
            data = JsonSerializer.Deserialize<DataClass>(jsonString, SourceGenerationContext.Default.DataClass)!;


            Console.WriteLine("Hello, World!");
        }
    }
}