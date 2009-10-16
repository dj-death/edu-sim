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
    public class ErrorProviderBehavior : UserControl
    {
        private Button button1;
        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private TextBox textBox2;
        private GroupBox groupBox1;
        private Panel panel1;
        private CheckBox checkBox3;
        private CheckBox checkBox2;
        private CheckBox checkBox1;

        private ErrorProvider errorProvider = null;
        private CheckedListBox checkedListBox1;
        private DateTimePicker dateTimePicker1;
        private MonthCalendar monthCalendar1;

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null;

        public ErrorProviderBehavior()
        {
            // This call is required by the WebGUI Form Designer.
            InitializeComponent();

            errorProvider = new ErrorProvider();
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
            this.button1 = new Gizmox.WebGUI.Forms.Button();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.textBox1 = new Gizmox.WebGUI.Forms.TextBox();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.textBox2 = new Gizmox.WebGUI.Forms.TextBox();
            this.groupBox1 = new Gizmox.WebGUI.Forms.GroupBox();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.checkBox3 = new Gizmox.WebGUI.Forms.CheckBox();
            this.checkBox2 = new Gizmox.WebGUI.Forms.CheckBox();
            this.checkBox1 = new Gizmox.WebGUI.Forms.CheckBox();
            this.checkedListBox1 = new Gizmox.WebGUI.Forms.CheckedListBox();
            this.dateTimePicker1 = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.monthCalendar1 = new Gizmox.WebGUI.Forms.MonthCalendar();
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.button1.ClientSize = new System.Drawing.Size(75, 23);
            this.button1.Location = new System.Drawing.Point(7, 319);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "OK";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.label1.ClientSize = new System.Drawing.Size(100, 23);
            this.label1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            this.textBox1.AcceptsTab = true;
            this.textBox1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.textBox1.ClientSize = new System.Drawing.Size(249, 20);
            this.textBox1.Lines = new string[0];
            this.textBox1.Location = new System.Drawing.Point(7, 30);
            this.textBox1.MaxLength = 0;
            this.textBox1.Multiline = false;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = false;
            this.textBox1.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(249, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Left;
            this.textBox1.Validator = null;
            this.textBox1.WordWrap = false;
            // 
            // label2
            // 
            this.label2.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.label2.ClientSize = new System.Drawing.Size(100, 23);
            this.label2.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.label2.Location = new System.Drawing.Point(4, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Description";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // textBox2
            // 
            this.textBox2.AcceptsReturn = true;
            this.textBox2.AcceptsTab = true;
            this.textBox2.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.textBox2.ClientSize = new System.Drawing.Size(249, 20);
            this.textBox2.Lines = new string[0];
            this.textBox2.Location = new System.Drawing.Point(7, 84);
            this.textBox2.MaxLength = 0;
            this.textBox2.Multiline = false;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = false;
            this.textBox2.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Both;
            this.textBox2.Size = new System.Drawing.Size(249, 20);
            this.textBox2.TabIndex = 0;
            this.textBox2.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Left;
            this.textBox2.Validator = null;
            this.textBox2.WordWrap = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.groupBox1.ClientSize = new System.Drawing.Size(249, 187);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(7, 126);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(249, 187);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.Text = "groupBox1";
            // 
            // panel1
            // 
            this.panel1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.panel1.ClientSize = new System.Drawing.Size(200, 100);
            this.panel1.Controls.Add(this.checkBox3);
            this.panel1.Controls.Add(this.checkBox2);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Location = new System.Drawing.Point(7, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 0;
            // 
            // checkBox3
            // 
            this.checkBox3.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.checkBox3.Checked = false;
            this.checkBox3.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.checkBox3.ClientSize = new System.Drawing.Size(104, 24);
            this.checkBox3.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.checkBox3.Location = new System.Drawing.Point(4, 66);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(104, 24);
            this.checkBox3.TabIndex = 0;
            this.checkBox3.Text = "checkBox3";
            this.checkBox3.ThreeState = false;
            // 
            // checkBox2
            // 
            this.checkBox2.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.checkBox2.Checked = false;
            this.checkBox2.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.checkBox2.ClientSize = new System.Drawing.Size(104, 24);
            this.checkBox2.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.checkBox2.Location = new System.Drawing.Point(4, 35);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(104, 24);
            this.checkBox2.TabIndex = 0;
            this.checkBox2.Text = "checkBox2";
            this.checkBox2.ThreeState = false;
            // 
            // checkBox1
            // 
            this.checkBox1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.checkBox1.Checked = false;
            this.checkBox1.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.checkBox1.ClientSize = new System.Drawing.Size(104, 24);
            this.checkBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.checkBox1.Location = new System.Drawing.Point(4, 4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(104, 24);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.ThreeState = false;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.checkedListBox1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.checkedListBox1.ClientSize = new System.Drawing.Size(120, 95);
            this.checkedListBox1.Items.AddRange(new object[] {
            "Red",
            "Green",
            "Yellow",
            "Black",
            "Blue",
            "Pink",
            "Lime",
            "Orange",
            "Brown",
            "White",
            "Gray"});
            this.checkedListBox1.Location = new System.Drawing.Point(275, 30);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(120, 95);
            this.checkedListBox1.TabIndex = 0;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.dateTimePicker1.Checked = false;
            this.dateTimePicker1.ClientSize = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.CustomFormat = null;
            this.dateTimePicker1.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Long;
            this.dateTimePicker1.Location = new System.Drawing.Point(275, 132);
            this.dateTimePicker1.MaxDate = new System.DateTime(2012, 2, 15, 7, 42, 15, 984);
            this.dateTimePicker1.MinDate = new System.DateTime(2002, 2, 1, 7, 42, 15, 984);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowCheckBox = false;
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.Value = new System.DateTime(2007, 2, 1, 0, 0, 0, 0);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.monthCalendar1.ClientSize = new System.Drawing.Size(178, 155);
            this.monthCalendar1.Location = new System.Drawing.Point(275, 159);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.Size = new System.Drawing.Size(178, 155);
            this.monthCalendar1.TabIndex = 0;
            this.monthCalendar1.Value = new System.DateTime(2007, 2, 1, 7, 42, 22, 125);
            // 
            // ErrorProviderBehavior
            // 
            this.ClientSize = new System.Drawing.Size(609, 580);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Location = new System.Drawing.Point(15, 15);
            this.Size = new System.Drawing.Size(609, 580);

        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {

            errorProvider.SetError(textBox1, textBox1.Text == "" ? "Please enter First name." : "");
            errorProvider.SetError(textBox2, textBox2.Text == "" ? "Please enter Last name." : "");
            errorProvider.SetError(checkBox1, !checkBox1.Checked ? "Please select this checkbox." : "");
            errorProvider.SetError(checkedListBox1, checkedListBox1.CheckedItems.Count < 3 ? "Please select at least 3 colors." : "");
            errorProvider.SetError(monthCalendar1, monthCalendar1.Value.Day > 10 ? "" : "Please select a date after the 10th.");
            errorProvider.SetError(dateTimePicker1, dateTimePicker1.Value.Day > 10 ? "" : "Please select a date after the 10th.");

        }





    }
}
