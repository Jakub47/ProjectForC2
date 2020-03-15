using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectForCompany2.Data;
using ProjectForCompany2.Encryption;

namespace ProjectForCompany2.IOUtility.Resx
{
    public class ResxFileWriter : IFileWriter
    {
        private IEncryptor _encryptor;

        public ResxFileWriter(IEncryptor encryptor)
        {
            _encryptor = encryptor;
        }

        /// <summary>
        /// Writes Entity list to Resx file
        /// </summary>
        /// <param name="listToSave">List which will be saved</param>
        /// <param name="filename">Filename to which data will be saved</param>
        /// <param name="password">Optional password for saving file</param>
        public void Write(IEnumerable<Entity> listToSave, string filename, string password = null)
        {
            using (Stream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                using (ResXResourceWriter resx = new ResXResourceWriter(fs))
                {
                    foreach (var item in listToSave)
                    {
                        resx.AddResource(new ResXDataNode(item.Name, item.Value) { Comment = item.Comment });
                    }
                }
            }
            if (password != null)
                _encryptor.EncryptFileWithPassword(filename, password);
            MessageBox.Show("Pomyślnie zapisano plik");
        }
    }
}
