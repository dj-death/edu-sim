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
        public EsimMainForm EsimMainForm = null;

        public BaseUserControl(EsimMainForm EsimMainForm)
        {
            this.EsimMainForm = EsimMainForm;
        }

        public BaseUserControl()
        {
        }
    }

}
