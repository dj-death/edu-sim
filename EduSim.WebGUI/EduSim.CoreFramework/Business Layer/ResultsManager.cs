using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using EduSim.CoreFramework.DTO;
using EduSim.CoreFramework.Common;
using Gizmox.WebGUI.Forms;
using EduSim.CoreFramework.BusinessLayer;
using System.Data.Linq;

namespace EduSim.Analyse.BusinessLayer
{
    public class ResultsManager
    {
        private List<CurrentRoundForecast> forecastData;
        private List<MarketingData> marketingData;
        private List<RnDData> rndData;
        private List<ComputerMarketingData> computerMarketingData;
        private List<ComputerRnDData> computerRndData;
        private List<CurrentRoundProductWiseInformation> data;
        private List<GameCriteria> gameCriteria;
        private List<RoundCriteria> roundCriteria;

        private ResultsManager(Round round)
        {
            Edusim edusim = new Edusim(Constants.ConnectionString);

            gameCriteria = (from g in edusim.GameCriteria
                            select g).ToList<GameCriteria>();
            roundCriteria = (from r in edusim.RoundCriteria
                             where r.RoundCategoryId == round.RoundCategoryId
                             select r).ToList<RoundCriteria>();
            marketingData = (from m in edusim.MarketingData
                             where m.RoundProduct.Round == round
                             select m).ToList();
            marketingData.ForEach(o =>
            {
                Console.WriteLine(o.RoundProduct.SegmentTypeId + "," + o.PurchasedQuantity + " " + o.ForecastingQuantity);
            });
            rndData = (from r in edusim.RnDData
                       where r.RoundProduct.Round == round
                       select r).ToList();
            computerMarketingData = (from m in edusim.ComputerMarketingData
                                     where m.ComputerRoundProduct.RoundCategory == round.RoundCategory
                                     select m).ToList();
            computerRndData = (from r in edusim.ComputerRnDData
                               where r.ComputerRoundProduct.RoundCategory == round.RoundCategory
                               select r).ToList();
        }

        public static void Run(Round round)
        {
            if (round != null)
            {
                ResultsManager rm = new ResultsManager(round);

                rm.GetForecastedData(round);
                rm.GetPlayersRating(round);

                rm.SetAllQuantityIfDemandMoreThenSupply();

                rm.SetProductRanking();

                Edusim db = new Edusim(Constants.ConnectionString);

                try
                {
                    rm.QuantityPurchased(db);

                    rm.SetNextRoundData(db, round);

                    db.SubmitChanges();
                }
                catch (ChangeConflictException e)
                {
                    throw new Exception(GameHelper.BuildSqlError(e).ToString());
                }
            }
            else
            {
                MessageBox.Show("Please select a valid Round");
            }
        }

        private void SetNextRoundData(Edusim db, Round round)
        {
            //TODO: Mark round.Current as False
            Round round1 = (from r in db.Round
                            where r.Id == round.Id
                            select r).FirstOrDefault();

            round1.Current = false;

            GameHelper.AddRoundInformation(db, round1);
        }

        private void GetForecastedData(Round round)
        {
            var data = (from r in rndData
                        join m in marketingData on r.RoundProduct equals m.RoundProduct
                        where m.RoundProduct.RoundId == round.Id
                        select new
                        {
                            RoundCategoryId = r.RoundProduct.Round.RoundCategoryId,
                            RoundName = r.RoundProduct.Round.RoundCategory.RoundName,
                            SegmentTypeId = r.RoundProduct.SegmentTypeId,
                            SegmentDescription = r.RoundProduct.SegmentType.Description,
                            Performance = r.Performance,
                            Size = r.Size,
                            Reliablity = r.Reliability,
                            SalesExpense = m.SalesExpense,
                            MarketingExpense = m.MarketingExpense,
                            Price = m.Price,
                            ForecastingQuantity = m.ForecastingQuantity
                        }).ToList();

            int count = data.Count();
            //TODO: Based on howmany players are involved, add the computer players

            int compRoundCount = (from r in computerRndData
                                  join m in computerMarketingData on r.ComputerRoundProduct equals m.ComputerRoundProduct
                                  where m.ComputerRoundProduct.RoundCategoryId == round.RoundCategoryId
                                  select r).Count();
            if (compRoundCount == 24)
            {
                (from r in computerRndData
                 join m in computerMarketingData on r.ComputerRoundProduct equals m.ComputerRoundProduct
                 where m.ComputerRoundProduct.RoundCategoryId == round.RoundCategoryId
                 orderby r.ComputerRoundProduct.TeamCategoryId descending
                 select new
                 {
                     RoundCategoryId = r.ComputerRoundProduct.RoundCategoryId,
                     RoundName = r.ComputerRoundProduct.RoundCategory.RoundName,
                     SegmentTypeId = r.ComputerRoundProduct.SegmentTypeId,
                     SegmentDescription = r.ComputerRoundProduct.SegmentType.Description,
                     Performance = r.Performance,
                     Size = r.Size,
                     Reliablity = r.Reliability,
                     SalesExpense = m.SalesExpense,
                     MarketingExpense = m.MarketingExpense,
                     Price = m.Price,
                     ForecastingQuantity = m.ForecastingQuantity
                 }).Take(30 - count).ToList().ForEach(o => data.Add(o));

                forecastData = (from d in data
                                group d by new { SegmentTypeId = d.SegmentTypeId } into grp
                                select new CurrentRoundForecast
                                {
                                    SegmentTypeId = grp.Key.SegmentTypeId,
                                    Quantity = grp.Sum(o => o.ForecastingQuantity.HasValue ? o.ForecastingQuantity.Value : 0)
                                }).ToList<CurrentRoundForecast>();

                forecastData.ForEach(o =>
                {
                    Console.WriteLine(o.SegmentTypeId + "," + o.Quantity);
                });
            }
            else
            {
                throw new Exception("Sufficient players or cumputer players are not available");
            }
        }

