using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace EduSim.CoreFramework.Common
{
    public class SessionConstants
    {
        public static string CurrentUser = "CurrentUser";
        public static string CurrentRound = "CurrentRound";
        public static string ActiveRound = "ActiveRound";
    }

    public enum SessionConstant
    {
        RnDData,
        MarketingData,
        ProductionData,
        FinanceData,
        LabourData
    }

    public class TabConstants
    {
        public static string Administrator = "Administrator";
        public static string Simulation = "Simulation";
    }

    public class Constants
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["ESimConnectionString"].ConnectionString;
    }

}
