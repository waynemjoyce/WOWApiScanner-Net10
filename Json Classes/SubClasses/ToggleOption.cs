using System;
using System.Collections.Generic;
using System.Text;

namespace WOWAuctionApi_Net10
{ 
    public class ToggleOption
    {
        public int? Id { get; set; }    
        public string? Name { get; set; }
        public string? Label { get; set; }
        public string? BackColorDark { get; set; }
        public string? ToggleColorDark { get; set; }
        public string? BackColorLight { get; set; }
        public string? ToggleColorLight { get; set; }
    }
}
