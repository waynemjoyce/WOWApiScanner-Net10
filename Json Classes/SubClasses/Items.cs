using System;
using System.Collections.Generic;
using System.Text;

namespace WOWAuctionApi_Net10
{
    public class BlizzItem
    {
        public long? id { get; set; }
        public string? name { get; set; }

        public ItemClass? item_class { get; set; }
        public ItemSubClass? item_subclass { get; set; }
        public Quality? quality { get; set; }
        public InventoryType? inventory_type { get; set; }

        public long? level { get; set; }
        public long? required_level { get; set; }
    }

    public class BlizzBattlePetType
    {
        public long? id { get; set; }
        public string? type { get; set; }
        public string? name { get; set; }
    }

    public class BlizzPet
    {
        public long? id { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }

        public BlizzBattlePetType? battle_pet_type { get; set; }

        public bool? is_capturable { get; set; }
        public bool? is_tradable { get; set; }
        public bool? is_battlepet { get; set; }
        public bool? is_alliance_only { get; set; }
        public bool? is_horde_only { get; set; }
    }

    public class ItemClass
    {
        public string? name { get; set; }
        public int? id { get; set; }
    }

    public class Quality
    {
        public string? type { get; set; }
        public string? name { get; set; }
    }

    public class InventoryType
    {
        public string? name { get; set; }
        public string? type { get; set; }
    }

    public class ItemSubClass
    {
        public string? name { get; set; }
        public int? id { get; set; }
    }
}
