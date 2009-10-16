using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Reflection;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Catalog.Controls;

namespace Gizmox.WebGUI.Forms.Catalog.Categories.CustomControls
{
    /// <summary>
    /// Summary description for CustomWindowPanelControl.
    /// </summary>

    [Serializable()]
    public class CustomWindowPanelControl : UserControl
    {
        private Gizmox.WebGUI.Forms.Catalog.Controls.WinPanel panel1;
        private Gizmox.WebGUI.Forms.Splitter splitter1;
        private Gizmox.WebGUI.Forms.Catalog.Controls.WinPanel panel2;
        private Gizmox.WebGUI.Forms.Splitter splitter2;
        private Gizmox.WebGUI.Forms.Catalog.Controls.WinPanel panel3;
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null;

        public CustomWindowPanelControl()
        {
            // This call is required by the WebGUI Form Designer.
            InitializeComponent();

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
            this.panel1 = new Gizmox.WebGUI.Forms.Catalog.Controls.WinPanel();
            this.splitter1 = new Gizmox.WebGUI.Forms.Splitter();
            this.panel2 = new Gizmox.WebGUI.Forms.Catalog.Controls.WinPanel();
            this.splitter2 = new Gizmox.WebGUI.Forms.Splitter();
            this.panel3 = new Gizmox.WebGUI.Forms.Catalog.Controls.WinPanel();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.panel1.ClientSize = new System.Drawing.Size(176, 546);
            this.panel1.CustomStyle = "Window";
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.PanelType = Gizmox.WebGUI.Forms.PanelType.Custom;
            this.panel1.Size = new System.Drawing.Size(176, 546);
            this.panel1.TabIndex = 0;
            this.panel1.Text = "Panel 1";
            this.panel1.CloseClick += new System.EventHandler(this.panel1_CloseClick);
            // 
            // splitter1
            // 
            this.splitter1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.splitter1.ClientSize = new System.Drawing.Size(3, 546);
            this.splitter1.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.splitter1.Location = new System.Drawing.Point(179, 3);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 546);
            this.splitter1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.panel2.ClientSize = new System.Drawing.Size(367, 152);
            this.panel2.CustomStyle = "Window";
            this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(182, 3);
            this.panel2.Name = "panel2";
            this.panel2.PanelType = Gizmox.WebGUI.Forms.PanelType.Custom;
            this.panel2.Size = new System.Drawing.Size(367, 152);
            this.panel2.TabIndex = 2;
            this.panel2.Text = "Panel 2";
            this.panel2.CloseClick += new System.EventHandler(this.panel2_CloseClick);
            // 
            // splitter2
            // 
            this.splitter2.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.splitter2.ClientSize = new System.Drawing.Size(367, 3);
            this.splitter2.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(182, 155);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(367, 3);
            this.splitter2.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.panel3.ClientSize = new System.Drawing.Size(367, 391);
            this.panel3.CustomStyle = "Window";
            this.panel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(182, 158);
            this.panel3.Name = "panel3";
            this.panel3.PanelType = Gizmox.WebGUI.Forms.PanelType.Custom;
            this.panel3.Size = new System.Drawing.Size(367, 391);
            this.panel3.TabIndex = 4;
            this.panel3.Text = "Panel 3";
            this.panel3.CloseClick += new System.EventHandler(this.panel3_CloseClick);
            this.panel3.BackColor = Color.AliceBlue;
            // 
            // CustomWindowPanelControl
            // 
            this.ClientSize = new System.Drawing.Size(552, 448);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.DockPadding.All = 3;
            this.Size = new System.Drawing.Size(552, 448);
            this.ResumeLayout(false);

        }
        #endregion

        private void button_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show(((Button)sender).Text);
        }

        private void panel1_CloseClick(object sender, System.EventArgs e)
        {
            this.Controls.Remove(this.panel1);
            this.panel1 = null;

            if (this.splitter1 != null)
            {
                this.Controls.Remove(this.splitter1);
                this.splitter1 = null;
            }
        }

        private void panel2_CloseClick(object sender, System.EventArgs e)
        {
            this.Controls.Remove(this.panel2);
            if (this.panel2.Dock == DockStyle.Fill && this.panel1 != null)
            {
                this.panel1.Dock = DockStyle.Fill;
            }
            this.panel2 = null;

            if (this.splitter2 != null)
            {
                this.Controls.Remove(this.splitter2);
                this.splitter2 = null;
            }

            if (this.splitter1 != null && this.panel3 == null)
            {
                this.Controls.Remove(this.splitter1);
                this.splitter1 = null;
            }
        }

        private void panel3_CloseClick(object sender, System.EventArgs e)
        {
            this.Controls.Remove(this.panel3);
            if (this.panel2 != null)
            {
                this.panel2.Dock = DockStyle.Fill;
            }
            else if (this.panel1 != null)
            {
                this.panel1.Dock = DockStyle.Fill;
            }
            this.panel3 = null;

            if (this.splitter2 != null)
            {
                this.Controls.Remove(this.splitter2);
                this.splitter2 = null;
            }

            if (this.splitter1 != null && this.panel2 == null)
            {
                this.Controls.Remove(this.splitter1);
                this.splitter1 = null;
            }
        }




    }
}
