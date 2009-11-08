using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EduSim.WebGUI.UI.BindedGrid;
using EduSim.CoreFramework.DTO;
using EduSim.CoreFramework.Common;

namespace EduSim.CoreFramework.Utilities
{
    internal static class SessionManager
    {
        internal static Dictionary<string, RnDDataView> SetRnDDataToSession(string sessionStr, Round round)
        {
            Dictionary<string, RnDDataView> dic = RoundDataModel.GetData<RnDDataView>(sessionStr);

            if (dic.Count == 0)
            {
                Edusim db = new Edusim();
                IQueryable<RnDDataView> rs = from r in db.RnDData
                                             join rp in db.RoundProduct on r.RoundProduct equals rp
                                             where rp.Round == round
                                             select new RnDDataView()
                                             {
                                                 ProductName = rp.ProductName,
                                                 ProductCategory = rp.SegmentType.Description,
                                                 PreviousRevisionDate = r.PreviousRevisionDate,
                                                 RevisionDate = r.PreviousRevisionDate,
                                                 PreviousAge = r.PreviousAge,
                                                 Age = r.PreviousAge,
                                                 PreviousReliability = r.PreviousReliability,
                                                 Reliability = r.PreviousReliability,
                                                 PreviousPerformance = r.PreviousPerformance,
                                                 Performance = r.PreviousPerformance,
                                                 PreviousSize = r.PreviousSize,
                                                 Size = r.PreviousSize,
                                                 RnDCost = 0.0
                                             };

                rs.ToList<RnDDataView>().ForEach(o =>
                {
                    dic[o.ProductName] = o;
                });
            }

            return dic;
        }

        internal static Dictionary<string, MarketingDataView> SetMarketingDataToSession(string sessionData, Round round)
        {
            Dictionary<string, MarketingDataView> dic = RoundDataModel.GetData<MarketingDataView>(sessionData);

            if (dic.Count == 0)
            {
                Edusim db = new Edusim();
                (from m in db.MarketingData
                 join rp in db.RoundProduct on m.RoundProduct equals rp
                 where rp.Round == round
                 select new MarketingDataView()
                 {
                     ProductName = rp.ProductName,
                     ProductCategory = rp.SegmentType.Description,
                     PreviousUnitPrice = m.PreviousPrice,
                     UnitPrice = m.Price.HasValue ? m.Price.Value : 0.0,
                     PreviousSalesExpense = m.PreviousSaleExpense,
                     SalesExpense = m.SalesExpense.HasValue ? m.SalesExpense.Value : 0.0,
                     PreviousMarketingExpense = m.PreviousMarketingExpense,
                     MarketingExpense = m.MarketingExpense.HasValue ? m.MarketingExpense.Value : 0.0,
                     PreviousForecastingQuantity = m.PreviousForecastingQuantity,
                     ForecastedQuantity = m.ForecastingQuantity.HasValue ? m.ForecastingQuantity.Value : 0.0,
                     ProjectedSales = 0.0
                 }).ToList<MarketingDataView>().ForEach(o => dic[o.ProductName] = o);
            }

            return dic;
        }

        internal static Dictionary<string, ProductionDataView> SetProductionDataToSession(string sessionData, Round round)
        {
            Dictionary<string, ProductionDataView> dic = RoundDataModel.GetData<ProductionDataView>(sessionData);

            if (dic.Count == 0)
            {
                Edusim db = new Edusim();
                IQueryable<ProductionDataView> rs = from p in db.ProductionData
                                                    join rp in db.RoundProduct on p.RoundProduct equals rp
                                                    join m in db.MarketingData on p.RoundProduct equals m.RoundProduct
                                                    where rp.Round == round
                                                    select new ProductionDataView()
                                                    {
                                                        ProductName = rp.ProductName,
                                                        ProductCategory = rp.SegmentType.Description,
                                                        Inventory = p.Inventory,
                                                        ForecastedQuantity = m.ForecastingQuantity.HasValue ? m.ForecastingQuantity.Value : 0.0,
                                                        TotalQuantity = p.Inventory + (m.ForecastingQuantity.HasValue ? m.ForecastingQuantity.Value : 0.0),
                                                        ManufacturedQuantity = p.ManufacturedQuantity,
                                                        MaterialCost = 0,
                                                        LabourRate = 0,
                                                        ContributionMargin = p.Contribution.HasValue ? p.Contribution.Value : 0.0,
                                                        SecondShift = 0.0,
                                                        OldAutomation = p.CurrentAutomation,
                                                        NewAutomation = p.AutomationForNextRound.HasValue ? p.AutomationForNextRound.Value : p.CurrentAutomation,
                                                        AutomationCost = 0.0,
                                                        Capacity = p.OldCapacity,
                                                        NewCapacity = p.NewCapacity.HasValue ? p.NewCapacity.Value : 0.0,
                                                        NewCapacityCost = 0,
                                                        NumberOfLabour = 0,
                                                        Utilization = 0,
                                                        LabourCost = 0,
                                                    };

                rs.ToList<ProductionDataView>().ForEach(o =>
                {
                    dic[o.ProductName] = o;
                });
            }
            return dic;
        }

        internal static Dictionary<string, FinanceDataView> SetFinanceDataToSession(string sessionData, Round round)
        {
            Dictionary<string, FinanceDataView> dic = RoundDataModel.GetData<FinanceDataView>(sessionData);

            if (dic.Count == 0)
            {
                Edusim db = new Edusim();

                (from f in db.FinanceData
                 where f.Round == round
                 select new FinanceDataView
                 {
                     RoundName = f.Round.RoundCategory.RoundName,
                     PreviousLongTermLoan = f.PreviousLongTermLoan,
                     LongTermLoan = f.LongTermLoan,
                     PreviousShortTermLoan = f.PreviousShortTermLoan,
                     ShortTermLoan = f.ShortTermLoan,
                     OriganalCash = f.Cash,
                     Cash = f.Cash + f.LongTermLoan + f.ShortTermLoan
                 }).ToList<FinanceDataView>().ForEach(o => dic[round.RoundCategory.RoundName] = o);
            }
            return dic;
        }
    }
}
