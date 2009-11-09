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

        internal static void SaveSessionData(Round round)
        {
            Dictionary<string, RnDDataView> dic = RoundDataModel.GetData<RnDDataView>(SessionConstants.RnDData);

            Edusim db = new Edusim();

            (from r in db.RnDData
             join rp in db.RoundProduct on r.RoundProduct equals rp
             where rp.Round == round
             select r).ToList<RnDData>().ForEach(o =>
             {
                 o.RevisionDate = dic[o.RoundProduct.ProductName].RevisionDate;
                 o.Age = dic[o.RoundProduct.ProductName].Age;
                 o.Performance = dic[o.RoundProduct.ProductName].Performance;
                 o.Size = dic[o.RoundProduct.ProductName].Size;
                 o.RnDCost = dic[o.RoundProduct.ProductName].RnDCost;
             });

            Dictionary<string, MarketingDataView> dic1 = RoundDataModel.GetData<MarketingDataView>(SessionConstants.MarketingData);

            (from r in db.MarketingData
             join rp in db.RoundProduct on r.RoundProduct equals rp
             where rp.Round == round
             select r).ToList<MarketingData>().ForEach(o =>
             {
                 o.Price = dic1[o.RoundProduct.ProductName].UnitPrice;
                 o.SalesExpense = dic1[o.RoundProduct.ProductName].SalesExpense;
                 o.MarketingExpense = dic1[o.RoundProduct.ProductName].MarketingExpense;
                 o.ForecastingQuantity = dic1[o.RoundProduct.ProductName].ForecastedQuantity;
             });

            Dictionary<string, ProductionDataView> dic2 = RoundDataModel.GetData<ProductionDataView>(SessionConstants.ProductionData);

            (from r in db.ProductionData
             join rp in db.RoundProduct on r.RoundProduct equals rp
             where rp.Round == round
             select r).ToList<ProductionData>().ForEach(o =>
             {
                 o.AutomationForNextRound = dic2[o.RoundProduct.ProductName].NewAutomation;
                 o.AutomationCost = dic2[o.RoundProduct.ProductName].AutomationCost;
                 o.NewCapacity = dic2[o.RoundProduct.ProductName].NewCapacity;
                 o.NewCapacityCost = dic2[o.RoundProduct.ProductName].NewCapacityCost;
                 o.LabourRate = dic2[o.RoundProduct.ProductName].LabourRate;
                 o.LabourCost = dic2[o.RoundProduct.ProductName].LabourCost;
                 o.MaterialCost = dic2[o.RoundProduct.ProductName].MaterialCost;
                 o.ManufacturedQuantity = dic2[o.RoundProduct.ProductName].ManufacturedQuantity;
                 o.SecondShift = dic2[o.RoundProduct.ProductName].SecondShift;
                 o.Utilization = dic2[o.RoundProduct.ProductName].Utilization;
                 o.NumberOfLabour = dic2[o.RoundProduct.ProductName].NumberOfLabour;
                 o.Contribution = dic2[o.RoundProduct.ProductName].ContributionMargin;
             });

            Dictionary<string, FinanceDataView> dic3 = RoundDataModel.GetData<FinanceDataView>(SessionConstants.FinanceData);

            (from f in db.FinanceData
             where f.Round == round
             select f).ToList<FinanceData>().ForEach(o =>
             {
                 o.LongTermLoan = dic3[o.Round.RoundCategory.RoundName].LongTermLoan;
                 o.Cash = dic3[o.Round.RoundCategory.RoundName].Cash;
                 o.ShortTermLoan = dic3[o.Round.RoundCategory.RoundName].ShortTermLoan;
             });

            db.SubmitChanges();
        }
    }
}
