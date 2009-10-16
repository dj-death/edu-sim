using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Reflection;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms;

namespace Gizmox.WebGUI.Forms.Catalog.Categories.ActionControls
{
	/// <summary>
	/// Summary description for ButtonsControl.
	/// </summary>

    [Serializable()]
    public class ButtonsControl : UserControl
	{
		private Gizmox.WebGUI.Forms.Button button1;
		private Gizmox.WebGUI.Forms.Button button2;
		private Gizmox.WebGUI.Forms.Button button3;
		private Gizmox.WebGUI.Forms.Button button4;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null;

		public ButtonsControl()
		{
			// This call is required by the WebGUI Form Designer.
			InitializeComponent();

            // This will call the window.open method on the client without 
            // having to create a server callback.
            button1.RegisterClientAction("open", "http://www.google.com");
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.button1 = new Gizmox.WebGUI.Forms.Button();
			this.button2 = new Gizmox.WebGUI.Forms.Button();
			this.button3 = new Gizmox.WebGUI.Forms.Button();
			this.button4 = new Gizmox.WebGUI.Forms.Button();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.button1.ClientSize = new System.Drawing.Size(184, 23);
			this.button1.Location = new System.Drawing.Point(8, 8);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(184, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Normal Button  1";
            this.button1.Image = new IconResourceHandle("Folder.gif");
            this.button1.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.button1.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// button2
			// 
			this.button2.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.button2.ClientSize = new System.Drawing.Size(184, 56);
			this.button2.Location = new System.Drawing.Point(8, 40);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(184, 56);
			this.button2.TabIndex = 1;
			this.button2.Text = "Normal Button 2";
			this.button2.Click += new System.EventHandler(this.button_Click);
            this.button2.Image = new IconResourceHandle("Folders.gif");
            this.button2.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.button2.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// button3
			// 
			this.button3.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.button3.ClientSize = new System.Drawing.Size(184, 23);
			this.button3.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.button3.Location = new System.Drawing.Point(208, 8);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(184, 23);
			this.button3.TabIndex = 2;
			this.button3.Text = "Flat Button 1";
			this.button3.Click += new System.EventHandler(this.button_Click);
            this.button3.Image = new IconResourceHandle("Add.gif");
            this.button3.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.button3.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// button4
			// 
			this.button4.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.button4.ClientSize = new System.Drawing.Size(184, 56);
			this.button4.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.button4.Location = new System.Drawing.Point(208, 40);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(184, 56);
			this.button4.TabIndex = 3;
			this.button4.Text = "Flat Botton 2";
			this.button4.Click += new System.EventHandler(this.button_Click);
            this.button4.Image = new IconResourceHandle("Delete.gif");
            this.button4.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.button4.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// ButtonsControl
			// 
			this.ClientSize = new System.Drawing.Size(552, 448);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Size = new System.Drawing.Size(552, 448);
			this.ResumeLayout(false);

		}
		#endregion

		private void button_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show(((Button)sender).Text);
		}




	}
}
