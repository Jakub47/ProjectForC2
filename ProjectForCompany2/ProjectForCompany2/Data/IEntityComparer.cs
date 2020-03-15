using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectForCompany2.Data
{
    public interface IEntityComparer
    {
        bool CompareEntityListWithObject(IEnumerable<Entity> nodeList, Entity node2);
    }
}
