using Microsoft.VisualBasic.Logging;
using System.CodeDom;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WOWAuctionApi_Net10
{
    public abstract class JsonBase
    {
        public string ToJson()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters = { new JsonStringEnumConverter() }
            };
            return JsonSerializer.Serialize(this, this.GetType(), options);
        }


        public void SaveToFile(string filePath)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters = { new JsonStringEnumConverter() }
            };
            File.WriteAllText(filePath, JsonSerializer.Serialize(this, this.GetType(), options));
        }

        /*
        public static JsonBase LoadFromFile(string fileName)
        {
            var options = new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter() }
            };
            var returnRI = JsonSerializer.Deserialize<JsonBase>(System.IO.File.ReadAllText(fileName), options);
            return returnRI;
        }
        */
    }
}
