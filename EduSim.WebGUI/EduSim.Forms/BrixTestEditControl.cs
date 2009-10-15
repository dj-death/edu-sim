using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Resources;
using System.Collections.Generic;
using Gizmox.WebGUI.Forms.Catalog;
using Aurigo.Brix.CoreFramework.Common;
using Aurigo.AMP3.Common;

namespace Aurigo.Brix.WebGUI.UI
{
    /// <summary>
    /// Summary description for WindowsBehavior.
    /// </summary>
    [Serializable()]
    public class BrixTestEditControl : BaseUserControl
    {
        private Gizmox.WebGUI.Forms.Button saveButton;
        private Gizmox.WebGUI.Forms.Button backButton;

        internal DataRow selectedRow;
        /// Required designer variable.
        /// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null;

        public BrixTestEditControl(BrixMainForm BrixMainForm, DataRow row)
            : base(BrixMainForm)
        {
            // This call is required by the WebGUI Form Designer.
            selectedRow = row;
            InitializeComponent();
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
            List<Label> labels = new List<Label>();
            List<TextBox> textBoxs = new List<TextBox>();

            backButton = new Button();
            saveButton = new Button();
            LoadControls(labels, textBoxs);

            this.SuspendLayout();

            this.Controls.AddRange(labels.ToArray());
            this.Controls.AddRange(textBoxs.ToArray());
            this.Controls.Add(backButton);
            this.Controls.Add(saveButton);

            this.Size = new System.Drawing.Size(456, 466);
            this.ResumeLayout(false);

        }

        private void LoadControls(List<Label> labels, List<TextBox> textBoxs)
        {
            int CurrentPage = 0, count;
            string filter = BrixMainForm.PrimaryKeyName + "='" + selectedRow[BrixMainForm.PrimaryKeyName] + "'"; 
            DataTable listDataSet = CoreDatabaseHelper.GetODSData(BrixMainForm.TableName, 100, BrixMainForm.PrimaryKeyName, filter, false,
                ref CurrentPage, out count, null).Tables[0];

            int firstColumnCount = 1;
            foreach (BrixDataEntry dataEntry in BrixMainForm.BrixDataEntries)
            {
                SetControl(labels, textBoxs, ref firstColumnCount, dataEntry, listDataSet, true);
            }

            int secondColumnCount = 1;
            foreach (BrixDataEntry dataEntry in BrixMainForm.BrixDataEntries)
            {
                SetControl(labels, textBoxs, ref secondColumnCount, dataEntry, listDataSet, false);
            }

            count = firstColumnCount > secondColumnCount ? firstColumnCount : secondColumnCount;
            backButton.Location = new Point(16, count * 25);
            backButton.Name = "backButton";
            backButton.Text = "Back";
            backButton.Size = new Size(50, 16);
            backButton.Click += new EventHandler((sender, e) =>
            {
                MainForm.SelectCategory(typeof(BrixListControl), new object[] { BrixMainForm});
            });

            saveButton.Location = new Point(70, count * 25);
            saveButton.Name = "saveButton";
            saveButton.Text = "Save";
            saveButton.Size = new Size(50, 16);
            saveButton.Click += new EventHandler((sender, e) =>
            {
                //TODO: Save data
            });

        }

        private static void SetControl(List<Label> labels, List<TextBox> textBoxs, ref int count, BrixDataEntry dataEntry, 
            DataTable table, bool firstColumn)
        {
            if (dataEntry.IsFirstColumn == firstColumn)
            {
                Label label = new Label();

                label.Location = dataEntry.IsFirstColumn ? new Point(20, count * 25) : new Point(200, count * 25);

                label.Name = "lbl" + dataEntry.Name;
                label.Size = new System.Drawing.Size(70, 16);
                label.TabIndex = 2;
                label.Text = dataEntry.Text;
                labels.Add(label);

                switch (dataEntry.BrixControl)
                {
                    case BrixControl.TextBox:
                        ControlFactory.CreateTextBoxControl(textBoxs, count, dataEntry, table);
                        break;
                    default:
                        break;
                }
                count++;
            }
        }

        #endregion

    }
}
