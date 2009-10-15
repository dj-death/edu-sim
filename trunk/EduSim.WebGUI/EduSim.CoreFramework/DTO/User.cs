using System;

namespace Aurigo.AMP3.UserManagementDTO
{
    /// <summary>
    /// DTO class for User Details
    /// </summary>
    public class User
    {
        //Members
        private string userID;

        private string firstname;

        private string lastname;

        private string middlename;

        private string password;

        private string companyname;

        private string address1;

        private string address2;

        private string address3;

        private string city;

        private string state;

        private string zipcode;

        private string telephone;

        private string email;

        private string fax;

        private bool isactive;

        private bool isregistered;

        private bool islocked;

        private DateTime regdate;

        private DateTime expirydate;

        private int uid;

        private string certno;

        private string roleids;

        private bool sendemail;
        
        private int webUser;

        private int mobileUser;

        //Properties
        public string UserName
        {
            get { return userID; }
            set { userID = value; }
        }

        public int UserId
        {
            get { return uid; }
            set { uid = value; }
        }

        public string CertNo
        {
            get { return certno; }
            set { certno = value; }
        }

        public string FirstName
        {
            get { return firstname; }
            set { firstname = value; }
        }

        public string MiddleName
        {
            get { return middlename; }
            set { middlename = value; }
        }

        public string LastName
        {
            get { return lastname; }
            set { lastname = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string CompanyName
        {
            get { return companyname; }
            set { companyname = value; }
        }

        public string Address1
        {
            get { return address1; }
            set { address1 = value; }
        }

        public string Address2
        {
            get { return address2; }
            set { address2 = value; }
        }

        public string Address3
        {
            get { return address3; }
            set { address3 = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public string State
        {
            get { return state; }
            set { state = value; }
        }

        public string Zipcode
        {
            get { return zipcode; }
            set { zipcode = value; }
        }

        public string Telephone
        {
            get { return telephone; }
            set { telephone = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Fax
        {
            get { return fax; }
            set { fax = value; }
        }

        public bool IsActive
        {
            get { return isactive; }
            set { isactive = value; }
        }

        public bool SendEmail
        {
            get { return sendemail; }
            set { sendemail = value; }
        }

        public bool IsRegistered
        {
            get { return isregistered; }
            set { isregistered = value; }
        }

        public bool IsLocked
        {
            get { return islocked; }
            set { islocked = value; }
        }

        public DateTime RegDate
        {
            get { return regdate; }
            set { regdate = value; }
        }

        public DateTime ExpiryDate
        {
            get { return expirydate; }
            set { expirydate = value; }
        }

        public string RoleIDs
        {
            get { return roleids; }
            set { roleids = value; }
        }

        public int WebUser
        {
            get { return webUser; }
            set { webUser = value; }
        }

        public int MobileUser
        {
            get { return mobileUser; }
            set { mobileUser = value; }
        }
    }
}