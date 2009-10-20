using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gizmox.WebGUI.Forms;
using System.Drawing;
using System.Data;
using EduSim.CoreFramework.Common;
using System.Reflection;
using EduSim.CoreFramework.DTO;

namespace EduSim.CoreFramework.Common
{
    [Serializable]
    public enum BrixControl
    {
        TextBox,
        CheckedListBox,
        CheckBox,
        ComboBox,
        Grid
    }

    public class ControlFactory
    {
        public static void CreateControl(List<Control> list, ref int count, 
            BrixMainForm brixMainForm, 
            BrixDataEntry dataEntry, 
            DataTable table)
        {
            switch (dataEntry.BrixControl)
            {
                case BrixControl.TextBox:
                    CreateTextBoxControl(list, ref count, dataEntry, table);
                    break;
                case BrixControl.CheckedListBox:
                    CreateCheckedListBoxControl(list, ref count, brixMainForm, dataEntry, table);
                    break;
                case BrixControl.CheckBox:
                    CreateCheckBoxControl(list, ref count, dataEntry, table);
                    break;
                case BrixControl.ComboBox:
                    CreateListBoxControl(list, ref count, brixMainForm, dataEntry, table);
                    break;
                default:
                    break;
            }
        }

        private static void CreateListBoxControl(List<Control> list, 
            ref int count, 
            BrixMainForm brixMainForm, 
            BrixDataEntry dataEntry, 
            DataTable table)
        {
            ComboBox comboBox = new ComboBox();

            comboBox.Location = dataEntry.IsFirstColumn ? new Point(100, count * 25) : new Point(280, count * 25);

            comboBox.Name = dataEntry.Name; ;
            comboBox.Size = new System.Drawing.Size(100, 20);
            comboBox.TabIndex = count;

            Type type = Type.GetType(brixMainForm.HandlerClass);
            MethodInfo miHandler = type.GetMethod(dataEntry.DataSource, BindingFlags.Public | BindingFlags.Static);

            miHandler.Invoke(null, new object[] { comboBox, dataEntry, table });

            list.Add(comboBox);
            count++;
        }

        private static void CreateCheckBoxControl(List<Control> list, ref int count, BrixDataEntry dataEntry, DataTable table)
        {
            CheckBox checkBox = new CheckBox();

            checkBox.Location = dataEntry.IsFirstColumn ? new Point(100, count * 25) : new Point(280, count * 25);

            checkBox.Name = dataEntry.Name; ;
            checkBox.Size = new System.Drawing.Size(80, 16);
            checkBox.TabIndex = count;

            if (table != null && table.Rows.Count > 0)
            {
                checkBox.Checked = (bool)table.Rows[0][dataEntry.Name] ;
            }
            list.Add(checkBox);
            count++;
        }

        //TODO: We need to build a framework to create a control
        public static void CreateTextBoxControl(List<Control > list, ref int count, BrixDataEntry dataEntry, DataTable table)
        {
            TextBox textBox = new TextBox();

            textBox.Location = dataEntry.IsFirstColumn ? new Point(100, count * 25) : new Point(280, count * 25);

            textBox.Name = dataEntry.Name; ;
            textBox.Size = new System.Drawing.Size(80, 16);
            textBox.TabIndex = count;
            if (dataEntry.IsPassword)
            {
            }
            if (table != null && table.Rows.Count > 0)
            {
                textBox.Text = table.Rows[0][dataEntry.Name] as string;
            }
            textBox.WordWrap = false;
            list.Add(textBox);
            count++;
        }

        internal static void CreateCheckedListBoxControl(List<Control> list,
            ref int count,
            BrixMainForm brixMainForm,
            BrixDataEntry dataEntry,
            DataTable table)
        {
            CheckedListBox checkedListBox = new CheckedListBox();

            checkedListBox.Location = dataEntry.IsFirstColumn ? new Point(100, count * 25) : new Point(280, count * 25);

            checkedListBox.Name = dataEntry.Name; ;
            checkedListBox.Size = new System.Drawing.Size(160, 100);
            checkedListBox.TabIndex = count;

            Type type = Type.GetType(brixMainForm.HandlerClass);
            MethodInfo miHandler = type.GetMethod(dataEntry.DataSource, BindingFlags.Public | BindingFlags.Static);

            miHandler.Invoke(null, new object[] { checkedListBox, dataEntry, table });

            list.Add(checkedListBox);

            count += 6;
        }

        public static void UpdateData(List<Control> list, BrixMainForm brixMainForm, string filter)
        {
            int count = 0;
            string updateData = string.Empty;

            brixMainForm.BrixDataEntries.ForEach(o =>
                updateData += o.Name + "='" + list[count++].Text + "',"
            );

            updateData = updateData.Remove(updateData.Length - 1, 1);
            CoreDatabaseHelper.GenericLibraryUpdate(updateData, filter, brixMainForm.TableName);
        }

        public static void FireSaveEvent(List<Control> list, BrixMainForm brixMainForm, string filter)
        {
            Type type = Type.GetType(brixMainForm.HandlerClass);
            MethodInfo miHandler = type.GetMethod(brixMainForm.SaveEvent, BindingFlags.Public | BindingFlags.Static);
            
            miHandler.Invoke(null, new object[] { list, brixMainForm, filter});
        }

        public static void InsertData(List<Control> list, BrixMainForm brixMainForm)
        {
            string columnNames = string.Empty;
            string values = string.Empty;

            brixMainForm.BrixDataEntries.ForEach(o =>
                columnNames += o.Name + ",");

            int count = 0;
            brixMainForm.BrixDataEntries.ForEach(o =>
            {
                values += "'" + list[count++].Text + "',";
            });

            columnNames = columnNames.Remove(columnNames.Length - 1, 1);
            values = values.Remove(values.Length - 1, 1);
            CoreDatabaseHelper.GenericLibraryInsert(columnNames, values, brixMainForm.TableName);
        }
    }

}
