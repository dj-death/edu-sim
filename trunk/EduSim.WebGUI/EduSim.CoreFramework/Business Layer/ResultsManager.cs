using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using EduSim.CoreFramework.DTO;
using EduSim.CoreFramework.Common;
using Gizmox.WebGUI.Forms;

namespace EduSim.Analyse.BusinessLayer
{
    public class ResultsManager
    {
        public static void Run(Round round)
        {
            if (round != null)
            {
                ResultsManager rm = new ResultsManager();

                rm.Init(round);

                //If demand is more
                IEnumerable<MarketingData> data = from demand in rm.roundData
                                                  join forecast in rm.forecastData on demand.SegmentTypeId equals forecast.SegmentTypeId
                                                  join m in rm.marketingData on demand.SegmentTypeId equals m.RoundProduct.SegmentTypeId
                                                  where demand.Quantity > forecast.Quantity
                                                  select m;

                foreach (MarketingData o in data)
                {
                    o.PurchasedQuantity = o.ForecastingQuantity;
                    o.Purchased = true;
                }

                double rank = 0;

                rm.rndData.ForEach(o =>
                {
                    GameCriteria gameCriterian = rm.GetGameCriteria(o.RoundProduct.SegmentTypeId);

                    double ageRating = (6.0 - rm.GetAgeRank(gameCriterian.SegmentTypeId, o)) / 5.0 * gameCriterian.AgeDecision;
                    double sizeRating = (6.0 - rm.GetSizeRank(gameCriterian.SegmentTypeId, o)) / 5.0 * gameCriterian.PerformanceDecision;
                    double performanceRating = (6.0 - rm.GetPerformanceRank(gameCriterian.SegmentTypeId, o)) / 5.0 * gameCriterian.PerformanceDecision;
                    double reliabilityRating = (6.0 - rm.GetReliabilityRank(gameCriterian.SegmentTypeId, o)) / 5.0 * gameCriterian.ReliabilityDecision;
                    rank += ageRating + sizeRating + performanceRating + reliabilityRating;
                });

                rm.marketingData.ForEach(o =>
                {
                    GameCriteria gameCriterian = rm.GetGameCriteria(o.RoundProduct.SegmentTypeId);

                    double clientAwarenessRating = (6.0 - rm.GetCustomerAccessRank(gameCriterian.SegmentTypeId, o)) / 5.0 * 0.5;
                    double priceRating = (6.0 - rm.GetPriceRank(gameCriterian.SegmentTypeId, o)) / 5.0 * gameCriterian.PriceDecision;
                    rank += clientAwarenessRating + priceRating;
                    o.Rating = rank;
                });

                rm.QuantityPurchased();
            }
            else
            {
                MessageBox.Show("Please select a valid Round");
            }
        }

        private List<CurrentRoundDemand> roundData;
        private List<CurrentRoundForecast> forecastData;
        private List<MarketingData> marketingData;
        private List<RnDData> rndData;
        private List<GameCriteria> gameCriteria;
        private List<RoundCriteria> roundCriteria;

        public void Init(Round round)
        {
            Edusim edusim = new Edusim(Constants.ConnectionString);

            gameCriteria = (from g in edusim.GameCriteria
                            select g).ToList<GameCriteria>();
            roundCriteria = (from r in edusim.RoundCriteria
                             join roundLoc in edusim.Round on r.RoundCategoryId equals round.RoundCategoryId
                             where roundLoc.RoundCategoryId == round.RoundCategoryId
                             select r).ToList<RoundCriteria>();

            Console.WriteLine();

            GetDemandData(round, edusim);

            roundData.ForEach(o =>
            {
                Console.WriteLine(o.SegmentTypeId + "," + o.Performance + "," + o.Size + "," + o.Quantity);
            });

            Console.WriteLine();

            GetForecastedData(round, edusim);

            forecastData.ForEach(o =>
            {
                Console.WriteLine(o.SegmentTypeId + "," + o.Quantity);
            });

            GetMarketingData(round, edusim);

            marketingData.ForEach(o =>
            {
                Console.WriteLine(o.RoundProduct.SegmentTypeId + "," + o.PurchasedQuantity + " " + o.ForecastingQuantity);
            });

            GetRnDData(round, edusim);
        }