        private void GetPlayersRating(Round round)
        {
            List<CurrentRoundProductWiseInformation> data1 = new List<CurrentRoundProductWiseInformation>();
            //Create a list of all the rating data
            (from m in marketingData
             join r in rndData on m.RoundProduct equals r.RoundProduct
             where m.RoundProduct.RoundId == round.Id
             select new CurrentRoundProductWiseInformation
                    {
                        RoundProductId = m.RoundProductId,
                        RoundCategoryId = m.RoundProduct.Round.RoundCategoryId,
                        SegmentTypeId = m.RoundProduct.SegmentTypeId,
                        SalesExpense = m.SalesExpense.HasValue ? m.SalesExpense.Value : 0.0,
                        MarketingExpense = m.MarketingExpense.HasValue ? m.SalesExpense.Value : 0.0,
                        Price = m.Price.HasValue ? m.Price.Value : 0.0,
                        Age = r.Age.HasValue ? r.Age.Value : 0.0,
                        Performance = r.Performance.HasValue ? r.Performance.Value : 0.0,
                        Reliability = r.Reliability.HasValue ? r.Reliability.Value : 0.0,
                        Size = r.Size.HasValue ? r.Size.Value : 0.0,
                        ForecastedQuantity = m.ForecastingQuantity.HasValue ? m.ForecastingQuantity.Value : 0.0
                    }).ToList().ForEach(o => data1.Add(o));

            (from m in computerMarketingData
             join r in computerRndData on m.ComputerRoundProduct equals r.ComputerRoundProduct
             where r.ComputerRoundProduct.RoundCategoryId == round.RoundCategoryId
             orderby r.ComputerRoundProduct.TeamCategoryId descending
             select new CurrentRoundProductWiseInformation
                     {
                         RoundCategoryId = m.ComputerRoundProduct.RoundCategoryId,
                         SegmentTypeId = m.ComputerRoundProduct.SegmentTypeId,
                         SalesExpense = m.SalesExpense.HasValue ? m.SalesExpense.Value : 0.0,
                         MarketingExpense = m.MarketingExpense.HasValue ? m.SalesExpense.Value : 0.0,
                         Price = m.Price.HasValue ? m.Price.Value : 0.0,
                         Age = r.Age.HasValue ? r.Age.Value : 0.0,
                         Performance = r.Performance.HasValue ? r.Performance.Value : 0.0,
                         Reliability = r.Reliability.HasValue ? r.Reliability.Value : 0.0,
                         Size = r.Size.HasValue ? r.Size.Value : 0.0,
                         ForecastedQuantity = m.ForecastingQuantity.HasValue ? m.ForecastingQuantity.Value : 0.0
                     }).Take(30 - data1.Count()).ToList().ForEach(o => data1.Add(o));

            data = new List<CurrentRoundProductWiseInformation>();
            (from d in data1
             select new CurrentRoundProductWiseInformation
                 {
                     RoundProductId = d.RoundProductId,
                     RoundCategoryId = d.RoundCategoryId,
                     SegmentTypeId = d.SegmentTypeId,
                     SalesExpense = d.SalesExpense,
                     MarketingExpense = d.MarketingExpense,
                     Price = d.Price,
                     Age = d.Age,
                     Performance = d.Performance,
                     Reliability = d.Reliability,
                     Size = d.Size,
                     ForecastedQuantity = d.ForecastedQuantity,
                     ClientAwarenessRating = ClientAwarenessRating(data1, d),
                     PriceRating = (from o in data1
                                    where d.Price < o.Price && d.SegmentTypeId == o.SegmentTypeId
                                    orderby d.Price descending
                                    select o).Count() + 1,
                     AgeRating = (from o in data1
                                  where d.Age < o.Age && d.SegmentTypeId == o.SegmentTypeId
                                  orderby d.Age descending
                                  select o).Count() + 1,
                     ReliabilityRating = (from o in data1
                                          where d.Reliability < o.Reliability && d.SegmentTypeId == o.SegmentTypeId
                                          orderby d.Reliability descending
                                          select o).Count() + 1,
                     PerformanceRating = (from o in data1
                                          where d.Performance < o.Performance && d.SegmentTypeId == o.SegmentTypeId
                                          orderby d.Performance descending
                                          select o).Count() + 1,
                     SizeRating = (from o in data1
                                   where d.Size > o.Size && d.SegmentTypeId == o.SegmentTypeId
                                   orderby d.Size 
                                   select o).Count() + 1,
                 }
            ).ToList().ForEach(o => data.Add(o));
        }

