using System;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.OleDb;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Resources;

namespace Gizmox.WebGUI.Forms.Catalog.Categories.DataControls
{
    /// <summary>
    /// 
    /// </summary>

    [Serializable()]
    public class DatagridviewSelectionChanged : UserControl, IHostedApplication
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private DataGridView DataGridView1 = new DataGridView();
        private Panel panel1 = new Panel();
        private Label Label1 = new Label();
        private Label Label2 = new Label();
        private Label Label3 = new Label();
        private Label Label4 = new Label();

        public DatagridviewSelectionChanged()
        {
            InitializeComponent();

            // Initialize the form.
            // This code can be replaced with designer generated code.
            AutoSize = true;

            // Set the FlowLayoutPanel1 properties.

            panel1.Location = new System.Drawing.Point(354, 0);
            panel1.AutoSize = true;
            panel1.Controls.Add(Label1);
            Label1.Dock = DockStyle.Top;
            panel1.Controls.Add(Label2);
            Label2.Dock = DockStyle.Top;
            panel1.Controls.Add(Label3);
            Label3.Dock = DockStyle.Top;
            panel1.Controls.Add(Label4);
            Label4.Dock = DockStyle.Top;
            panel1.Width = 400;
            Controls.Add(panel1);
            Controls.Add(DataGridView1);

            // Set the Label properties.
            Label1.AutoSize = true;
            Label2.AutoSize = true;
            Label3.AutoSize = true;
            Label4.AutoSize = true;
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

        #region Visual WebGui UserControl Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // 
            // DatagridviewSelectionChanged
            // 
            this.ClientSize = new System.Drawing.Size(391, 306);
            this.Size = new System.Drawing.Size(391, 306);
            this.Text = "DatagridviewSelectionChanged";

        }

        #endregion

        protected override void OnLoad(EventArgs e)
        {
            PopulateDataGridView();
            UpdateLabelText();
            UpdateBalance();

            DataGridView1.CellValidating += new
                DataGridViewCellValidatingEventHandler(
                DataGridView1_CellValidating);
            DataGridView1.CellValidated += new DataGridViewCellEventHandler(
                DataGridView1_CellValidated);
            DataGridView1.CellValueChanged += new DataGridViewCellEventHandler(
                DataGridView1_CellValueChanged);
            DataGridView1.RowsRemoved += new DataGridViewRowsRemovedEventHandler(
                DataGridView1_RowsRemoved);
            DataGridView1.SelectionChanged += new EventHandler(
                DataGridView1_SelectionChanged);
            DataGridView1.UserAddedRow += new DataGridViewRowEventHandler(
                DataGridView1_UserAddedRow);
            DataGridView1.UserDeletingRow += new
                DataGridViewRowCancelEventHandler(DataGridView1_UserDeletingRow);

            base.OnLoad(e);
        }

        // Replace this with your own code to populate the DataGridView.
        private void PopulateDataGridView()
        {
            DataGridView1.Name = "DataGridView1";
            DataGridView1.Size = new Size(350, 300);
            DataGridView1.AllowUserToDeleteRows = true;

            // Add columns to the DataGridView.
            DataGridView1.ColumnCount = 4;
            DataGridView1.SelectionMode =
                DataGridViewSelectionMode.RowHeaderSelect;

            // Set the properties of the DataGridView columns.

            DataGridView1.Columns[0].Name = "Description";
            DataGridView1.Columns[1].Name = "Withdrawals";
            DataGridView1.Columns[2].Name = "Deposits";
            DataGridView1.Columns[3].Name = "Balance";
            DataGridView1.Columns["Description"].HeaderText = "Description";
            DataGridView1.Columns["Withdrawals"].HeaderText = "W(-)";
            DataGridView1.Columns["Withdrawals"].Width = 45;
            DataGridView1.Columns["Deposits"].HeaderText = "D(+)";
            DataGridView1.Columns["Deposits"].Width = 45;
            DataGridView1.Columns["Balance"].HeaderText = "Balance";
            DataGridView1.Columns["Balance"].ReadOnly = true;
            DataGridView1.Columns["Description"].SortMode =
                DataGridViewColumnSortMode.NotSortable;
            DataGridView1.Columns["Withdrawals"].SortMode =
                DataGridViewColumnSortMode.NotSortable;
            DataGridView1.Columns["Deposits"].SortMode =
                DataGridViewColumnSortMode.NotSortable;
            DataGridView1.Columns["Balance"].SortMode =
                DataGridViewColumnSortMode.NotSortable;

            // Add rows of data to the DataGridView.
            DataGridView1.Rows.Add(new string[] {
            "Starting Balance", "", "", "1000" });
            DataGridView1.Rows.Add(new string[] {
            "Paycheck Deposit", "", "850", "" });
            DataGridView1.Rows.Add(new string[] { "Rent", "-500", "", "" });
            DataGridView1.Rows.Add(new string[] { "Groceries", "-25", "", "" });
            DataGridView1.Rows.Add(new string[] { "Tax Return", "", "300", "" });


            // Allow the user to edit the starting balance cell
            DataGridView1.Rows[0].ReadOnly = true;
            DataGridView1.Rows[0].Cells["Balance"].ReadOnly = false;

            // Autosize the columns.
            // DataGridView1.AutoResizeColumns();
        }

