using System;
using System.Collections.Generic;
using System.Text;

namespace WOWAuctionApi_Net10
{
    public static class MsgHelper
    {
        public static class Info
        {
            private static void Message(string message, string title, MessageBoxIcon icon = MessageBoxIcon.Information)
            {
                MessageBox.Show(message, title, MessageBoxButtons.OK, icon);
            }
        }
        public static class Error
        {
            private static void Message(string message, string title, MessageBoxIcon icon = MessageBoxIcon.Error)
            {
                MessageBox.Show(message, title, MessageBoxButtons.OK, icon);
            }

            public static void RealmsNotLoaded()
            {
                Message("One or more of your realms has not yet its data loaded. "
                + "\n\nPlease click the refresh button in the top left corner and wait for "
                + "all chosen realms' data to load before searching", "Please Load Realm Data");
            }

            public static void CannotDeleteDefault()
            {
                Message("Please note you can't delete or rename the [Default] profile, "
                + "since this is the model profile against which all new profiles are based.","Cannot Delete Default Profile");
            }
        }

        public static class Confirm
        {
            private static bool Message(string message, string title, 
                MessageBoxIcon icon = MessageBoxIcon.Warning, string proceedMessage = "Are you sure you want to proceed?")
            {
                return ((MessageBox.Show(message + "\n\n" + proceedMessage, "Confirm: " + title, 
                    MessageBoxButtons.YesNo, icon) == DialogResult.Yes));
            }

            public static bool UpdateAllData()
            {
                return Message($"This will do several tasks in one action:-\n\n" +
                    "1) Write the TSM Region data to \\tsm\\tsmdata.json\n" +
                    "2) Update the item, then pet, caches with any new items in tsmdata not in the caches\n" +
                    "3) Sort the item, then pet, caches within the respective .json data file, if config.json 'SortCacheOnUpdate' = true",
                    "Update All Data");
            }

            public static bool RebuildCache(string cacheName)
            {
                return Message($"This will completely rebuild the {cacheName} cache by querying Blizzard's item API one by one." +
                    "\n\nThis may take up to several hours to run.\n\n", "Cache Rebuild", MessageBoxIcon.Exclamation);
            }

            public static bool SortCache(string cacheName, string direction)
            {
                return Message($"This will sort the {cacheName} cache .json file on your system by Id in {direction} order.",
                    "Cache Sort", MessageBoxIcon.Exclamation);
            }

            public static bool OverwriteProfile()
            {
                return Message("This will overrite the current search profile.", "Save Search Profile");
            }

            public static bool DefaultProfile()
            {
                return Message("This will overwrite the default search profile.", "Default Search Profile");
            }

            public static bool DeleteProfile()
            {
                return Message("This will delete the currently selected Search Profile.","Delete Search Profile");
            }
        }

    }
}
