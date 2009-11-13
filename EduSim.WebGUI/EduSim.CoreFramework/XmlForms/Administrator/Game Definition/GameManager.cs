using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gizmox.WebGUI.Forms;
using EduSim.CoreFramework.Common;
using System.Data;
using EduSim.CoreFramework.DTO;
using System.Reflection;
using System.Text;

namespace EduSim.WebGUI.UI
{
    public static class GameManager
    {
        public static void SaveGame(List<Control> list, EsimMainForm esimMainForm, string filter)
        {
            Edusim db = new Edusim(Constants.ConnectionString);
            Game game;
            //Insert
            if (filter.Equals(string.Empty))
            {
                game = new Game();
                CoreDatabaseHelper.Modify(list, game, (o, c1) =>
                {
                    if (c1 is CheckedListBox)
                    {
                        CheckedListBox c = (c1 as CheckedListBox);
                        int count = 0;
                        foreach (string str in c.Items)
                        {
                            if (c.GetItemChecked(count++))
                            {
                                string[] split = str.Split(".".ToCharArray());
                                TeamGame tg = new TeamGame();
                                tg.Game = (o as Game);
                                Team user = (from u in db.Team
                                             where u.Id == int.Parse(split[0])
                                             select u).FirstOrDefault<Team>();
                                tg.Team = user;
                                db.TeamGame.InsertOnSubmit(tg);
                                AddGameInformatoin(db, tg);
                            }
                        }
                    }
                });

                game.CreatedDate = DateTime.Now;
                db.Game.InsertOnSubmit(game);

            }
            //Update
            else
            {
                string[] splits = filter.Split("=".ToCharArray());
                game = (from t in db.Game
                        where t.Id == int.Parse(splits[1])
                        select t).FirstOrDefault<Game>();

                CoreDatabaseHelper.Modify(list, game, (o, c1) =>
                {
                    if (c1 is CheckedListBox)
                    {
                        CheckedListBox c = (c1 as CheckedListBox);
                        int count = 0;
                        foreach (string str in c.Items)
                        {
                            if (c.GetItemChecked(count++))
                            {
                                string[] split = str.Split(".".ToCharArray());
                                Team team = (from u in db.Team
                                             where u.Id == int.Parse(split[0])
                                             select u).FirstOrDefault<Team>();
                                TeamGame tu1 = (from tu in db.TeamGame
                                                where tu.Game == (o as Game) && tu.TeamId == team.Id
                                                select tu).FirstOrDefault<TeamGame>();
                                if (tu1 == null)
                                {
                                    TeamGame tu = new TeamGame();
                                    tu.Game = (o as Game);
                                    tu.Team = team;
                                    db.TeamGame.InsertOnSubmit(tu);
                                }
                            }
                        }
                    }
                });
            }
            db.SubmitChanges();
        }

        public static void AddGameInformatoin(Edusim db, TeamGame tg)
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
                         PreviousLongTermLoan = o1.PreviousLongTermLoan,
                         LongTermLoan = o1.LongTermLoan,
                         PreviousShortTermLoan = o1.PreviousShortTermLoan,
                         ShortTermLoan = o1.ShortTermLoan
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

        public static void FillGameDetails(CheckedListBox control, EsimDataEntry dataEntry, DataTable table)
        {
            Edusim db = new Edusim(Constants.ConnectionString);

            (from t in db.Team
             join tc in db.TeamCategory on t.TeamCategory equals tc
             select t.Id + "." + tc.Name).ToList<string>().ForEach(o => control.Items.Add(o));

            if (table != null)
            {
                DataRow row = table.Rows[0];

                int gameId = (int)row["Id"];
                (from tg in db.TeamGame
                 join t in db.Team on tg.TeamId equals t.Id
                 where tg.GameId == gameId
                 select t.Id).ToList<int>().ForEach(o =>
                 {
                     int count = 0;
                     foreach (string str in control.Items)
                     {
                         string[] split = str.Split(".".ToCharArray());
                         if (o == int.Parse(split[0]))
                         {
                             control.SetItemChecked(count, true);
                             break;
                         }
                         count++;
                     }
                 });
            }
        }

        public static void DeleteGame(EsimMainForm esimMainForm, string filter)
        {
            Edusim db = new Edusim(Constants.ConnectionString);
            (from tu in db.TeamGame
             where tu.GameId == int.Parse(filter)
             select tu).ToList<TeamGame>().ForEach(o => db.TeamGame.DeleteOnSubmit(o));

            (from t in db.Team
             where t.Id == int.Parse(filter)
             select t).ToList<Team>().ForEach(o => db.Team.DeleteOnSubmit(o));

            db.SubmitChanges();
        }
    }
}
