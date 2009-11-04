using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EduSim.WebGUI.UI.BindedGrid
{
    public class RnDDataView
    {
        public string ProductName { get; set; }
        public string ProductCategory { get; set; }
        public DateTime PreviousRevisionDate { get; set; }
        public DateTime RevisionDate { get; set; }
        public double PreviousAge { get; set; }
        public double Age { get; set; }
        public double PreviousReliability { get; set; }
        public double Reliability { get; set; }
        public double PreviousPerformance { get; set; }
        public double Performance { get; set; }
        public double PreviousSize { get; set; }
        public double Size { get; set; }
        public double RnDCost { get; set; }
    }

    public class MarketingDataView
    {
       public string ProductName { get; set; }
       public string ProductCategory { get; set; }
       public double PreviousUnitPrice { get; set; }
       public double UnitPrice { get; set; }
       public double PreviousSalesExpense { get; set; }
       public double SalesExpense { get; set; }
       public double PreviousMarketingExpense { get; set; }
       public double MarketingExpense { get; set; }
       public double PreviousForecastingQuantity { get; set; }
       public double ForecastedQuantity { get; set; }
       public double ProjectedSales { get; set; }
    }

    public class ProductionDataView
    {
        public string ProductName { get; set; }
        public string ProductCategory { get; set; }
        public double Inventory { get; set; }
        public double ForecastedQuantity { get; set; }
        public double TotalQuantity { get; set; }
        public double ManufacturedQuantity { get; set; }
        public double MaterialCost { get; set; }
        public double LabourRate { get; set; }
        public double LabourCost { get; set; }
        public double ContributionMargin { get; set; }
        public double SecondShift { get; set; }
        public double OldAutomation { get; set; }
        public double NewAutomation { get; set; }
        public double AutomationCost { get; set; }
        public double Capacity { get; set; }
        public double NewCapacity { get; set; }
        public double NewCapacityCost { get; set; }
        public double NumberOfLabour { get; set; }
        public double Utilization { get; set; }
    }
}
