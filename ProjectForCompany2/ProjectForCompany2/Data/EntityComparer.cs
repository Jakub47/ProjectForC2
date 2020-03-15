using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectForCompany2.Data
{
    /// <summary>
    /// Class responsible for comparing objects
    /// </summary>
    public class EntityComparer : IEntityComparer
    {
        /// <summary>
        /// Checks wheter list contains a given object
        /// </summary>
        /// <param name="nodeList">List with objects</param>
        /// <param name="node2">Object to check in list</param>
        /// <returns>bool does list contains given object</returns>
        public bool CompareEntityListWithObject(IEnumerable<Entity> nodeList, Entity node2)
        {
            return nodeList.Any(a => a == node2) ? true : false;
        }
    }
}
