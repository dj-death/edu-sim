using System;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Forms.Catalog.Controls
{
    /// <summary>
    /// Summary description for WinPanel.
    /// </summary>

    [Gizmox.WebGUI.Forms.Skins.Skin(typeof(Gizmox.WebGUI.Forms.Catalog.Controls.Skins.WinPanelSkin)), Serializable()]
    public class WinPanel : Panel
    {
        public event EventHandler CloseClick;

        public WinPanel()
        {
            this.PanelType = PanelType.Custom;
            this.CustomStyle = "Window";
        }

        protected override void FireEvent(IEvent objEvent)
        {
            //If the control is hidden or disabled
            //don't fire it's events
            if (this.Visible && this.Enabled)
            {

                switch (objEvent.Type)
                {
                    case "PanelClose":
                        if (CloseClick != null)
                        {
                            CloseClick(this, EventArgs.Empty);
                        }
                        break;
                    default:
                        base.FireEvent(objEvent);
                        break;
                }
            }
        }

    }
}
