using System;
using System.Collections.Generic;
using System.Text;

namespace WOWAuctionApi_Net10
{
    public class ListBoxItem
    {
        public string ListName = "";
        public int IconIndex = 0;
        public ItemList List = new ItemList();
        public Image Picture { get; set; }

        public override string ToString()
        {
            return ListName;
        }
    }
}
