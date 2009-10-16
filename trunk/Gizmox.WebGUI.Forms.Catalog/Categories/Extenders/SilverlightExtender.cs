#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

#endregion

namespace Gizmox.WebGUI.Forms.Catalog.Categories.Extenders
{
    [Serializable()]
    public class SilverlightExtender : UserControl
    {
        public SilverlightExtender()
        {
            InitializeComponent();
        }

        private Panel panel1;
        private Label label5;

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

        #region Visual WebGui UserControl Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.trackBar1 = new Gizmox.WebGUI.Forms.TrackBar();
            this.trackBar2 = new Gizmox.WebGUI.Forms.TrackBar();
            this.trackBar3 = new Gizmox.WebGUI.Forms.TrackBar();
            this.trackBar4 = new Gizmox.WebGUI.Forms.TrackBar();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.silverlight1 = new Gizmox.WebGUI.Forms.Extenders.SilverlightExtender();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(37, 361);
            this.trackBar1.Minimum = 2;
            this.trackBar1.Name = "trackBar1";
            this.silverlight1.SetOpacity(this.trackBar1, 1);
            this.trackBar1.Orientation = Gizmox.WebGUI.Forms.Orientation.Horizontal;
            this.silverlight1.SetRotation(this.trackBar1, 0);
            this.silverlight1.SetScaleX(this.trackBar1, 1);
            this.silverlight1.SetScaleY(this.trackBar1, 1);
            this.trackBar1.Size = new System.Drawing.Size(209, 45);
            this.silverlight1.SetSkewX(this.trackBar1, 0);
            this.silverlight1.SetSkewY(this.trackBar1, 0);
            this.trackBar1.TabIndex = 2;
            this.trackBar1.TickStyle = Gizmox.WebGUI.Forms.TickStyle.BottomRight;
            this.trackBar1.Value = 2;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(37, 401);
            this.trackBar2.Maximum = 360;
            this.trackBar2.Name = "trackBar2";
            this.silverlight1.SetOpacity(this.trackBar2, 1);
            this.trackBar2.Orientation = Gizmox.WebGUI.Forms.Orientation.Horizontal;
            this.silverlight1.SetRotation(this.trackBar2, 0);
            this.silverlight1.SetScaleX(this.trackBar2, 1);
            this.silverlight1.SetScaleY(this.trackBar2, 1);
            this.trackBar2.Size = new System.Drawing.Size(209, 45);
            this.silverlight1.SetSkewX(this.trackBar2, 0);
            this.silverlight1.SetSkewY(this.trackBar2, 0);
            this.trackBar2.TabIndex = 2;
            this.trackBar2.TickFrequency = 36;
            this.trackBar2.TickStyle = Gizmox.WebGUI.Forms.TickStyle.BottomRight;
            this.trackBar2.ValueChanged += new System.EventHandler(this.trackBar2_ValueChanged);
            // 
            // trackBar3
            // 
            this.trackBar3.Location = new System.Drawing.Point(37, 441);
            this.trackBar3.Maximum = 100;
            this.trackBar3.Name = "trackBar3";
            this.silverlight1.SetOpacity(this.trackBar3, 1);
            this.trackBar3.Orientation = Gizmox.WebGUI.Forms.Orientation.Horizontal;
            this.silverlight1.SetRotation(this.trackBar3, 0);
            this.silverlight1.SetScaleX(this.trackBar3, 1);
            this.silverlight1.SetScaleY(this.trackBar3, 1);
            this.trackBar3.Size = new System.Drawing.Size(209, 45);
            this.silverlight1.SetSkewX(this.trackBar3, 0);
            this.silverlight1.SetSkewY(this.trackBar3, 0);
            this.trackBar3.TabIndex = 2;
            this.trackBar3.TickFrequency = 10;
            this.trackBar3.TickStyle = Gizmox.WebGUI.Forms.TickStyle.BottomRight;
            this.trackBar3.ValueChanged += new System.EventHandler(this.trackBar3_ValueChanged);
            // 
            // trackBar4
            // 
            this.trackBar4.Location = new System.Drawing.Point(37, 481);
            this.trackBar4.Minimum = 1;
            this.trackBar4.Name = "trackBar4";
            this.silverlight1.SetOpacity(this.trackBar4, 1);
            this.trackBar4.Orientation = Gizmox.WebGUI.Forms.Orientation.Horizontal;
            this.silverlight1.SetRotation(this.trackBar4, 0);
            this.silverlight1.SetScaleX(this.trackBar4, 1);
            this.silverlight1.SetScaleY(this.trackBar4, 1);
            this.trackBar4.Size = new System.Drawing.Size(209, 45);
            this.silverlight1.SetSkewX(this.trackBar4, 0);
            this.silverlight1.SetSkewY(this.trackBar4, 0);
            this.trackBar4.TabIndex = 2;
            this.trackBar4.TickStyle = Gizmox.WebGUI.Forms.TickStyle.BottomRight;
            this.trackBar4.Value = 1;
            this.trackBar4.ValueChanged += new System.EventHandler(this.trackBar4_ValueChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(37, 361);
            this.label1.Name = "label1";
            this.silverlight1.SetOpacity(this.label1, 1);
            this.silverlight1.SetRotation(this.label1, 0);
            this.silverlight1.SetScaleX(this.label1, 1);
            this.silverlight1.SetScaleY(this.label1, 1);
            this.label1.Size = new System.Drawing.Size(200, 20);
            this.silverlight1.SetSkewX(this.label1, 0);
            this.silverlight1.SetSkewY(this.label1, 0);
            this.label1.TabIndex = 0;
            this.label1.Text = "Opacity Value: ";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(37, 401);
            this.label2.Name = "label2";
            this.silverlight1.SetOpacity(this.label2, 1);
            this.silverlight1.SetRotation(this.label2, 0);
            this.silverlight1.SetScaleX(this.label2, 1);
            this.silverlight1.SetScaleY(this.label2, 1);
            this.label2.Size = new System.Drawing.Size(200, 20);
            this.silverlight1.SetSkewX(this.label2, 0);
            this.silverlight1.SetSkewY(this.label2, 0);
            this.label2.TabIndex = 0;
            this.label2.Text = "Rotate Value: ";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(37, 441);
            this.label3.Name = "label3";
            this.silverlight1.SetOpacity(this.label3, 1);
            this.silverlight1.SetRotation(this.label3, 0);
            this.silverlight1.SetScaleX(this.label3, 1);
            this.silverlight1.SetScaleY(this.label3, 1);
            this.label3.Size = new System.Drawing.Size(200, 20);
            this.silverlight1.SetSkewX(this.label3, 0);
            this.silverlight1.SetSkewY(this.label3, 0);
            this.label3.TabIndex = 0;
            this.label3.Text = "SkewX Value: ";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(37, 481);
            this.label4.Name = "label4";
            this.silverlight1.SetOpacity(this.label4, 1);
            this.silverlight1.SetRotation(this.label4, 0);
            this.silverlight1.SetScaleX(this.label4, 1);
            this.silverlight1.SetScaleY(this.label4, 1);
            this.label4.Size = new System.Drawing.Size(200, 20);
            this.silverlight1.SetSkewX(this.label4, 0);
            this.silverlight1.SetSkewY(this.label4, 0);
            this.label4.TabIndex = 0;
            this.label4.Text = "ScaleX Value: ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Navy;
            this.panel1.Location = new System.Drawing.Point(131, 136);
            this.panel1.Name = "panel1";
            this.silverlight1.SetOpacity(this.panel1, 1);
            this.silverlight1.SetRotation(this.panel1, 0);
            this.silverlight1.SetScaleX(this.panel1, 1);
            this.silverlight1.SetScaleY(this.panel1, 1);
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.silverlight1.SetSkewX(this.panel1, 0);
            this.silverlight1.SetSkewY(this.panel1, 0);
            this.panel1.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(37, 30);
            this.label5.Name = "label5";
            this.silverlight1.SetOpacity(this.label5, 1);
            this.silverlight1.SetRotation(this.label5, 0);
            this.silverlight1.SetScaleX(this.label5, 1);
            this.silverlight1.SetScaleY(this.label5, 1);
            this.label5.Size = new System.Drawing.Size(393, 53);
            this.silverlight1.SetSkewX(this.label5, 0);
            this.silverlight1.SetSkewY(this.label5, 0);
            this.label5.TabIndex = 4;
            this.label5.Text = "\r\nThis control only works in silverlight.\r\nChange the extension to swgx to see it" +
                " work\r\n";
            // 
            // SilverlightExtender
            // 
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.trackBar3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.trackBar4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.silverlight1.SetOpacity(this, 1);
            this.silverlight1.SetRotation(this, 0);
            this.silverlight1.SetScaleX(this, 1);
            this.silverlight1.SetScaleY(this, 1);
            this.Size = new System.Drawing.Size(697, 656);
            this.silverlight1.SetSkewX(this, 0);
            this.silverlight1.SetSkewY(this, 0);
            this.Text = "UserControl1";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).EndInit();
            this.ResumeLayout(false);

        }

