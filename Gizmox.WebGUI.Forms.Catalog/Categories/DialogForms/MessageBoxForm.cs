using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using Gizmox.WebGUI.Forms;

namespace Gizmox.WebGUI.Forms.Catalog.Categories.DialogForms
{
	/// <summary>
	/// Summary description for MessageBoxForm.
	/// </summary>

    [Serializable()]
    public class MessageBoxForm : UserControl
	{
		private Gizmox.WebGUI.Forms.TextBox mobjTextTitle;
		private Gizmox.WebGUI.Forms.Label label1;
		private Gizmox.WebGUI.Forms.Label label3;
		private Gizmox.WebGUI.Forms.TextBox mobjTextMessage;
		private Gizmox.WebGUI.Forms.Label label4;
		private Gizmox.WebGUI.Forms.ComboBox mobjComboButtons;
		private Gizmox.WebGUI.Forms.Label label5;
		private Gizmox.WebGUI.Forms.ComboBox mobjComboIcon;
		private Gizmox.WebGUI.Forms.Button mobjButtonShow;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null;

		public MessageBoxForm()
		{
			// This call is required by the WebGUI Form Designer.
			InitializeComponent();

			this.mobjComboButtons.Items.AddRange(Enum.GetValues(typeof(MessageBoxButtons)));
			this.mobjComboIcon.Items.AddRange(Enum.GetValues(typeof(MessageBoxIcon)));

			this.mobjComboButtons.SelectedIndex = 0;
			this.mobjComboIcon.SelectedIndex = 0;
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
			this.mobjTextTitle = new Gizmox.WebGUI.Forms.TextBox();
			this.label1 = new Gizmox.WebGUI.Forms.Label();
			this.label3 = new Gizmox.WebGUI.Forms.Label();
			this.mobjTextMessage = new Gizmox.WebGUI.Forms.TextBox();
			this.label4 = new Gizmox.WebGUI.Forms.Label();
			this.mobjComboButtons = new Gizmox.WebGUI.Forms.ComboBox();
			this.label5 = new Gizmox.WebGUI.Forms.Label();
			this.mobjComboIcon = new Gizmox.WebGUI.Forms.ComboBox();
			this.mobjButtonShow = new Gizmox.WebGUI.Forms.Button();
			this.SuspendLayout();
			// 
			// mobjTextTitle
			// 
			this.mobjTextTitle.AcceptsReturn = true;
			this.mobjTextTitle.AcceptsTab = true;
			this.mobjTextTitle.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
			this.mobjTextTitle.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
			this.mobjTextTitle.ClientSize = new System.Drawing.Size(360, 20);
			this.mobjTextTitle.Lines = new string[0];
			this.mobjTextTitle.Location = new System.Drawing.Point(24, 48);
			this.mobjTextTitle.MaxLength = 0;
			this.mobjTextTitle.Multiline = false;
			this.mobjTextTitle.Name = "mobjTextTitle";
			this.mobjTextTitle.ReadOnly = false;
			this.mobjTextTitle.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Both;
			this.mobjTextTitle.Size = new System.Drawing.Size(360, 20);
			this.mobjTextTitle.TabIndex = 1;
			this.mobjTextTitle.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Left;
			this.mobjTextTitle.Validator = null;
			this.mobjTextTitle.WordWrap = false;
			// 
			// label1
			// 
			this.label1.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
			this.label1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
			this.label1.ClientSize = new System.Drawing.Size(360, 23);
			this.label1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.label1.Location = new System.Drawing.Point(24, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(360, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Title";
			this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// label3
			// 
			this.label3.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
			this.label3.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
			this.label3.ClientSize = new System.Drawing.Size(360, 23);
			this.label3.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.label3.Location = new System.Drawing.Point(24, 88);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(360, 23);
			this.label3.TabIndex = 2;
			this.label3.Text = "Message";
			this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// mobjTextMessage
			// 
			this.mobjTextMessage.AcceptsReturn = true;
			this.mobjTextMessage.AcceptsTab = true;
			this.mobjTextMessage.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
			this.mobjTextMessage.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
			this.mobjTextMessage.ClientSize = new System.Drawing.Size(360, 120);
			this.mobjTextMessage.Lines = new string[0];
			this.mobjTextMessage.Location = new System.Drawing.Point(24, 112);
			this.mobjTextMessage.MaxLength = 0;
			this.mobjTextMessage.Multiline = true;
			this.mobjTextMessage.Name = "mobjTextMessage";
			this.mobjTextMessage.ReadOnly = false;
			this.mobjTextMessage.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Both;
			this.mobjTextMessage.Size = new System.Drawing.Size(360, 120);
			this.mobjTextMessage.TabIndex = 3;
			this.mobjTextMessage.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Left;
			this.mobjTextMessage.Validator = null;
			this.mobjTextMessage.WordWrap = false;
			// 
			// label4
			// 
			this.label4.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
			this.label4.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
			this.label4.ClientSize = new System.Drawing.Size(100, 23);
			this.label4.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.label4.Location = new System.Drawing.Point(24, 240);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 5;
			this.label4.Text = "Buttons";
			this.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// mobjComboButtons
			// 
			this.mobjComboButtons.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
			this.mobjComboButtons.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
			this.mobjComboButtons.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
			this.mobjComboButtons.ClientSize = new System.Drawing.Size(360, 21);
			this.mobjComboButtons.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
			this.mobjComboButtons.Location = new System.Drawing.Point(24, 264);
			this.mobjComboButtons.Name = "mobjComboButtons";
			this.mobjComboButtons.Size = new System.Drawing.Size(360, 21);
			this.mobjComboButtons.TabIndex = 6;
			// 
			// label5
			// 
			this.label5.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
			this.label5.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
			this.label5.ClientSize = new System.Drawing.Size(100, 23);
			this.label5.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.label5.Location = new System.Drawing.Point(24, 288);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 23);
			this.label5.TabIndex = 7;
			this.label5.Text = "Icon";
			this.label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// mobjComboIcon
			// 
			this.mobjComboIcon.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
			this.mobjComboIcon.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
			this.mobjComboIcon.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
			this.mobjComboIcon.ClientSize = new System.Drawing.Size(360, 21);
			this.mobjComboIcon.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
			this.mobjComboIcon.Location = new System.Drawing.Point(24, 312);
			this.mobjComboIcon.Name = "mobjComboIcon";
			this.mobjComboIcon.Size = new System.Drawing.Size(360, 21);
			this.mobjComboIcon.TabIndex = 8;
			// 
			// mobjButtonShow
			// 
			this.mobjButtonShow.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
			this.mobjButtonShow.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
			this.mobjButtonShow.ClientSize = new System.Drawing.Size(75, 23);
			this.mobjButtonShow.Location = new System.Drawing.Point(312, 352);
			this.mobjButtonShow.Name = "mobjButtonShow";
			this.mobjButtonShow.Size = new System.Drawing.Size(75, 23);
			this.mobjButtonShow.TabIndex = 9;
			this.mobjButtonShow.Text = "Show";
			this.mobjButtonShow.Click += new System.EventHandler(this.mobjButtonShow_Click);
			// 
			// MessageBoxForm
			// 
			this.ClientSize = new System.Drawing.Size(608, 512);
			this.Controls.Add(this.mobjButtonShow);
			this.Controls.Add(this.mobjComboIcon);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.mobjComboButtons);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.mobjTextMessage);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.mobjTextTitle);
			this.Controls.Add(this.label1);
			this.DockPadding.All = 0;
			this.DockPadding.Bottom = 0;
			this.DockPadding.Left = 0;
			this.DockPadding.Right = 0;
			this.DockPadding.Top = 0;
			this.Size = new System.Drawing.Size(608, 512);
			this.ResumeLayout(false);

		}
		#endregion

		private void mobjButtonShow_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show(this.mobjTextMessage.Text, this.mobjTextTitle.Text,(MessageBoxButtons)this.mobjComboButtons.SelectedItem,(MessageBoxIcon)this.mobjComboIcon.SelectedItem);
		}
	}
}
