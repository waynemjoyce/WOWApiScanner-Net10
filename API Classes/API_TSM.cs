using RestSharp;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace WOWAuctionApi_Net10
{
    public static class API_TSM
    {
        public static string GetAccessToken(string tsmKey, string tsmClientId)
        {
            var client = new RestClient("https://auth.tradeskillmaster.com/oauth2/token");
            var request = new RestRequest();
            request.Method = Method.Post;

            request.AddParameter("client_id", tsmClientId);
            request.AddParameter("grant_type", "api_token");
            request.AddParameter("scope", "app:realm-api app:pricing-api");
            request.AddParameter("token", tsmKey);

            RestResponse response = client.Execute(request);

            var tokenResponse = JsonSerializer.Deserialize<AccessTokenResponse>(response.Content);

            return tokenResponse.access_token;
        }

        public static List<TsmItem> GetRegionTsmItemsFromFile()
        {
            string regionItems = File.ReadAllText(Paths.TsmRegionData);
            return JsonSerializer.Deserialize<List<TsmItem>>(regionItems);
        }

        public static void WriteRegionTsmItems(string access_token)
        {
            var client = new RestClient("https://pricing-api.tradeskillmaster.com/");
            var request = new RestRequest($"/region/1", Method.Get);

            string returnString = String.Empty;

            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            request.AddParameter("format", "json");
            request.AddHeader("authorization", $"Bearer {access_token}");
            RestResponse response = client.Execute(request);

            File.WriteAllText(Paths.TsmRegionData, response.Content);
        }
    }
}
