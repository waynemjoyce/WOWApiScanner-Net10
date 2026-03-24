using System;
using System.Collections.Generic;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WOWAuctionApi_Net10
{
    public static class UIHelper
    {
        public static void SetPanelBitwiseValues(Panel searchPanel, int bitwiseValue)
        {
            var checkedBoxes = searchPanel.Controls.OfType<ToggleSlider>();

            foreach (ToggleSlider checkBox in checkedBoxes)
            {
                if ((checkBox.Tag != null) && (checkBox.Tag.ToString() == "!EXCLUDE")) { continue; }
                checkBox.Checked = ((bitwiseValue & checkBox.OptionBit) != 0);
            }
        }


        public static void RenderUIOptionsSet(List<ToggleOption> optionList, Panel searchPanel, FormCache fc)
        {
            int x = fc.UIOptions.Toggle.XStart;
            int y = fc.UIOptions.Toggle.YStart;
            int count = 0;
            foreach (var option in optionList)
            {
                count++;
                RenderUIOptionsControl(option, searchPanel, x, y, fc);
                y += fc.UIOptions.Toggle.YRowOffset;
                if (count >= fc.UIOptions.Toggle.TogsPerColumn)
                {
                    count = 0;
                    y = fc.UIOptions.Toggle.YStart;
                    x += fc.UIOptions.Toggle.XColumnOffset;
                }
            }
        }


        private static void RenderUIOptionsControl(ToggleOption togOption, Panel searchPanel, 
            int renderX, int renderY, FormCache fc)
        {
            var newToggle = new ToggleSlider();
            Color backColor;
            Color togColor;
            if (fc.UIOptions.ColorMode == SystemColorMode.Dark)
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
            newToggle.Size = new Size(fc.UIOptions.Toggle.Width, fc.UIOptions.Toggle.Height);
            newToggle.UseVisualStyleBackColor = true;

            newToggle.OptionValue = togOption.Name;
            newToggle.OptionBit = togOption.Id.Value;
            newToggle.Name = "tsl_" + searchPanel.Name + togOption.Name.Replace(" ", "");

            newToggle.OnBackColor = backColor;
            newToggle.OnToggleColor = togColor;
            newToggle.OffBackColor = Color.Gray;
            newToggle.OffToggleColor = Color.Gainsboro;

            searchPanel.Controls.Add(newToggle);

            var newLabel = new System.Windows.Forms.Label();

            newLabel.AutoSize = true;
            newLabel.ForeColor = backColor;
            newLabel.Location = new Point(renderX + fc.UIOptions.Toggle.XLabelGap, renderY);
            newLabel.Name = "lbl_" + searchPanel.Name + togOption.Name.Replace(" ", "");
            newLabel.Text = togOption.Label;

            searchPanel.Controls.Add(newLabel);

        }

        public static Color GetColorForQuality(string quality, FormCache fc)
        {
            switch (fc.UIOptions.ColorMode)
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
                var hostPanel = clickedButton.Parent as Panel;
                if (hostPanel != null)
                {
                    var checkedBoxes = hostPanel.Controls.OfType<ToggleSlider>();
                    bool toggleValue = !(checkedBoxes.First().Checked);
                    foreach (CheckBox checkBox in checkedBoxes)
                    {
                        checkBox.Checked = toggleValue;
                    }
                }
            }
        }

        public static List<string> GetPanelCheckedList(Panel searchPanel)
        {
            var returnValue = new List<string>();

            var checkedBoxes = searchPanel.Controls.OfType<ToggleSlider>().Where(c => c.Checked);

            foreach (ToggleSlider checkBox in checkedBoxes)
            {
                returnValue.Add(checkBox.OptionValue);
            }

            return returnValue;
        }

    }

    public enum DisplayMode
    {
        Auctions,
        ItemsLists
    }
}
