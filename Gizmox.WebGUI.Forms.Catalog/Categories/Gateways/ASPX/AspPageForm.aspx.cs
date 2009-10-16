using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Gizmox.WebGUI.Forms.Catalog.Categories.Gateways.ASPX
{

    [Serializable()]
    public class ASPXBoxForm : Gizmox.WebGUI.Forms.Hosts.AspPageBase
    {
		protected System.Web.UI.HtmlControls.HtmlForm form1;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.TextBox TextBox2;
		protected System.Web.UI.WebControls.Button Button1;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.TextBox2.Text = this.TextBox1.Text;
        }
    }
}
