using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WOWAuctionApi_Net10
{
    public partial class FormSaveProfileDialog : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ProfileName
        {
            get { return this.textBoxProfileName.Text; }
            set
            {
                if (value != null)
                {
                    this.textBoxProfileName.Text = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Test cannot be null.");
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ImageIndex
        {
            get { return _imageIndex; }
            set
            {
                if (value >= 0)
                {
                    _imageIndex = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "ImageIndex must be non-negative.");
                }
            }
        }

        //0 = Save as
        //1 = Edit
        //2 = New
        private int _imageIndex = 0;
        private ImageList _profileImages;

        public FormSaveProfileDialog(string title, string profileName, int iconIndex, int imageIndex, ImageList images48)
        {
            InitializeComponent();
            this.Text = title;
            this.textBoxProfileName.Text = profileName;
            _imageIndex = imageIndex;
            _profileImages = images48;

            if (imgIcons.Images.Count > 0)
            {
                // Retrieve image and convert to bitmap
                Bitmap bmp = new Bitmap(imgIcons.Images[iconIndex]);

                // Create icon from bitmap handle and assign to form
                this.Icon = Icon.FromHandle(bmp.GetHicon());
            }

            this.picProfileImage.Image = images48.Images[imageIndex];
        }

        private void btnChangeIcon_Click(object sender, EventArgs e)
        {

            FormChoseIconDlg iconDlg = new FormChoseIconDlg(_profileImages, _imageIndex);
            iconDlg.ShowDialog();
            if (iconDlg.DialogResult == DialogResult.OK)
            {
                _imageIndex = iconDlg.SelectedImageIndex;
                this.picProfileImage.Image = _profileImages.Images[_imageIndex];
            }

        }
    }
}
