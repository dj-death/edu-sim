using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EduSim.CoreFramework.DTO
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

    public class FinanceDataView
    {
        public string RoundName { get; set; }
        public double TotalLongTermLoan { get; set; }
        public double CurrentTotalLongTermLoan { get; set; }
        public double LongTermLoan { get; set; }
        public double TotalShortTermLoan { get; set; }
        public double CurrentTotalShortTermLoan { get; set; }
        public double ShortTermLoan { get; set; }
        public double PreviousCash { get; set; }
        public double Cash { get; set; }
    }

    public class LabourDataView
    {
        public string RoundName { get; set; }
        public double PreviousNumberOfLabour { get; set; }
        public double NumberOfLabour { get; set; }
        public double PreviousAnnualRaise { get; set; }
        public double AnnualRaise { get; set; }
        public double PreviousRate { get; set; }
        public double Rate { get; set; }
        public double PreviousProfitSharing { get; set; }
        public double ProfitSharing { get; set; }
        public double PreviousBenefits { get; set; }
        public double Benefits { get; set; }
    }

    public class CurrentRoundForecast
    {
        public int SegmentTypeId { get; set; }
        public double Quantity { get; set; }
    }

    public class CurrentRoundDemand
    {
        public int SegmentTypeId { get; set; }
        public double Quantity { get; set; }
        public double Performance { get; set; }
        public double Size { get; set; }
    }

    public class CurrentRoundProductWiseInformation
    {
        public int RoundCategoryId { get; set; }
        public int RoundProductId { get; set; }
        public int ComputerRoundProductId { get; set; }
        public int SegmentTypeId { get; set; }
        public bool Purchased { get; set; }
        public double PurchasedQuantity { get; set; }
        public double ForecastedQuantity { get; set; }
        public double Ranking { get; set; }
        public double Age { get; set; }
        public int AgeRating { get; set; }
        public double Performance { get; set; }
        public int PerformanceRating { get; set; }
        public double Size { get; set; }
        public int SizeRating { get; set; }
        public double Reliability { get; set; }
        public int ReliabilityRating { get; set; }
        public double SalesExpense { get; set; }
        public double MarketingExpense { get; set; }
        public int ClientAwarenessRating { get; set; }
        public double Price { get; set; }
        public int PriceRating { get; set; }

        public override string ToString()
        {
            return RoundProductId + "," +
                ComputerRoundProductId + "," +
                SegmentTypeId + "," +
                Purchased + "," +
                PurchasedQuantity + "," +
                ForecastedQuantity + "," +
                Ranking + "," +
                Age + "," +
                AgeRating + "," +
                Performance + "," +
                PerformanceRating + "," +
                Size + "," +
                SizeRating + "," +
                Reliability + "," +
                ReliabilityRating + "," +
                SalesExpense + "," +
                MarketingExpense + "," +
                ClientAwarenessRating + "," +
                Price + "," +
                PriceRating;
        }
    }
}
