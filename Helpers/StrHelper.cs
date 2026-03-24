using System;
using System.Collections.Generic;
using System.Text;

namespace WOWAuctionApi_Net10
{
    public static class StrHelper
    {
        public static string FormatLongN0(long price)
        {
            try
            {
                if (price < 10000) { price = 0; }
                price = price / 10000;
                return price.ToString("N0");
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
