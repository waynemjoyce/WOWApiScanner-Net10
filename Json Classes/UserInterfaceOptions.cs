using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WOWAuctionApi_Net10
{
    public class UserInterfaceOptions : JsonBase
    {

        public List<ToggleOption>? Main { get; set; }
        public List<ToggleOption>? Class { get; set; }
        public List<ToggleOption>? Quality { get; set; }
        public List<ToggleOption>? Bonuses { get; set; }

        public ToggleAttributes? Toggle { get; set; }

        [JsonIgnore]
        public SystemColorMode ColorMode = AppSettingsHelper.GetColorMode();

        public void Save()
        {
            SaveToFile(Paths.UIOptions);
        }
        public static UserInterfaceOptions LoadFromFile()
        {
            string fileName = Paths.UIOptions;
            string uioptions = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<UserInterfaceOptions>(uioptions);
        }

        public class ToggleAttributes
        {
            public int TogsPerColumn { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
            public int XStart { get; set; }
            public int YStart { get; set; }
            public int YRowOffset { get; set; }
            public int XColumnOffset { get; set; }
            public int XLabelGap { get; set; }
        }
    }
}


