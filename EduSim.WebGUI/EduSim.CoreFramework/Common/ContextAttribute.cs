using System;
using System.Collections.Generic;
using System.Text;

namespace EduSim.CoreFramework.Common
{
    public class ContextAttribute : Attribute 
    {
        public string Name = string.Empty;
    }

    public class XMLTreeContextAttribute : ContextAttribute
    {
        public string ModuleId = string.Empty;
    }

    public class ListModelContextAttribute : ContextAttribute
    {
        public string Table = string.Empty;
        public string DefaultSortColumn = string.Empty;
    }

    public class ReportModelContextAttribute : ContextAttribute
    {
        public bool HasGrid = false;
        public bool HasFilter = false;
        public string ModuleId = string.Empty;
    }

    public class ItemModelContextAttribute : ContextAttribute
    {
        public string ModuleId = string.Empty;
    }
    public class ItemListModelContextAttribute : ContextAttribute
    {
    }
    public class WebPartsAttribute : ContextAttribute
    {
        //List of (,) seperated Module Ids. Dashboard show this Webpart only if the context module Id is available in this list.
        public string SupportedDashboard;
        //Module Id of the WebPart. Web part Visibility is based on the users visibility permission on this module Id.
        public string ModuleId;
    }
}
