using System;
using System.Collections.Generic;
using System.Text;

namespace WOWAuctionApi_Net10
{
    public class DataCount
    {
        public ListCount ItemCache = new ListCount();
        public ListCount PetCache = new ListCount();
        public ListCount RegionItems = new ListCount();

        public RealmCount Realm = new RealmCount(); 
    }


    public class ListCount
    {
        public int Total = 0;
        public int New = 0;
        public int Old = 0;
    }

    public class RealmCount
    {
        public int Count = 0;
        public int RealmId = 0;
        public string RealmName = "";
        public long TotalValue = 0;
    }
}
