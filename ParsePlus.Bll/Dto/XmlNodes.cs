using System;
using System.Collections.Generic;

namespace ParsePlus.Bll.Dto
{
    [Serializable]
    public class XmlNodes
    {
        public string NodeName { get; set; }

        public List<XmlNodes> SubNodeList { get; set; }
    }
}
