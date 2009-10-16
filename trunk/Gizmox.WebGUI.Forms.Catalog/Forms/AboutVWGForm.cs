/*
' Visual WebGui Enterprise Manager - http://www.visualwebgui.com
' Copyright (c) 2005
' by Gizmox Inc. ( http://www.gizmox.com )
'
' This program is free software; you can redistribute it and/or modify it 
' under the terms of the GNU General Public License as published by the Free 
' Software Foundation; either version 2 of the License, or (at your option) 
' any later version.
'
' THIS PROGRAM IS DISTRIBUTED IN THE HOPE THAT IT WILL BE USEFUL, 
' BUT WITHOUT ANY WARRANTY; WITHOUT EVEN THE IMPLIED WARRANTY OF MERCHANTABILITY 
' OR FITNESS FOR A PARTICULAR PURPOSE. SEE THE GNU GENERAL PUBLIC LICENSE FOR MORE DETAILS.
' YOU SHOULD HAVE RECEIVED A COPY OF THE GNU GENERAL PUBLIC LICENSE ALONG WITH THIS PROGRAM; if not, 
' write to the Free Software Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
'
' contact: opensource@visualwebgui.com
*/

#region Using

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Resources;

#endregion Using

namespace Gizmox.WebGUI.Forms.Catalog.Forms
{
	#region AboutVWGForm Class
	
	/// <summary>
	/// Summary description for AboutVWGForm.
	/// </summary>

    [Serializable()]
    public class AboutVWGForm : Form
	{
		#region Class Members
		
		private Gizmox.WebGUI.Forms.PictureBox mobjPictureLogo;
		
		private Gizmox.WebGUI.Forms.LinkLabel linkLabel2;
		
		private Gizmox.WebGUI.Forms.TextBox textBox2;
		
		private Gizmox.WebGUI.Forms.Button button1;
		
		private Gizmox.WebGUI.Forms.Label label3;
		
		private Gizmox.WebGUI.Forms.LinkLabel linkLabel3;
		
		private Gizmox.WebGUI.Forms.Label mobjLabelVersion;
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null;
		
		
		#endregion Class Members
		
		#region C'Tor\D'Tor
		
		/// <summary>
		///
		/// </summary>
		public AboutVWGForm()
		{
			// This call is required by the WebGUI Form Designer.
			InitializeComponent();

            this.mobjPictureLogo.Image = new ImageResourceHandle("AboutVWGLogo.jpg");
			this.mobjLabelVersion.Text = string.Format(mobjLabelVersion.Text,WGConst.Version.Replace("WebGUI-V",""));
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
		}
		
		
		#endregion C'Tor\D'Tor
		
