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
        public ToggleAttributes? DefaultAttributes { get; set; }
        public List<OptionSet>? OptionSets { get; set; }
   

        [JsonIgnore]
        public SystemColorMode ColorMode = AppSettingsHelper.GetColorMode();

        public void Save()
        {
            SaveToFile(sc.Paths.UIOptions);
        }
        public static UserInterfaceOptions LoadFromFile()
        {
            string fileName = sc.Paths.UIOptions;
            string uioptions = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<UserInterfaceOptions>(uioptions);
        }
    }
    public class OptionSet
    {
        public string? SetName { get; set; }
        public bool? UseDefaultAttributes { get; set; }
        public ToggleAttributes? Attributes { get; set; }
        public List<ToggleOption>? ToggleOptions { get; set; }
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


