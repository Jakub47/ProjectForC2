using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectForCompany2.Data;
using ProjectForCompany2.Data.Serialization;

namespace ProjectForCompany2Tests
{
    [TestClass]
    public class SerializationTests
    {
        [TestMethod]
        public void checkDeserializationOfEntity()
        {
            var entity = new Entity { Name = "TEXT_COMBO-ENABLED", Value = "AKTYWNY", Comment = String.Empty };
            var serializer = new XmlSerializer(typeof(EntityElements));
            EntityElements entites = new EntityElements();
            string xmlToCompare = @"<?xml version=""1.0""?><EntityElements xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">  <data name=""TEXT_COMBO-ENABLED"">  <value>AKTYWNY</value>  <comment />  </data></EntityElements>";

            //XmlDocument was used since Deserializer have problem with xml file from memory stream
            XmlDocument cas = new XmlDocument();
            cas.LoadXml(xmlToCompare);

            using (XmlNodeReader reader = new XmlNodeReader(cas))
            {
                entites = (EntityElements)serializer.Deserialize(reader);
            }

            Assert.AreEqual(entites.Entities[0].Name, entity.Name);
        }

        [TestMethod]
        public void checkSerializationOfEntity()
        {
            var entity = new Entity { Name = "TEXT_COMBO-ENABLED ", Value = "AKTYWNY", Comment = String.Empty };
            var serializer = new XmlSerializer(typeof(EntityElements));
            EntityElements entites = new EntityElements()
            {
                Entities = new System.Collections.Generic.List<Entity>()
            };
            entites.Entities.Add(entity);
            MemoryStream stream = new MemoryStream();

            string xmlToCompare = @"<?xml version=""1.0""?><EntityElements xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">  <data name=""TEXT_COMBO-ENABLED"">  <value>AKTYWNY</value>  <comment />  </data></EntityElements>";
            xmlToCompare = Regex.Replace(xmlToCompare, @"\s+", "");

            //save entites to memory stream to test serialization in acctual file
            serializer.Serialize(stream, entites);

            //Delete neccessary elemnts for easier comparrision
            string stringStream = Encoding.Default.GetString(stream.ToArray());
            stringStream = stringStream.Replace("\r\n", string.Empty);
            stringStream = stringStream.Replace(@"\", string.Empty);
            stringStream = Regex.Replace(xmlToCompare, @"\s+", "");

            Assert.AreEqual(xmlToCompare, stringStream);
        }
    }
}
