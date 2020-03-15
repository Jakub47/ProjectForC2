using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjectForCompany2.Data.Serialization
{
    /// <summary>
    /// Helper class meant to serialize xml tags 
    /// </summary>
    public class EntityElements
    {
        [XmlElement("data")]
        public List<Entity> Entities { get; set; }

        public EntityElements()
        {

        }
    }
}