		#region Form Designer generated code
		
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
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.mobjPictureLogo = new Gizmox.WebGUI.Forms.PictureBox();
			this.linkLabel2 = new Gizmox.WebGUI.Forms.LinkLabel();
			this.textBox2 = new Gizmox.WebGUI.Forms.TextBox();
			this.mobjLabelVersion = new Gizmox.WebGUI.Forms.Label();
			this.button1 = new Gizmox.WebGUI.Forms.Button();
			this.label3 = new Gizmox.WebGUI.Forms.Label();
			this.linkLabel3 = new Gizmox.WebGUI.Forms.LinkLabel();
			this.SuspendLayout();
			//
			// mobjPictureLogo
			//
			this.mobjPictureLogo.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
			this.mobjPictureLogo.BackColor = System.Drawing.Color.White;
			this.mobjPictureLogo.ClientSize = new System.Drawing.Size(382, 100);
			this.mobjPictureLogo.Image = null;
			this.mobjPictureLogo.Location = new System.Drawing.Point(0, 0);
			this.mobjPictureLogo.Name = "mobjPictureLogo";
			this.mobjPictureLogo.Size = new System.Drawing.Size(382, 100);
			this.mobjPictureLogo.SizeMode = Gizmox.WebGUI.Forms.PictureBoxSizeMode.StretchImage;
			//
			// linkLabel2
			//
			this.linkLabel2.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
			this.linkLabel2.ClientSize = new System.Drawing.Size(272, 23);
			this.linkLabel2.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.linkLabel2.Location = new System.Drawing.Point(8, 296);
			this.linkLabel2.Name = "linkLabel2";
			this.linkLabel2.Size = new System.Drawing.Size(272, 23);
			this.linkLabel2.Text = "Copyright (c) 2005 Gizmox";
			this.linkLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.linkLabel2.Url = null;
			//
			// textBox2
			//
			this.textBox2.AcceptsReturn = true;
			this.textBox2.AcceptsTab = true;
			this.textBox2.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
			this.textBox2.ClientSize = new System.Drawing.Size(360, 120);
			this.textBox2.Lines = new string[] {
			@"Visual WebGui is a new aproch for developing AJAX applications that lets you develop in WinForms like server side API (including designtime support) to create a full AJAX enabled highly complex applications like this application (without using HTML/JavaScript or any other web language)."};
			this.textBox2.Location = new System.Drawing.Point(8, 168);
			this.textBox2.MaxLength = 0;
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Both;
			this.textBox2.Size = new System.Drawing.Size(360, 120);
			this.textBox2.Text = @"Visual WebGui is a new aproch for developing AJAX applications that lets you develop in WinForms like server side API (including designtime support) to create a full AJAX enabled highly complex applications like this application (without using HTML/JavaScript or any other web language).";
			this.textBox2.Validator = null;
			this.textBox2.WordWrap = false;
			//
			// mobjLabelVersion
			//
			this.mobjLabelVersion.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
			this.mobjLabelVersion.ClientSize = new System.Drawing.Size(360, 16);
			this.mobjLabelVersion.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.mobjLabelVersion.Location = new System.Drawing.Point(8, 112);
			this.mobjLabelVersion.Name = "mobjLabelVersion";
			this.mobjLabelVersion.Size = new System.Drawing.Size(360, 16);
			this.mobjLabelVersion.Text = "Version: {0}";
			this.mobjLabelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			//
			// button1
			//
			this.button1.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
			this.button1.ClientSize = new System.Drawing.Size(75, 23);
			this.button1.Location = new System.Drawing.Point(296, 296);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.Text = "OK";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			//
			// label3
			//
			this.label3.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
			this.label3.ClientSize = new System.Drawing.Size(40, 16);
			this.label3.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.label3.Location = new System.Drawing.Point(8, 128);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(40, 16);
			this.label3.Text = "Site:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			//
			// linkLabel3
			//
			this.linkLabel3.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
			this.linkLabel3.ClientSize = new System.Drawing.Size(320, 16);
			this.linkLabel3.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.linkLabel3.Location = new System.Drawing.Point(48, 128);
			this.linkLabel3.Name = "linkLabel3";
			this.linkLabel3.Size = new System.Drawing.Size(320, 16);
			this.linkLabel3.Text = "www.visualwebgui.com";
			this.linkLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.linkLabel3.Url = "http://www.visualwebgui.com";
			//
			// AboutVWGForm
			//
			this.BackColor = System.Drawing.Color.White;
			this.BorderColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(376, 326);
			this.Controls.Add(this.linkLabel3);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.linkLabel2);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.mobjLabelVersion);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.mobjPictureLogo);
			this.DockPadding.All = 0;
			this.DockPadding.Bottom = 0;
			this.DockPadding.Left = 0;
			this.DockPadding.Right = 0;
			this.DockPadding.Top = 0;
			this.Size = new System.Drawing.Size(376, 326);
			this.Text = "About Visual WebGui";
			this.ResumeLayout(false);
			
		}
		
		
		#endregion Form Designer generated code
		
		#region Methods
		
		/// <summary>
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button1_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		
		
		#endregion Methods
		
	}
	
	#endregion AboutVWGForm Class
	
}
