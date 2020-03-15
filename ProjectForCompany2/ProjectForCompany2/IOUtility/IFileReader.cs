using ProjectForCompany2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectForCompany2.IOUtility
{
    public interface IFileReader
    {
        IEnumerable<Entity> Read(string filename, IEnumerable<Entity> currentList);
    }
}
