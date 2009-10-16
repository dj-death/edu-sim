using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using Gizmox.WebGUI.Forms;

namespace Gizmox.WebGUI.Forms.Catalog.Categories.DialogForms.Forms
{
	/// <summary>
	/// Summary description for SearchForm.
	/// </summary>

    [Serializable()]
    public class SearchForm : Gizmox.WebGUI.Forms.Form
	{
		private Gizmox.WebGUI.Forms.Label label1;
		private Gizmox.WebGUI.Forms.ComboBox comboBox1;
		private Gizmox.WebGUI.Forms.CheckBox checkBox1;
		private Gizmox.WebGUI.Forms.CheckBox checkBox2;
		private Gizmox.WebGUI.Forms.CheckBox checkBox3;
		private Gizmox.WebGUI.Forms.CheckBox checkBox4;
		private Gizmox.WebGUI.Forms.GroupBox groupBox1;
		private Gizmox.WebGUI.Forms.RadioButton radioButton1;
		private Gizmox.WebGUI.Forms.RadioButton radioButton2;
		private Gizmox.WebGUI.Forms.RadioButton radioButton3;
		private Gizmox.WebGUI.Forms.Button button1;
		private Gizmox.WebGUI.Forms.Button button2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null;

		public SearchForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

            this.button1.Click += new EventHandler(button1_Click);
            this.Closing += new CancelEventHandler(SearchForm_Closing);
		}

        private bool mblnTerminate = false;

        void SearchForm_Closing(object sender, CancelEventArgs e)
        {
            mblnTerminate = true;
        }

        void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                if (!mblnTerminate)
                {
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }


        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new Gizmox.WebGUI.Forms.Label();
			this.comboBox1 = new Gizmox.WebGUI.Forms.ComboBox();
			this.checkBox1 = new Gizmox.WebGUI.Forms.CheckBox();
			this.checkBox2 = new Gizmox.WebGUI.Forms.CheckBox();
			this.checkBox3 = new Gizmox.WebGUI.Forms.CheckBox();
			this.checkBox4 = new Gizmox.WebGUI.Forms.CheckBox();
			this.groupBox1 = new Gizmox.WebGUI.Forms.GroupBox();
			this.radioButton1 = new Gizmox.WebGUI.Forms.RadioButton();
			this.radioButton2 = new Gizmox.WebGUI.Forms.RadioButton();
			this.radioButton3 = new Gizmox.WebGUI.Forms.RadioButton();
			this.button1 = new Gizmox.WebGUI.Forms.Button();
			this.button2 = new Gizmox.WebGUI.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Find what:";
			// 
			// comboBox1
			// 
			this.comboBox1.Location = new System.Drawing.Point(96, 8);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(304, 21);
			this.comboBox1.TabIndex = 1;
			this.comboBox1.Text = "comboBox1";
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(8, 35);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(104, 16);
			this.checkBox1.TabIndex = 2;
			this.checkBox1.Text = "Match case";
			// 
			// checkBox2
			// 
			this.checkBox2.Location = new System.Drawing.Point(8, 54);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(125, 16);
			this.checkBox2.TabIndex = 3;
			this.checkBox2.Text = "Match whole word";
			// 
			// checkBox3
			// 
			this.checkBox3.Location = new System.Drawing.Point(8, 73);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(136, 16);
			this.checkBox3.TabIndex = 4;
			this.checkBox3.Text = "Search hidden text";
			// 
			// checkBox4
			// 
			this.checkBox4.Location = new System.Drawing.Point(8, 92);
			this.checkBox4.Name = "checkBox4";
			this.checkBox4.Size = new System.Drawing.Size(136, 16);
			this.checkBox4.TabIndex = 5;
			this.checkBox4.Text = "Search up";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radioButton3);
			this.groupBox1.Controls.Add(this.radioButton2);
			this.groupBox1.Controls.Add(this.radioButton1);
			this.groupBox1.Location = new System.Drawing.Point(192, 35);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(208, 93);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Search";
			// 
			// radioButton1
			// 
			this.radioButton1.Location = new System.Drawing.Point(8, 16);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(120, 16);
			this.radioButton1.TabIndex = 0;
			this.radioButton1.Text = "Current document";
			// 
			// radioButton2
			// 
			this.radioButton2.Location = new System.Drawing.Point(8, 36);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(120, 16);
			this.radioButton2.TabIndex = 1;
			this.radioButton2.Text = "All open documents";
			// 
			// radioButton3
			// 
			this.radioButton3.Location = new System.Drawing.Point(8, 56);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(120, 16);
			this.radioButton3.TabIndex = 2;
			this.radioButton3.Text = "Current project";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(409, 9);
			this.button1.Name = "button1";
			this.button1.TabIndex = 7;
			this.button1.Text = "Find Next";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(410, 37);
			this.button2.Name = "button2";
			this.button2.TabIndex = 8;
			this.button2.Text = "Close";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// SearchForm
			// 			
			this.ClientSize = new System.Drawing.Size(496, 134);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.checkBox4);
			this.Controls.Add(this.checkBox3);
			this.Controls.Add(this.checkBox2);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.label1);
			this.Name = "SearchForm";
			this.Text = "SearchForm";
			this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
