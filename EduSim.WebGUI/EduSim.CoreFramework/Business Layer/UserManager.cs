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

        public int ValidateUser(string username, string password)
        {
            EduSimDb db = new EduSimDb();

            return (from u in db.User
                    where u.UserName.Equals(username) && u.Password.Equals(password)
                    select u).Count<UserDetails>();
        }
    }
}