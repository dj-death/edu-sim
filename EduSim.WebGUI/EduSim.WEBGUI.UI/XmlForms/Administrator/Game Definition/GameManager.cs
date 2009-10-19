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
        public static void SaveGame(List<Control> list, BrixMainForm brixMainForm, string filter)
        {
            EduSimDb db = new EduSimDb();
            Game game;
            //Insert
            if (filter.Equals(string.Empty))
            {
                game = new Game();
                CoreDatabaseHelper.Modify(list, game, (o, c) =>
                {
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
                            break;
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

                CoreDatabaseHelper.Modify(list, game, (o, c) =>
                {
                    int count = 0;
                    foreach (string str in c.Items)
                    {
                        if (c.GetItemChecked(count++))
                        {
                            string[] split = str.Split(".".ToCharArray());
                            Team user = (from u in db.Team
                                                where u.Id  == int.Parse(split[0])
                                                select u).FirstOrDefault<Team>();
                            TeamGame tu1 = (from tu in db.TeamGame
                                            where tu.Game == (o as Game) && tu.TeamId == user.Id
                                            select tu).FirstOrDefault<TeamGame>();
                            if (tu1 == null)
                            {
                                TeamGame tu = new TeamGame();
                                tu.Game = (o as Game);
                                tu.Team = user;
                                db.TeamGame.InsertOnSubmit(tu);
                            }
                            break;
                        }
                    }
                });
            }
            db.SubmitChanges();
        }

        public static void FillGameDetails(CheckedListBox control, BrixDataEntry dataEntry, DataTable table)
        {
            EduSimDb db = new EduSimDb();

            (from u in db.Team
             select u.Id + "." + u.Name).ToList<string>().ForEach(o => control.Items.Add(o));

            if (table != null)
            {
                DataRow row = table.Rows[0];

                int gameId = (int)row["Id"];
                (from tg in db.TeamGame
                 join t in db.Team on tg.TeamId equals t.Id
                 where tg.GameId == gameId
                 select t.Name).ToList<string>().ForEach(o =>
                 {
                     int count = 0;
                     foreach (string str in control.Items)
                     {
                         string[] split = str.Split(".".ToCharArray());
                         if (split[0].Equals(o))
                         {
                             control.SetItemChecked(count, true);
                             break;
                         }
                         count++;
                     }
                 });
            }
        }

        public static void DeleteGame(BrixMainForm brixMainForm, string filter)
        {
            EduSimDb db = new EduSimDb();
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
