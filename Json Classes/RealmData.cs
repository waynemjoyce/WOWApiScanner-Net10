using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WOWAuctionApi_Net10
{
    public class RealmData : JsonBase
    {
        public List<Realm>? Realms { get; set; }

        public static RealmData LoadFromFile(string fileName)
        {
            var options = new JsonSerializerOptions
            {
                Converters = { new ColorConverter(), new JsonStringEnumConverter() }
            };
            var returnRI = JsonSerializer.Deserialize<RealmData>(System.IO.File.ReadAllText(fileName), options);
            return returnRI;
        }

        public void Save()
        {
            Realms = Realms.OrderBy(r => r.RealmName).ToList();
            SaveToFile(sc.Paths.RealmData);
        }

        public void SaveBackup()
        {
            Realms = Realms.OrderBy(r => r.RealmName).ToList();
            SaveToFile(sc.Paths.RealmDataBackup.Replace("realmdata.json", 
                $"realmdata_backup_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.json"));
        }
    }   
}
