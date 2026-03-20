using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;


namespace WOWAuctionApi_Net10
{
    public static class API_Blizzard
    {
        public static string GetAccessToken(string clientId, string clientSecret)
        {
            var client = new RestClient("https://us.battle.net/oauth/token");
            var request = new RestRequest();
            request.Method = Method.Post;

            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", $"grant_type=client_credentials&client_id={clientId}&client_secret={clientSecret}", ParameterType.RequestBody);
            RestResponse response = client.Execute(request);

            var tokenResponse = JsonSerializer.Deserialize<AccessTokenResponse>(response.Content);

            return tokenResponse.access_token;

        }

        public static AuctionFileContents GetAuctionsFromAPI(string token, Realm r, out HttpStatusCode statusCode, out string lastModified)
        {
            var client = new RestClient("https://us.api.blizzard.com");
            var request = new RestRequest($"/data/wow/connected-realm/{r.RealmId.ToString()}/auctions", Method.Get);
            AuctionFileContents afc = new AuctionFileContents();

            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            request.AddParameter("namespace", "dynamic-us");
            request.AddParameter("locale", "en_US");

            if (r.LastModified != String.Empty)
            {
                request.AddHeader("If-Modified-Since", r.LastModified);
            }
            request.AddHeader("Accept-Encoding", "gzip, deflate");
            request.AddHeader("Authorization", $"Bearer {token}");
                
            RestResponse response = client.Execute(request);

            statusCode = response.StatusCode;

            try
            {
                afc = JsonSerializer.Deserialize<AuctionFileContents>(response.Content);
            }
            catch { }
            ;

            Dictionary<string, string> headersList = new Dictionary<string, string>();

            foreach (HeaderParameter item in response.ContentHeaders)
            {
                if (!headersList.ContainsKey(item.Name))
                {
                    headersList.Add(item.Name, item.Value.ToString());
                }
            }

            headersList.TryGetValue("Last-Modified", out lastModified);

            return afc;
        }

        /*
        public static async Task<string> GetDataFromServiceAsync(string url)
        {
            using var client = new HttpClient();
            string response = await client.GetStringAsync(url);
            return response;
        }

        public static async Task<AuctionEventInfo> GetAuctionsFromAPI(string token, Realm r)
        {
            var client = new RestClient("https://us.api.blizzard.com");
            var request = new RestRequest($"/data/wow/connected-realm/{r.RealmId.ToString()}/auctions", Method.Get);
            AuctionEventInfo ae = new AuctionEventInfo();
            AuctionFileContents afc = new AuctionFileContents();

            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            request.AddParameter("namespace", "dynamic-us");
            request.AddParameter("locale", "en_US");
            //request.AddParameter("access_token", token);



            if (r.LastModified != String.Empty)
            {
                request.AddHeader("If-Modified-Since", r.LastModified);
            }
            request.AddHeader("Accept-Encoding", "gzip, deflate");
            request.AddHeader("Authorization", $"Bearer {token}");

            RestResponse response = await client.ExecuteAsync(request);

            ae.StatusCode = response.StatusCode;

            try
            {
                afc = JsonSerializer.Deserialize<AuctionFileContents>(response.Content);
            }
            catch
            { }
    ;

            Dictionary<string, string> headersList = new Dictionary<string, string>();

            foreach (HeaderParameter item in response.ContentHeaders)
            {
                if (!headersList.ContainsKey(item.Name))
                {
                    headersList.Add(item.Name, item.Value.ToString());
                }
            }

            string lastModified;
            headersList.TryGetValue("Last-Modified", out lastModified);
            ae.Auctions = afc;
            ae.LastModified = lastModified;     
            return ae;
        }
        */

        public static BlizzItem GetBlizzItemFromItemId(string accessToken, long itemId)
        {
            var client = new RestClient("https://us.api.blizzard.com");
            var request = new RestRequest($"/data/wow/item/{itemId}", Method.Get);
            request.AddQueryParameter("namespace", "static-us");
            request.AddQueryParameter("locale", "en_US");
            request.AddHeader("Authorization", $"Bearer {accessToken}");
            var response = client.Execute(request);

            try
            {
                BlizzItem ba = JsonSerializer.Deserialize<BlizzItem>(response.Content);
                return ba;
            }
            catch
            {
                BlizzItem ba = new BlizzItem();
                ba.id = itemId;
                ba.name = "{Serialization error}";
                return ba;
            }

        }

        public static BlizzPet GetBlizzPetFromItemId(string accessToken, long petId)
        {
            var client = new RestClient("https://us.api.blizzard.com");
            var request = new RestRequest($"/data/wow/pet/{petId}", Method.Get);
            request.AddQueryParameter("namespace", "static-us");
            request.AddQueryParameter("locale", "en_US");
            request.AddHeader("Authorization", $"Bearer {accessToken}");
            var response = client.Execute(request);

            try
            {
                BlizzPet blizzPet = JsonSerializer.Deserialize<BlizzPet>(response.Content);
                return blizzPet;
            }
            catch
            {
                BlizzPet blizzPet = new BlizzPet();
                blizzPet.id = petId;
                blizzPet.name = "{Serialization error}";
                return blizzPet;
            }

        }
    }

    public class AccessTokenResponse
    {
        public string? access_token { get; set; }
    }

    public class AuctionEventInfo
    {
        public int ConnectedRealmId { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public AuctionFileContents? Auctions { get; set; }

        public Realm? RealmObject { get; set; }

        public string? LastModified { get; set; }
    }
}
