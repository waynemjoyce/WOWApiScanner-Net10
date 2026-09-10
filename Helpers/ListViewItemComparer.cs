
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace WOWAuctionApi_Net10
{
    public class ListViewItemComparer : IComparer
    {
        public int ColumnIndex { get; set; } = 0;
        public SortOrder Order { get; set; } = SortOrder.Ascending;

        public ListViewItemComparer() { }

        public ListViewItemComparer(int column, SortOrder order)
        {
            ColumnIndex = column;
            Order = order;
        }

        public int Compare(object? x, object? y)
        {
            if (x is not ListViewItem itemX || y is not ListViewItem itemY)
                return 0;

            string textX = itemX.SubItems.Count > ColumnIndex ? itemX.SubItems[ColumnIndex].Text : string.Empty;
            string textY = itemY.SubItems.Count > ColumnIndex ? itemY.SubItems[ColumnIndex].Text : string.Empty;

            int result;

            // Try parsing as numbers first for accurate numeric sorting
            if (decimal.TryParse(textX, out decimal numX) && decimal.TryParse(textY, out decimal numY))
            {
                result = numX.CompareTo(numY);
            }
            // Try parsing as dates
            else if (DateTime.TryParse(textX, out DateTime dateX) && DateTime.TryParse(textY, out DateTime dateY))
            {
                result = dateX.CompareTo(dateY);
            }
            // Fallback to string comparison
            else
            {
                result = string.Compare(textX, textY, StringComparison.CurrentCultureIgnoreCase);
            }

            // Reverse the result if the order is descending
            return Order == SortOrder.Descending ? -result : result;
        }

    }
}
