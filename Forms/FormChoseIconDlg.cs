using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WOWAuctionApi_Net10
{
    public partial class FormChoseIconDlg : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int SelectedImageIndex { get; set; }

        public FormChoseIconDlg(ImageList imgList, int initialSelection = 0)
        {
            InitializeComponent();
            lvImages.LargeImageList = imgList;
            SelectedImageIndex = initialSelection;
        }

        private void FormChoseIcon_Load(object sender, EventArgs e)
        {

            int imageCount = lvImages.LargeImageList?.Images?.Count ?? 0;
            for (int j = 0; j < imageCount; j++)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = j; // Assigns the image at index j to the list item
                this.lvImages.Items.Add(item);
            }

            // Only select an item if there are images and the selected index is valid
            if (imageCount > 0 && SelectedImageIndex >= 0 && SelectedImageIndex < imageCount)
            {
                lvImages.Items[SelectedImageIndex].Selected = true;
            }
            else if (imageCount > 0)
            {
                // Fallback: select first image
                SelectedImageIndex = 0;
                lvImages.Items[0].Selected = true;
            }
        }

        private void lvImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SelectedImageIndex = lvImages.SelectedIndices[0];
            if (lvImages.SelectedIndices.Count > 0)
            {
                ListViewItem selectedItem = lvImages.SelectedItems[0];
                SelectedImageIndex = lvImages.Items.IndexOf(selectedItem);
            }

        }
    }
}
