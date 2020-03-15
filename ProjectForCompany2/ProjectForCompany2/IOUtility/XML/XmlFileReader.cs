using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using ProjectForCompany2.Data;
using ProjectForCompany2.Data.Serialization;

namespace ProjectForCompany2.IOUtility.XML
{
    public class XmlFileReader : IFileReader
    {
        private IEntityComparer _comparer;

        public XmlFileReader(IEntityComparer entityComparer)
        {
            _comparer = entityComparer;
        }

        /// <summary>
        /// Reads xml file and returns data in entites
        /// </summary>
        /// <param name="filename">File filename from which data will be taken</param>
        /// <param name="currentList">Current list in view</param>
        /// <returns>All data from file</returns>
        public IEnumerable<Entity> Read(string filename, IEnumerable<Entity> currentList)
        {
            List<Entity> elements = new List<Entity>();

            //Serialize file in order to easier setting values
            var serializer = new XmlSerializer(typeof(EntityElements));
            EntityElements entites = new EntityElements();
            using (Stream fs = new FileStream(filename, FileMode.Open))
            {
                entites = (EntityElements)serializer.Deserialize(fs);
            }

            foreach (var item in entites.Entities)
            {
                if (!(_comparer.CompareEntityListWithObject(currentList, item)))
                    elements.Add(item);
            }
            return elements;
        }

    }
}
