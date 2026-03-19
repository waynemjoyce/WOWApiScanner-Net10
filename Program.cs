using Microsoft.Extensions.Configuration;

namespace WOWAuctionApi_Net10
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetColorMode(HelpAppSettings.GetColorMode());
            ApplicationConfiguration.Initialize();
            Application.Run(new FormMain());
        }
    }
}