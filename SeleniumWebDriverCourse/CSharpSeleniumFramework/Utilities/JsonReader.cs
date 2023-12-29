using Newtonsoft.Json.Linq;

namespace CSharpSelFramework.Utilities
{
    public class JsonReader
    {
        private readonly string JsonFilePath;

        public JsonReader(string jsonFilePath)
        {
            JsonFilePath = jsonFilePath;
        }

        public string ExtractData(string tokenName)
        {
            var jsonObject = ReadJsonObject();
            return jsonObject.SelectToken(tokenName)?.Value<string>();
        }

        public string[] ExtractDataArray(string tokenName)
        {
            var jsonObject = ReadJsonObject();
            var productsList = jsonObject.SelectTokens(tokenName)?.Values<string>() ?? new List<string>();
            return productsList.ToArray();
        }

        private JToken ReadJsonObject()
        {
            string myJsonString = File.ReadAllText(JsonFilePath);
            return JToken.Parse(myJsonString);
        }
    }
}
