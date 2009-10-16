using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Resources;

namespace Gizmox.WebGUI.Forms.Catalog.Categories.Behaviors
{
    /// <summary>
    /// Summary description for TableLayoutBehavior.
    /// </summary>

    [Serializable()]
    public class SurfacePanelBehavior : UserControl
    {


        /// <summary> 
        /// Required designer variable.
        /// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null;

        public SurfacePanelBehavior()
        {
            // This call is required by the WebGUI Form Designer.
            InitializeComponent();

            PictureBox objPictureBox1 = new PictureBox();
            PictureBox objPictureBox2 = new PictureBox();
            PictureBox objPictureBox3 = new PictureBox();



            objPictureBox1.Image = new ImageResourceHandle("Stone.jpg");
            objSurfacePanel1.Controls.Add(objPictureBox1);

            objPictureBox2.Image = new ImageResourceHandle("Sea.jpg");
            objSurfacePanel1.Controls.Add(objPictureBox2);

            objPictureBox3.Image = new ImageResourceHandle("View.jpg");
            objSurfacePanel1.Controls.Add(objPictureBox3);

        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.objSurfacePanel1 = new Gizmox.WebGUI.Forms.SurfacePanel();
            this.SuspendLayout();
            lable1 = new Label();
            this.lable1.Size = new System.Drawing.Size(393, 53);
            lable1.Dock = DockStyle.Top;
            this.lable1.Text = "\r\nThis control only works in silverlight.\r\nChange the extension to swgx to see it" +
" work\r\n";

            this.Controls.Add(this.lable1);

            // 
            // objSurfacePanel1
            // 
            this.objSurfacePanel1.CustomStyle = "Surface";
            this.objSurfacePanel1.Dock = DockStyle.Fill;
            this.objSurfacePanel1.Name = "objSurfacePanel1";
            this.objSurfacePanel1.PanelType = Gizmox.WebGUI.Forms.PanelType.Custom;
            this.objSurfacePanel1.Size = new System.Drawing.Size(100, 100);
            this.objSurfacePanel1.TabIndex = 0;
            // 
            // SurfacePanelBehavior
            // 
            this.Controls.Add(this.objSurfacePanel1);
            this.Size = new System.Drawing.Size(586, 583);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.SurfacePanel objSurfacePanel1;
        Label lable1;


    }
}
