using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using ProjectForCompany2.Data;


namespace ProjectForCompany2.IOUtility.Resx
{
    public class ResxFileReader : IFileReader
    {
        private IEntityComparer _comparer;

        public ResxFileReader(IEntityComparer entityComparer)
        {
            _comparer = entityComparer;
        }
        /// <summary>
        /// Reads resx file and returns data in entites
        /// </summary>
        /// <param name="filename">Resx filename from which data will be taken</param>
        /// <param name="currentList">Current list in view</param>
        /// <returns>All data from file</returns>
        public IEnumerable<Entity> Read(string filename, IEnumerable<Entity> currentList)
        {
            List<Entity> elements = new List<Entity>();

            using (ResXResourceReader resxReader = new ResXResourceReader(filename))
            {
                resxReader.UseResXDataNodes = true;
                elements = ProcessResxResourceFile(resxReader.GetEnumerator(), currentList); //get enumerator from reader for easier getting values
            }
            return elements;
        }

        /// <summary>
        /// Method which from enumerator converts Values from dictionary and saves them into list
        /// </summary>
        /// <param name="dict">IDictionary which is in fact enumerator of ResXResourceReader</param>
        /// <param name="currentListFromView">Current list in view<</param>
        /// <returns>Converted objects from resx file</returns>
        public List<Entity> ProcessResxResourceFile(IDictionaryEnumerator dict, IEnumerable<Entity> currentListFromView)
        {
            List<Entity> elements = new List<Entity>();

            while (dict.MoveNext())
            {
                ResXDataNode node = (ResXDataNode)dict.Value;
                var newEntityObject = ProcessEntity(node);
                if (!(_comparer.CompareEntityListWithObject(currentListFromView, newEntityObject)))
                    elements.Add(newEntityObject);
            }

            return elements;
        }

        /// <summary>
        /// Convert ResXDataNode to Entity
        /// </summary>
        /// <param name="node">ResXDataNode with name, value and additional comment</param>
        /// <returns>Enity object with values from ResXDataNode</returns>
        private Entity ProcessEntity(ResXDataNode node)
        {
            string name = node.Name;
            string value = node.GetValue((ITypeResolutionService)null) as string;
            string comment = node.Comment;

            return new Entity(name, value, comment);
        }
    }
}