        private static int ClientAwarenessRating(List<CurrentRoundProductWiseInformation> data1, CurrentRoundProductWiseInformation d)
        {
            return (from o in data1
                    where ((d.SalesExpense + d.MarketingExpense ) < (o.SalesExpense + o.MarketingExpense)) && d.SegmentTypeId == o.SegmentTypeId
                    orderby d.SalesExpense descending
                    orderby d.MarketingExpense descending
                    select o).Count() + 1;
        }

        private GameCriteria GetGameCriteria(int segId)
        {
            GameCriteria gameCriterian = (from gc in gameCriteria
                                          where gc.SegmentTypeId == segId
                                          select gc).FirstOrDefault();
            return gameCriterian;
        }

        private void SetProductRanking()
        {
            (from d in data
             join m in marketingData on d.RoundProductId equals m.RoundProductId
             where m.Purchased == false
             select d).ToList().ForEach(o =>
             {
                 GameCriteria gameCriterian = GetGameCriteria(o.SegmentTypeId);

                 double ageRating = (6.0 - o.AgeRating) / 5.0 * gameCriterian.AgeDecision;
                 double sizeRating = (6.0 - o.SizeRating) / 5.0 * gameCriterian.PerformanceDecision;
                 double performanceRating = (6.0 - o.PerformanceRating) / 5.0 * gameCriterian.PerformanceDecision;
                 double reliabilityRating = (6.0 - o.ReliabilityRating) / 5.0 * gameCriterian.ReliabilityDecision;
                 double clientAwarenessRating = (6.0 - o.ClientAwarenessRating) / 5.0 * 0.5;
                 double priceRating = (6.0 - o.PriceRating) / 5.0 * gameCriterian.PriceDecision;
                 o.Ranking = ageRating + sizeRating + performanceRating + reliabilityRating + clientAwarenessRating + priceRating;
             });
        }

        private void SetAllQuantityIfDemandMoreThenSupply()
        {
            IEnumerable<CurrentRoundProductWiseInformation> data1 = from demand in roundCriteria
                                              join forecast in forecastData on demand.SegmentTypeId equals forecast.SegmentTypeId
                                              join m in data on demand.SegmentTypeId equals m.SegmentTypeId
                                              where demand.MarketDemand > forecast.Quantity
                                              select m;

            foreach (CurrentRoundProductWiseInformation o in data1)
            {
                o.PurchasedQuantity = o.ForecastedQuantity;
                o.Purchased = true;
            }
        }

        public void QuantityPurchased(Edusim db)
        {
            Dictionary<int, double> crds = new Dictionary<int, double>();

            roundCriteria.ForEach(o => 
                crds[o.SegmentTypeId] = o.MarketDemand.HasValue ? o.MarketDemand.Value : 0.0
            );

            (from m in data
             where m.Purchased == true
             select m).ToList().ForEach(m =>
                 {
                     MarketingData mktData = (from mk in db.MarketingData
                                              where mk.RoundProductId == m.RoundProductId
                                              select mk).FirstOrDefault();

                     if (mktData != null)
                     {
                         mktData.PurchasedQuantity = m.PurchasedQuantity;
                         mktData.Purchased = m.Purchased;
                     }
                 });

            (from m in data
             where m.Purchased == false
             orderby m.Ranking descending
             select m).ToList().ForEach(m =>
            {
                Console.WriteLine("Remaining Quantity After " + crds[m.SegmentTypeId] + " md.ForecastingQuantity = " + m.ForecastedQuantity + " c.PurchasedQuantity " + m.PurchasedQuantity);
                double remainingQty = crds[m.SegmentTypeId];
                Console.WriteLine("Remaining Quantity Before " + remainingQty);

                m.PurchasedQuantity = (m.ForecastedQuantity > remainingQty) ? remainingQty : m.ForecastedQuantity;
                m.Purchased = true;

                double purchaseQty = m.PurchasedQuantity ;

                crds[m.SegmentTypeId] -= purchaseQty;

                Console.WriteLine("Remaining Quantity After " + crds[m.SegmentTypeId] + " md.ForecastingQuantity = " + m.ForecastedQuantity + " c.PurchasedQuantity " + m.PurchasedQuantity);

                MarketingData mktData = (from mk in db.MarketingData
                                         where mk.RoundProductId == m.RoundProductId
                                         select mk).FirstOrDefault();

                if (mktData != null)
                {
                    mktData.PurchasedQuantity = m.PurchasedQuantity;
                    mktData.Purchased = m.Purchased;
                }
            });
        }
    }
}
