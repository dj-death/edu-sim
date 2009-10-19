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
            List<Control> list = LoadControls();

            this.SuspendLayout();

            this.Controls.AddRange(list.ToArray());
            this.Controls.Add(backButton);
            this.Controls.Add(saveButton);

            this.Size = new System.Drawing.Size(456, 466);
            this.ResumeLayout(false);

        }

        private List<Control> LoadControls()
        {
            int CurrentPage = 0, count;
            string filter = (selectedRow != null) ? BrixMainForm.PrimaryKeyName + "=" + selectedRow[BrixMainForm.PrimaryKeyName] : string.Empty; 

            DataTable listDataSet = null;
            if (filter != string.Empty)
            {
                listDataSet = CoreDatabaseHelper.GetODSData(BrixMainForm.TableName, 100, BrixMainForm.PrimaryKeyName, filter, false,
                    ref CurrentPage, out count, null).Tables[0];
            }
            int firstColumnCount = 1;
            List<Control> list = new List<Control>();
            foreach (BrixDataEntry dataEntry in BrixMainForm.BrixDataEntries)
            {
                SetControl(list, ref firstColumnCount, BrixMainForm, dataEntry, listDataSet, true);
            }

            int secondColumnCount = 1;
            foreach (BrixDataEntry dataEntry in BrixMainForm.BrixDataEntries)
            {
                SetControl(list, ref secondColumnCount, BrixMainForm, dataEntry, listDataSet, false);
            }

            SetSaveAndBackButtonEvents(filter, firstColumnCount, list, secondColumnCount);

            return list;
        }

        private void SetSaveAndBackButtonEvents(string filter, int firstColumnCount, List<Control> list, int secondColumnCount)
        {
            backButton = new Button();
            saveButton = new Button();

            int count = firstColumnCount > secondColumnCount ? firstColumnCount : secondColumnCount;
            backButton.Location = new Point(16, count * 25);
            backButton.Name = "backButton";
            backButton.Text = "Back";
            backButton.Size = new Size(50, 16);
            backButton.Click += new EventHandler((sender, e) =>
            {
                MainForm.SelectCategory(typeof(BrixXmlListControl), new object[] { BrixMainForm });
            });

            saveButton.Location = new Point(70, count * 25);
            saveButton.Name = "saveButton";
            saveButton.Text = "Save";
            saveButton.Size = new Size(50, 16);
            saveButton.Click += new EventHandler((sender, e) =>
            {
                if (!BrixMainForm.SaveEvent.Equals(string.Empty))
                {
                    ControlFactory.FireSaveEvent(list, BrixMainForm, filter);
                    return;
                }

                if (filter != null)
                {
                    ControlFactory.UpdateData(list, BrixMainForm, filter);
                }
                else
                {
                    ControlFactory.InsertData(list, BrixMainForm);
                }
            });
        }

        private static void SetControl( List<Control > list,
            ref int count, BrixMainForm brixMainForm,
            BrixDataEntry dataEntry, 
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
                list.Add(label);

                ControlFactory.CreateControl(list, ref count, brixMainForm, dataEntry, table);
            }
        }

        #endregion

    }
}
