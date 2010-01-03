using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EduSim.CoreFramework.DTO;
using System.Data.Linq;
using EduSim.CoreFramework.Common;
using EduSim.CoreFramework.DataControls;
using Gizmox.WebGUI.Forms;

namespace EduSim.CoreFramework.BusinessLayer
{
    static class GameHelper
    {
        internal static void AddGameInformatoin(Edusim db, TeamGame tg)
        {
            //Create Round
            Round round = new Round() { RoundCategoryId = 1, TeamGame = tg, Current = true };
            db.Round.InsertOnSubmit(round);

            IQueryable<ProductCategory> pcs = from pc in db.ProductCategory
                                              where pc.TeamCategoryId == tg.Team.TeamCategoryId
                                              select pc;

            (from g in db.GameInitialData
             select g).ToList<GameInitialData>().ForEach(o1 =>
             {
                 ProductCategory pc = (from p in pcs
                                       where p.SegmentTypeId == o1.SegmentTypeId
                                       select p).FirstOrDefault<ProductCategory>();

                 //Create RoundProduct 
                 RoundProduct rp = new RoundProduct()
                 {
                     Round = round,
                     ProductName = pc.ProductName,
                     SegmentType = o1.SegmentType
                 };
                 db.RoundProduct.InsertOnSubmit(rp);
                 //Create RnDData
                 RnDData rd = new RnDData()
                 {
                     RoundProduct = rp,
                     PreviousAge = o1.AgeDec31,
                     PreviousPerformance = o1.Performance,
                     PreviousReliability = o1.Reliability,
                     PreviousRevisionDate = o1.RevisionDate,
                     PreviousSize = o1.Size,
                 };
                 db.RnDData.InsertOnSubmit(rd);
                 //Create MarketingData
                 MarketingData md = new MarketingData()
                 {
                     RoundProduct = rp,
                     PreviousSaleExpense = o1.SalesExpense,
                     PreviousMarketingExpense = o1.MarketingExpense,
                     PreviousPrice = o1.Price,
                     PreviousForecastingQuantity = o1.UnitInventory,
                 };
                 db.MarketingData.InsertOnSubmit(md);
                 //Create ProductionData
                 ProductionData pd = new ProductionData()
                 {
                     RoundProduct = rp,
                     PreviousNumberOfLabour = 0,
                     OldCapacity = o1.CapacityForNextRound,
                     Inventory = o1.UnitInventory,
                     CurrentAutomation = o1.AutomationForNextRound,
                 };
                 db.ProductionData.InsertOnSubmit(pd);
             }
                                                );

            (from g in db.GameInitialFinanceData
             select g).ToList<GameInitialFinanceData>().ForEach(o1 =>
             {
                 FinanceData fd = new FinanceData()
                 {
                     Round = round,
                     Cash = o1.Cash,
                 };
                 db.FinanceData.InsertOnSubmit(fd);
             });

            (from g in db.LabourGameInitialData
             select g).ToList<LabourGameInitialData>().ForEach(o1 =>
             {
                 LabourData ld = new LabourData()
                 {
                     Round = round,
                     PreviousRate = o1.PreviousRate,
                     PreviousBenefits = o1.Benefits.HasValue ? o1.Benefits.Value : 0.0,
                     PreviousProfitSharing = o1.ProfitSharing.HasValue ? o1.ProfitSharing.Value : 0.0,
                     PreviousAnnualRaise = o1.AnnualRaise.HasValue ? o1.AnnualRaise.Value : 0.0,
                     PreviousNumberOfLabour = o1.PreviousNumberOfLabour,
                     Rate = o1.PreviousRate,
                     Benefits = o1.Benefits,
                     ProfitSharing = o1.ProfitSharing,
                     AnnualRaise = o1.AnnualRaise,
                     NumberOfLabour = o1.PreviousNumberOfLabour
                 };
                 db.LabourData.InsertOnSubmit(ld);
             });
        }