        private void GetForecastedData(Round round, Edusim edusim)
        {
            var data = (from r in edusim.RnDData
                        join m in edusim.MarketingData on r.RoundProductId equals m.RoundProductId
                        where m.RoundProduct.Round == round
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

            //TODO: Based on howmany players are involved, add the computer players
            (from r in edusim.ComputerRnDData
             join m in edusim.ComputerMarketingData on r.ComputerRoundProduct equals m.ComputerRoundProduct
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
             }).Take(30 - data.Count()).ToList().ForEach(o => data.Add(o));

            forecastData = (from d in data
                            group d by new { SegmentTypeId = d.SegmentTypeId } into grp
                            select new CurrentRoundForecast
                            {
                                SegmentTypeId = grp.Key.SegmentTypeId,
                                Quantity = grp.Sum(o => o.ForecastingQuantity.HasValue ? o.ForecastingQuantity.Value : 0)
                            }).ToList<CurrentRoundForecast>();
        }

        private void GetDemandData(Round round, Edusim edusim)
        {
            roundData = (from smd in edusim.SegmentMarketDemand
                         join rc in edusim.RoundCriteria on smd.RoundCategoryId equals rc.RoundCategoryId
                         where smd.RoundCategoryId == round.RoundCategoryId && smd.SegmentTypeId == rc.SegmentTypeId
                         select new CurrentRoundDemand
                         {
                             SegmentTypeId = rc.SegmentTypeId,
                             Quantity = smd.Quantity,
                             Performance = rc.Performance,
                             Size = rc.Size
                         }).ToList<CurrentRoundDemand>();
        }

        private void GetRnDData(Round round, Edusim edusim)
        {
            rndData = (from r in edusim.RnDData
                       where r.RoundProduct.Round == round
                       select r).ToList<RnDData>();

            (from r in edusim.ComputerRnDData
             where r.ComputerRoundProduct.RoundCategoryId == round.RoundCategoryId
             orderby r.ComputerRoundProduct.TeamCategoryId descending
             select new RnDData
             {
                 Age = r.Age,
                 Performance = r.Performance,
                 PreviousAge = r.PreviousAge,
                 PreviousPerformance = r.PreviousPerformance,
                 PreviousReliability = r.PreviousReliability,
                 PreviousRevisionDate = r.PreviousRevisionDate,
                 PreviousSize = r.PreviousSize,
                 Reliability = r.Reliability,
                 RevisionDate = r.RevisionDate,
                 RnDCost = r.RnDCost,
                 Size = r.Size
             }).Take(30 - rndData.Count()).ToList().ForEach(o => rndData.Add(o));
        }

        private void GetMarketingData(Round round, Edusim edusim)
        {
            marketingData = (from m in edusim.MarketingData
                             where m.RoundProduct.Round == round
                             select m).ToList<MarketingData>();

            (from r in edusim.ComputerMarketingData
             where r.ComputerRoundProduct.RoundCategoryId == round.RoundCategoryId
             orderby r.ComputerRoundProduct.TeamCategoryId descending
             select new MarketingData
             {
                 ForecastingQuantity = r.ForecastingQuantity,
                 MarketingExpense = r.MarketingExpense,
                 PreviousForecastingQuantity = r.PreviousForecastingQuantity,
                 PreviousMarketingExpense = r.PreviousMarketingExpense,
                 PreviousPrice = r.PreviousPrice,
                 PreviousSaleExpense = r.PreviousSaleExpense,
                 Price = r.Price,
                 PurchasedQuantity = r.PurchasedQuantity
             }).Take(30 - marketingData.Count()).ToList().ForEach(o => marketingData.Add(o));
        }

        public int GetPriceRank(int segmentTypeId, MarketingData mktData)
        {
            IOrderedEnumerable<MarketingData> data =  from m in marketingData
                                              where m.RoundProduct.SegmentTypeId == segmentTypeId
                                              orderby m.Price ascending
                                              select m;
            return MarketingRanking(mktData, data);
        }

