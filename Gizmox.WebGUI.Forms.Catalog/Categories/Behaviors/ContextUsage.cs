using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using Gizmox.WebGUI.Forms;

namespace Gizmox.WebGUI.Forms.Catalog.Categories.Behaviors
{
	/// <summary>
	/// Summary description for ContextUsage.
	/// </summary>

    [Serializable()]
    public class ContextUsage : UserControl
	{


		private Gizmox.WebGUI.Forms.GroupBox groupBox1;
		private Gizmox.WebGUI.Forms.Label label1;
		private Gizmox.WebGUI.Forms.Label label2;
		private Gizmox.WebGUI.Forms.TextBox textBox1;
		private Gizmox.WebGUI.Forms.TextBox textBox2;
		private Gizmox.WebGUI.Forms.Button buttonSave;
		private Gizmox.WebGUI.Forms.Button buttonLoad;
		private Gizmox.WebGUI.Forms.GroupBox groupBox3;
		private Gizmox.WebGUI.Forms.GroupBox groupBox4;
		private Gizmox.WebGUI.Forms.Label label5;
		private Gizmox.WebGUI.Forms.Label label6;
		private Gizmox.WebGUI.Forms.Label label7;
		private Gizmox.WebGUI.Forms.Label label8;
		private Gizmox.WebGUI.Forms.TextBox textBox5;
		private Gizmox.WebGUI.Forms.TextBox textBox6;
		private Gizmox.WebGUI.Forms.TextBox textBox7;
		private Gizmox.WebGUI.Forms.TextBox textBox8;
		private Gizmox.WebGUI.Forms.Button button3;
		private Gizmox.WebGUI.Forms.Button button4;
		private Gizmox.WebGUI.Forms.Button button5;
		private Gizmox.WebGUI.Forms.Button button6;

		private static string mobjLock = "lock";
		private Gizmox.WebGUI.Forms.GroupBox groupBox7;
		private Gizmox.WebGUI.Forms.Label label13;
		private Gizmox.WebGUI.Forms.Label label14;
		private Gizmox.WebGUI.Forms.Button button11;
		private Gizmox.WebGUI.Forms.Button button12;
		private Gizmox.WebGUI.Forms.TextBox textBox13;
		private Gizmox.WebGUI.Forms.TextBox textBox14;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null;

