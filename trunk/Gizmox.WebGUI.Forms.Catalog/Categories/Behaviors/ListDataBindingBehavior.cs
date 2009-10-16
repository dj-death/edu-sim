using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using Gizmox.WebGUI.Forms;

namespace Gizmox.WebGUI.Forms.Catalog.Categories.Behaviors
{
	/// <summary>
	/// Summary description for ListDataBindingBehavior.
	/// </summary>

    [Serializable()]
    public class ListDataBindingBehavior : UserControl
	{
		private Gizmox.WebGUI.Forms.ListBox listBox1;
		private Gizmox.WebGUI.Forms.ComboBox comboBox1;
		private Gizmox.WebGUI.Forms.Label label1;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null;

		public ListDataBindingBehavior()
		{
			// This call is required by the WebGUI Form Designer.
			InitializeComponent();

			this.comboBox1.DisplayMember = "Name";
			this.comboBox1.ValueMember = "Name";
			this.comboBox1.DataSource = RandomData.GetSystemColors();
			this.comboBox1.SelectedValueChanged+=new EventHandler(comboBox1_SelectedValueChanged);
			
			
			this.listBox1.DisplayMember = "Name";
			this.listBox1.ValueMember = "Name";
			this.listBox1.DataSource = RandomData.GetSystemColors();
			this.listBox1.SelectedValueChanged+=new EventHandler(listBox1_SelectedValueChanged);
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
			this.listBox1 = new Gizmox.WebGUI.Forms.ListBox();
			this.comboBox1 = new Gizmox.WebGUI.Forms.ComboBox();
			this.label1 = new Gizmox.WebGUI.Forms.Label();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.listBox1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
			this.listBox1.ClientSize = new System.Drawing.Size(208, 303);
			this.listBox1.Location = new System.Drawing.Point(40, 40);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(208, 303);
			this.listBox1.TabIndex = 0;
			// 
			// comboBox1
			// 
			this.comboBox1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.comboBox1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
			this.comboBox1.ClientSize = new System.Drawing.Size(200, 21);
			this.comboBox1.Location = new System.Drawing.Point(288, 40);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(200, 21);
			this.comboBox1.TabIndex = 1;
			this.comboBox1.Text = "comboBox1";
			// 
			// label1
			// 
			this.label1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.label1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
			this.label1.ClientSize = new System.Drawing.Size(504, 224);
			this.label1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.label1.Location = new System.Drawing.Point(48, 368);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(504, 224);
			this.label1.TabIndex = 2;
			this.label1.Text = "No data.";
			// 
			// ListDataBindingBehavior
			// 
			this.ClientSize = new System.Drawing.Size(576, 648);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.listBox1);
			this.Size = new System.Drawing.Size(576, 648);
			this.ResumeLayout(false);

		}
		#endregion

		private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
		{
			if(this.comboBox1.SelectedValue!=null)
			{
				this.label1.Text = "comboBox1.SelectedValue="+comboBox1.SelectedValue.ToString();
			}
			else
			{
				this.label1.Text = "comboBox1.SelectedValue is null.";
			}
		}

		private void listBox1_SelectedValueChanged(object sender, EventArgs e)
		{
			if(this.listBox1.SelectedValue!=null)
			{
				this.label1.Text = "listBox1.SelectedValue="+listBox1.SelectedValue.ToString();
			}
			else
			{
				this.label1.Text = "listBox1.SelectedValue is null.";
			}
		}
	}
}
