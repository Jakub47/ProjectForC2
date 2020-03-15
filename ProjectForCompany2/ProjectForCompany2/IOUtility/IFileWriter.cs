using ProjectForCompany2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectForCompany2.IOUtility
{
    public interface IFileWriter
    {
        void Write(IEnumerable<Entity> listToSave, string filename, string password = null);
    }
}
