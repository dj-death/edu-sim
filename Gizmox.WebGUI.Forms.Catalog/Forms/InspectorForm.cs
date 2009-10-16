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

namespace Gizmox.WebGUI.Forms.Catalog
{


    #region InspectorForm Class

    /// <summary>
	/// Summary description for AboutVWGForm.
	/// </summary>

    [Serializable()]
    public class InspectorForm : Form
	{



        [Serializable()]
    public class InspectorItem
        {
            private Control mobjControl = null;
            private object mobjObject = null;

            public InspectorItem(Control objControl)
            {
                mobjControl = objControl;
            }

            public InspectorItem(object objObject)
            {
                mobjObject = objObject;
            }

            public Control Control
            {
                get
                {
                    return mobjControl;
                }
            }

            public object Object
            {
                get
                {
                    return mobjObject;
                }
            }

            public override string ToString()
            {
                if (mobjControl != null)
                {
                    return mobjControl.Name;
                }
                else if (mobjObject != null)
                {
                    return mobjObject.GetType().Name;
                }
                else
                {
                    return base.ToString();
                }
            }
        }

		#region Class Members

        private ComboBox comboBox1;
        private PropertyGrid propertyGrid1;
		
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
        public InspectorForm()
		{
			// This call is required by the WebGUI Form Designer.
			InitializeComponent();

            comboBox1.SelectedIndexChanged += new EventHandler(comboBox1_SelectedIndexChanged);
		}

        void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            InspectorItem objInspectorItem = comboBox1.SelectedItem as InspectorItem;
            if (objInspectorItem != null)
            {
                if (objInspectorItem.Control != null)
                {
                    this.propertyGrid1.SelectedObject = objInspectorItem.Control;
                }
                else if (objInspectorItem.Object != null)
                {
                    this.propertyGrid1.SelectedObject = objInspectorItem.Object;
                }
            }
        }

        public void SetContainer(Control objContainer)
        {
            comboBox1.Items.Clear();
            AddContainerControls(objContainer);
            comboBox1.SelectedIndex = 0;
            if (comboBox1.Items.Count > 0)
            {
                this.propertyGrid1.SelectedObject = ((InspectorItem)comboBox1.Items[0]).Control;
            }
        }

        public void SetControls(params Control[] objControls)
        {
            comboBox1.Items.Clear();
            foreach (Control objControl in objControls)
            {
                comboBox1.Items.Add(new InspectorItem(objControl));
            }
            comboBox1.SelectedIndex = 0;
            this.propertyGrid1.SelectedObject = objControls[0];
        }

        public void SetObjects(params object[] objObjects)
        {
            comboBox1.Items.Clear();
            foreach (object objObject in objObjects)
            {
                comboBox1.Items.Add(new InspectorItem(objObject));
            }
            comboBox1.SelectedIndex = 0;
            this.propertyGrid1.SelectedObject = objObjects[0];
        }

        private void AddContainerControls(Control objContainer)
        {            
            foreach (Control objControl in objContainer.Controls)
            {
                comboBox1.Items.Add(new InspectorItem(objControl));
                AddContainerControls(objControl);
            }
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
            this.comboBox1 = new Gizmox.WebGUI.Forms.ComboBox();
            this.propertyGrid1 = new Gizmox.WebGUI.Forms.PropertyGrid();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.comboBox1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.comboBox1.ClientSize = new System.Drawing.Size(269, 21);
            this.comboBox1.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.comboBox1.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Location = new System.Drawing.Point(0, 0);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(269, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.Text = "comboBox1";
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.propertyGrid1.CategoryForeColor = System.Drawing.Color.Empty;
            this.propertyGrid1.ClientSize = new System.Drawing.Size(269, 248);
            this.propertyGrid1.CommandsVisibleIfAvailable = false;
            this.propertyGrid1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.propertyGrid1.HelpForeColor = System.Drawing.Color.Black;
            this.propertyGrid1.HelpVisible = false;
            this.propertyGrid1.LineColor = System.Drawing.Color.Empty;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 21);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.PropertySort = Gizmox.WebGUI.Forms.PropertySort.CategorizedAlphabetical;
            this.propertyGrid1.Size = new System.Drawing.Size(269, 248);
            this.propertyGrid1.TabIndex = 0;
            this.propertyGrid1.ViewBackColor = System.Drawing.SystemColors.Control;
            this.propertyGrid1.ViewForeColor = System.Drawing.Color.Black;
            // 
            // InspectorForm
            // 
            this.DockPadding.All = 2;
            this.ClientSize = new System.Drawing.Size(269, 456);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.comboBox1);
            this.Size = new System.Drawing.Size(269, 456);
            this.Text = "Inspector";
            this.ResumeLayout(false);

		}
		
		
		#endregion Form Designer generated code
		
		#region Methods

		
		#endregion Methods
		
	}
	
	#endregion AboutVWGForm Class
	
}