        private void DataGridView1_CellValueChanged(
            object sender, DataGridViewCellEventArgs e)
        {
            // Update the balance column whenever the value of any cell changes.
            UpdateBalance();
        }

        private void DataGridView1_RowsRemoved(
            object sender, DataGridViewRowsRemovedEventArgs e)
        {
            // Update the balance column whenever rows are deleted.
            UpdateBalance();
        }

        private void UpdateBalance()
        {
            int counter;
            int balance;
            int deposit;
            int withdrawal;

            // Iterate through the rows, skipping the Starting Balance row.
            for (counter = 1; counter < (DataGridView1.Rows.Count - 1);
                counter++)
            {
                deposit = 0;
                withdrawal = 0;
                balance = int.Parse(DataGridView1.Rows[counter - 1]
                    .Cells["Balance"].Value.ToString());

                if (DataGridView1.Rows[counter].Cells["Deposits"].Value != null)
                {
                    // Verify that the cell value is not an empty string.
                    if (DataGridView1.Rows[counter]
                        .Cells["Deposits"].Value.ToString().Length != 0)
                    {
                        deposit = int.Parse(DataGridView1.Rows[counter]
                            .Cells["Deposits"].Value.ToString());
                    }
                }

                if (DataGridView1.Rows[counter].Cells["Withdrawals"].Value != null)
                {
                    if (DataGridView1.Rows[counter]
                        .Cells["Withdrawals"].Value.ToString().Length != 0)
                    {
                        withdrawal = int.Parse(DataGridView1.Rows[counter]
                            .Cells["Withdrawals"].Value.ToString());
                    }
                }
                DataGridView1.Rows[counter].Cells["Balance"].Value =
                    (balance + deposit + withdrawal).ToString();
            }
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            // Update the labels to reflect changes to the selection.
            UpdateLabelText();
        }

        private void DataGridView1_UserAddedRow(
            object sender, DataGridViewRowEventArgs e)
        {
            // Update the labels to reflect changes to the number of entries.
            UpdateLabelText();
        }

        private void UpdateLabelText()
        {
            int WithdrawalTotal = 0;
            int DepositTotal = 0;
            int SelectedCellTotal = 0;
            int counter;

            // Iterate through all the rows and sum up the appropriate columns.
            for (counter = 0; counter < (DataGridView1.Rows.Count);
                counter++)
            {
                if (DataGridView1.Rows[counter].Cells["Withdrawals"].Value
                    != null)
                {
                    if (DataGridView1.Rows[counter].
                        Cells["Withdrawals"].Value.ToString().Length != 0)
                    {
                        WithdrawalTotal += int.Parse(DataGridView1.Rows[counter].
                            Cells["Withdrawals"].Value.ToString());
                    }
                }

                if (DataGridView1.Rows[counter].Cells["Deposits"].Value != null)
                {
                    if (DataGridView1.Rows[counter]
                        .Cells["Deposits"].Value.ToString().Length != 0)
                    {
                        DepositTotal += int.Parse(DataGridView1.Rows[counter]
                            .Cells["Deposits"].Value.ToString());
                    }
                }
            }

            // Iterate through the SelectedCells collection and sum up the values.
            for (counter = 0;
                counter < (DataGridView1.SelectedCells.Count); counter++)
            {
                if (DataGridView1.SelectedCells[counter].FormattedValueType ==
                    Type.GetType("System.String"))
                {
                    string value = null;

                    // If the cell contains a value that has not been commited,
                    // use the modified value.
                    if (DataGridView1.IsCurrentCellDirty == true)
                    {

                        value = DataGridView1.SelectedCells[counter]
                            .EditedFormattedValue.ToString();
                    }
                    else
                    {
                        value = DataGridView1.SelectedCells[counter]
                            .FormattedValue.ToString();
                    }
                    if (value != null)
                    {
                        // Ignore cells in the Description column.
                        if (DataGridView1.SelectedCells[counter].ColumnIndex !=
                            DataGridView1.Columns["Description"].Index)
                        {
                            if (value.Length != 0)
                            {
                                SelectedCellTotal += int.Parse(value);
                            }
                        }
                    }
                }
            }

            // Set the labels to reflect the current state of the DataGridView.
            Label1.Text = "Withdrawals Total: " + WithdrawalTotal.ToString();
            Label1.Width = CommonUtils.GetStringMeasurements(Label1.Text, Label1.Font).Width;
            Label2.Text = "Deposits Total: " + DepositTotal.ToString();
            Label2.Width = CommonUtils.GetStringMeasurements(Label2.Text, Label1.Font).Width;
            Label3.Text = "Selected Cells Total: " + SelectedCellTotal.ToString();
            Label3.Width = CommonUtils.GetStringMeasurements(Label3.Text, Label1.Font).Width;
            Label4.Text = "Total entries: " + DataGridView1.RowCount.ToString();
            Label4.Width = CommonUtils.GetStringMeasurements(Label4.Text, Label1.Font).Width;
        }

