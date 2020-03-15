using System;
using System.Collections.Generic;
using System.Resources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProjectForCompany2.Data;
using ProjectForCompany2.IOUtility.CSV;
using ProjectForCompany2.IOUtility.Resx;

namespace ProjectForCompany2Tests
{
    [TestClass]
    public class EntityReadingConversionTests
    {

        [TestMethod]
        public void Csv_file_reader_shouldCreateCorrectEntity()
        {
            string[] emptyEntites = new string[0];
            string[] entitesArray = new string[]
            {
                "Name1", "Value1","Comment1"
            };

            Mock<IEntityComparer> mock = new Mock<IEntityComparer>();
            mock.Setup(m => m.CompareEntityListWithObject(new List<Entity>(), new Entity())).Returns(false);

            CsvFileReader csvFileReader = new CsvFileReader(mock.Object);

            Entity eleWithEmptyEntityArray = csvFileReader.CsvEntityToDataEntity(emptyEntites);
            Entity eleWithEntity = csvFileReader.CsvEntityToDataEntity(entitesArray);

            Assert.AreEqual(eleWithEmptyEntityArray.Name, null);
            Assert.AreEqual(eleWithEntity.Name, entitesArray[0]);
        }

        [TestMethod]
        public void Resx_file_reader_shouldReturnCorrectResxDataNode()
        {
            var mockDict = new Dictionary<string, ResXDataNode>();
            mockDict.Add("Name1", new ResXDataNode("Name1", "Value1") { Comment = "Comment1" });
            mockDict.Add("Name2", new ResXDataNode("Name2", "Value2"));

            Mock<IEntityComparer> mockComparer = new Mock<IEntityComparer>();
            mockComparer.Setup(m => m.CompareEntityListWithObject(new List<Entity>(), new Entity())).Returns(false);

            ResxFileReader csvFileReader = new ResxFileReader(mockComparer.Object);
            var list = csvFileReader.ProcessResxResourceFile(mockDict.GetEnumerator(), new List<Entity>());
            var rX1 = new Entity { Name = "Name1", Value = "Value1", Comment = "Comment1" };
            Assert.AreEqual(list[0], rX1);
        }



    }
}
