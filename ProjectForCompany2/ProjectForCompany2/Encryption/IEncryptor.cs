using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectForCompany2.Encryption
{
    public interface IEncryptor
    {
        void EncryptFileWithPassword(string filename, string pwd);
    }
}
