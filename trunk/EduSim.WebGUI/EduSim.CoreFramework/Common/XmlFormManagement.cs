using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace EduSim.CoreFramework.Common
{
    [Serializable]
    [XmlRoot("EsimMainForm", IsNullable = false)]
    public class EsimMainForm
    {
        [XmlAttribute("TableName")]
        public string TableName = string.Empty;
        [XmlAttribute("PrimaryKeyName")]
        public string PrimaryKeyName = string.Empty;
        [XmlAttribute("HandlerClass")]
        public string HandlerClass = string.Empty;
        [XmlAttribute("SaveEvent")]
        public string SaveEvent = string.Empty;
        [XmlAttribute("DeleteEvent")]
        public string DeleteEvent = string.Empty;
        [XmlElement("EsimDataEntry")]
        public List<EsimDataEntry> EsimDataEntries = new List<EsimDataEntry>();
    }

    [Serializable]
    public class EsimDataEntry
    {
        [XmlAttribute("EsimControl")]
        public EsimControl EsimControl = EsimControl.TextBox;
        [XmlAttribute("Name")]
        public string Name;
        [XmlAttribute("Text")]
        public string Text;
        [XmlAttribute("IsFirstColumn")]
        public bool IsFirstColumn = true;
        [XmlAttribute("IsPassword")]
        public bool IsPassword = false;
        [XmlAttribute("DataSource")]
        public string DataSource = string.Empty;
    }

}
