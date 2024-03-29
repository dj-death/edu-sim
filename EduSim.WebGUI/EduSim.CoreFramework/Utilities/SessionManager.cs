﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EduSim.CoreFramework.DTO;
using EduSim.CoreFramework.Common;
using System.Data.Linq;
using EduSim.CoreFramework.BusinessLayer;
using EduSim.CoreFramework.DataControls;
using Gizmox.WebGUI.Forms;

namespace EduSim.CoreFramework.Utilities
{
    internal static class SessionManager
    {
        internal static void SetSessionData(Round o)
        {
            SessionManager.SetLabourDataToSession(SessionConstant.LabourData, o);
            SessionManager.SetRnDDataToSession(SessionConstant.RnDData, o);
            SessionManager.SetMarketingDataToSession(SessionConstant.MarketingData, o);
            SessionManager.SetProductionDataToSession(SessionConstant.ProductionData, o);
            SessionManager.SetFinanceDataToSession(SessionConstant.FinanceData, o);
        }

        internal static Dictionary<string, RnDDataView> SetRnDDataToSession(SessionConstant sessionStr, Round round)
        {
            Dictionary<string, RnDDataView> dic = RoundDataModel.GetData<RnDDataView>(sessionStr, round.Id);

            if (dic.Count == 0)
            {
                Edusim db = new Edusim(Constants.ConnectionString);
                IQueryable<RnDDataView> rs = from r in db.RnDData
                                             join rp in db.RoundProduct on r.RoundProduct equals rp
                                             where rp.Round == round
                                             select CopyRndDataToView(r, rp);

                rs.ToList<RnDDataView>().ForEach(o =>
                {
                    dic[o.ProductName] = o;
                });
            }
            return dic;
        }

        public static RnDDataView CopyRndDataToView(RnDData r, RoundProduct rp)
        {
            return new RnDDataView()
            {
                ProductName = rp.ProductName,
                ProductCategory = rp.SegmentType.Description,
                PreviousRevisionDate = r.PreviousRevisionDate,
                RevisionDate = r.RevisionDate.HasValue ? r.RevisionDate.Value : r.PreviousRevisionDate,
                PreviousAge = r.PreviousAge,
                Age = r.Age.HasValue ? r.Age.Value : r.PreviousAge,
                PreviousReliability = r.PreviousReliability,
                Reliability = r.Reliability.HasValue ? r.Reliability.Value : r.PreviousReliability,
                PreviousPerformance = r.PreviousPerformance,
                Performance = r.Performance.HasValue ? r.Performance.Value : r.PreviousPerformance,
                PreviousSize = r.PreviousSize,
                Size = r.Size.HasValue ? r.Size.Value : r.PreviousSize,
                RnDCost = r.RnDCost.HasValue ? r.RnDCost.Value : 0.0
            };
        }

        internal static Dictionary<string, MarketingDataView> SetMarketingDataToSession(SessionConstant sessionData, Round round)
        {
            Dictionary<string, MarketingDataView> dic = RoundDataModel.GetData<MarketingDataView>(sessionData, round.Id);

            if (dic.Count == 0)
            {
                Edusim db = new Edusim(Constants.ConnectionString);
                (from m in db.MarketingData
                 join rp in db.RoundProduct on m.RoundProduct equals rp
                 where rp.Round == round
                 select CopyMarketingDataToView(m, rp)).ToList<MarketingDataView>().ForEach(o => dic[o.ProductName] = o);
            }

            ProductionDataModel pdm = new ProductionDataModel();
            DataGridView data = new DataGridView();
            pdm.GetList(data);

            return dic;
        }

        public static MarketingDataView CopyMarketingDataToView(MarketingData m, RoundProduct rp)
        {
            return new MarketingDataView()
            {
                ProductName = rp.ProductName,
                ProductCategory = rp.SegmentType.Description,
                PreviousUnitPrice = m.PreviousPrice,
                UnitPrice = m.Price.HasValue ? m.Price.Value : m.PreviousPrice,
                PreviousSalesExpense = m.PreviousSaleExpense,
                SalesExpense = m.SalesExpense.HasValue ? m.SalesExpense.Value : m.PreviousSaleExpense,
                PreviousMarketingExpense = m.PreviousMarketingExpense,
                MarketingExpense = m.MarketingExpense.HasValue ? m.MarketingExpense.Value : m.PreviousMarketingExpense,
                PreviousForecastingQuantity = m.PreviousForecastingQuantity,
                ForecastedQuantity = m.ForecastingQuantity.HasValue ? m.ForecastingQuantity.Value : m.PreviousForecastingQuantity,
                ProjectedSales = (m.Price.HasValue ? m.Price.Value : m.PreviousPrice) *
                                   (m.ForecastingQuantity.HasValue ? m.ForecastingQuantity.Value : m.PreviousForecastingQuantity),
                PurchaseQuantity = m.PurchasedQuantity.HasValue ? m.PurchasedQuantity.Value : 0.0
            };
        }

