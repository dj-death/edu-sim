using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Resources;

namespace Gizmox.WebGUI.Forms.Catalog.Categories.InputControls
{
	/// <summary>
	/// Summary description for ListInputControls.
	/// </summary>

    [Serializable()]
    public class ListInputControls : UserControl, IHostedApplication
	{
		private Gizmox.WebGUI.Forms.ListBox listBox1;
		private Gizmox.WebGUI.Forms.CheckedListBox checkedListBox1;
		private Gizmox.WebGUI.Forms.ColorListBox colorListBox1;
		private Gizmox.WebGUI.Forms.ComboBox comboBox1;
		private Gizmox.WebGUI.Forms.ComboBox comboBox3;
        private Gizmox.WebGUI.Forms.ComboBox comboBox4;
        private Gizmox.WebGUI.Forms.ColorComboBox colorComboBox1;

		private RandomData mobjRandomData;
        private Controls.OwnerDrawnComboBox comboBox2;
		

		/// <summary> 
		/// Required designer variable.
		/// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null;

		public ListInputControls()
		{
			// This call is required by the WebGUI Form Designer.
			InitializeComponent();

			mobjRandomData = new RandomData();

			this.comboBox1.Items.AddRange(mobjRandomData.GetStrings("Item",100));
			this.listBox1.DataSource = mobjRandomData.GetStrings("Item",50);
            this.listBox1.SelectedIndex = 3;
			this.checkedListBox1.Items.AddRange(mobjRandomData.GetStrings("Item",50));
			this.colorListBox1.Items.AddRange(RandomData.GetSystemColors());
            this.colorComboBox1.Items.AddRange(RandomData.GetWebColors());
			this.comboBox3.Items.AddRange(Enum.GetNames(typeof(Keys)));
            this.comboBox4.Items.AddRange(Enum.GetNames(typeof(Keys)));

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
            this.checkedListBox1 = new Gizmox.WebGUI.Forms.CheckedListBox();
            this.colorListBox1 = new Gizmox.WebGUI.Forms.ColorListBox();
            this.comboBox1 = new Gizmox.WebGUI.Forms.ComboBox();
            this.comboBox3 = new Gizmox.WebGUI.Forms.ComboBox();
            this.comboBox4 = new Gizmox.WebGUI.Forms.ComboBox();
            this.comboBox2 = new Controls.OwnerDrawnComboBox();
            this.colorComboBox1 = new Gizmox.WebGUI.Forms.ColorComboBox(); 
            // 
            // listBox1
            // 
            this.listBox1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
            this.listBox1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.listBox1.ClientSize = new System.Drawing.Size(168, 199);
            this.listBox1.Location = new System.Drawing.Point(24, 24);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(168, 199);
            this.listBox1.TabIndex = 0;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
            this.checkedListBox1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.checkedListBox1.ClientSize = new System.Drawing.Size(160, 260);
            this.checkedListBox1.Location = new System.Drawing.Point(24, 256);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(160, 260);
            this.checkedListBox1.TabIndex = 1;
            // 
            // colorListBox1
            // 
            this.colorListBox1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
            this.colorListBox1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.colorListBox1.ClientSize = new System.Drawing.Size(240, 199);
            this.colorListBox1.Location = new System.Drawing.Point(216, 24);
            this.colorListBox1.Name = "colorListBox1";
            this.colorListBox1.SelectionMode = Gizmox.WebGUI.Forms.SelectionMode.One;
            this.colorListBox1.Size = new System.Drawing.Size(240, 199);
            this.colorListBox1.TabIndex = 2;
            // 
            // comboBox1
            // 
            this.comboBox1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
            this.comboBox1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.comboBox1.ClientSize = new System.Drawing.Size(240, 21);
            this.comboBox1.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Location = new System.Drawing.Point(216, 256);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(240, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.Text = "comboBox1";
            this.comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            //this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox3
            // 
            this.comboBox3.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.comboBox3.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.comboBox3.ClientSize = new System.Drawing.Size(240, 21);
            this.comboBox3.Location = new System.Drawing.Point(216, 296);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(240, 21);
            this.comboBox3.TabIndex = 4;
            this.comboBox3.Text = "comboBox3";
            this.comboBox3.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            // 
            // comboBox4
            // 
            this.comboBox4.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.comboBox4.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.comboBox4.ClientSize = new System.Drawing.Size(240, 85);
            this.comboBox4.Location = new System.Drawing.Point(216, 430);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(240, 85);
            this.comboBox4.TabIndex = 4;
            this.comboBox4.Text = "comboBox4";
            this.comboBox4.DropDownStyle = ComboBoxStyle.Simple;
            this.comboBox4.MaxDropDownItems = 4;
            this.comboBox4.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            // 
            // comboBox2
            // 
            this.comboBox2.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.comboBox2.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.comboBox2.ClientSize = new System.Drawing.Size(240, 21);
            this.comboBox2.Location = new System.Drawing.Point(216, 339);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(240, 21);
            this.comboBox2.TabIndex = 0;
            this.comboBox2.Text = "comboBox2";
            this.comboBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            // 
            // colorComboBox1
            // 
            this.colorComboBox1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.colorComboBox1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.colorComboBox1.ClientSize = new System.Drawing.Size(240, 21);
            this.colorComboBox1.Location = new System.Drawing.Point(216, 389);
            this.colorComboBox1.Name = "colorComboBox1";
            this.colorComboBox1.Size = new System.Drawing.Size(240, 21);
            this.colorComboBox1.TabIndex = 5;
            this.colorComboBox1.Text = "colorComboBox1";
            this.colorComboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            // 
            // ListInputControls
            // 
            this.ClientSize = new System.Drawing.Size(528, 640);
            this.Controls.Add(this.colorComboBox1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.colorListBox1);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.listBox1);
            this.Size = new System.Drawing.Size(528, 640);

		}
		#endregion

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			MessageBox.Show("You have changed the combobox.");
		}

        #region IHostedApplication Members

        public void InitializeApplication()
        {
        }

        public HostedToolBarElement[] GetToolBarElements()
        {
            ArrayList objElements = new ArrayList();
            objElements.Add(new HostedToolBarButton("Add Item", new IconResourceHandle("NewItem.gif"), "AddItem"));
            //objElements.Add(new HostedToolBarButton("Remove Item", new IconResourceHandle("RemoveItem.gif"), "RemoveItem"));
            objElements.Add(new HostedToolBarButton("Clear Items", new IconResourceHandle("Clear.gif"), "ClearItems"));
            objElements.Add(new HostedToolBarSeperator());
            objElements.Add(new HostedToolBarButton("Properties", new IconResourceHandle("Properties.gif"), "Properties"));
            return (HostedToolBarElement[])objElements.ToArray(typeof(HostedToolBarElement));
        }

        public void OnToolBarButtonClick(HostedToolBarButton objButton, EventArgs objEvent)
        {          
            string strAction = (string)objButton.Tag;
            switch (strAction)
            {
                case "AddItem":
                    this.listBox1.Items.AddRange(mobjRandomData.GetStrings("Item", 1));
                    break;
                case "RemoveItem":
                    
                    break;
                case "ClearItems":
                    this.listBox1.Items.Clear();
                    break;
                case "Properties":
                    InspectorForm objInspectorForm = new InspectorForm();
                    objInspectorForm.SetContainer(this);
                    objInspectorForm.ShowDialog();
                    break;
            }
        }
        #endregion
    }
}
