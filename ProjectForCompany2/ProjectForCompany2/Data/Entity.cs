using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjectForCompany2.Data
{
    /// <summary>
    /// Main class for setting and getting data from files
    /// </summary>
    public class Entity
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "value")]
        public string Value { get; set; }

        [XmlElement(ElementName = "comment")]
        public string Comment { get; set; }

        public Entity(string name, string value, string comment)
        {
            Name = name;
            Value = value;
            Comment = comment;
        }

        public Entity()
        {

        }

        public static bool operator ==(Entity left,
                            Entity right)
        {
            return Equals(left, right);
        }


        public static bool operator !=(Entity left,
                               Entity right)
        {
            return !(left == right);
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (this.GetType() != other.GetType())
                return false;

            return Equals((Entity)other);
        }

        public bool Equals(Entity other)
        {
            return Equals(other.Name, Name);
        }


        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }

        public override string ToString()
        {
            string com = Comment == String.Empty || Comment == null ? String.Empty : ";" + Comment;
            return Name + ";" + Value + com;
        }
    }
}
