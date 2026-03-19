using System;
using System.Collections.Generic;
using System.Text;

namespace WOWAuctionApi_Net10
{
    public class TsmItem
    {
        public int? regionId { get; set; }
        public long? itemId { get; set; }
        public long? petSpeciesId { get; set; }
        public float? quantity { get; set; }
        public long? marketValue { get; set; }
        public long? avgSalePrice { get; set; }
        public float? saleRate { get; set; }
        public float? soldPerDay { get; set; }
        public long? historical { get; set; }
    }
}
