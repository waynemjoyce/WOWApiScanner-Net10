using System;
using System.Collections.Generic;
using System.Text;

namespace WOWAuctionApi_Net10
{
    public static class HelpString
    {
        public static string FormatItemPrice(long price)
        {
            try
            {
                
                string gold = price.ToString().Substring(0, price.ToString().Length - 4);
                //string silver = price.ToString().Substring(price.ToString().Length - 4, 2);
                //Note copper should always be zero now so ignore last 2 chars

                //return gold + "g " + silver + "s ";
                long newPrice = long.Parse(gold);
                string formatted = newPrice.ToString("N0");
                return gold + "g";
            }
            catch
            {
                return price.ToString();
            }
        }

        public static string FormatItemPriceGoldOnly(long price)
        {
            try
            {
                string gold = price.ToString().Substring(0, price.ToString().Length - 4);
                return gold;
            }
            catch
            {
                return price.ToString();
            }
        }
    }
}