        private void DataGridView1_CellValidating(object sender,
            DataGridViewCellValidatingEventArgs e)
        {
            int testint;

            if (e.ColumnIndex != 0)
            {
                if (e.FormattedValue.ToString().Length != 0)
                {
                    // Try to convert the cell value to an int.
                    if (!CommonUtils.TryParse(e.FormattedValue.ToString(), out testint))
                    {
                        DataGridView1.Rows[e.RowIndex].ErrorText =
                            "Error: Invalid entry";
                        e.Cancel = true;
                    }
                }
            }
        }

        private void DataGridView1_CellValidated(object sender,
            DataGridViewCellEventArgs e)
        {
            // Clear any error messages that may have been set in cell validation.
            DataGridView1.Rows[e.RowIndex].ErrorText = null;
        }

        private void DataGridView1_UserDeletingRow(object sender,
            DataGridViewRowCancelEventArgs e)
        {
            DataGridViewRow startingBalanceRow = DataGridView1.Rows[0];

            // Check if the Starting Balance row is included in the selected rows
            if (DataGridView1.SelectedRows.Contains(startingBalanceRow))
            {
                // Do not allow the user to delete the Starting Balance row.
                if (e.Row.Equals(startingBalanceRow))
                {
                    MessageBox.Show("Cannot delete Starting Balance row!");
                }

                // Cancel the deletion if the Starting Balance row is included.
                e.Cancel = true;
            }
        }

        #region IHostedApplication Members

        public void InitializeApplication()
        {
            // TODO:  Add DataGridViewControl.InitializeApplication implementation
        }

        public HostedToolBarElement[] GetToolBarElements()
        {
            ArrayList objElements = new ArrayList();
            objElements.Add(new HostedToolBarButton("Copy", new IconResourceHandle("Copy.gif"), "Copy"));
            objElements.Add(new HostedToolBarSeperator());
            objElements.Add(new HostedToolBarButton("Properties", new IconResourceHandle("Properties.gif"), "Properties"));
            objElements.Add(new HostedToolBarSeperator());
            objElements.Add(new HostedToolBarButton("Help", new IconResourceHandle("Help.gif"), "Help"));
            return (HostedToolBarElement[])objElements.ToArray(typeof(HostedToolBarElement));
        }

        public void OnToolBarButtonClick(HostedToolBarButton objButton, EventArgs objEvent)
        {            
            string strAction = (string)objButton.Tag;
            switch (strAction)
            {
                case "Copy":
                    // Copy the clipboard content to the clipboard
                    Clipboard.SetDataObject(this.DataGridView1.GetClipboardContent(TextDataFormat.Html));
                    // Send to client and clear clipboard
                    Clipboard.Update(TextDataFormat.Html);
                    break;                    
                case "Properties":
                    InspectorForm objInspectorForm = new InspectorForm();
                    objInspectorForm.SetControls(this.DataGridView1);
                    objInspectorForm.ShowDialog();
                    break;
                case "Help":
                    Help.ShowHelp(this, CatalogSettings.ProjectCHM, HelpNavigator.KeywordIndex, "DataGridView class");
                    break;
            }
        }

        #endregion
    }
}