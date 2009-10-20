using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Caching;
using System.IO;
using EduSim.CoreFramework.DTO;

namespace EduSim.UserManagementBL
{
    /// <summary>
    /// Class for all the business functionality methods
    /// </summary>
    public class UserManager
    {
        public static UserManager Instance = new UserManager();
        private object lockObj = new object();

        public UserDetails ValidateUser(string email, string password)
        {
            Edusim db = new Edusim();
            UserDetails user = null;

            try
            {
                user = (from u in db.UserDetails
                        where u.Email.Equals(email) && u.Password.Equals(password)
                        select u).Single<UserDetails>();
            }
            catch (Exception) { }
            return user;
        }
    }
}