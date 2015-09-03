using ParsePlus.Bll.Dto;
using System.Collections.Generic;

namespace ParsePlus.Web.Views
{
    public class XmlViewModel
    {
        public string SourceFilePath { get; set; }

        public List<XmlNodes> XmlNodes { get; set; }
    }
}