        public int GetCustomerAccessRank(int segmentTypeId, MarketingData mktData)
        {
            IOrderedEnumerable<MarketingData> data = from m in marketingData
                                             where m.RoundProduct.SegmentTypeId == segmentTypeId
                                             orderby m.SalesExpense descending
                                             orderby m.MarketingExpense descending
                                             select m;
            return MarketingRanking(mktData, data);
        }

        private static int MarketingRanking(MarketingData mktData, IOrderedEnumerable<MarketingData> data)
        {
            int count = 1;
            foreach (MarketingData mData in data)
            {
                if (mData == mktData)
                {
                    return count;
                }
                count++;
            }

            return 0;
        }

        public int GetPerformanceRank(int segmentTypeId, RnDData rnDData)
        {
            IOrderedEnumerable<RnDData> data = from r in rndData
                                       where r.RoundProduct.SegmentTypeId == segmentTypeId
                                       orderby r.Performance descending 
                                             select r;
            return RndRanking(rnDData, data);
        }

        public int GetSizeRank(int segmentTypeId, RnDData rnDData)
        {
            IOrderedEnumerable<RnDData> data = from r in rndData
                                       where r.RoundProduct.SegmentTypeId == segmentTypeId
                                       orderby r.Size ascending
                                       select r;
            return RndRanking(rnDData, data);
        }

        public int GetReliabilityRank(int segmentTypeId, RnDData rnDData)
        {
            IOrderedEnumerable<RnDData> data = from r in rndData
                                       where r.RoundProduct.SegmentTypeId == segmentTypeId
                                       orderby r.Reliability descending 
                                       select r;
            return RndRanking(rnDData, data);
        }

        public int GetAgeRank(int segmentTypeId, RnDData rnDData)
        {
            IOrderedEnumerable<RnDData> data = from r in rndData
                                       where r.RoundProduct.SegmentTypeId == segmentTypeId
                                       orderby r.Performance descending 
                                       select r;
            return RndRanking(rnDData, data);
        }

        private static int RndRanking(RnDData rnDData, IOrderedEnumerable<RnDData> data)
        {
            int count = 1;

            foreach (RnDData mData in data)
            {
                if (mData == rnDData)
                {
                    return count;
                }
                count++;
            }

            return 0;
        }

        public void QuantityPurchased()
        {
            Dictionary<int, double> crds = new Dictionary<int, double>();

            roundData.ToList<CurrentRoundDemand>().ForEach(o => 
                crds[o.SegmentTypeId] = o.Quantity
            );

            IOrderedEnumerable<MarketingData> mds = (from m in marketingData
                                             where m.Purchased == false
                                             orderby m.Rating descending 
                                             select m);


            foreach (MarketingData m in mds)
            {
                Console.WriteLine("Remaining Quantity After " + crds[m.RoundProduct.SegmentTypeId] + " md.ForecastingQuantity = " + m.ForecastingQuantity + " c.PurchasedQuantity " + m.PurchasedQuantity);
                double remainingQty = crds[m.RoundProduct.SegmentTypeId];
                Console.WriteLine("Remaining Quantity Before " + remainingQty);
                
                m.PurchasedQuantity = (m.ForecastingQuantity > remainingQty) ? remainingQty : m.ForecastingQuantity;
                m.Purchased = true;

                double purchaseQty = m.PurchasedQuantity.HasValue ? m.PurchasedQuantity.Value : 0.0;

                crds[m.RoundProduct.SegmentTypeId] -= purchaseQty;

                Console.WriteLine("Remaining Quantity After " + crds[m.RoundProduct.SegmentTypeId] + " md.ForecastingQuantity = " + m.ForecastingQuantity + " c.PurchasedQuantity " + m.PurchasedQuantity);
            }
        }

        private GameCriteria GetGameCriteria(int segId)
        {
            GameCriteria gameCriterian = (from gc in gameCriteria
                                          where gc.SegmentTypeId == segId
                                          select gc).FirstOrDefault();
            return gameCriterian;
        }
    }
}