        void trackBar4_ValueChanged(object sender, EventArgs e)
        {
            this.silverlight1.SetScaleX(this.panel1, Convert.ToDouble(trackBar4.Value));
            this.label4.Text = "ScaleX Value: " + trackBar4.Value.ToString();
        }

        void trackBar3_ValueChanged(object sender, EventArgs e)
        {
            this.silverlight1.SetSkewX(this.panel1, Convert.ToDouble(trackBar3.Value));
            this.label3.Text = "SkewX Value: " + trackBar3.Value.ToString();
        }

        void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            this.silverlight1.SetRotation(this.panel1, Convert.ToDouble(trackBar2.Value));
            this.label2.Text = "Rotate Value: " + trackBar2.Value.ToString();
        }

        void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            double dblOpc = Convert.ToDouble(trackBar1.Value) / 10;
            this.silverlight1.SetOpacity(this.panel1, dblOpc);
            this.label1.Text = "Opacity Value: " + dblOpc.ToString();
        }




        #endregion

        private Gizmox.WebGUI.Forms.TrackBar trackBar1;
        private Gizmox.WebGUI.Forms.TrackBar trackBar2;
        private Gizmox.WebGUI.Forms.TrackBar trackBar3;
        private Gizmox.WebGUI.Forms.TrackBar trackBar4;
        private Gizmox.WebGUI.Forms.Label label1;
        private Gizmox.WebGUI.Forms.Label label2;
        private Gizmox.WebGUI.Forms.Label label3;
        private Gizmox.WebGUI.Forms.Label label4;
        private Gizmox.WebGUI.Forms.Extenders.SilverlightExtender silverlight1;
    }
}