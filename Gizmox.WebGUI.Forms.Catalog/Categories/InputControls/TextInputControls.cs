using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms;

namespace Gizmox.WebGUI.Forms.Catalog.Categories.InputControls
{
    /// <summary>
    /// Summary description for TextInputControls.
    /// </summary>

    [Serializable()]
    public class TextInputControls : UserControl, IHostedApplication
    {
        private Gizmox.WebGUI.Forms.Label label1;
        private Gizmox.WebGUI.Forms.TextBox textBox1;
        private Label label2;
        private TextBox textBox2;
        private Label label3;
        private MaskedTextBox maskedTextBox1;
        private WatermarkTextBox watermarkTextBox1;
        private SearchTextBox searchTextBox1;
        private TextBox textBox3;
        private Label label4;
        private Label label5;
        private Label label6;

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null;

        public TextInputControls()
        {
            // This call is required by the WebGUI Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call
            ((WatermarkTextBox)watermarkTextBox1).Message = "Please enter text...";


            ContextMenu objContextMenu = new ContextMenu();
            objContextMenu.MenuItems.Add(new MenuItem("test1"));
            objContextMenu.MenuItems.Add(new MenuItem("test2"));
            objContextMenu.MenuItems.Add(new MenuItem("test2"));
            objContextMenu.MenuItems.Add(new MenuItem("test2"));

            searchTextBox1.DropDownMenu = objContextMenu;
            searchTextBox1.MenuClick += new MenuEventHandler(searchTextBox1_MenuClick);
            searchTextBox1.Search += new EventHandler(searchTextBox1_Search);
            searchTextBox1.Clear += new EventHandler(searchTextBox1_Clear);
        }

        void searchTextBox1_Clear(object sender, EventArgs e)
        {
            MessageBox.Show(string.Format("Clear {0}", searchTextBox1.Text));
        }

        void searchTextBox1_Search(object sender, EventArgs e)
        {
            MessageBox.Show(string.Format("Search {0}", searchTextBox1.Text));
        }

