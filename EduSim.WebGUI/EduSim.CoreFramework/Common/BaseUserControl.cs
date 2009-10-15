using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Catalog;

namespace EduSim.CoreFramework.Common
{
    public class BaseUserControl : UserControl
    {
        public BaseForm MainForm = null;
        public BrixMainForm BrixMainForm = null;

        public BaseUserControl(BrixMainForm BrixMainForm)
        {
            this.BrixMainForm = BrixMainForm;
        }

        public BaseUserControl()
        {
        }
    }

}
