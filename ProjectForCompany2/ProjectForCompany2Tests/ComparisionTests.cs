using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectForCompany2.Data;

namespace ProjectForCompany2Tests
{
    [TestClass]
    public class ComparisionTests
    {
        [TestMethod]
        public void check_data_entityComparision()
        {
            EntityComparer comparer = new EntityComparer();

            var listOfEntites = new List<Entity>()
            {
                new Entity("name1","value1","com1"),
                new Entity("name2","value2","com2"),
            };

            var objectBeingCompared = new Entity("name2", "value2", "com2");

            Assert.IsTrue(comparer.CompareEntityListWithObject(listOfEntites, objectBeingCompared));

        }
    }
}