        internal static Dictionary<string, ProductionDataView> SetProductionDataToSession(SessionConstant sessionData, Round round)
        {
            Dictionary<string, ProductionDataView> dic = RoundDataModel.GetData<ProductionDataView>(sessionData, round.Id);

            if (dic.Count == 0)
            {
                Edusim db = new Edusim(Constants.ConnectionString);
                IQueryable<ProductionDataView> rs = from p in db.ProductionData
                                                    join rp in db.RoundProduct on p.RoundProduct equals rp
                                                    join m in db.MarketingData on p.RoundProduct equals m.RoundProduct
                                                    where rp.Round == round
                                                    select CopyProductionDataToView(p, rp, m);

                rs.ToList<ProductionDataView>().ForEach(o =>
                {
                    dic[o.ProductName] = o;
                });
            }
            return dic;
        }

        public static ProductionDataView CopyProductionDataToView(ProductionData p, RoundProduct rp, MarketingData m)
        {
            return new ProductionDataView()
            {
                ProductName = rp.ProductName,
                ProductCategory = rp.SegmentType.Description,
                Inventory = p.Inventory,
                ForecastedQuantity = m.ForecastingQuantity.HasValue ? m.ForecastingQuantity.Value : 0.0,
                TotalQuantity = p.Inventory + (m.ForecastingQuantity.HasValue ? m.ForecastingQuantity.Value : 0.0),
                ManufacturedQuantity = p.ManufacturedQuantity,
                MaterialCost = p.MaterialCost.HasValue ? p.MaterialCost.Value : 0.0,
                LabourRate = p.LabourRate.HasValue ? p.LabourRate.Value : 0.0,
                ContributionMargin = p.Contribution.HasValue ? p.Contribution.Value : 0.0,
                SecondShift = p.SecondShift.HasValue ? p.SecondShift.Value : 0.0,
                OldAutomation = p.CurrentAutomation,
                NewAutomation = p.AutomationForNextRound.HasValue ? p.AutomationForNextRound.Value : p.CurrentAutomation,
                AutomationCost = p.AutomationCost.HasValue ? p.AutomationCost.Value : 0.0,
                Capacity = p.OldCapacity,
                NewCapacity = p.NewCapacity.HasValue ? p.NewCapacity.Value : 0.0,
                NewCapacityCost = p.NewCapacityCost.HasValue ? p.NewCapacityCost.Value : 0.0,
                NumberOfLabour = p.NumberOfLabour.HasValue ? p.NumberOfLabour.Value : 0.0,
                Utilization = p.Utilization.HasValue ? p.Utilization.Value : 0.0,
                LabourCost = p.LabourCost.HasValue ? p.LabourCost.Value : 0.0
            };
        }

        internal static Dictionary<string, FinanceDataView> SetFinanceDataToSession(SessionConstant sessionData, Round round)
        {
            Dictionary<string, FinanceDataView> dic = RoundDataModel.GetData<FinanceDataView>(sessionData, round.Id);

            if (dic.Count == 0)
            {
                Edusim db = new Edusim(Constants.ConnectionString);

                (from f in db.FinanceData
                 where f.Round == round
                 select new FinanceDataView
                 {
                     RoundName = f.Round.RoundCategory.RoundName,
                     StockSell = f.StockSell.HasValue ? f.StockSell.Value : 0.0,
                     StockBuy = f.StockBuyBack.HasValue ? f.StockBuyBack.Value : 0.0,
                     DividandPaid = f.DividendPerShare.HasValue ? f.DividendPerShare.Value : 0.0,
                     LongTermLoan = f.LongTermLoan,
                     RetireLongTermLoan = f.RetireLongTermLoan.HasValue ? f.RetireLongTermLoan.Value : 0.0,
                     ShortTermLoan = f.ShortTermLoan,
                     PreviousCash = f.PreviousCash.HasValue ? f.PreviousCash.Value : 0.0,
                 }).ToList<FinanceDataView>().ForEach(o => dic[round.RoundCategory.RoundName] = o);
            }
            return dic;
        }

