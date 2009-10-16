using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Gizmox.WebGUI.Common.Resources;

namespace Gizmox.WebGUI.Forms.Catalog.Categories.Behaviors
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    public class DragAndDropBehavior : UserControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ListBox listBox1;
        private Label label5;
        private TreeView treeView1;
        private Label label18;
        private Panel panel1;
        private Label label4;
        private Label label10;
        private Label label1;
        private Label label9;
        private Label label11;
        private Label label2;
        private Label label12;
        private Label label17;
        private Label label6;
        private Label label8;
        private Label label15;
        private Label label16;
        private Label label3;
        private Label label14;
        private Label label13;
        private Label label7;
        private Gizmox.WebGUI.Forms.SplitContainer splitContainer1;


        public DragAndDropBehavior()
        {
            InitializeComponent();
        }

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

        private void DragAndDropBehavior_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 5; i++)
            {
                listView1.Items.Add(new ListViewItem("List view item " + i.ToString()));
            }

            treeView1.Nodes.Add("Root");
            treeView1.Nodes[0].Image = new IconResourceHandle("Folder.gif");
            treeView1.Nodes[0].DragTargets = new Gizmox.WebGUI.Forms.Component[] { this.listBox1, this.treeView1 };
            treeView1.Nodes[0].AllowDrop = true;

            for (int i = 1; i <= 10; i++)
            {
                TreeNode objTreeNode = new TreeNode();
                objTreeNode.Label = "New list box item " + i.ToString();
                objTreeNode.Image = new IconResourceHandle("Folder.gif");

                objTreeNode.DragTargets = new Gizmox.WebGUI.Forms.Component[] { this.listBox1, this.treeView1 };
                objTreeNode.AllowDrop = true;

                treeView1.Nodes[0].Nodes.Add(objTreeNode);
            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new Gizmox.WebGUI.Forms.SplitContainer();
            this.listView1 = new Gizmox.WebGUI.Forms.ListView();
            this.columnHeader1 = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.listBox1 = new Gizmox.WebGUI.Forms.ListBox();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.label10 = new Gizmox.WebGUI.Forms.Label();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.label9 = new Gizmox.WebGUI.Forms.Label();
            this.label11 = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.label12 = new Gizmox.WebGUI.Forms.Label();
            this.label17 = new Gizmox.WebGUI.Forms.Label();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.label8 = new Gizmox.WebGUI.Forms.Label();
            this.label15 = new Gizmox.WebGUI.Forms.Label();
            this.label16 = new Gizmox.WebGUI.Forms.Label();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.label14 = new Gizmox.WebGUI.Forms.Label();
            this.label13 = new Gizmox.WebGUI.Forms.Label();
            this.label7 = new Gizmox.WebGUI.Forms.Label();
            this.treeView1 = new Gizmox.WebGUI.Forms.TreeView();
            this.label18 = new Gizmox.WebGUI.Forms.Label();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.splitContainer1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.BorderWidth = 2;
            this.splitContainer1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.splitContainer1.DragTargets = new Gizmox.WebGUI.Forms.Control[0];
            this.splitContainer1.FixedPanel = Gizmox.WebGUI.Forms.FixedPanel.None;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = Gizmox.WebGUI.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listView1);
            this.splitContainer1.Panel1.Controls.Add(this.listBox1);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.DragTargets = new Gizmox.WebGUI.Forms.Control[0];
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.treeView1);
            this.splitContainer1.Panel2.Controls.Add(this.label18);
            this.splitContainer1.Panel2.DragTargets = new Gizmox.WebGUI.Forms.Control[0];
            this.splitContainer1.Size = new System.Drawing.Size(837, 576);
            this.splitContainer1.SplitterDistance = 268;
            this.splitContainer1.TabIndex = 1;
            // 
            // listView1
            // 
            this.listView1.AllowDrop = true;
            this.listView1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.listView1.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.listView1.DragTargets = new Gizmox.WebGUI.Forms.Control[0];
            this.listView1.ItemsPerPage = 20;
            this.listView1.Location = new System.Drawing.Point(212, 34);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(625, 234);
            this.listView1.TabIndex = 0;
            this.listView1.DragDrop += new Gizmox.WebGUI.Forms.DragEventHandler(this.listView1_DragDrop);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Image = null;
            this.columnHeader1.Text = "Drop ListView";
            this.columnHeader1.Width = 450;
            // 
            // listBox1
            // 
            this.listBox1.AllowDrop = true;
            this.listBox1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.listBox1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.listBox1.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.listBox1.DragTargets = new Gizmox.WebGUI.Forms.Control[0];
            this.listBox1.Items.AddRange(new object[] {
            "List box item 1",
            "List box item 2",
            "List box item 3",
            "List box item 4",
            "List box item 5"});
            this.listBox1.Location = new System.Drawing.Point(0, 34);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = Gizmox.WebGUI.Forms.SelectionMode.MultiSimple;
            this.listBox1.Size = new System.Drawing.Size(350, 234);
            this.listBox1.TabIndex = 1;
            this.listBox1.DragDrop += new Gizmox.WebGUI.Forms.DragEventHandler(this.listBox1_DragDrop);
            // 
            // label5
            // 
            this.label5.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.label5.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.label5.DragTargets = new Gizmox.WebGUI.Forms.Control[0];
            this.label5.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(837, 34);
            this.label5.TabIndex = 2;
            this.label5.Text = "Drop Targets";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel1.DragTargets = new Gizmox.WebGUI.Forms.Control[0];
            this.panel1.Location = new System.Drawing.Point(212, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(625, 270);
            this.panel1.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.DarkGray;
            this.label4.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Inset;
            this.label4.DragTargets = new Gizmox.WebGUI.Forms.Component[] {
        ((Gizmox.WebGUI.Forms.Control)(this.listView1))};
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label4.Location = new System.Drawing.Point(238, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 23);
            this.label4.TabIndex = 0;
            this.label4.Text = "New List view item 1";
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.LightGray;
            this.label10.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Inset;
            this.label10.DragTargets = new Gizmox.WebGUI.Forms.Component[] {
        ((Gizmox.WebGUI.Forms.Control)(this.listBox1))};
            this.label10.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label10.Location = new System.Drawing.Point(26, 38);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(136, 23);
            this.label10.TabIndex = 0;
            this.label10.Text = "New List box item 1";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DarkGray;
            this.label1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.label1.DragTargets = new Gizmox.WebGUI.Forms.Component[] {
        ((Gizmox.WebGUI.Forms.Control)(this.listView1))};
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label1.Location = new System.Drawing.Point(238, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "New List view item 4";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.LightGray;
            this.label9.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Inset;
            this.label9.DragTargets = new Gizmox.WebGUI.Forms.Control[0];
            this.label9.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label9.Location = new System.Drawing.Point(26, 38);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(136, 23);
            this.label9.TabIndex = 0;
            this.label9.Text = "New List box item 1";
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.LightGray;
            this.label11.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Inset;
            this.label11.DragTargets = new Gizmox.WebGUI.Forms.Component[] {
        ((Gizmox.WebGUI.Forms.Control)(this.listBox1))};
            this.label11.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label11.Location = new System.Drawing.Point(26, 76);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(136, 23);
            this.label11.TabIndex = 0;
            this.label11.Text = "New List box item 2";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.DarkGray;
            this.label2.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Inset;
            this.label2.DragTargets = new Gizmox.WebGUI.Forms.Component[] {
        ((Gizmox.WebGUI.Forms.Control)(this.listView1))};
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label2.Location = new System.Drawing.Point(238, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "New List view item 3";
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.DarkGray;
            this.label12.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Inset;
            this.label12.DragTargets = new Gizmox.WebGUI.Forms.Control[0];
            this.label12.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label12.Location = new System.Drawing.Point(238, 38);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(136, 23);
            this.label12.TabIndex = 0;
            this.label12.Text = "New List view item 1";
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.DarkGray;
            this.label17.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.label17.DragTargets = new Gizmox.WebGUI.Forms.Control[0];
            this.label17.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label17.Location = new System.Drawing.Point(238, 151);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(136, 23);
            this.label17.TabIndex = 0;
            this.label17.Text = "New List view item 4";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.LightGray;
            this.label6.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.label6.DragTargets = new Gizmox.WebGUI.Forms.Component[] {
        ((Gizmox.WebGUI.Forms.Control)(this.listBox1))};
            this.label6.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label6.Location = new System.Drawing.Point(26, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 23);
            this.label6.TabIndex = 0;
            this.label6.Text = "New List box item 4";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.LightGray;
            this.label8.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Inset;
            this.label8.DragTargets = new Gizmox.WebGUI.Forms.Control[0];
            this.label8.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label8.Location = new System.Drawing.Point(26, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 23);
            this.label8.TabIndex = 0;
            this.label8.Text = "New List box item 2";
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.LightGray;
            this.label15.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Inset;
            this.label15.DragTargets = new Gizmox.WebGUI.Forms.Component[] {
        ((Gizmox.WebGUI.Forms.Control)(this.listBox1))};
            this.label15.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label15.Location = new System.Drawing.Point(26, 113);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(136, 23);
            this.label15.TabIndex = 0;
            this.label15.Text = "New List box item 3";
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.DarkGray;
            this.label16.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Inset;
            this.label16.DragTargets = new Gizmox.WebGUI.Forms.Control[0];
            this.label16.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label16.Location = new System.Drawing.Point(238, 113);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(136, 23);
            this.label16.TabIndex = 0;
            this.label16.Text = "New List view item 3";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.DarkGray;
            this.label3.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Inset;
            this.label3.DragTargets = new Gizmox.WebGUI.Forms.Component[] {
        ((Gizmox.WebGUI.Forms.Control)(this.listView1))};
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label3.Location = new System.Drawing.Point(238, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "New List view item 2";
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.LightGray;
            this.label14.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.label14.DragTargets = new Gizmox.WebGUI.Forms.Control[0];
            this.label14.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label14.Location = new System.Drawing.Point(26, 151);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(136, 23);
            this.label14.TabIndex = 0;
            this.label14.Text = "New List box item 4";
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.DarkGray;
            this.label13.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Inset;
            this.label13.DragTargets = new Gizmox.WebGUI.Forms.Control[0];
            this.label13.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label13.Location = new System.Drawing.Point(238, 76);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(136, 23);
            this.label13.TabIndex = 0;
            this.label13.Text = "New List view item 2";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.LightGray;
            this.label7.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Inset;
            this.label7.DragTargets = new Gizmox.WebGUI.Forms.Control[0];
            this.label7.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label7.Location = new System.Drawing.Point(26, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(136, 23);
            this.label7.TabIndex = 0;
            this.label7.Text = "New List box item 3";
            // 
            // treeView1
            // 
            this.treeView1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.treeView1.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.treeView1.Location = new System.Drawing.Point(0, 34);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(212, 270);
            this.treeView1.TabIndex = 0;
            this.treeView1.DragTargets = new Component[] { this.treeView1 };
            this.treeView1.DragDrop += new DragEventHandler(treeView1_DragDrop);
            // 
            // label18
            // 
            this.label18.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.label18.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.label18.DragTargets = new Gizmox.WebGUI.Forms.Control[0];
            this.label18.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.label18.Location = new System.Drawing.Point(0, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(837, 34);
            this.label18.TabIndex = 2;
            this.label18.Text = "Drag Sources";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DragAndDropBehavior
            // 
            this.Controls.Add(this.splitContainer1);
            this.DragTargets = new Gizmox.WebGUI.Forms.Control[0];
            this.Location = new System.Drawing.Point(15, -17);
            this.Size = new System.Drawing.Size(837, 576);
            this.Text = "DragAndDropBehavior";
            this.Load += new System.EventHandler(this.DragAndDropBehavior_Load);
            this.ResumeLayout(false);

        }

        void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            if (e is DragDropEventArgs)
            {
                DragDropEventArgs objDragDropEventArgs = e as DragDropEventArgs;
                TreeNode objSourceNode = objDragDropEventArgs.SourceMember as TreeNode;
                TreeNode objTargetNode = objDragDropEventArgs.TargetMember as TreeNode;

                if (objSourceNode != null && objTargetNode != null)
                {
                    TreeNode objNewTreeNode = new TreeNode(objSourceNode.Name, objSourceNode.Label, objSourceNode.Image.File.Replace(".gif", string.Empty));
                    objTargetNode.Nodes.Add(objNewTreeNode);

                    objNewTreeNode.AllowDrop = true;
                    objNewTreeNode.DragTargets = new Component[] { this.treeView1 };
                }
            }
        }

        #endregion

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            if (e is DragDropEventArgs)
            {
                DragDropEventArgs objDragDropEventArgs = e as DragDropEventArgs;

                if (objDragDropEventArgs != null)
                {
                    string strCursorPosition = string.Format(" (Cursor position = {0},{1})", e.X, e.Y);
                    string strKeysState = string.Format(" (Keys State = {0})", e.KeyState.ToString());

                    if (objDragDropEventArgs.Source is Label)
                    {
                        listBox1.Items.Add(((Label)objDragDropEventArgs.Source).Text + strCursorPosition + strKeysState);
                    }
                    else if (objDragDropEventArgs.Source is TreeView && 
                             objDragDropEventArgs.SourceMember is TreeNode)
                    {
                        listBox1.Items.Add(((TreeNode)objDragDropEventArgs.SourceMember).Text + strCursorPosition + strKeysState);
                    }
                }
            }
        }

        private void listView1_DragDrop(object sender, DragEventArgs e)
        {
            if (e is DragDropEventArgs)
            {
                DragDropEventArgs objDragDropEventArgs = e as DragDropEventArgs;

                if (objDragDropEventArgs != null)
                {
                    string strCursorPosition = string.Format(" (Cursor position = {0},{1})", e.X, e.Y);
                    string strKeysState = string.Format(" (Keys State = {0})", e.KeyState.ToString());

                    if (objDragDropEventArgs.Source is Label)
                    {
                        listView1.Items.Add(new ListViewItem(((Label)objDragDropEventArgs.Source).Text) + strCursorPosition + strKeysState);
                    }
                }
            }
        }
    }
}
