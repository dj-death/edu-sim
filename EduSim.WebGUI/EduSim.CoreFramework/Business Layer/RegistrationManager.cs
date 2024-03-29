﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EduSim.CoreFramework.DTO;
using EduSim.WebGUI.UI;
using EduSim.CoreFramework.Common;
using System.Data.Linq;

namespace EduSim.CoreFramework.BusinessLayer
{
    public class RegistrationManager
    {
        //Create user
        //Create a new team 
        //Create a new TeamUser associating this user with this team
        //Create new game 
        //Create a GameTeam associating this team with this game
        //Create all requirement data and user is ready to try

        public static void ProcessRegistration(UserDetails user)
        {
            try
            {
                Edusim db = new Edusim(Constants.ConnectionString);

                db.UserDetails.InsertOnSubmit(user);

                Team team = new Team()
                {
                    TeamCategoryId = 1,
                    CreatedDate = DateTime.Now,
                    Players = true,
                };
                db.Team.InsertOnSubmit(team);

                TeamUser teamUser = new TeamUser()
                {
                    Team = team,
                    UserDetails = user
                };
                db.TeamUser.InsertOnSubmit(teamUser);

                Game game = new Game()
                {
                    Active = true,
                    CreatedDate = DateTime.Now
                };
                db.Game.InsertOnSubmit(game);

                TeamGame teamGame = new TeamGame()
                {
                    Game = game,
                    Team = team
                };
                db.TeamGame.InsertOnSubmit(teamGame);

                GameHelper.AddGameInformatoin(db, teamGame);

                db.SubmitChanges();
            }
            catch (ChangeConflictException e)
            {
                throw new Exception(GameHelper.BuildSqlError(e).ToString());
            }

        }
    }
}
