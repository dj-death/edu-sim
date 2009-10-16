using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using Gizmox.WebGUI.Forms;


namespace Gizmox.WebGUI.Forms.Catalog
{

    [Serializable()]
    public class MdiMainForm : MainForm
    {
        protected override void InitialzeWorspace()
        {
            this.IsMdiContainer = true;
        }

        protected override void ClearWorspace()
        {
           
        }

        protected override void AddWorspaceControl(Control objControl)
        {
            MdiChildForm objForm = new MdiChildForm(objControl);
            objForm.MdiParent = this;
            objForm.Show();            
        }
    }
}
