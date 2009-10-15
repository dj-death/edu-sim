using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gizmox.WebGUI.Forms;
using System.Drawing;
using System.Data;
using EduSim.CoreFramework.Common;

namespace EduSim.WebGUI.UI
{
    public class ControlFactory
    {
        //TODO: We need to build a framework to create a control
        public static void CreateTextBoxControl(List<TextBox> textBoxs, int count, BrixDataEntry dataEntry, DataTable table)
        {
            TextBox textBox = new TextBox();

            textBox.Location = dataEntry.IsFirstColumn ? new Point(100, count * 25) : new Point(280, count * 25);

            textBox.Name = "txt" + dataEntry.Name; ;
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
            textBoxs.Add(textBox);
        }
    }
}
