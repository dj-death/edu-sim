using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EduSim.CoreFramework.Common;
using EduSim.CoreFramework.DTO;
using Gizmox.WebGUI.Forms;
using EduSim.CoreUtilities.Utility;
using System.Data;

namespace EduSim.CoreFramework.DataControls
{
    public class RnDDataModel : RoundDataModel
    {
        private List<DateTime> C = new List<DateTime>();
        private List<DateTime> D = new List<DateTime>();
        private List<double> E = new List<double>();
        private List<double> F = new List<double>();
        private List<double> G = new List<double>();
        private List<double> H = new List<double>();
        private List<double> I = new List<double>();
        private List<double> J = new List<double>();
        private List<double> K = new List<double>();
        private List<double> L = new List<double>();
        private List<double> M = new List<double>();

        public override void GetList(DataGridView dataGridView1)
        {
            Dictionary<string, RnDDataView> dic = RoundDataModel.GetData<RnDDataView>(SessionConstant.RnDData);

            dic.Values.ToList<RnDDataView>().ForEach(o =>
            {
                C.Add(o.PreviousRevisionDate);
                D.Add(o.RevisionDate);
                E.Add(o.PreviousAge);
                F.Add(o.Age);
                G.Add(o.PreviousReliability);
                H.Add(o.Reliability);
                I.Add(o.PreviousPerformance);
                J.Add(o.Performance);
                K.Add(o.PreviousSize);
                L.Add(o.Size);
                M.Add(o.RnDCost);
            });

            DataTable table = dic.Values.ToDataTable<RnDDataView>(null).Transpose();

            dataGridView1.DataSource = table;
        }

        public override int[] HiddenColumns()
        {
            return new int[]  { 0, 1, 2, 3, 4, 5, 7, 9, 11 };
        }

        protected override void HandleDataChange(DataGridView dataGridView1, DataGridViewRow row, DataGridViewCell c, double oldValue)
        {
            int colIndex = c.ColumnIndex - 1;
            H[colIndex] = dataGridView1.Rows[6].Cells[c.ColumnIndex].Value.ToDouble2(); //Reliability
            J[colIndex] = dataGridView1.Rows[8].Cells[c.ColumnIndex].Value.ToDouble2(); //Performance
            L[colIndex] = dataGridView1.Rows[10].Cells[c.ColumnIndex].Value.ToDouble2(); //Size
            //M[i] = (double)r.Cells[12].Value;//RnDCost

            //Fix the following bug like
            //with negative value like Capacity sold is at depreciated value
            //reduce of performance, reliability, size also cost money
            //RnD Cost: (H2-G2)*$B$9+ (J2-I2)*$B$10 + (K2-L2)*$B$11
            M[colIndex] = GetCost(H[colIndex], G[colIndex], configurationInfo["ReliabilityCost"]) + 
                GetCost(J[colIndex], I[colIndex], configurationInfo["PerformanceCost"]) +
                GetCost(L[colIndex], K[colIndex], configurationInfo["SizeCost"], false);
            
            dataGridView1.Rows[11].Cells[c.ColumnIndex].Value = M[colIndex].ToString("###0.00");

            //Age: =IF(M2=0, E2, (E2+((H2-G2)*$B$14+(J2-I2)*$B$13+(K2-L2)*$B$12)/365)/2)
            double val = (M[colIndex] == 0.0) ? E[colIndex] : (E[colIndex] + ((H[colIndex] - G[colIndex]) * configurationInfo["ReliabilityFactor"] +
                (J[colIndex] - I[colIndex]) * configurationInfo["PerformanceFactor"] + (K[colIndex] - L[colIndex]) * configurationInfo["SizeFactor"]) / 365) / 2;

            dataGridView1.Rows[4].Cells[c.ColumnIndex].Value = val.ToString("###0.0");

            //RevisionDate: =C2+(H2-G2)*$B$14+(J2-I2)*$B$13+(K2-L2)*$B$12
            DateTime dt = C[colIndex].AddDays((H[colIndex] - G[colIndex]) * configurationInfo["ReliabilityFactor"] +
                (J[colIndex] - I[colIndex]) * configurationInfo["PerformanceFactor"] + (K[colIndex] - L[colIndex]) * configurationInfo["SizeFactor"]);
            dataGridView1.Rows[2].Cells[c.ColumnIndex].Value = dt;

            Dictionary<string, RnDDataView> dic = GetData<RnDDataView>(SessionConstant.RnDData);
            dic[dataGridView1.Columns[c.ColumnIndex].HeaderText].Reliability = H[colIndex];
            dic[dataGridView1.Columns[c.ColumnIndex].HeaderText].Performance = J[colIndex];
            dic[dataGridView1.Columns[c.ColumnIndex].HeaderText].Size = L[colIndex];
            dic[dataGridView1.Columns[c.ColumnIndex].HeaderText].RnDCost = M[colIndex];
            dic[dataGridView1.Columns[c.ColumnIndex].HeaderText].Age = val;
            dic[dataGridView1.Columns[c.ColumnIndex].HeaderText].RevisionDate = dt;
        }

        public override void AddProduct(DataGridView dataGridView1)
        {
            base.AddProduct(dataGridView1);
        }
    }
}
