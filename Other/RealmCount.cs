using System;
using System.Collections.Generic;
using System.Text;

namespace WOWAuctionApi_Net10
{
    public class RealmCount
    {
        public int Count { get; set; }  
        public int RealmId { get; set; }    
        public string RealmName { get; set; } 
        public long TotalValue { get; set; }
    }
}
