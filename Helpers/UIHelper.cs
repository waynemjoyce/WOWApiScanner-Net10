using System;
using System.Collections.Generic;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WOWAuctionApi_Net10
{
    public static class UIHelper
    {
        public static void SetControlBitwiseValue(Control hostControl, int bitwiseValue)
        {
            var checkedBoxes = hostControl.Controls.OfType<ToggleSlider>();

            foreach (ToggleSlider checkBox in checkedBoxes)
            {
                if ((checkBox.Tag != null) && (checkBox.Tag.ToString() == "!EXCLUDE")) { continue; }
                checkBox.Checked = ((bitwiseValue & checkBox.OptionBit) != 0);
            }
        }
        public static List<int> GetIntsFromBitwise(int bitwise)
        {
            var activeBits = new List<int>();

            for (int i = 0; i < 32; i++)
            {
                int mask = 1 << i;
                if ((bitwise & mask) != 0)
                {
                    activeBits.Add(mask); // Add the value (1, 2, 4...)
                }
            }

            return activeBits;  
        }

        public static (string profileName, int iconIndex) GetProfileDetails(
            int searchType, int startingIndex, string startingProfileName, string itemTitle, ImageList imgList)
        {
            string title;

            switch (searchType)
            {
                case 0: default: title = "Save Current {itemTitle} As"; break;
                case 1: title = $"Rename Current {itemTitle}"; break;
                case 2: title = $"New {itemTitle}"; break;
            }

            FormSaveProfileDialog saveDlg = new FormSaveProfileDialog(title,
                startingProfileName, searchType, startingIndex, imgList);
            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                return (saveDlg.ProfileName, saveDlg.ImageIndex);
            }

            return ("", 0);
        }
        public static int GetControlBitwiseValue(Control hostControl)
        {
            var returnValue = 0;

            var checkedBoxes = hostControl.Controls.OfType<ToggleSlider>().Where(c => c.Checked);

            foreach (ToggleSlider checkBox in checkedBoxes)
            {
                returnValue += checkBox.OptionBit;
            }

            return returnValue;
        }


        public static void RenderUIOptionsSet(OptionSet setToRender, Control hostControl)
        {
            ToggleAttributes attributes;

            if (setToRender.UseDefaultAttributes.Value)
            {
                attributes = sc.UIOptions.DefaultAttributes;
            }
            else
            {
                attributes = setToRender.Attributes;
            }

            int x = sc.UIOptions.DefaultAttributes.XStart;
            int y = sc.UIOptions.DefaultAttributes.YStart;
            int count = 0;
            foreach (var option in setToRender.ToggleOptions)
            {
                count++;
                RenderUIOptionsControl(option, hostControl, x, y);
                y += attributes.YRowOffset;
                if (count >= attributes.TogsPerColumn)
                {
                    count = 0;
                    y = attributes.YStart;
                    x += attributes.XColumnOffset;
                }
            }
        }


        private static void RenderUIOptionsControl(ToggleOption togOption, Control hostControl, 
            int renderX, int renderY)
        {
            var newToggle = new ToggleSlider();
            Color backColor;
            Color togColor;
            if (sc.UIOptions.ColorMode == SystemColorMode.Dark)
            {
                backColor = Color.FromName(togOption.BackColorDark);
                togColor = Color.FromName(togOption.ToggleColorDark);
            }
            else
            {
                backColor = Color.FromName(togOption.BackColorLight);
                togColor = Color.FromName(togOption.ToggleColorLight);
            }

            newToggle.Checked = true;
            newToggle.CheckState = CheckState.Checked;
            newToggle.Location = new Point(renderX, renderY);
            newToggle.Size = new Size(sc.UIOptions.DefaultAttributes.Width, sc.UIOptions.DefaultAttributes.Height);
            newToggle.UseVisualStyleBackColor = true;

            newToggle.OptionValue = togOption.Name;
            newToggle.OptionBit = togOption.Id.Value;
            newToggle.Name = "tsl_" + hostControl.Name + togOption.Name.Replace(" ", "");

            newToggle.OnBackColor = backColor;
            newToggle.OnToggleColor = togColor;
            newToggle.OffBackColor = Color.Gray;
            newToggle.OffToggleColor = Color.Gainsboro;

            hostControl.Controls.Add(newToggle);

            var newLabel = new System.Windows.Forms.Label();

            newLabel.AutoSize = true;
            newLabel.ForeColor = backColor;
            newLabel.Location = new Point(renderX + sc.UIOptions.DefaultAttributes.XLabelGap, renderY);
            newLabel.Name = "lbl_" + hostControl.Name + togOption.Name.Replace(" ", "");
            newLabel.Text = togOption.Label;

            hostControl.Controls.Add(newLabel);

        }

        public static Color GetColorForQuality(string quality)
        {
            switch (sc.UIOptions.ColorMode)
            {
                case SystemColorMode.Classic:
                    switch (quality)
                    {
                        case "UNCOMMON": default: return Color.DarkGreen;
                        case "RARE": return Color.MidnightBlue;
                        case "EPIC": return Color.DarkViolet;
                        case "POOR": return Color.DimGray;
                        case "COMMON": return Color.DarkGray;
                        case "LEGENDARY": return Color.Chocolate;
                        case "ARTIFACT": return Color.Tan;
                    }
                case SystemColorMode.Dark:
                default:

                    switch (quality)
                    {
                        case "UNCOMMON": default: return Color.LimeGreen;
                        case "RARE": return Color.CornflowerBlue;
                        case "EPIC": return Color.MediumOrchid;
                        case "POOR": return Color.DarkGray;
                        case "COMMON": return Color.White;
                        case "LEGENDARY": return Color.Orange;
                        case "ARTIFACT": return Color.Tan;
                    }

            }
        }

        public static void ToggleOnOffClick(object sender, EventArgs e)
        {
            var clickedButton = sender as System.Windows.Forms.Button;
            if (clickedButton != null)
            {
                if ((clickedButton.Tag != null) && (clickedButton.Tag.ToString() == "!EXCLUDE")) { return; }
                var hostControl = clickedButton.Parent as Control;
                if (hostControl != null)
                {
                    var checkedBoxes = hostControl.Controls.OfType<ToggleSlider>();
                    bool toggleValue = !(checkedBoxes.First().Checked);
                    foreach (CheckBox checkBox in checkedBoxes)
                    {
                        checkBox.Checked = toggleValue;
                    }
                }
            }
        }

        public static List<string> GetControlCheckedList(Control hostControl)
        {
            var returnValue = new List<string>();

            var checkedBoxes = hostControl.Controls.OfType<ToggleSlider>().Where(c => c.Checked);

            foreach (ToggleSlider checkBox in checkedBoxes)
            {
                returnValue.Add(checkBox.OptionValue);
            }

            return returnValue;
        }

        public static Color StringToColor(string hexColor)
        {
            return System.Drawing.ColorTranslator.FromHtml(hexColor);
        }

        public static String ColorToString(Color hexColor)
        {
            return System.Drawing.ColorTranslator.ToHtml(hexColor);
        }


    }

    public enum DisplayMode
    {
        Auctions,
        ItemsLists,
        Config
    }
}
