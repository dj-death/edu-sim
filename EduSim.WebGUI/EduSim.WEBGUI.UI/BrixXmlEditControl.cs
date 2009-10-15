using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Resources;
using System.Collections.Generic;
using Gizmox.WebGUI.Forms.Catalog;
using EduSim.CoreFramework.Common;
using EduSim.CoreFramework.DataAccess;

namespace EduSim.WebGUI.UI
{
    /// <summary>
    /// Summary description for WindowsBehavior.
    /// </summary>
    [Serializable()]
    public class BrixXmlEditControl : BaseUserControl
    {
        private Gizmox.WebGUI.Forms.Button saveButton;
        private Gizmox.WebGUI.Forms.Button backButton;

        internal DataRow selectedRow;
        /// Required designer variable.
        /// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null;

        public BrixXmlEditControl(BrixMainForm BrixMainForm, DataRow row)
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
            string filter = (selectedRow != null) ? BrixMainForm.PrimaryKeyName + "='" + selectedRow[BrixMainForm.PrimaryKeyName] + "'" : string.Empty; 

            DataTable listDataSet = null;
            if (filter != string.Empty)
            {
                listDataSet = CoreDatabaseHelper.GetODSData(BrixMainForm.TableName, 100, BrixMainForm.PrimaryKeyName, filter, false,
                    ref CurrentPage, out count, null).Tables[0];
            }
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
                MainForm.SelectCategory(typeof(BrixXmlListControl), new object[] { BrixMainForm});
            });

            saveButton.Location = new Point(70, count * 25);
            saveButton.Name = "saveButton";
            saveButton.Text = "Save";
            saveButton.Size = new Size(50, 16);
            saveButton.Click += new EventHandler((sender, e) =>
            {
                if (filter != null)
                {
                    UpdateData(textBoxs, filter);
                }
                else
                {
                    InsertData(textBoxs);
                }
            });
        }

        private void UpdateData(List<TextBox> textBoxs, string filter)
        {
            int count = 0;
            string updateData = string.Empty;

            BrixMainForm.BrixDataEntries.ForEach(o =>
                updateData += o.Name + "='" + textBoxs[count++].Text + "',"
            );

            updateData = updateData.Remove(updateData.Length - 1, 1);
            CoreDatabaseHelper.GenericLibraryUpdate(updateData, filter, BrixMainForm.TableName);
        }

        private void InsertData(List<TextBox> textBoxs)
        {
            string columnNames = string.Empty;
            string values = string.Empty;

            BrixMainForm.BrixDataEntries.ForEach(o =>
                columnNames += o.Name + ",");

            int count = 0;
            BrixMainForm.BrixDataEntries.ForEach(o =>
                {
                    values += "'" + textBoxs[count++] + "',";
                });

            columnNames = columnNames.Remove(columnNames.Length - 1, 1);
            values = values.Remove(values.Length - 1, 1);
            CoreDatabaseHelper.GenericLibraryInsert(columnNames, values, BrixMainForm.TableName);
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
