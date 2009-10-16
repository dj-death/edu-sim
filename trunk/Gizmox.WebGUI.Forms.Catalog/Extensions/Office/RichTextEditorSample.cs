using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Drawing;
using System.Collections;
using Gizmox.WebGUI.Common.Resources;


namespace Gizmox.WebGUI.Forms.Catalog.Extensions.Office
{
    [Serializable()]
    public class RichTextEditorSample : UserControl, IHostedApplication
    {
        private RichTextEditor mobjRichTextEditor;

        private RibbonBar mobjRichTextRibbonBar;

        public RichTextEditorSample()
        {
            this.BackColor = Color.FromArgb(191, 219, 255);

            mobjRichTextEditor = new RichTextEditor();
            mobjRichTextEditor.Dock = DockStyle.Fill;
            mobjRichTextEditor.Value = "<b>Hi from <i>RichTextEditor</i>...</b>";
            this.Controls.Add(mobjRichTextEditor);

            mobjRichTextRibbonBar = new RibbonBar();
            this.Controls.Add(mobjRichTextRibbonBar);

            RibbonBarPage objFormatTextPage = new RibbonBarPage("Format Text");
            objFormatTextPage.Groups.Add(mobjRichTextEditor, "Clipboard");
            objFormatTextPage.Groups.Add(mobjRichTextEditor, "BasicText");
            objFormatTextPage.Groups.Add(mobjRichTextEditor, "Proofing");
            mobjRichTextRibbonBar.Pages.Add(objFormatTextPage);
        }

        #region IHostedApplication Members

        void IHostedApplication.InitializeApplication()
        {
            
        }

        HostedToolBarElement[] IHostedApplication.GetToolBarElements()
        {
            ArrayList objElements = new ArrayList();
            objElements.Add(new HostedToolBarButton("Show", new IconResourceHandle("Show.gif"), "Show"));
            return (HostedToolBarElement[])objElements.ToArray(typeof(HostedToolBarElement));
        }

        void IHostedApplication.OnToolBarButtonClick(HostedToolBarButton objButton, EventArgs objEvent)
        {
            string strAction = (string)objButton.Tag;

            switch (strAction)
            {
                case "Show":
                    MessageBox.Show(mobjRichTextEditor.Value);
                    break;
            }
        }

        #endregion
    }
}