		public ContextUsage()
		{
			// This call is required by the WebGUI Form Designer.
			InitializeComponent();

			LoadContextParams();
			LoadSessionParams();
			LoadApplicationParams();
			LoadCookiesParams();
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
			this.groupBox1 = new Gizmox.WebGUI.Forms.GroupBox();
			this.buttonLoad = new Gizmox.WebGUI.Forms.Button();
			this.buttonSave = new Gizmox.WebGUI.Forms.Button();
			this.textBox2 = new Gizmox.WebGUI.Forms.TextBox();
			this.textBox1 = new Gizmox.WebGUI.Forms.TextBox();
			this.label2 = new Gizmox.WebGUI.Forms.Label();
			this.label1 = new Gizmox.WebGUI.Forms.Label();
			this.groupBox3 = new Gizmox.WebGUI.Forms.GroupBox();
			this.button4 = new Gizmox.WebGUI.Forms.Button();
			this.button3 = new Gizmox.WebGUI.Forms.Button();
			this.textBox6 = new Gizmox.WebGUI.Forms.TextBox();
			this.textBox5 = new Gizmox.WebGUI.Forms.TextBox();
			this.label6 = new Gizmox.WebGUI.Forms.Label();
			this.label5 = new Gizmox.WebGUI.Forms.Label();
			this.groupBox4 = new Gizmox.WebGUI.Forms.GroupBox();
			this.button6 = new Gizmox.WebGUI.Forms.Button();
			this.button5 = new Gizmox.WebGUI.Forms.Button();
			this.textBox8 = new Gizmox.WebGUI.Forms.TextBox();
			this.textBox7 = new Gizmox.WebGUI.Forms.TextBox();
			this.label8 = new Gizmox.WebGUI.Forms.Label();
			this.label7 = new Gizmox.WebGUI.Forms.Label();
			this.groupBox7 = new Gizmox.WebGUI.Forms.GroupBox();
			this.label13 = new Gizmox.WebGUI.Forms.Label();
			this.label14 = new Gizmox.WebGUI.Forms.Label();
			this.button11 = new Gizmox.WebGUI.Forms.Button();
			this.button12 = new Gizmox.WebGUI.Forms.Button();
			this.textBox13 = new Gizmox.WebGUI.Forms.TextBox();
			this.textBox14 = new Gizmox.WebGUI.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.groupBox1.ClientSize = new System.Drawing.Size(288, 144);
			this.groupBox1.Controls.Add(this.buttonLoad);
			this.groupBox1.Controls.Add(this.buttonSave);
			this.groupBox1.Controls.Add(this.textBox2);
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(288, 144);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.Text = "Context Scope Parameters";
			// 
			// buttonLoad
			// 
			this.buttonLoad.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.buttonLoad.ClientSize = new System.Drawing.Size(75, 23);
			this.buttonLoad.Location = new System.Drawing.Point(104, 104);
			this.buttonLoad.Name = "buttonLoad";
			this.buttonLoad.Size = new System.Drawing.Size(75, 23);
			this.buttonLoad.TabIndex = 5;
			this.buttonLoad.Text = "Load";
			this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
			// 
			// buttonSave
			// 
			this.buttonSave.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.buttonSave.ClientSize = new System.Drawing.Size(75, 23);
			this.buttonSave.Location = new System.Drawing.Point(192, 104);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 4;
			this.buttonSave.Text = "Save";
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// textBox2
			// 
			this.textBox2.AcceptsReturn = true;
			this.textBox2.AcceptsTab = true;
			this.textBox2.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.textBox2.ClientSize = new System.Drawing.Size(176, 20);
			this.textBox2.Lines = new string[0];
			this.textBox2.Location = new System.Drawing.Point(88, 64);
			this.textBox2.MaxLength = 0;
			this.textBox2.Multiline = false;
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = false;
			this.textBox2.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Both;
			this.textBox2.Size = new System.Drawing.Size(176, 20);
			this.textBox2.TabIndex = 3;
			this.textBox2.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Left;
			this.textBox2.Validator = null;
			this.textBox2.WordWrap = false;
			// 
			// textBox1
			// 
			this.textBox1.AcceptsReturn = true;
			this.textBox1.AcceptsTab = true;
			this.textBox1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.textBox1.ClientSize = new System.Drawing.Size(176, 20);
			this.textBox1.Lines = new string[0];
			this.textBox1.Location = new System.Drawing.Point(88, 32);
			this.textBox1.MaxLength = 0;
			this.textBox1.Multiline = false;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = false;
			this.textBox1.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Both;
			this.textBox1.Size = new System.Drawing.Size(176, 20);
			this.textBox1.TabIndex = 2;
			this.textBox1.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Left;
			this.textBox1.Validator = null;
			this.textBox1.WordWrap = false;
			// 
			// label2
			// 
			this.label2.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.label2.ClientSize = new System.Drawing.Size(72, 16);
			this.label2.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.label2.Location = new System.Drawing.Point(16, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "ParameterB:";
			// 
			// label1
			// 
			this.label1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.label1.ClientSize = new System.Drawing.Size(72, 16);
			this.label1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.label1.Location = new System.Drawing.Point(16, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "ParameterA:";
			// 
			// groupBox3
			// 
			this.groupBox3.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.groupBox3.ClientSize = new System.Drawing.Size(288, 136);
			this.groupBox3.Controls.Add(this.button4);
			this.groupBox3.Controls.Add(this.button3);
			this.groupBox3.Controls.Add(this.textBox6);
			this.groupBox3.Controls.Add(this.textBox5);
			this.groupBox3.Controls.Add(this.label6);
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.groupBox3.Location = new System.Drawing.Point(8, 168);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(288, 136);
			this.groupBox3.TabIndex = 1;
			this.groupBox3.Text = "Session Scope Parameters";
			// 
			// button4
			// 
			this.button4.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.button4.ClientSize = new System.Drawing.Size(75, 23);
			this.button4.Location = new System.Drawing.Point(104, 104);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(75, 23);
			this.button4.TabIndex = 5;
			this.button4.Text = "Load";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button3
			// 
			this.button3.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.button3.ClientSize = new System.Drawing.Size(75, 23);
			this.button3.Location = new System.Drawing.Point(192, 104);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 4;
			this.button3.Text = "Save";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// textBox6
			// 
			this.textBox6.AcceptsReturn = true;
			this.textBox6.AcceptsTab = true;
			this.textBox6.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.textBox6.ClientSize = new System.Drawing.Size(176, 20);
			this.textBox6.Lines = new string[0];
			this.textBox6.Location = new System.Drawing.Point(88, 64);
			this.textBox6.MaxLength = 0;
			this.textBox6.Multiline = false;
			this.textBox6.Name = "textBox6";
			this.textBox6.ReadOnly = false;
			this.textBox6.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Both;
			this.textBox6.Size = new System.Drawing.Size(176, 20);
			this.textBox6.TabIndex = 3;
			this.textBox6.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Left;
			this.textBox6.Validator = null;
			this.textBox6.WordWrap = false;
			// 
			// textBox5
			// 
			this.textBox5.AcceptsReturn = true;
			this.textBox5.AcceptsTab = true;
			this.textBox5.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.textBox5.ClientSize = new System.Drawing.Size(176, 20);
			this.textBox5.Lines = new string[0];
			this.textBox5.Location = new System.Drawing.Point(88, 32);
			this.textBox5.MaxLength = 0;
			this.textBox5.Multiline = false;
			this.textBox5.Name = "textBox5";
			this.textBox5.ReadOnly = false;
			this.textBox5.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Both;
			this.textBox5.Size = new System.Drawing.Size(176, 20);
			this.textBox5.TabIndex = 2;
			this.textBox5.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Left;
			this.textBox5.Validator = null;
			this.textBox5.WordWrap = false;
			// 
			// label6
			// 
			this.label6.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.label6.ClientSize = new System.Drawing.Size(72, 16);
			this.label6.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.label6.Location = new System.Drawing.Point(16, 67);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(72, 16);
			this.label6.TabIndex = 1;
			this.label6.Text = "ParameterB:";
			// 
			// label5
			// 
			this.label5.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.label5.ClientSize = new System.Drawing.Size(72, 16);
			this.label5.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.label5.Location = new System.Drawing.Point(16, 35);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(72, 16);
			this.label5.TabIndex = 0;
			this.label5.Text = "ParameterA:";
			// 
			// groupBox4
			// 
			this.groupBox4.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.groupBox4.ClientSize = new System.Drawing.Size(288, 136);
			this.groupBox4.Controls.Add(this.button6);
			this.groupBox4.Controls.Add(this.button5);
			this.groupBox4.Controls.Add(this.textBox8);
			this.groupBox4.Controls.Add(this.textBox7);
			this.groupBox4.Controls.Add(this.label8);
			this.groupBox4.Controls.Add(this.label7);
			this.groupBox4.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.groupBox4.Location = new System.Drawing.Point(8, 320);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(288, 136);
			this.groupBox4.TabIndex = 2;
			this.groupBox4.Text = "Application Scope Parameters";
			// 
			// button6
			// 
			this.button6.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.button6.ClientSize = new System.Drawing.Size(75, 23);
			this.button6.Location = new System.Drawing.Point(104, 104);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(75, 23);
			this.button6.TabIndex = 5;
			this.button6.Text = "Load";
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// button5
			// 
			this.button5.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.button5.ClientSize = new System.Drawing.Size(75, 23);
			this.button5.Location = new System.Drawing.Point(192, 104);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(75, 23);
			this.button5.TabIndex = 4;
			this.button5.Text = "Save";
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// textBox8
			// 
			this.textBox8.AcceptsReturn = true;
			this.textBox8.AcceptsTab = true;
			this.textBox8.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.textBox8.ClientSize = new System.Drawing.Size(176, 20);
			this.textBox8.Lines = new string[0];
			this.textBox8.Location = new System.Drawing.Point(88, 64);
			this.textBox8.MaxLength = 0;
			this.textBox8.Multiline = false;
			this.textBox8.Name = "textBox8";
			this.textBox8.ReadOnly = false;
			this.textBox8.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Both;
			this.textBox8.Size = new System.Drawing.Size(176, 20);
			this.textBox8.TabIndex = 3;
			this.textBox8.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Left;
			this.textBox8.Validator = null;
			this.textBox8.WordWrap = false;
			// 
			// textBox7
			// 
			this.textBox7.AcceptsReturn = true;
			this.textBox7.AcceptsTab = true;
			this.textBox7.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.textBox7.ClientSize = new System.Drawing.Size(176, 20);
			this.textBox7.Lines = new string[0];
			this.textBox7.Location = new System.Drawing.Point(88, 32);
			this.textBox7.MaxLength = 0;
			this.textBox7.Multiline = false;
			this.textBox7.Name = "textBox7";
			this.textBox7.ReadOnly = false;
			this.textBox7.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Both;
			this.textBox7.Size = new System.Drawing.Size(176, 20);
			this.textBox7.TabIndex = 2;
			this.textBox7.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Left;
			this.textBox7.Validator = null;
			this.textBox7.WordWrap = false;
			// 
			// label8
			// 
			this.label8.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.label8.ClientSize = new System.Drawing.Size(72, 16);
			this.label8.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.label8.Location = new System.Drawing.Point(16, 68);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(72, 16);
			this.label8.TabIndex = 1;
			this.label8.Text = "ParameterB:";
			// 
			// label7
			// 
			this.label7.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.label7.ClientSize = new System.Drawing.Size(72, 16);
			this.label7.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.label7.Location = new System.Drawing.Point(16, 37);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(72, 16);
			this.label7.TabIndex = 0;
			this.label7.Text = "ParameterA:";
			// 
			// groupBox7
			// 
			this.groupBox7.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.groupBox7.ClientSize = new System.Drawing.Size(288, 144);
			this.groupBox7.Controls.Add(this.textBox14);
			this.groupBox7.Controls.Add(this.textBox13);
			this.groupBox7.Controls.Add(this.button12);
			this.groupBox7.Controls.Add(this.button11);
			this.groupBox7.Controls.Add(this.label14);
			this.groupBox7.Controls.Add(this.label13);
			this.groupBox7.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.groupBox7.Location = new System.Drawing.Point(320, 8);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(288, 144);
			this.groupBox7.TabIndex = 3;
			this.groupBox7.Text = "Cookies Scope Parameters";
			// 
			// label13
			// 
			this.label13.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.label13.ClientSize = new System.Drawing.Size(72, 23);
			this.label13.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.label13.Location = new System.Drawing.Point(16, 35);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(72, 23);
			this.label13.TabIndex = 0;
			this.label13.Text = "ParameterA:";
			// 
			// label14
			// 
			this.label14.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.label14.ClientSize = new System.Drawing.Size(72, 23);
			this.label14.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.label14.Location = new System.Drawing.Point(16, 66);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(72, 23);
			this.label14.TabIndex = 1;
			this.label14.Text = "ParameterB:";
			// 
			// button11
			// 
			this.button11.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.button11.ClientSize = new System.Drawing.Size(75, 23);
			this.button11.Location = new System.Drawing.Point(192, 104);
			this.button11.Name = "button11";
			this.button11.Size = new System.Drawing.Size(75, 23);
			this.button11.TabIndex = 2;
			this.button11.Text = "Save";
			this.button11.Click += new System.EventHandler(this.button11_Click);
			// 
			// button12
			// 
			this.button12.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.button12.ClientSize = new System.Drawing.Size(75, 23);
			this.button12.Location = new System.Drawing.Point(104, 104);
			this.button12.Name = "button12";
			this.button12.Size = new System.Drawing.Size(75, 23);
			this.button12.TabIndex = 3;
			this.button12.Text = "Load";
			this.button12.Click += new System.EventHandler(this.button12_Click);
			// 
			// textBox13
			// 
			this.textBox13.AcceptsReturn = true;
			this.textBox13.AcceptsTab = true;
			this.textBox13.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.textBox13.ClientSize = new System.Drawing.Size(168, 20);
			this.textBox13.Lines = new string[0];
			this.textBox13.Location = new System.Drawing.Point(96, 32);
			this.textBox13.MaxLength = 0;
			this.textBox13.Multiline = false;
			this.textBox13.Name = "textBox13";
			this.textBox13.ReadOnly = false;
			this.textBox13.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Both;
			this.textBox13.Size = new System.Drawing.Size(168, 20);
			this.textBox13.TabIndex = 4;
			this.textBox13.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Left;
			this.textBox13.Validator = null;
			this.textBox13.WordWrap = false;
			// 
			// textBox14
			// 
			this.textBox14.AcceptsReturn = true;
			this.textBox14.AcceptsTab = true;
			this.textBox14.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.textBox14.ClientSize = new System.Drawing.Size(168, 20);
			this.textBox14.Lines = new string[0];
			this.textBox14.Location = new System.Drawing.Point(96, 64);
			this.textBox14.MaxLength = 0;
			this.textBox14.Multiline = false;
			this.textBox14.Name = "textBox14";
			this.textBox14.ReadOnly = false;
			this.textBox14.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Both;
			this.textBox14.Size = new System.Drawing.Size(168, 20);
			this.textBox14.TabIndex = 5;
			this.textBox14.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Left;
			this.textBox14.Validator = null;
			this.textBox14.WordWrap = false;
			// 
			// ContextUsage
			// 
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(632, 560);
			this.Controls.Add(this.groupBox7);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox1);
			this.Size = new System.Drawing.Size(632, 560);
			this.groupBox1.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox7.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion



		private void buttonSave_Click(object sender, System.EventArgs e)
		{
			this.Context["ParameterA"] = this.textBox1.Text;
			this.Context["ParameterB"] = this.textBox2.Text;
		}

		private void buttonLoad_Click(object sender, System.EventArgs e)
		{
			LoadContextParams();
			
		}

		private void LoadContextParams()
		{
			this.textBox1.Text = GetContextParameter("ParameterA");
			this.textBox2.Text = GetContextParameter("ParameterB");
		}

		private void LoadSessionParams()
		{
			this.textBox5.Text = GetSessionParameter("ParameterA");
			this.textBox6.Text = GetSessionParameter("ParameterB");
		}

		private void LoadApplicationParams()
		{
			this.textBox7.Text = GetApplicationParameter("ParameterA");
			this.textBox8.Text = GetApplicationParameter("ParameterB");
		}

		private void LoadCookiesParams()
		{
			this.textBox13.Text = GetCookiesParameter("ParameterA");
			this.textBox14.Text = GetCookiesParameter("ParameterB");
		}

		private string GetContextParameter(string strKey)
		{
			object objValue = VWGContext.Current[strKey];
			if(objValue!=null)
			{
				return objValue.ToString();
			}
			else
			{
				return "";
			}
		}

		private string GetSessionParameter(string strKey)
		{
			object objValue = VWGContext.Current.Session[strKey];
			if(objValue!=null)
			{
				return objValue.ToString();
			}
			else
			{
				return "";
			}
		}

		private string GetCookiesParameter(string strKey)
		{
			object objValue = VWGContext.Current.Cookies[strKey];
			if(objValue!=null)
			{
				return objValue.ToString();
			}
			else
			{
				return "";
			}
		}

		private string GetApplicationParameter(string strKey)
		{
			object objValue = VWGContext.Current.Application[strKey];
			if(objValue!=null)
			{
				return objValue.ToString();
			}
			else
			{
				return "";
			}
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			lock(mobjLock)
			{
				VWGContext.Current.Session["ParameterA"] = this.textBox5.Text;
				VWGContext.Current.Session["ParameterB"] = this.textBox6.Text;
			}
		}

		private void button5_Click(object sender, System.EventArgs e)
		{
			lock(mobjLock)
			{
				VWGContext.Current.Application["ParameterA"] = this.textBox7.Text;
				VWGContext.Current.Application["ParameterB"] = this.textBox8.Text;
			}
		}

		private void button4_Click(object sender, System.EventArgs e)
		{
			LoadSessionParams();
		}

		private void button6_Click(object sender, System.EventArgs e)
		{
			LoadApplicationParams();
		}

		private void button12_Click(object sender, System.EventArgs e)
		{
			LoadCookiesParams();
		}

		private void button11_Click(object sender, System.EventArgs e)
		{
			VWGContext.Current.Cookies["ParameterA"] = this.textBox13.Text;
			VWGContext.Current.Cookies["ParameterB"] = this.textBox14.Text;
		}
	}
}
