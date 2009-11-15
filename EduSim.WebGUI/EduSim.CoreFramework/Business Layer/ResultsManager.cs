using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using EduSim.CoreFramework.DTO;
using EduSim.CoreFramework.Common;
using EduSim.WebGUI.UI.BindedGrid;
using org.drools.dotnet.compiler;
using org.drools.dotnet.rule;
using Gizmox.WebGUI.Forms;

namespace EduSim.Analyse.BusinessLayer
{
    public class ResultsManager
    {
        private List<CurrentRoundDemand> roundData;
        private List<CurrentRoundForecast> forecastData;
        private List<MarketingData> marketingData;
        private List<RnDData> rndData;

        public void Init(org.drools.dotnet.WorkingMemory workingMemory, Round round)
        {
            Edusim edusim = new Edusim(Constants.ConnectionString);

            workingMemory.assertObject(round);

            (from g in edusim.GameCriteria select g).ToList<GameCriteria>().ForEach(o =>
            {
                workingMemory.assertObject(o);
            });

            Console.WriteLine();

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

            roundData.ForEach(o =>
            {
                Console.WriteLine(o.SegmentTypeId + "," + o.Performance + "," + o.Size + "," + o.Quantity);
                workingMemory.assertObject(o);
            });

            Console.WriteLine();

            var data = from r in edusim.RnDData
                       join m in edusim.MarketingData on r.RoundProductId equals m.RoundProductId
                       join roundLoc in edusim.Round on round.Id equals roundLoc.Id
                       where roundLoc.RoundCategoryId == round.RoundCategoryId
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
                       };

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
                workingMemory.assertObject(o);
            });

            marketingData = (from m in edusim.MarketingData
                            join roundLoc in edusim.Round on round.Id equals roundLoc.Id
                            where roundLoc.RoundCategoryId == round.RoundCategoryId
                            select m).ToList<MarketingData>();

            marketingData.ForEach(o =>
            {
                 Console.WriteLine(o.RoundProduct.SegmentTypeId + "," + o.PurchasedQuantity + " " + o.ForecastingQuantity);
                 workingMemory.assertObject(o);
            });

            rndData = (from r in edusim.RnDData
                      join roundLoc in edusim.Round on round.Id equals roundLoc.Id
                      where roundLoc.RoundCategoryId == round.RoundCategoryId
                      select r).ToList<RnDData>();

            rndData.ForEach(o =>
            {
                 workingMemory.assertObject(o);
            });

            (from rp in edusim.RoundProduct
             where rp.RoundId == round.Id
             select rp).ToList<RoundProduct>().ForEach(o =>
             {
                 workingMemory.assertObject(o);
             });

            (from r in edusim.RoundCriteria
             join roundLoc in edusim.Round on r.RoundCategoryId equals round.RoundCategoryId
             where roundLoc.RoundCategoryId == round.RoundCategoryId
             select r).ToList<RoundCriteria>().ForEach(o =>
             {
                 workingMemory.assertObject(o);
             });
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

        public static void Run(Round round)
        {
            if (round != null)
            {
                Stream stream = new FileStream("./rules/EduSimRules.drl", FileMode.Open);
                PackageBuilder builder = new PackageBuilder();
                builder.AddPackageFromDrl(stream);
                Package pkg = builder.GetPackage();
                org.drools.dotnet.RuleBase ruleBase = org.drools.dotnet.RuleBaseFactory.NewRuleBase();
                ruleBase.AddPackage(pkg);
                org.drools.dotnet.WorkingMemory workingMemory = ruleBase.NewWorkingMemory();

                ResultsManager rm = new ResultsManager();

                rm.Init(workingMemory, round);

                workingMemory.assertObject(rm);
                ArrayList resultList = new ArrayList();
                workingMemory.assertObject(resultList);

                workingMemory.fireAllRules();

                rm.QuantityPurchased();
            }
            else
            {
                MessageBox.Show("Please select a valid Round");
            }
        }
    }
}
