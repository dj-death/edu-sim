using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EduSim.CoreFramework.Common;

namespace MyTestForm
{
    [ListModelContext(Name = "LIBACTI", Table = "MODMGMTModules", DefaultSortColumn = "ModuleID")]
    public class TestListModel : ListModel
    {
    }
}