        void searchTextBox1_MenuClick(object objSource, MenuItemEventArgs objArgs)
        {
            MessageBox.Show("d");
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
            this.textBox1 = new TextBox();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.textBox2 = new Gizmox.WebGUI.Forms.TextBox();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.maskedTextBox1 = new Gizmox.WebGUI.Forms.MaskedTextBox();
            this.searchTextBox1 = new SearchTextBox();
            this.watermarkTextBox1 = new WatermarkTextBox();
            this.textBox3 = new Gizmox.WebGUI.Forms.TextBox();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
            this.label1.ClientSize = new System.Drawing.Size(175, 23);
            this.label1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.label1.Location = new System.Drawing.Point(24, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Multiline TextBox Control:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            this.textBox1.AcceptsTab = true;
            this.textBox1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
            this.textBox1.ClientSize = new System.Drawing.Size(544, 57);
            this.textBox1.Lines = new string[0];
            this.textBox1.Location = new System.Drawing.Point(24, 42);
            this.textBox1.MaxLength = 34;
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = false;
            this.textBox1.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(544, 57);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Left;
            this.textBox1.Validator = null;
            this.textBox1.WordWrap = false;
            // 
            // label2
            // 
            this.label2.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.label2.ClientSize = new System.Drawing.Size(270, 23);
            this.label2.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.label2.Location = new System.Drawing.Point(21, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(270, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "TextBox Control:";
            // 
            // textBox2
            // 
            this.textBox2.AcceptsReturn = true;
            this.textBox2.AcceptsTab = true;
            this.textBox2.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.textBox2.ClientSize = new System.Drawing.Size(267, 20);
            this.textBox2.Lines = new string[0];
            this.textBox2.Location = new System.Drawing.Point(24, 134);
            this.textBox2.MaxLength = 0;
            this.textBox2.Multiline = false;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = false;
            this.textBox2.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Both;
            this.textBox2.Size = new System.Drawing.Size(267, 20);
            this.textBox2.TabIndex = 0;
            this.textBox2.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Left;
            this.textBox2.Validator = null;
            this.textBox2.WordWrap = false;
            // 
            // label3
            // 
            this.label3.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.label3.ClientSize = new System.Drawing.Size(158, 23);
            this.label3.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.label3.Location = new System.Drawing.Point(24, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "MaskedTextBox Control:";
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.AcceptsReturn = true;
            this.maskedTextBox1.AcceptsTab = true;
            this.maskedTextBox1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.maskedTextBox1.ClientSize = new System.Drawing.Size(267, 20);
            this.maskedTextBox1.Lines = new string[0];
            this.maskedTextBox1.Location = new System.Drawing.Point(24, 191);
            this.maskedTextBox1.Mask = "99/99/9999";
            this.maskedTextBox1.MaxLength = 0;
            this.maskedTextBox1.Multiline = false;
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.ReadOnly = false;
            this.maskedTextBox1.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Both;
            this.maskedTextBox1.Size = new System.Drawing.Size(267, 20);
            this.maskedTextBox1.TabIndex = 0;
            this.maskedTextBox1.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Left;
            this.maskedTextBox1.Validator = null;
            this.maskedTextBox1.WordWrap = false;
            // 
            // textBox3
            // 
            this.textBox3.AcceptsReturn = true;
            this.textBox3.AcceptsTab = true;
            this.textBox3.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.textBox3.ClientSize = new System.Drawing.Size(267, 20);
            this.textBox3.Lines = new string[0];
            this.textBox3.Location = new System.Drawing.Point(24, 246);
            this.textBox3.MaxLength = 0;
            this.textBox3.Multiline = false;
            this.textBox3.Name = "textBox3";
            this.textBox3.PasswordChar = '*';
            this.textBox3.ReadOnly = false;
            this.textBox3.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Both;
            this.textBox3.Size = new System.Drawing.Size(267, 20);
            this.textBox3.TabIndex = 0;
            this.textBox3.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Left;
            this.textBox3.Validator = null;
            this.textBox3.WordWrap = false;
            // 
            // watermarkTextBox1
            // 
            this.watermarkTextBox1.AcceptsReturn = true;
            this.watermarkTextBox1.AcceptsTab = true;
            this.watermarkTextBox1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.watermarkTextBox1.ClientSize = new System.Drawing.Size(267, 20);
            this.watermarkTextBox1.Lines = new string[0];
            this.watermarkTextBox1.Location = new System.Drawing.Point(24, 302);
            this.watermarkTextBox1.MaxLength = 0;
            this.watermarkTextBox1.Multiline = false;
            this.watermarkTextBox1.Name = "watermarkTextBox1";
            this.watermarkTextBox1.ReadOnly = false;
            this.watermarkTextBox1.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Both;
            this.watermarkTextBox1.Size = new System.Drawing.Size(267, 20);
            this.watermarkTextBox1.TabIndex = 0;
            this.watermarkTextBox1.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Left;
            this.watermarkTextBox1.Validator = null;
            this.watermarkTextBox1.WordWrap = false;


            // 
            // label4
            // 
            this.label4.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.label4.ClientSize = new System.Drawing.Size(270, 23);
            this.label4.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.label4.Location = new System.Drawing.Point(24, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(270, 23);
            this.label4.TabIndex = 0;
            this.label4.Text = "Password TextBox Control:";
            // 
            // label5
            // 
            this.label5.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.label5.ClientSize = new System.Drawing.Size(270, 23);
            this.label5.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.label5.Location = new System.Drawing.Point(24, 286);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(270, 23);
            this.label5.TabIndex = 0;
            this.label5.Text = "Watermark TextBox Control (Extended Library):";


            // 
            // label6
            // 
            this.label6.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.label6.ClientSize = new System.Drawing.Size(270, 23);
            this.label6.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.label6.Location = new System.Drawing.Point(24, 341);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(270, 23);
            this.label6.TabIndex = 0;
            this.label6.Text = "SearchTextBox Control (Office Library):";

            // 
            // searchTextBox1
            // 
            this.searchTextBox1.Name = "searchTextBox1";
            this.searchTextBox1.ReadOnly = false;
            this.searchTextBox1.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Both;
            this.searchTextBox1.Size = new System.Drawing.Size(267, 20);
            this.searchTextBox1.Location = new System.Drawing.Point(24, 358);
            this.searchTextBox1.WatermarkText = "Search items....";

            // 
            // TextInputControls
            // 
            this.ClientSize = new System.Drawing.Size(656, 656);
            this.Controls.Add(this.searchTextBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.watermarkTextBox1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            
            this.Location = new System.Drawing.Point(15, 15);
            this.Size = new System.Drawing.Size(656, 656);
            this.ResumeLayout(false);

        }
        #endregion

        #region IHostedApplication Members

        public void InitializeApplication()
        {
        }

        public HostedToolBarElement[] GetToolBarElements()
        {
            ArrayList objElements = new ArrayList();
            objElements.Add(new HostedToolBarToggleButton("Focus", new IconResourceHandle("Focus.gif"), "Focus"));
            //objElements.Add(new HostedToolBarToggleButton("Disable",new IconResourceHandle("Disable.gif"),"Disable"));
            //objElements.Add(new HostedToolBarButton("Show Selection", new IconResourceHandle("Disable.gif"), "ShowSelection"));
            //objElements.Add(new HostedToolBarButton("Select All", new IconResourceHandle("Disable.gif"), "SelectAll"));
            //objElements.Add(new HostedToolBarButton("Select Section", new IconResourceHandle("Disable.gif"), "SelectSection"));
            //objElements.Add(new HostedToolBarSeperator());
            objElements.Add(new HostedToolBarButton("Properties", new IconResourceHandle("Properties.gif"), "Properties"));
            return (HostedToolBarElement[])objElements.ToArray(typeof(HostedToolBarElement));
        }

        public void OnToolBarButtonClick(HostedToolBarButton objButton, EventArgs objEvent)
        {
            HostedToolBarToggleButton objHostedToolBarToggleButton = null;

            string strAction = (string)objButton.Tag;
            switch (strAction)
            {
                case "Disable":
                    objHostedToolBarToggleButton = objButton as HostedToolBarToggleButton;
                    if (objHostedToolBarToggleButton != null)
                    {
                        this.textBox1.Enabled = !objHostedToolBarToggleButton.Pushed;
                    }
                    break;
                case "ShowSelection":
                    MessageBox.Show(textBox1.SelectionLength.ToString() + " " + textBox1.SelectionStart.ToString() + " " + textBox1.SelectedText);
                    break;
                case "SelectAll":
                    textBox1.SelectAll();
                    break;
                case "SelectSection":
                    textBox1.Select(10, 4);
                    break;
                case "Focus":
                    textBox2.Focus();
                    break;
                case "Properties":
                    InspectorForm objInspectorForm = new InspectorForm();
                    objInspectorForm.SetControls(this.textBox1, this.textBox2, this.textBox3, this.maskedTextBox1);
                    objInspectorForm.ShowDialog();
                    break;
            }
        }

        #endregion
    }
}