        internal static Dictionary<string, LabourDataView> SetLabourDataToSession(SessionConstant sessionData, Round round)
        {
            Dictionary<string, LabourDataView> dic = RoundDataModel.GetData<LabourDataView>(sessionData, round.Id);

            if (dic.Count == 0)
            {

                Edusim db = new Edusim(Constants.ConnectionString);

                (from f in db.LabourData
                 where f.Round == round
                 select new LabourDataView
                 {
                     RoundName = f.Round.RoundCategory.RoundName,
                     PreviousNumberOfLabour = f.PreviousNumberOfLabour,
                     NumberOfLabour = f.NumberOfLabour.HasValue ? f.NumberOfLabour.Value : 0.0,
                     PreviousAnnualRaise = f.PreviousAnnualRaise,
                     AnnualRaise = f.AnnualRaise.HasValue ? f.AnnualRaise.Value : 0.0,
                     PreviousRate = f.PreviousRate,
                     Rate = f.Rate.HasValue ? f.Rate.Value : 0.0,
                     PreviousProfitSharing = f.PreviousProfitSharing,
                     ProfitSharing = f.ProfitSharing.HasValue ? f.ProfitSharing.Value : 0.0,
                     PreviousBenefits = f.PreviousBenefits,
                     Benefits = f.Benefits.HasValue ? f.Benefits.Value : 0.0
                 }).ToList<LabourDataView>().ForEach(o => dic[round.RoundCategory.RoundName] = o);
            }
            return dic;
        }

        internal static void SaveSessionData(Round round)
        {
            Dictionary<string, RnDDataView> dic = RoundDataModel.GetData<RnDDataView>(SessionConstant.RnDData, round.Id);

            try
            {
                Edusim db = new Edusim(Constants.ConnectionString);

                (from r in db.RnDData
                 join rp in db.RoundProduct on r.RoundProduct equals rp
                 where rp.Round == round
                 select r).ToList<RnDData>().ForEach(o =>
                 {
                     o.RevisionDate = dic[o.RoundProduct.ProductName].RevisionDate;
                     o.Age = dic[o.RoundProduct.ProductName].Age;
                     o.Reliability = dic[o.RoundProduct.ProductName].Reliability;
                     o.Performance = dic[o.RoundProduct.ProductName].Performance;
                     o.Size = dic[o.RoundProduct.ProductName].Size;
                     o.RnDCost = dic[o.RoundProduct.ProductName].RnDCost;
                 });

                Dictionary<string, MarketingDataView> dic1 = RoundDataModel.GetData<MarketingDataView>(SessionConstant.MarketingData, round.Id);

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

                Dictionary<string, ProductionDataView> dic2 = RoundDataModel.GetData<ProductionDataView>(SessionConstant.ProductionData, round.Id);

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

                Dictionary<string, FinanceDataView> dic3 = RoundDataModel.GetData<FinanceDataView>(SessionConstant.FinanceData, round.Id);

                (from f in db.FinanceData
                 where f.Round == round
                 select f).ToList<FinanceData>().ForEach(o =>
                 {
                     o.DividendPerShare = dic3[o.Round.RoundCategory.RoundName].DividandPaid;
                     o.StockSell = dic3[o.Round.RoundCategory.RoundName].StockSell;
                     o.StockBuyBack = dic3[o.Round.RoundCategory.RoundName].StockBuy;
                     o.LongTermLoan = dic3[o.Round.RoundCategory.RoundName].LongTermLoan;
                     o.RetireLongTermLoan = dic3[o.Round.RoundCategory.RoundName].RetireLongTermLoan;
                     o.Cash = dic3[o.Round.RoundCategory.RoundName].Cash;
                     o.ShortTermLoan = dic3[o.Round.RoundCategory.RoundName].ShortTermLoan;
                 });

                Dictionary<string, LabourDataView> dic4 = RoundDataModel.GetData<LabourDataView>(SessionConstant.LabourData, round.Id);

                (from f in db.LabourData
                 where f.Round == round
                 select f).ToList<LabourData>().ForEach(o =>
                 {
                     o.NumberOfLabour = dic4[o.Round.RoundCategory.RoundName].NumberOfLabour;
                     o.AnnualRaise = dic4[o.Round.RoundCategory.RoundName].AnnualRaise;
                     o.Rate = dic4[o.Round.RoundCategory.RoundName].Rate;
                     o.ProfitSharing = dic4[o.Round.RoundCategory.RoundName].ProfitSharing;
                     o.Benefits = dic4[o.Round.RoundCategory.RoundName].Benefits;
                 });

                db.SubmitChanges();
            }
            catch (ChangeConflictException e)
            {
                throw new Exception(GameHelper.BuildSqlError(e).ToString());
            }
        }
    }
}
