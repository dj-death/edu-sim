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
    public static class TeamManager
    {
        public static void SaveTeam(List<Control> list, BrixMainForm brixMainForm, string filter)
        {
            Edusim db = new Edusim(Constants.ConnectionString);
            Team team;
            //Insert
            if (filter.Equals(string.Empty))
            {
                team = new Team();
                CoreDatabaseHelper.Modify(list, team, (o, c1) =>
                    {
                        if (c1 is CheckedListBox)
                        {
                            CheckedListBox c = (c1 as CheckedListBox);

                            int count = 0;
                            foreach (string str in c.Items)
                            {
                                if (c.GetItemChecked(count++))
                                {
                                    TeamUser tu = new TeamUser();
                                    tu.Team = (o as Team);
                                    UserDetails user = (from u in db.UserDetails
                                                        where u.Email.Equals(str)
                                                        select u).FirstOrDefault<UserDetails>();
                                    tu.UserDetails = user;
                                    db.TeamUser.InsertOnSubmit(tu);
                                    break;
                                }
                            }
                        }
                        if (c1 is ComboBox)
                        {
                            ComboBox c = (c1 as ComboBox);
                            team.TeamCategoryId = c.SelectedIndex + 1;
                        }
                    });

                team.CreatedDate = DateTime.Now;
                db.Team.InsertOnSubmit(team);
            }
            //Update
            else
            {
                string[] splits = filter.Split("=".ToCharArray());
                team = (from t in db.Team
                             where t.Id == int.Parse(splits[1])
                             select t).FirstOrDefault<Team>();

                CoreDatabaseHelper.Modify(list, team, (o, c1) =>
                    {
                        if (c1 is CheckedListBox)
                        {
                            CheckedListBox c = (c1 as CheckedListBox);
                            int count = 0;
                            foreach (string str in c.Items)
                            {
                                if (c.GetItemChecked(count++))
                                {
                                    UserDetails user = (from u in db.UserDetails
                                                        where u.Email.Equals(str)
                                                        select u).FirstOrDefault<UserDetails>();
                                    TeamUser tu1 = (from tu in db.TeamUser
                                                    where tu.Team == (o as Team) && tu.UserDetails == user
                                                    select tu).FirstOrDefault<TeamUser>();
                                    if (tu1 == null)
                                    {
                                        TeamUser tu = new TeamUser();
                                        tu.Team = (o as Team);
                                        tu.UserDetails = user;
                                        db.TeamUser.InsertOnSubmit(tu);
                                    }
                                    break;
                                }
                            }
                        }
                        if (c1 is ComboBox)
                        {
                            ComboBox c = (c1 as ComboBox);
                            team.TeamCategoryId = c.SelectedIndex + 1;
                        }
                    });
            }
            db.SubmitChanges();
        }

        public static void FillUserDetails(CheckedListBox control, BrixDataEntry dataEntry, DataTable table)
        {
            Edusim db = new Edusim(Constants.ConnectionString);
            
            (from u in db.UserDetails
             select u.Email).ToList<string>().ForEach(o => control.Items.Add(o));

            if (table != null)
            {
                DataRow row = table.Rows[0];

                int teamId = (int)row["Id"] ;
                (from tu in db.TeamUser
                 where tu.TeamId == teamId
                 select tu.UserDetails.Email).ToList<string>().ForEach(o =>
                     {
                         int count = 0;
                         foreach (string str in control.Items)
                         {
                             if(str.Equals(o))
                             {
                                 control.SetItemChecked(count, true);
                                 break;
                             }
                             count++;
                         }
                     });

            }
        }

        public static void FillTeamNamesDetails(ComboBox control, BrixDataEntry dataEntry, DataTable table)
        {
            Edusim db = new Edusim(Constants.ConnectionString);

            (from tc in db.TeamCategory
             select tc.Name).ToList<string>().ForEach(o => control.Items.Add(o));

            if (table != null)
            {
                DataRow row = table.Rows[0];

                int tcId = (int)row["TeamCategoryId"];

                control.SelectedIndex = tcId - 1;
            }
        }

        public static void DeleteTeam(BrixMainForm brixMainForm, string filter)
        {
            Edusim db = new Edusim(Constants.ConnectionString);

            (from tu in db.TeamUser
             where tu.TeamId == int.Parse(filter)
             select tu).ToList<TeamUser>().ForEach(o => db.TeamUser.DeleteOnSubmit(o));

            (from t in db.Team
             where t.Id == int.Parse(filter)
             select t).ToList<Team>().ForEach(o => db.Team.DeleteOnSubmit(o));

            db.SubmitChanges();
        }
    }
}
