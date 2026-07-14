using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Text;
using WOWAuctionApi_Net10.Json_Classes;

namespace WOWAuctionApi_Net10
{
    public partial class ItemListOptions : OptionsBase
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ImageList ProfileImageList { get; set; }

        public event EventHandler<ItemListEventArgs>? SelectedChanged;    

        public ItemListOptions()
        {
            InitializeComponent();
        }

        public ItemListOptions(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void ProfileToUI()
        {
            rbSearch_List_DontUse.Checked = (sc.CurrentProfile.ListOption == 0);
            rbSearch_List_AdditionalCriteria.Checked = (sc.CurrentProfile.ListOption == 1);
            rbSearch_List_OnlyByList.Checked = (sc.CurrentProfile.ListOption == 2);
            SetListItems();
        }

        public void UIToProfile()
        {
            if (rbSearch_List_DontUse.Checked) { sc.CurrentProfile.ListOption = 0; }
            if (rbSearch_List_AdditionalCriteria.Checked) { sc.CurrentProfile.ListOption = 1; }
            if (rbSearch_List_OnlyByList.Checked) { sc.CurrentProfile.ListOption = 2; }

            sc.CurrentProfile.Lists.Clear();
            foreach (ListBoxItem lbi in lbItems.SelectedItems)
            {
                sc.CurrentProfile.Lists.Add(lbi.ListName);
            }
        }

        public void SetListItems(int index)
        {
            for (int i = 0; i < lbItems.Items.Count; i++)
            {
                lbItems.SetSelected(i, (i == index));
            }
        }

        public void SetListItems()
        {
            for (int i = 0; i < lbItems.Items.Count; i++)
            {
                ListBoxItem lbi = lbItems.Items[i] as ListBoxItem;
                if (lbi != null)
                {
                    lbItems.SetSelected(i, sc.CurrentProfile.Lists.Contains(lbi.ListName));
                }
            }
        }

        private void lbItems_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= lbItems.Items.Count) return;

            ListBoxItem item = (ListBoxItem)lbItems.Items[e.Index];
            
            // Draw the background
            e.DrawBackground();

            // Draw the image
            // The Y coordinate positions the image vertically within the item bounds
            e.Graphics.DrawImage(item.Picture, e.Bounds.X, e.Bounds.Y, 48, 48); // Draw a 32x32 image

            // Draw the text
            // Adjust the X coordinate to position text next to the image
            e.Graphics.DrawString(item.ListName, e.Font, new SolidBrush(Color.Gray), e.Bounds.X + 54, e.Bounds.Y + 5);

            // Draw the focus rectangle if the item is selected
            e.DrawFocusRectangle();


        }

        private void lbItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Need to raise an event here
            if (sc.DisplayMode == DisplayMode.ItemsLists && lbItems.SelectedItems.Count > 0)
            {
                ListBoxItem lbi = lbItems.SelectedItems[0] as ListBoxItem;
                if (lbi != null)
                {
                    ItemListEventArgs eventArgs = new ItemListEventArgs();
                    eventArgs.ItemList = lbi.List;
                    SelectedChanged?.Invoke(this, eventArgs);   
                }
            }
        }

        private void btnItemListNew_Click(object sender, EventArgs e)
        {
            var (profileName, iconIndex) = UIHelper.GetProfileDetails(2, 0, "(New List)", "Item List", ProfileImageList);
            if (profileName != null && profileName.Trim() != "")
            {
                ItemList newList = new ItemList();

                newList.Name = profileName;
                newList.IconIndex = iconIndex;
                sc.ItemLists.AddList(newList);
                sc.CurrentItemList = newList;
                sc.ItemLists.Save();
                LoadItemLists();
            }
        }

        public void LoadItemLists()
        {
            lbItems.Items.Clear();
            sc.ItemLists = ItemLists.Load();
            sc.ItemLists.Lists = sc.ItemLists.Lists.OrderBy(list => list.Name).ToList();

            foreach (ItemList itemList in sc.ItemLists.Lists)
            {
                lbItems.Items.Add(new ListBoxItem
                {
                    ListName = itemList.Name,
                    IconIndex = itemList.IconIndex.Value,
                    List = itemList,
                    Picture = ProfileImageList.Images[itemList.IconIndex.Value]
                }
                );
            }
        }

        private void btnItemListDelete_Click(object sender, EventArgs e)
        {
            /*
            if (MsgHelper.Confirm.DeleteItemList())
            {
                sc.ItemLists.Lists.Remove(sc.CurrentItemList);
                sc.ItemLists.Save();
                LoadItemLists();
            }
            */
        }

        private void btnItemListEdit_Click(object sender, EventArgs e)
        {
            var (profileName, iconIndex) = UIHelper.GetProfileDetails(1, sc.CurrentItemList.IconIndex.Value,
                sc.CurrentItemList.Name, "Item List", ProfileImageList);
            if (profileName != null && profileName.Trim() != "")
            {
                sc.CurrentItemList.Name = profileName;
                sc.CurrentItemList.IconIndex = iconIndex;
                sc.ItemLists.Save();
                LoadItemLists();
            }
        }

        private void btnItemListSaveAs_Click(object sender, EventArgs e)
        {
            var (profileName, iconIndex) = UIHelper.GetProfileDetails(0, sc.CurrentItemList.IconIndex.Value,
                sc.CurrentItemList.Name + " (Copy)", "Item List", ProfileImageList);
            if (profileName != null && profileName.Trim() != "")
            {
                ItemList newList = new ItemList();

                newList.Name = profileName;
                newList.IconIndex = iconIndex;
                newList.ItemCache = new ItemCache();
                foreach (CacheItem item in sc.CurrentItemList.ItemCache.Items)
                {
                    newList.ItemCache.AddItem(item);
                }
                sc.ItemLists.AddList(newList);
                sc.CurrentItemList = newList;
                sc.ItemLists.Save();
                LoadItemLists();
            }
        }

        public void SetDisplayMode(DisplayMode displayMode)
        {
            switch (displayMode)
            {
                case DisplayMode.Auctions:
                default:
                    OptionsTitle = " List Options For This Search";
                    lbItems.SelectionMode = SelectionMode.MultiExtended;
                    pnlButtons.Visible = false;
                    pnlOptions.Visible = true;
                    SetListItems();
                    break;

                case DisplayMode.ItemsLists:
                    OptionsTitle = " Manage My Lists";
                    lbItems.SelectionMode = SelectionMode.One;
                    pnlButtons.Visible = true;
                    pnlOptions.Visible = false;
                    SetListItems(0);
                    break;
            }
        }
    }

    public class ItemListEventArgs : EventArgs
    {
        public ItemList ItemList { get; set; }  
    }
}
