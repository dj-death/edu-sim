using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.Caching;
using Aurigo.AMP3.Common;
using Aurigo.AMP3.DataAccess.Core;
using Aurigo.AMP3.Logging;
using Aurigo.AMP3.UserManagementDTO;
using Aurigo.Brix.Platform.BusinessLayer.DataAccessHelper;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Aurigo.Brix.Platform.CoreUtilities.Utility;

namespace Aurigo.AMP3.UserManagementDAC
{
    /// <summary>
    /// Class for all the methods that access the database
    /// </summary>
    internal class UserComponent
    {
        //private SqlDatabase db;
        private Database db = DatabaseFactory.CreateDatabase();
        internal static UserComponent Instance = new UserComponent();

        //checks whether user is active and unlocked and also if user account duration is valid
        internal bool CheckAccountValidity(int uid)
        {
            try
            {
                DbCommand cmd = db.GetStoredProcCommand("usp_USRMGMTCheckAccountValidity");

                db.AddInParameter(cmd, "UID", DbType.Int32, uid);
                db.AddOutParameter(cmd, "STATUS", DbType.Int32, 4);
                db.ExecuteScalar(cmd);

                return (BrixDatatypeHelper.ToInt32_2(db.GetParameterValue(cmd, "STATUS").ToString2()) > 0);
            }
            catch (Exception ex)
            {
                Logger.Log(Enumerations.LogType.Error, ex.Message, "Constants.MODID_USRMGMT");
                throw;
            }
        }
        //Checks whether the email is present into the system
        internal bool CheckUserEmail(string email)
        {
            try
            {
                DbCommand cmd = db.GetStoredProcCommand("usp_USRMGMTCheckUserEmail");

                db.AddInParameter(cmd, "EMAIL", DbType.String, email);
                db.AddOutParameter(cmd, "STATUS", DbType.Int32, 4);

                db.ExecuteScalar(cmd);
                return (BrixDatatypeHelper.ToInt32_2(db.GetParameterValue(cmd, "STATUS").ToString2()) == 1);
            }
            catch (Exception ex)
            {
                Logger.Log(Enumerations.LogType.Error, ex.Message, "Constants.MODID_USRMGMT");
                throw;
            }
        }
        //gets the emails of all administrators
        internal Dictionary<int, string> GetAdminEmail()
        {
            try
            {
                Dictionary<int, string> AdminEmails = new Dictionary<int, string>();
                DbCommand cmd = db.GetStoredProcCommand("usp_USRMGMTGetAdminEmail");

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                        AdminEmails.Add(dr.GetInt32(0), dr.GetString(1));
                }
                return AdminEmails;
            }
            catch (Exception ex)
            {
                Logger.Log(Enumerations.LogType.Error, ex.Message, "Constants.MODID_USRMGMT");
                throw;
            }
        }
        internal string ForgotPassword(string userID, string email)
        {
            try
            {
                DbCommand cmd = db.GetStoredProcCommand("usp_USRMGMTGetUserPassword");

                db.AddInParameter(cmd, "USERNAME", DbType.String, userID);
                db.AddInParameter(cmd, "EMAIL", DbType.String, email);
                db.AddOutParameter(cmd, "PWD", DbType.String, 50);
                db.ExecuteScalar(cmd);

                return db.GetParameterValue(cmd, "PWD").ToString2();
            }
            catch (Exception ex)
            {
                Logger.Log(Enumerations.LogType.Error, ex.Message, "Constants.MODID_USRMGMT");
                throw;
            }
        }


        internal int GetUsersRoleId(string rolename)
        {
            try
            {
                DbCommand cmd = db.GetStoredProcCommand("usp_USRMGMTGetUsersRoleId");

                db.AddInParameter(cmd, "ROLENAME", DbType.String, rolename);
                db.AddOutParameter(cmd, "STATUS", DbType.Int32, 4);
                db.ExecuteScalar(cmd);

                return BrixDatatypeHelper.ToInt32_2(db.GetParameterValue(cmd, "STATUS").ToString2());
            }
            catch (Exception ex)
            {
                Logger.Log(Enumerations.LogType.Error, ex.Message, "Constants.MODID_USRMGMT");
                throw;
            }
        }
        internal Dictionary<int, string> GetUsersInRole(int roleid)
        {
            try
            {
                Dictionary<int, string> activeUserColl = new Dictionary<int, string>();
                DbCommand cmd = db.GetStoredProcCommand("usp_USRMGMTGetUsersInRole");

                db.AddInParameter(cmd, "ROLEID", DbType.Int32, roleid);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read()) //populate columns of dictionary from dataset
                        activeUserColl.Add(dr.GetInt32(0), dr.GetString(1));
                }

