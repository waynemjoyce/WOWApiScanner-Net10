using System;
using System.Collections.Generic;
using System.Text;

namespace WOWAuctionApi_Net10
{
    public class ToolStripBlankSeparatorRenderer : ToolStripSystemRenderer
    {
        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {
            // Do nothing, results in blank space
        }
    }
}
