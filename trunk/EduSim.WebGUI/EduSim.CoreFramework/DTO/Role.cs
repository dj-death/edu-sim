namespace Aurigo.AMP3.UserManagementDTO
{
    public class Role
    {
        //methods
        private int roleid;
        private string rolename;
        private string roledescription;

        //properties
        public int RoleId
        {
            get { return roleid; }
            set { roleid = value; }
        }

        public string RoleName
        {
            get { return rolename; }
            set { rolename = value; }
        }

        public string RoleDescription
        {
            get { return roledescription; }
            set { roledescription = value; }
        }
    }
}