                return activeUserColl;
            }
            catch (Exception ex)
            {
                Logger.Log(Enumerations.LogType.Error, ex.Message, "Constants.MODID_USRMGMT");
                throw;
            }
        }

        //Adding users to role specified by roleid
        internal int AddUsersToRole(int roleid, int uid)
        {
            try
            {
                DbCommand cmd = db.GetStoredProcCommand("usp_USRMGMTAddUsersToRole");

                db.AddInParameter(cmd, "ROLEID", DbType.Int32, roleid);
                db.AddInParameter(cmd, "USERID", DbType.Int32, uid);
                db.AddOutParameter(cmd, "STATUS", DbType.Int32, 4);
                db.ExecuteScalar(cmd);

                return (BrixDatatypeHelper.ToInt32_2(db.GetParameterValue(cmd, "STATUS").ToString2()) > 0) ? 1 : 0;
            }
            catch (Exception ex)
            {
                Logger.Log(Enumerations.LogType.Error, ex.Message, "Constants.MODID_USRMGMT");
                throw;
            }
        }
        internal Dictionary<string, string> GetRole(int roleid)
        {
            try
            {
                Dictionary<string, string> RoleColl = new Dictionary<string, string>();
                DbCommand cmd = db.GetStoredProcCommand("usp_USRMGMTGetRole");

                db.AddInParameter(cmd, "ROLEID", DbType.Int32, roleid);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read()) //populate columns of dictionary from dataset
                        RoleColl.Add(dr.GetString(1), dr.GetString(2));
                }
                return RoleColl;
            }
            catch (Exception ex)
            {
                Logger.Log(Enumerations.LogType.Error, ex.Message, "Constants.MODID_USRMGMT");
                throw;
            }
        }
        internal int UpdateRole(Role roleDTO)
        {
            try
            {
                DbCommand cmd = db.GetStoredProcCommand("usp_USRMGMTUpdateRole");

                db.AddInParameter(cmd, "ROLEID", DbType.Int32, roleDTO.RoleId);
                db.AddInParameter(cmd, "ROLENAME", DbType.String, roleDTO.RoleName);
                db.AddInParameter(cmd, "ROLEDESC", DbType.String, roleDTO.RoleDescription);
                db.AddOutParameter(cmd, "STATUS", DbType.Int32, 4);
                db.ExecuteScalar(cmd);

                return (BrixDatatypeHelper.ToInt32_2(db.GetParameterValue(cmd, "STATUS").ToString2()) > 0) ? 1 : 0;
            }
            catch (Exception ex)
            {
                Logger.Log(Enumerations.LogType.Error, ex.Message, "Constants.MODID_USRMGMT");
                throw;
            }
        }
        internal string GetUserName(int uid)
        {
            try
            {
                string username;
                DbCommand cmd = db.GetStoredProcCommand("usp_USRMGMTGetUserName");

                db.AddInParameter(cmd, "USERID", DbType.Int32, uid);
                db.AddOutParameter(cmd, "STATUS", DbType.String, 1000);
                db.ExecuteScalar(cmd);

                username = db.GetParameterValue(cmd, "STATUS").ToString2();
                return String.IsNullOrEmpty(username) ? "0" : username;
            }
            catch (Exception ex)
            {
                Logger.Log(Enumerations.LogType.Error, ex.Message, "Constants.MODID_USRMGMT");
                throw;
            }
        }
        internal User GetAUser(string userid)
        {
            Hashtable ht = GetUserHT(userid);
            Int32 uid = 0;
            if (Int32.TryParse(ht["UID"].ToString2(), out uid))
                return GetAUser(uid);
            else
                return null;
        }
        internal User GetAUser(int uid)
        {
            try
            {
                DbCommand cmd = db.GetStoredProcCommand("usp_USRMGMTGetAUser");
                User UserDTO = new User();

                db.AddInParameter(cmd, "USERID", DbType.Int32, uid);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        UserDTO.UserId = uid;
                        UserDTO.FirstName = dr[0].ToString2();
                        UserDTO.MiddleName = dr[1].ToString2();
                        UserDTO.LastName = dr[2].ToString2();
                        UserDTO.CompanyName = dr[3].ToString2();
                        UserDTO.UserName = dr[4].ToString2();
                        UserDTO.Password = dr[5].ToString2();
                        UserDTO.Email = dr[6].ToString2();
                        UserDTO.Telephone = dr[7].ToString2();
                        UserDTO.Fax = dr[8].ToString2();
                        UserDTO.Address1 = dr[9].ToString2();
                        UserDTO.Address2 = dr[10].ToString2();
                        UserDTO.Address3 = dr[11].ToString2();
                        UserDTO.City = dr[12].ToString2();
                        UserDTO.State = dr[13].ToString2();
                        UserDTO.Zipcode = dr[14].ToString2();
                        UserDTO.IsActive = dr.GetBoolean(15);
                        UserDTO.ExpiryDate = dr.GetDateTime(16);
                        UserDTO.CertNo = dr["CertNo"].ToString2();
                        UserDTO.WebUser = BrixDatatypeHelper.ToInt32_2(dr["WebUser"]);
                        UserDTO.MobileUser = BrixDatatypeHelper.ToInt32_2(dr["MobileUser"]);

                        //if (dr["SendEmail"] != null && ! String.IsNullOrEmpty(dr["SendEmail"].ToString2())  )
                        //    UserDTO.SendEmail = BrixDatatypeHelper.ToBoolean2(dr["SendEmail"].ToString2());
                        //else
                        //    UserDTO.SendEmail = false;
                        //get all roles for this user
                        Dictionary<int, string> userroles = GetAssignedRolesOfUser(uid);
                        string csvrole = "";

                        if (userroles.Count != 0)
                        {
                            foreach (KeyValuePair<int, string> kvp in userroles)
                                csvrole += kvp.Value.ToString2() + ", ";

                            csvrole = csvrole.Substring(0, csvrole.Length - 2);
                            UserDTO.RoleIDs = csvrole;
                        }
                    }
                }
                return UserDTO;
            }
            catch (Exception ex)
            {
                Logger.Log(Enumerations.LogType.Error, ex.Message, "Constants.MODID_USRMGMT");
                throw;
            }
        }
        internal Hashtable GetUserHT(int uid)
        {
            try
            {
                DbCommand cmd = db.GetStoredProcCommand("usp_USRMGMTGetAUser");
                Hashtable UserHT;

                db.AddInParameter(cmd, "USERID", DbType.Int32, uid);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    UserHT = new Hashtable();
                    while (dr.Read())
                    {
                        UserHT.Add("FirstName", dr["FirstName"].ToString2());
                        UserHT.Add("MiddleName", dr["MiddleName"].ToString2());
                        UserHT.Add("LastName", dr["LastName"].ToString2());
                        UserHT.Add("CompanyName", dr["CompanyName"].ToString2());
                        UserHT.Add("UserID", dr["Username"].ToString2());
                        UserHT.Add("Password", dr["Password"].ToString2());
                        UserHT.Add("Email", dr["Email"].ToString2());
                        UserHT.Add("Telephone", dr["Telephone"].ToString2());
                        UserHT.Add("Fax", dr["Fax"].ToString2());
                        UserHT.Add("Address1", dr["Address1"].ToString2());
                        UserHT.Add("Address2", dr["Address2"].ToString2());
                        UserHT.Add("Address3", dr["Address3"].ToString2());
                        UserHT.Add("City", dr["City"].ToString2());
                        UserHT.Add("State", dr["State"].ToString2());
                        UserHT.Add("Zipcode", dr["Zipcode"].ToString2());
                        UserHT.Add("IsActive", dr.GetBoolean(15));
                        UserHT.Add("ExpiryDate", dr.GetDateTime(16));
                        UserHT.Add("IsLocked", dr.GetBoolean(17));
                        UserHT.Add("IsRegistered", dr.GetBoolean(18));
                        UserHT.Add("RegistrationDate", dr.GetDateTime(19));
                        UserHT.Add("CertNo", dr["CertNo"].ToString2());
                    }
                }
                return UserHT;
            }
            catch (Exception ex)
            {
                Logger.Log(Enumerations.LogType.Error, ex.Message, "Constants.MODID_USRMGMT");
                throw;
            }
        }
        internal Hashtable GetUserHT(string userContact)
        {
            try
            {
                DbCommand cmd = db.GetStoredProcCommand("usp_USRMGMTGetUserFromContact");
                Hashtable UserHT;

                db.AddInParameter(cmd, "UserName", DbType.String, userContact);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    UserHT = new Hashtable();
                    while (dr.Read())
                    {
                        UserHT.Add("UID", dr["Userid"].ToString2());
                        UserHT.Add("FirstName", dr["FirstName"].ToString2());
                        UserHT.Add("MiddleName", dr["MiddleName"].ToString2());
                        UserHT.Add("LastName", dr["LastName"].ToString2());
                        UserHT.Add("CompanyName", dr["CompanyName"].ToString2());
                        UserHT.Add("UserID", dr["Username"].ToString2());
                        UserHT.Add("Password", dr["Password"].ToString2());
                        UserHT.Add("Email", dr["Email"].ToString2());
                        UserHT.Add("Telephone", dr["Telephone"].ToString2());
                        UserHT.Add("Fax", dr["Fax"].ToString2());
                        UserHT.Add("Address1", dr["Address1"].ToString2());
                        UserHT.Add("Address2", dr["Address2"].ToString2());
                        UserHT.Add("Address3", dr["Address3"].ToString2());
                        UserHT.Add("City", dr["City"].ToString2());
                        UserHT.Add("State", dr["State"].ToString2());
                        UserHT.Add("Zipcode", dr["Zipcode"].ToString2());
                        UserHT.Add("IsActive", dr.GetBoolean(16));
                        UserHT.Add("ExpiryDate", dr.GetDateTime(17));
                        UserHT.Add("IsLocked", dr.GetBoolean(18));
                        UserHT.Add("IsRegistered", dr.GetBoolean(19));
                        UserHT.Add("RegistrationDate", dr.GetDateTime(20));
                        UserHT.Add("CertNo", dr["CertNo"].ToString2());
                    }
                }
                return UserHT;
            }
            catch (Exception ex)
            {
                Logger.Log(Enumerations.LogType.Error, ex.Message, "Constants.MODID_USRMGMT");
                throw;
            }
        }
        internal Dictionary<int, string> GetUnassignedUserRoles(int uid)
        {
            try
            {
                Dictionary<int, string> userroles = new Dictionary<int, string>();
                DbCommand cmd = db.GetStoredProcCommand("usp_USRMGMTGetUserRoles");

                db.AddInParameter(cmd, "USERID", DbType.Int32, uid);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read()) // Populate dictionary
                        userroles.Add(dr.GetInt32(0), dr.GetString(1));
                }
                return userroles;
            }
            catch (Exception ex)
            {
                Logger.Log(Enumerations.LogType.Error, ex.Message, "Constants.MODID_USRMGMT");
                throw;
            }
        }
        internal Dictionary<int, string> GetAssignedRolesOfUser(int uid)
        {
            try
            {
                Dictionary<int, string> savedroles = new Dictionary<int, string>();
                DbCommand cmd = db.GetStoredProcCommand("usp_USRMGMTGetRolesOfUser");

                db.AddInParameter(cmd, "USERID", DbType.Int32, uid);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read()) //populate columns of dictionary from dataset
                        savedroles.Add(dr.GetInt32(0), dr.GetString(1));
                }
                return savedroles;
            }
            catch (Exception ex)
            {
                Logger.Log(Enumerations.LogType.Error, ex.Message, "Constants.MODID_USRMGMT");
                throw;
            }
        }
        //Adding roles to user specified by uid
        internal int AddRolesToUser(int uid, int roleid)
        {
            try
            {
                DbCommand cmd = db.GetStoredProcCommand("usp_USRMGMTAddRolesToUser");

                db.AddInParameter(cmd, "ROLEID", DbType.Int32, roleid);
                db.AddInParameter(cmd, "USERID", DbType.Int32, uid);
                db.AddOutParameter(cmd, "STATUS", DbType.Int32, 4);
                db.ExecuteScalar(cmd);

                return (BrixDatatypeHelper.ToInt32_2(db.GetParameterValue(cmd, "STATUS").ToString2()) > 0) ? 1 : 0;
            }
            catch (Exception ex)
            {
                Logger.Log(Enumerations.LogType.Error, ex.Message, "Constants.MODID_USRMGMT");
                throw;
            }
        }
        //deletes uerid with ids in userids
        internal int DeleteUser(int uid)
        {
            try
            {
                DbCommand cmd = db.GetStoredProcCommand("usp_USRMGMTDeleteUser");

                db.AddInParameter(cmd, "USERID", DbType.Int32, uid);
                db.AddOutParameter(cmd, "STATUS", DbType.Int32, 4);
                db.ExecuteScalar(cmd);

                return BrixDatatypeHelper.ToInt32_2(db.GetParameterValue(cmd, "STATUS").ToString2());
            }
            catch (Exception ex)
            {
                Logger.Log(Enumerations.LogType.Error, ex.Message, "Constants.MODID_USRMGMT");
                throw;
            }
        }
        internal int UpdateUser(User UserDTO)
        {
            try
            {
                DbCommand cmd = db.GetStoredProcCommand("usp_USRMGMTUpdateUser");

                db.AddInParameter(cmd, "FIRSTNAME", DbType.String, UserDTO.FirstName);
                db.AddInParameter(cmd, "MIDDLENAME", DbType.String, UserDTO.MiddleName);
                db.AddInParameter(cmd, "LASTNAME", DbType.String, UserDTO.LastName);
                db.AddInParameter(cmd, "COMPANYNAME", DbType.String, UserDTO.CompanyName);
                db.AddInParameter(cmd, "USERNAME", DbType.String, UserDTO.UserName);
                db.AddInParameter(cmd, "PASSWORD", DbType.String, UserDTO.Password);
                db.AddInParameter(cmd, "EMAIL", DbType.String, UserDTO.Email);
                db.AddInParameter(cmd, "ADDRESS1", DbType.String, UserDTO.Address1);
                db.AddInParameter(cmd, "ADDRESS2", DbType.String, UserDTO.Address2);
                db.AddInParameter(cmd, "ADDRESS3", DbType.String, UserDTO.Address3);
                db.AddInParameter(cmd, "CITY", DbType.String, UserDTO.City);
                db.AddInParameter(cmd, "STATE", DbType.String, UserDTO.State);
                db.AddInParameter(cmd, "ZIPCODE", DbType.String, UserDTO.Zipcode);
                db.AddInParameter(cmd, "TELEPHONE", DbType.String, UserDTO.Telephone);
                db.AddInParameter(cmd, "FAX", DbType.String, UserDTO.Fax);
                db.AddInParameter(cmd, "USERID", DbType.Int32, UserDTO.UserId);
                db.AddInParameter(cmd, "ISACTIVE", DbType.Boolean, UserDTO.IsActive);
                db.AddInParameter(cmd, "EXPDATE", DbType.DateTime, UserDTO.ExpiryDate);
                db.AddInParameter(cmd, "CERTNO", DbType.String, UserDTO.CertNo);
                db.AddInParameter(cmd, "WEBUSER", DbType.Boolean, UserDTO.WebUser);
                db.AddInParameter(cmd, "MOBILEUSER", DbType.Boolean, UserDTO.MobileUser);
                //db.AddInParameter(cmd, "SENDEMAIL", DbType.Boolean, UserDTO.SendEmail);
                db.AddOutParameter(cmd, "STATUS", DbType.Int32, 4);

                db.ExecuteScalar(cmd);

                return BrixDatatypeHelper.ToInt32_2(db.GetParameterValue(cmd, "STATUS").ToString2());
            }
            catch (Exception ex)
            {
                Logger.Log(Enumerations.LogType.Error, ex.Message, "Constants.MODID_USRMGMT");
                throw;
            }
        }
        internal int ActivateUser(int uid)
        {
            try
            {
                DbCommand cmd = db.GetStoredProcCommand("usp_USRMGMTActivateUser");

                db.AddInParameter(cmd, "USERID", DbType.Int32, uid);
                db.AddOutParameter(cmd, "STATUS", DbType.Int32, 4);
                db.ExecuteScalar(cmd);

                return BrixDatatypeHelper.ToInt32_2(db.GetParameterValue(cmd, "STATUS").ToString2());
            }
            catch (Exception ex)
            {
                Logger.Log(Enumerations.LogType.Error, ex.Message, "Constants.MODID_USRMGMT");
                throw;
            }
        }
        internal Dictionary<int, object> GetPendingUsers()
        {
            try
            {
                Dictionary<int, object> pendingusercoll = new Dictionary<int, object>();
                DbCommand cmd = db.GetStoredProcCommand("usp_USRMGMTGetPendingUsers");

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        User DTOobj = new User();

                        //populate all fields of DTO object from dataset
                        DTOobj.UserId = dr.GetInt32(0);
                        DTOobj.FirstName = dr[1].ToString2();
                        DTOobj.MiddleName = dr[2].ToString2();
                        DTOobj.LastName = dr[3].ToString2();
                        DTOobj.UserName = dr[4].ToString2();
                        DTOobj.Email = dr[5].ToString2();
                        DTOobj.RegDate = dr.GetDateTime(6);
                        DTOobj.CertNo = dr["CertNo"].ToString2();
                        pendingusercoll.Add(dr.GetInt32(0), DTOobj);
                    }
                }
                return pendingusercoll;
            }
            catch (Exception ex)
            {
                Logger.Log(Enumerations.LogType.Error, ex.Message, "Constants.MODID_USRMGMT");
                throw;
            }
        }
        //setting isregistered to 1 
        internal int ApproveUser(string uids)
        {
            try
            {
                int result;
                DbCommand cmd = db.GetStoredProcCommand("usp_USRMGMTApproveUser");
                db.AddInParameter(cmd, "USERIDS", DbType.String, uids);
                db.AddOutParameter(cmd, "STATUS", DbType.Int32, 4);
                db.ExecuteScalar(cmd);

                result = BrixDatatypeHelper.ToInt32_2(db.GetParameterValue(cmd, "STATUS").ToString2());

                if (result == 1)
                {
                    //add default role to user
                    string[] csvuids = uids.Split(',');
                    for (int i = 0; i < csvuids.Length; i++)
                        AddRolesToUser(BrixDatatypeHelper.ToInt32_2(csvuids[i]), 1);
                }

                return result;
            }
            catch (Exception ex)
            {
                Logger.Log(Enumerations.LogType.Error, ex.Message, "Constants.MODID_USRMGMT");
                throw;
            }
        }
        //deleting users who are rejected
        internal int RejectUser(string uids)
        {
            try
            {
                DbCommand cmd = db.GetStoredProcCommand("usp_USRMGMTRejectUser");

                db.AddInParameter(cmd, "USERIDS", DbType.String, uids);
                db.AddOutParameter(cmd, "STATUS", DbType.Int32, 4);
                db.ExecuteScalar(cmd);

                return BrixDatatypeHelper.ToInt32_2(db.GetParameterValue(cmd, "STATUS").ToString2());
            }
            catch (Exception ex)
            {
                Logger.Log(Enumerations.LogType.Error, ex.Message, "Constants.MODID_USRMGMT");
                throw;
            }
        }
        //deletes existing users for role
        internal int DeleteRoleUsers(int roleid)
        {
            try
            {
                int result;
                DbCommand cmd = db.GetStoredProcCommand("usp_USRMGMTDeleteRoleUsers");

                db.AddInParameter(cmd, "ROLEID", DbType.Int32, roleid);
                db.AddOutParameter(cmd, "STATUS", DbType.Int32, 4);
                db.ExecuteScalar(cmd);

                result = BrixDatatypeHelper.ToInt32_2(db.GetParameterValue(cmd, "STATUS").ToString2());
                return result == 1 ? 1 : result;
            }
            catch (Exception ex)
            {
                Logger.Log(Enumerations.LogType.Error, ex.Message, "Constants.MODID_USRMGMT");
                throw;
            }
        }
        //deletes existing roles for user
        internal int DeleteUserRoles(int uid)
        {
            try
            {
                int result;
                DbCommand cmd = db.GetStoredProcCommand("usp_USRMGMTDeleteUserRoles");

                db.AddInParameter(cmd, "USERID", DbType.Int32, uid);
                db.AddOutParameter(cmd, "STATUS", DbType.Int32, 4);
                db.ExecuteScalar(cmd);

                result = BrixDatatypeHelper.ToInt32_2(db.GetParameterValue(cmd, "STATUS").ToString2());
                return result == 1 ? 1 : result;
            }
            catch (Exception ex)
            {
                Logger.Log(Enumerations.LogType.Error, ex.Message, "Constants.MODID_USRMGMT");
                throw;
            }
        }
        internal Dictionary<int, string> GetRoles()
        {
            try
            {
                Dictionary<int, string> rolecollection = new Dictionary<int, string>();
                DbCommand cmd = db.GetStoredProcCommand("usp_USRMGMTGetAllRoles");

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                        rolecollection.Add(BrixDatatypeHelper.ToInt32_2(dr["RoleId"]), dr["RoleName"].ToString2());
                }
                return rolecollection;
            }
            catch (Exception ex)
            {
                Logger.Log(Enumerations.LogType.Error, ex.Message, "Constants.MODID_USRMGMT");
                throw;
            }
        }
        internal Dictionary<string, string> GetUserSettings()
        {
            Cache UMCache = HttpContext.Current.Cache;
            return UMCache["GetSettings"] != null
                             ? (Dictionary<string, string>)UMCache["GetSettings"]
                             : UpdateSettingsCache();
        }
        private Dictionary<string, string> UpdateSettingsCache()
        {
            try
            {
                Cache UMCache = HttpContext.Current.Cache;
                Dictionary<string, string> SettingsHT = new Dictionary<string, string>();

                DbCommand cmd = db.GetStoredProcCommand("usp_USRMGMTGetSettings");
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                        SettingsHT.Add(dr.GetString(0), dr.GetString(1));
                    UMCache.Insert("GetSettings", SettingsHT);
                }
                return SettingsHT;
            }
            catch (Exception ex)
            {
                Logger.Log(Enumerations.LogType.Error, ex.Message, "Constants.MODID_USRMGMT");
                throw;
            }
        }
        internal int UpdateSettings(Dictionary<string, string> Settingsht)
        {
            try
            {
                int result = 0;

                foreach (KeyValuePair<string, string> kvp in Settingsht)
                {
                    DbCommand cmd = db.GetStoredProcCommand("usp_USRMGMTUpdateSettings");
                    db.AddInParameter(cmd, "SETTINGNAME", DbType.String, kvp.Key);
                    db.AddInParameter(cmd, "SETTINGVAL", DbType.String, kvp.Value);
                    db.AddOutParameter(cmd, "STATUS", DbType.Int32, 4);
                    db.ExecuteScalar(cmd);
                    result = BrixDatatypeHelper.ToInt32_2(db.GetParameterValue(cmd, "STATUS"));
                }

                if (result == 1)
                    UpdateSettingsCache();

                return result;
            }
            catch (Exception ex)
            {
                Logger.Log(Enumerations.LogType.Error, ex.Message, "Constants.MODID_USRMGMT");
                throw;
            }
        }
        //locks the user from logging in to insite3.0
        internal int LockUser(int uid)
        {
            try
            {
                DbCommand cmd = db.GetStoredProcCommand("usp_USRMGMTLockUser");

                db.AddInParameter(cmd, "USERID", DbType.Int32, uid);
                db.AddOutParameter(cmd, "STATUS", DbType.Int32, 4);
                db.ExecuteScalar(cmd);

                return BrixDatatypeHelper.ToInt32_2(db.GetParameterValue(cmd, "STATUS"));
            }
            catch (Exception ex)
            {
                Logger.Log(Enumerations.LogType.Error, ex.Message, "Constants.MODID_USRMGMT");
                throw;
            }
        }
        //unlocks user 
        internal int UnlockUser(int uid)
        {
            try
            {
                DbCommand cmd = db.GetStoredProcCommand("usp_USRMGMTUnlockUser");

                db.AddInParameter(cmd, "USERID", DbType.Int32, uid);
                db.AddOutParameter(cmd, "STATUS", DbType.Int32, 4);
                db.ExecuteScalar(cmd);

                return BrixDatatypeHelper.ToInt32_2(db.GetParameterValue(cmd, "STATUS").ToString2());
            }
            catch (Exception ex)
            {
                Logger.Log(Enumerations.LogType.Error, ex.Message, "Constants.MODID_USRMGMT");
                throw;
            }
        }
        internal DataTable GetUserSummary()
        {
            try
            {
                DbCommand cmd = db.GetStoredProcCommand("usp_USRMGMTGetUserSummary");

                return db.ExecuteDataSet(cmd).Tables[0];
            }
            catch (Exception ex)
            {
                Logger.Log(Enumerations.LogType.Error, ex.Message, "Constants.MODID_USRMGMT");
                throw;
            }
        }
        /// <summary>
        /// ggets the complete details of all the users or requested users (for QSR))
        /// </summary>
        /// <returns>Dictionary<int,string>(key-uid,value-username)</returns>
        internal DataTable GetAllUsersDetails(string userlist)
        {
            try
            {
                DbCommand cmd = db.GetStoredProcCommand("usp_USRMGMTGetAllActiveUsers");

                if (!String.IsNullOrEmpty(userlist))
                    db.AddInParameter(cmd, "Userlist", DbType.String, userlist);

                return db.ExecuteDataSet(cmd).Tables[0];
            }
            catch (Exception ex)
            {
                Logger.Log(Enumerations.LogType.Error, ex.Message, "Constants.MODID_USRMGMT");
                throw;
            }
        }
        /// <summary>
        /// gets the uid and username from the DB in the form of a Dictionary(for DWR2)
        /// </summary>
        /// <returns>Dictionary<int,string>(key-uid,value-username)</returns>
        internal Dictionary<int, string> GetAllUsersDT()
        {
            try
            {
                Dictionary<int, string> userDT = new Dictionary<int, string>();
                DbCommand cmd = db.GetStoredProcCommand("usp_USRMGMTGetAllActiveUsers");

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        //populate dictionary key - uid,value - username
                        string fullname;
                        if (!String.IsNullOrEmpty(dr[2].ToString2()))
                            fullname = dr[1].ToString2() + " " + dr[2].ToString2() + " " + dr[3].ToString2();
                        else
                            fullname = dr[1].ToString2() + " " + dr[3].ToString2();

                        userDT.Add(dr.GetInt32(0), fullname);
                    }
                }

                return userDT;
            }
            catch (Exception ex)
            {
                Logger.Log(Enumerations.LogType.Error, ex.Message, "Constants.MODID_USRMGMT");
                throw;
            }
        }
        /// <summary>
        /// gets the user login id from a uid.
        /// </summary>
        /// <param name="uid"></param>
        /// <returns>string</returns>
        internal string GetLoginId(int uid)
        {
            try
            {
                string userid;

                DbCommand cmd = db.GetStoredProcCommand("usp_USRMGMTGetLoginId");

                db.AddInParameter(cmd, "USERID", DbType.Int32, uid);
                db.AddOutParameter(cmd, "STATUS", DbType.String, 100);
                db.ExecuteScalar(cmd);

                userid = BrixDatatypeHelper.ToString2(db.GetParameterValue(cmd, "STATUS"));
                return String.IsNullOrEmpty(userid) ? "0" : userid;
            }
            catch (Exception ex)
            {
                Logger.Log(Enumerations.LogType.Error, ex.Message, "Constants.MODID_USRMGMT");
                throw;
            }
        }
        internal int GetPasswordLength()
        {
            Dictionary<string, string> settings = GetUserSettings();
            string pwdformat = settings["PasswordFormat"];
            //int indx = pwdformat.IndexOf("{");
            int comma = pwdformat.IndexOf(",",StringComparison.OrdinalIgnoreCase);
            int endbkt = pwdformat.IndexOf("}",StringComparison.OrdinalIgnoreCase);
            int pwdlength = BrixDatatypeHelper.ToInt32_2(pwdformat.Substring(comma + 1, endbkt - (comma + 1)));
            return pwdlength;
        }
        internal int UpdateUserPassword(string pwd, int uid)
        {
            try
            {
                DbCommand cmd = db.GetStoredProcCommand("usp_USRMGMTUpdateUserPassword");

                db.AddInParameter(cmd, "PASSWORD", DbType.String, pwd);
                db.AddInParameter(cmd, "USERID", DbType.Int32, uid);
                db.AddOutParameter(cmd, "STATUS", DbType.Int32, 4);
                db.ExecuteScalar(cmd);

                return BrixDatatypeHelper.ToInt32_2(db.GetParameterValue(cmd, "STATUS").ToString2());
            }
            catch (Exception ex)
            {
                Logger.Log(Enumerations.LogType.Error, ex.Message, "Constants.MODID_USRMGMT");
                throw;
            }
        }
        internal bool IsUserRole(int uid, int roleid)
        {
            try
            {
                DbCommand cmd = db.GetStoredProcCommand("usp_USRMGMTIsUserRole");

                db.AddInParameter(cmd, "USERID", DbType.String, uid);
                db.AddInParameter(cmd, "ROLEID", DbType.String, roleid);
                db.AddOutParameter(cmd, "RESULT", DbType.Int32, 4);
                db.ExecuteScalar(cmd);

                return BrixDatatypeHelper.ToInt32_2(db.GetParameterValue(cmd, "RESULT").ToString2()) == 1 ? true : false;
            }
            catch (Exception ex)
            {
                Logger.Log(Enumerations.LogType.Error, ex.Message, "Constants.MODID_USRMGMT");
                throw;
            }
        }
        internal Dictionary<string, string> GetUserEmailIdByRole(int roleid)
        {
            try
            {
                Dictionary<string, string> result = new Dictionary<string, string>();

                DbCommand cmd = db.GetStoredProcCommand("usp_USRMGMTGetUsersEmailInRole");

                db.AddInParameter(cmd, "ROLEID", DbType.Int32, roleid);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read()) //populate dictionary key - emailid,value - username
                        result.Add(dr.GetString(0), dr.GetString(1));
                }
                return result;
            }
            catch (Exception ex)
            {
                Logger.Log(Enumerations.LogType.Error, ex.Message, "Constants.MODID_USRMGMT");
                throw;
            }
        }
        internal int GetCountOfMobileUsers()
        {
            try
            {
                return BrixDatatypeHelper.ToInt32_2(db.ExecuteScalar(CommandType.Text, "SELECT COUNT(*) FROM USRMGMTUserDetails WHERE MobileUser = 1"));
            }
            catch (Exception ex)
            {
                Logger.Log(Enumerations.LogType.Error, ex.Message, "Constants.MODID_USRMGMT");
                throw;
            }
        }

        // This function is for the mobile. It checks whether the registered user is marked as mobile user.
        internal bool CheckForMobileUser(string userID, string password)
        {
            try
            {
                DbCommand command = db.GetSqlStringCommand("SELECT COUNT(*) FROM USRMGMTUserDetails WHERE isnull(MobileUser,0) = 1 AND Username= @USERID AND Password= @PASSWORD");

                db.AddInParameter(command, "USERID", DbType.String, userID);
                db.AddInParameter(command, "PASSWORD", DbType.String, password);

                return BrixDatatypeHelper.ToInt32_2(db.ExecuteScalar(command)) == 1 ? true : false;

            }
            catch (Exception ex)
            {
                Logger.Log(Enumerations.LogType.Error, ex.Message, "Constants.MODID_USRMGMT");
                throw;
            }
        }

        internal bool IsUserOnlyMobileuser(string userID, string password)
        {
            try
            {
                DbCommand command = db.GetSqlStringCommand("SELECT COUNT(*) FROM USRMGMTUserDetails WHERE isnull(MobileUser,0) = 1 AND isnull(WebUser,1) = 0 AND Username= @USERID AND Password= @PASSWORD");

                db.AddInParameter(command, "USERID", DbType.String, userID);
                db.AddInParameter(command, "PASSWORD", DbType.String, password);

                return BrixDatatypeHelper.ToInt32_2(db.ExecuteScalar(command)) == 1 ? true : false;

            }
            catch (Exception ex)
            {
                Logger.Log(Enumerations.LogType.Error, ex.Message, "Constants.MODID_USRMGMT");
                throw;
            }
        }

        internal User GetUserDTO(string userName)
        {
            //try
            //{
            //    return (from usr in new CoreDb().Users
            //            where usr.UserName == userName
            //            select usr).Single();
            //}
            //catch (Exception ex)
            //{
            //    Logger.Log(Enumerations.LogType.Error, ex.Message, "Constants.MODID_USRMGMT");
            //    throw;
            //}
            return null;
        }

        internal User GetUserDTO(int uid)
        {
            try
            {
                return null;  //(from usr in new CoreDb().Users
                //              where usr.UserId == uid
                //              select usr).Single();
            }
            catch (Exception ex)
            {
                Logger.Log(Enumerations.LogType.Error, ex.Message, "Constants.MODID_USRMGMT");
                throw;
            }
        }

        #region Mobile APIs - used only when running in mobile mode

        //public User ValidateUserFromWebServer(string userName, string hashPassword)
        //{
        //    // call a web service and then return the details
        //    // finally you need to save the details in the local database
        //    User user = new User();
        //    return user;

        //}

        internal DataSet GetFormExplorerXML(string username)
        {
            return ComponentHelper.Instance.ExecuteDataSet(StoredProcedure.usp_OFFLINEGetFormExplorerXML, null, username);
        }

        internal DataSet GetMobileUserData(string username)
        {
            return ComponentHelper.Instance.ExecuteDataSet(StoredProcedure.usp_OFFLINEGetMobileUserData, null, username);
        }

        internal void InsertProjects(string xmlProjects, int UserID)
        {
            ComponentHelper.Instance.ExecuteNonQueryWithVariableParameters(StoredProcedure.usp_OFFLINEInsertProjects, null, xmlProjects, UserID);
        }

        internal void InsertContracts(string xmlContracts)
        {
            ComponentHelper.Instance.ExecuteNonQueryWithVariableParameters(StoredProcedure.usp_OFFLINEInsertContracts, null, xmlContracts);
        }

        internal void InsertModules(string xmlModules)
        {
            ComponentHelper.Instance.ExecuteNonQueryWithVariableParameters(StoredProcedure.usp_OFFLINEInsertModules, null, xmlModules);
        }

        internal void InsertContModules(string xmlContModules)
        {
            ComponentHelper.Instance.ExecuteNonQueryWithVariableParameters(StoredProcedure.usp_OFFLINEInsertContModules, null, xmlContModules);
        }

        #endregion
    }
}