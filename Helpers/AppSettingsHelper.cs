using Microsoft.Extensions.Configuration;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WOWAuctionApi_Net10
{
    public static class AppSettingsHelper
    {
        public static void SetColorMode(SystemColorMode colorMode)
        {
            var filePath = Path.Combine(AppContext.BaseDirectory, "appsettings.json");
            var json = File.ReadAllText(filePath);
            var appNode = JsonSerializer.Deserialize<RootNode>(json);

            appNode.ColorMode = colorMode.ToString();

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            var updatedJsonContent = JsonSerializer.Serialize(appNode, options);
            File.WriteAllText(filePath, updatedJsonContent);

        }


        public static SystemColorMode GetColorMode()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            // 1. Build configuration
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // 2. Read the color mode setting
            string colorModeString = configuration["ApplicationSettings.ColorMode"] ?? "Dark";
            SystemColorMode colorMode;

            if (!Enum.TryParse(colorModeString, true, out colorMode))
            {
                colorMode = SystemColorMode.System; // Default to System if parsing fails
            }

            // 3. Set the application color mode before initialization
            //Application.SetColorMode(colorMode);

            return colorMode;
        }

        public class RootNode
        {
            [JsonPropertyNameAttribute("ApplicationSettings.ColorMode")]
            public string ColorMode { get; set; } = "";
        }

    }

}
