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
    /// Summary description for WindowsBehavior.
    /// </summary>
    [Serializable()]
    public class WindowsBehavior : UserControl
    {
        private Gizmox.WebGUI.Forms.Label label1;
        private Gizmox.WebGUI.Forms.ListBox listBox1;
        private Gizmox.WebGUI.Forms.Label label2;
        private Gizmox.WebGUI.Forms.TextBox textBox1;
        private Gizmox.WebGUI.Forms.Button button1;
        private Gizmox.WebGUI.Forms.Button button2;
        private Gizmox.WebGUI.Forms.Button button3;
        private Gizmox.WebGUI.Forms.CheckBox checkBox1;
        private Gizmox.WebGUI.Forms.TextBox mobjTextWidth;
        private Gizmox.WebGUI.Forms.TextBox mobjTextHeight;
        private Gizmox.WebGUI.Forms.Label label5;
        private Gizmox.WebGUI.Forms.Label label6;
        private CheckBox mobjCheckMinimize;
        private CheckBox mobjCheckMaximize;
        private Label label3;
        private TextBox mobjTextTop;
        private Label label4;
        private TextBox mobjTextLeft;
        private Label label7;
        private ComboBox comboBox1;
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null;

        public WindowsBehavior()
        {
            // This call is required by the WebGUI Form Designer.
            InitializeComponent();

            this.listBox1.DataSource = Enum.GetValues(typeof(FormBorderStyle));
            this.listBox1.SelectedIndex = 4;

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
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.listBox1 = new Gizmox.WebGUI.Forms.ListBox();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.textBox1 = new Gizmox.WebGUI.Forms.TextBox();
            this.button1 = new Gizmox.WebGUI.Forms.Button();
            this.button2 = new Gizmox.WebGUI.Forms.Button();
            this.button3 = new Gizmox.WebGUI.Forms.Button();
            this.checkBox1 = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjTextWidth = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjTextHeight = new Gizmox.WebGUI.Forms.TextBox();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.mobjCheckMinimize = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjCheckMaximize = new Gizmox.WebGUI.Forms.CheckBox();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.mobjTextTop = new Gizmox.WebGUI.Forms.TextBox();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.mobjTextLeft = new Gizmox.WebGUI.Forms.TextBox();
            this.label7 = new Gizmox.WebGUI.Forms.Label();
            this.comboBox1 = new Gizmox.WebGUI.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Form Border Style";
            // 
            // listBox1
            // 
            this.listBox1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.listBox1.Location = new System.Drawing.Point(16, 40);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = Gizmox.WebGUI.Forms.SelectionMode.One;
            this.listBox1.Size = new System.Drawing.Size(120, 160);
            this.listBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(168, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Title";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(168, 40);
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(256, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "Form";
            this.textBox1.WordWrap = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(168, 112);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(256, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Show Modal";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(168, 144);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(256, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Show Non Modal";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(168, 176);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(256, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Show Popup";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Checked = false;
            this.checkBox1.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.checkBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.checkBox1.Location = new System.Drawing.Point(168, 72);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(256, 24);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Open MainForm";
            this.checkBox1.ThreeState = false;
            // 
            // mobjTextWidth
            // 
            this.mobjTextWidth.Location = new System.Drawing.Point(16, 244);
            this.mobjTextWidth.Name = "mobjTextWidth";
            this.mobjTextWidth.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Both;
            this.mobjTextWidth.Size = new System.Drawing.Size(120, 20);
            this.mobjTextWidth.TabIndex = 8;
            this.mobjTextWidth.Text = "600";
            this.mobjTextWidth.WordWrap = false;
            // 
            // mobjTextHeight
            // 
            this.mobjTextHeight.Location = new System.Drawing.Point(16, 300);
            this.mobjTextHeight.Name = "mobjTextHeight";
            this.mobjTextHeight.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Both;
            this.mobjTextHeight.Size = new System.Drawing.Size(120, 20);
            this.mobjTextHeight.TabIndex = 9;
            this.mobjTextHeight.Text = "600";
            this.mobjTextHeight.WordWrap = false;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Width";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(16, 276);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Height";
            // 
            // mobjCheckMinimize
            // 
            this.mobjCheckMinimize.Checked = false;
            this.mobjCheckMinimize.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.mobjCheckMinimize.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.mobjCheckMinimize.Location = new System.Drawing.Point(168, 216);
            this.mobjCheckMinimize.Name = "mobjCheckMinimize";
            this.mobjCheckMinimize.Size = new System.Drawing.Size(120, 24);
            this.mobjCheckMinimize.TabIndex = 0;
            this.mobjCheckMinimize.Text = "Minimize Button";
            this.mobjCheckMinimize.ThreeState = false;
            // 
            // mobjCheckMaximize
            // 
            this.mobjCheckMaximize.Checked = false;
            this.mobjCheckMaximize.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.mobjCheckMaximize.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.mobjCheckMaximize.Location = new System.Drawing.Point(168, 244);
            this.mobjCheckMaximize.Name = "mobjCheckMaximize";
            this.mobjCheckMaximize.Size = new System.Drawing.Size(120, 24);
            this.mobjCheckMaximize.TabIndex = 0;
            this.mobjCheckMaximize.Text = "Maximize Button";
            this.mobjCheckMaximize.ThreeState = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 332);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "Top";
            // 
            // mobjTextTop
            // 
            this.mobjTextTop.Location = new System.Drawing.Point(16, 358);
            this.mobjTextTop.Name = "mobjTextTop";
            this.mobjTextTop.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Both;
            this.mobjTextTop.Size = new System.Drawing.Size(120, 20);
            this.mobjTextTop.TabIndex = 0;
            this.mobjTextTop.Text = "50";
            this.mobjTextTop.WordWrap = false;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(16, 388);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 0;
            this.label4.Text = "Left";
            // 
            // mobjTextLeft
            // 
            this.mobjTextLeft.Location = new System.Drawing.Point(16, 414);
            this.mobjTextLeft.Name = "mobjTextLeft";
            this.mobjTextLeft.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Both;
            this.mobjTextLeft.Size = new System.Drawing.Size(120, 20);
            this.mobjTextLeft.TabIndex = 0;
            this.mobjTextLeft.Text = "50";
            this.mobjTextLeft.WordWrap = false;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(165, 276);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 21);
            this.label7.TabIndex = 13;
            this.label7.Text = "Window state";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox1
            // 
            this.comboBox1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.comboBox1.Location = new System.Drawing.Point(257, 276);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(167, 21);
            this.comboBox1.TabIndex = 14;
            this.comboBox1.Text = "comboBox1";
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox1.DataSource = Enum.GetValues(typeof(FormWindowState));
            // 
            // WindowsBehavior
            // 
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.mobjTextLeft);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.mobjTextTop);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.mobjCheckMaximize);
            this.Controls.Add(this.mobjCheckMinimize);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.mobjTextHeight);
            this.Controls.Add(this.mobjTextWidth);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Size = new System.Drawing.Size(456, 466);
            this.ResumeLayout(false);

        }

        #endregion

        private void button1_Click(object sender, System.EventArgs e)
        {
            Form objForm = CreateForm();
            objForm.MaximizeBox = mobjCheckMaximize.Checked;
            objForm.MinimizeBox = mobjCheckMinimize.Checked;
            objForm.WindowState = (FormWindowState)comboBox1.SelectedItem;
            objForm.Icon = new IconResourceHandle("Paste.gif");
            objForm.ShowDialog();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            Form objForm = CreateForm();
            objForm.MaximizeBox = mobjCheckMaximize.Checked;
            objForm.MinimizeBox = mobjCheckMinimize.Checked;
            objForm.WindowState = (FormWindowState)comboBox1.SelectedItem;
            objForm.Icon = new IconResourceHandle("Paste.gif");
            objForm.Show();
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            Form objForm = CreateForm();
            objForm.MaximizeBox = mobjCheckMaximize.Checked;
            objForm.MinimizeBox = mobjCheckMinimize.Checked;
            objForm.WindowState = (FormWindowState)comboBox1.SelectedItem;
            objForm.Icon = new IconResourceHandle("Paste.gif");
            objForm.ShowPopup(button3);
        }

        private Form CreateForm()
        {
            Form objForm = null;

            if (checkBox1.Checked)
            {
                objForm = new MainForm();
            }
            else
            {
                objForm = new Forms.WindowsBehaviorForm();
            }

            objForm.Text = textBox1.Text;

            try
            {
                objForm.Size = new Size(int.Parse(mobjTextWidth.Text), int.Parse(mobjTextHeight.Text));
            }
            catch (Exception)
            {
            }

            try
            {
                objForm.Location = new Point(int.Parse(mobjTextLeft.Text), int.Parse(mobjTextTop.Text));
                objForm.StartPosition = FormStartPosition.Manual;
            }
            catch (Exception)
            {
            }

            //objForm.Resize+=new EventHandler(objForm_Resize);
            //objForm.LocationChanged += new EventHandler(objForm_LocationChanged);
            objForm.Closed += new EventHandler(objForm_Closed);
            if (listBox1.SelectedValue != null)
            {
                objForm.FormBorderStyle = (FormBorderStyle)listBox1.SelectedValue;
            }
            return objForm;
        }

        void objForm_Closed(object sender, EventArgs e)
        {
            objForm_Resize(sender, e);
            objForm_LocationChanged(sender, e);
        }

        private void objForm_LocationChanged(object sender, EventArgs e)
        {
            mobjTextTop.Text = ((Form)sender).Top.ToString();
            mobjTextLeft.Text = ((Form)sender).Left.ToString();
        }

        private void objForm_Resize(object sender, EventArgs e)
        {
            mobjTextHeight.Text = ((Form)sender).Height.ToString();
            mobjTextWidth.Text = ((Form)sender).Width.ToString();
        }
    }
}
