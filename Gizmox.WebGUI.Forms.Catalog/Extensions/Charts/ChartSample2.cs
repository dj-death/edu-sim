#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Charts;

#endregion

namespace Gizmox.WebGUI.Forms.Catalog.Extensions.Charts
{
    [Serializable()]
    public partial class ChartSample2 : UserControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        public ChartSample2()
        {
            InitializeComponent();
            InitializeChart();
        }

        private void InitializeChart()
        {
            Chart objChart = new Chart();
            objChart.Theme = ThemeTypes.Theme1;
            objChart.AnimationType = AnimationTypes.Type2;
            objChart.Dock = DockStyle.Fill;


            AxisX x = new AxisX();
            x.Title = "Company";

            AxisY y = new AxisY();
            y.Title = "Total (Millions of dollar)";
            y.Prefix = "$";

            objChart.Title = new Title("Downstream Results of the Integrated Oil Companies, 2005");
            objChart.AxisX = x;
            objChart.AxisY = y;










            DataSeries ds = new DataSeries();
            ds.Name = "Product Sales";
            ds.RenderAs = DisplayTypes.Doughnut;
            ds.MarkerScale = 0.8;
            ds.ToolTipText = "Production: #YValue, Reserves: #ZValue";

            ds.Add("ExxonMobil", 7992);
            ds.Add("Shell", 7532);
            ds.Add("BP", 4405);
            ds.Add("Chevron", 2766);
            ds.Add("Conoco", 4173);
            ds.Add("Marathon", 3013);
            objChart.Data.Add(ds);


            this.Controls.Add(objChart);
        }


        #region Component Designer generated code


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

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {

        }

        #endregion
    }
}