        internal static void AddRoundInformation(Edusim db, Round round)
        {
            //Create Round 2 and copy all previous information to Round 2values 
            Round round2 = new Round
            {
                RoundCategoryId = round.RoundCategoryId + 1,
                TeamGame = round.TeamGame,
                Current = true
            };
            db.Round.InsertOnSubmit(round2);

            //copy previous RnD data
            IQueryable<RoundProduct> roundProduct = from r in db.RoundProduct
                                                    where r.Round == round
                                                    select r;

            foreach (RoundProduct rval in roundProduct)
            {
                RoundProduct data = new RoundProduct
                {
                    ProductName = rval.ProductName,
                    Round = round2,
                    SegmentType = rval.SegmentType
                };
                db.RoundProduct.InsertOnSubmit(data);

                //copy previous RnD data
                RnDData rndval = (from r in db.RnDData
                                  where r.RoundProduct == rval
                                  select r).FirstOrDefault();

                RnDData data1 = new RnDData
                {
                    PreviousAge = rndval.Age.HasValue ? rndval.Age.Value : 0.0,
                    PreviousPerformance = rndval.Performance.HasValue ? rndval.Performance.Value : 0.0,
                    PreviousReliability = rndval.Reliability.HasValue ? rndval.Reliability.Value : 0.0,
                    PreviousRevisionDate = rndval.RevisionDate.HasValue ? rndval.RevisionDate.Value : DateTime.Now,
                    PreviousSize = rndval.Size.HasValue ? rndval.Size.Value : 0.0,
                    RoundProduct = data
                };
                db.RnDData.InsertOnSubmit(data1);

                //copy previous Marketing data
                MarketingData mktData = (from m in db.MarketingData
                                         where m.RoundProduct == rval
                                         select m).FirstOrDefault();
                MarketingData data2 = new MarketingData
                {
                    PreviousSaleExpense = mktData.SalesExpense.HasValue ? mktData.SalesExpense.Value : 0.0,
                    PreviousMarketingExpense = mktData.MarketingExpense.HasValue ? mktData.MarketingExpense.Value : 0.0,
                    PreviousForecastingQuantity = mktData.ForecastingQuantity.HasValue ? mktData.ForecastingQuantity.Value : 0.0,
                    PreviousPrice = mktData.Price.HasValue ? mktData.Price.Value : 0.0,
                    RoundProduct = data
                };
                db.MarketingData.InsertOnSubmit(data2);

                //copy previous Production data
                ProductionData prodData = (from p in db.ProductionData
                                           where p.RoundProduct == rval
                                           select p).FirstOrDefault();

                ProductionData data3 = new ProductionData
                {
                    PreviousNumberOfLabour = prodData.NumberOfLabour.HasValue ? prodData.NumberOfLabour.Value : 0.0,
                    OldCapacity = prodData.OldCapacity + (prodData.NewCapacity.HasValue ? prodData.NewCapacity.Value : 0.0),
                    CurrentAutomation = prodData.AutomationForNextRound.HasValue ? prodData.AutomationForNextRound.Value : 0.0,
                    Inventory = prodData.ManufacturedQuantity - (mktData.PurchasedQuantity.HasValue ? mktData.PurchasedQuantity.Value : 0.0),
                    RoundProduct = data
                };
                db.ProductionData.InsertOnSubmit(data3);

            }

            PnLDataModel model = new PnLDataModel();
            model.GetList(new DataGridView ());

            Dictionary<string, ProductionDataView> productionData = RoundDataModel.GetData<ProductionDataView>(SessionConstant.ProductionData, round.Id);
            double investmentsInPlantAndMachinary = 0;
            foreach (string product in productionData.Keys)
            {
                investmentsInPlantAndMachinary += productionData[product].NewCapacityCost;
                investmentsInPlantAndMachinary += productionData[product].AutomationCost;
            }

            //copy previous RnD data
            FinanceData oldFinData = (from o in db.FinanceData
                                      where o.Round == round
                                      select o).FirstOrDefault();
            //TODO: 4. Finance Data, Plugh back the revenue to cash
            FinanceData finData = new FinanceData
            {
                //PreviousCash is NetProfit + LongTermLoan - ShorttermLoan - investmentsInPlantAndMachinary + StockSell - StockRetire - DividantPaid
                PreviousCash = model.data[model.netProfitIndex] + 
                oldFinData.LongTermLoan - oldFinData.ShortTermLoan +
                investmentsInPlantAndMachinary + 
                oldFinData.StockSell - 
                oldFinData.StockBuyBack - 
                oldFinData.DividendPerShare,

                Round = round2
            };
            db.FinanceData.InsertOnSubmit(finData);

            //Labour Data
            LabourData oldLibData = (from o in db.LabourData
                                      where o.Round == round
                                      select o).FirstOrDefault();

            LabourData libdata = new LabourData
            {
                PreviousRate = oldLibData.Rate.HasValue ? oldLibData.Rate.Value : 0.0,
                PreviousAnnualRaise = oldLibData.AnnualRaise.HasValue ? oldLibData.AnnualRaise.Value : 0.0,
                PreviousNumberOfLabour = oldLibData.NumberOfLabour.HasValue ? oldLibData.NumberOfLabour.Value : 0.0,
                PreviousBenefits = oldLibData.Benefits.HasValue ? oldLibData.Benefits.Value : 0.0,
                PreviousProfitSharing = oldLibData.ProfitSharing.HasValue ? oldLibData.ProfitSharing.Value : 0.0,
                Rate = oldLibData.Rate.HasValue ? oldLibData.Rate.Value : 0.0,
                AnnualRaise = oldLibData.AnnualRaise.HasValue ? oldLibData.AnnualRaise.Value : 0.0,
                NumberOfLabour = oldLibData.NumberOfLabour.HasValue ? oldLibData.NumberOfLabour.Value : 0.0,
                Benefits = oldLibData.Benefits.HasValue ? oldLibData.Benefits.Value : 0.0,
                ProfitSharing = oldLibData.ProfitSharing.HasValue ? oldLibData.ProfitSharing.Value : 0.0,
                Round = round2
            };
            db.LabourData.InsertOnSubmit(libdata);
        }

        internal static StringBuilder BuildSqlError(ChangeConflictException e)
        {
            StringBuilder builder = new StringBuilder();

            foreach (string str in e.InnerException.Data)
            {
                builder.Append(str);
            }

            return builder;
        }
    }
}
