using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using Gizmox.WebGUI.Forms;

namespace Gizmox.WebGUI.Forms.Catalog.Categories.Behaviors
{
    /// <summary>
    /// Summary description for BindingNavigatorBehavior.
    /// </summary>

    [Serializable()]
    public class BindingNavigatorBehavior : UserControl
    {
        private Gizmox.WebGUI.Forms.BindingNavigator bindingNavigator1;
        private Gizmox.WebGUI.Forms.BindingSource bindingSource1;
        private Gizmox.WebGUI.Forms.ListBox listBox1;

        public BindingNavigatorBehavior()
        {
            // This call is required by the WebGUI Form Designer.
            InitializeComponent();

            // Fill the binding source.
            //bindingSource1.DataSource = new Worker[10] { new Worker("Joe"), new Worker("George"), new Worker("Sam"), new Worker("David"), new Worker("Martin"), new Worker("Jimi"), new Worker("Frank"), new Worker("Noah"), new Worker("Samuel"), new Worker("John") }; 

            ArrayList objArrayList = new ArrayList();
            objArrayList.Add(new Worker("Joe"));
            objArrayList.Add(new Worker("George"));
            objArrayList.Add(new Worker("Sam"));
            objArrayList.Add(new Worker("David"));
            objArrayList.Add(new Worker("Martin"));

            bindingSource1.DataSource = objArrayList;
        }

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bindingNavigator1 = new Gizmox.WebGUI.Forms.BindingNavigator(this.components);
            this.bindingSource1 = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.listBox1 = new Gizmox.WebGUI.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.Size = new System.Drawing.Size(505, 25);
            this.bindingNavigator1.TabIndex = 1;
            this.bindingNavigator1.Text = "bindingNavigator1";
            this.bindingNavigator1.BindingSource = bindingSource1;
            this.bindingNavigator1.AddStandardItems();
            // 
            // listBox1
            // 
            this.listBox1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.listBox1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.listBox1.DataSource = this.bindingSource1;
            this.listBox1.Location = new System.Drawing.Point(27, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = Gizmox.WebGUI.Forms.SelectionMode.One;
            this.listBox1.Size = new System.Drawing.Size(120, 95);
            this.listBox1.TabIndex = 0;
            // 
            // BindingNavigatorBehavior
            // 
            this.ClientSize = new System.Drawing.Size(576, 648);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.bindingNavigator1);
            this.Size = new System.Drawing.Size(576, 648);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout();
            this.ResumeLayout(false);
        }

        #endregion
    }


    [Serializable()]
    public class Worker
    {
        string mstrWorkerName = string.Empty;

        public Worker(string strWorkerName)
        {
            mstrWorkerName = strWorkerName;
        }

        public Worker()
        {
            mstrWorkerName = "New Worker";
        }

        public override string ToString()
        {
            return mstrWorkerName;
        }
    }
}
