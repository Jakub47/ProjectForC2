using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using ProjectForCompany2.Data;
using ProjectForCompany2.Data.Serialization;
using ProjectForCompany2.Encryption;

namespace ProjectForCompany2.IOUtility.XML
{
    public class XmlFileWriter : IFileWriter
    {
        private IEncryptor _encryptor;

        public XmlFileWriter(IEncryptor encryptor)
        {
            _encryptor = encryptor;
        }

        /// <summary>
        /// Writes Entity list to Xml file
        /// </summary>
        /// <param name="listToSave">List which will be saved</param>
        /// <param name="filename">Filename to which data will be saved</param>
        /// <param name="password">Optional password for saving file</param>
        public void Write(IEnumerable<Entity> listToSave, string filename, string password = null)
        {
            var entityList = new EntityElements() { Entities = (List<Entity>)listToSave };
            var serializer = new XmlSerializer(typeof(EntityElements));
            using (Stream fs = new FileStream(filename, FileMode.Create))
            {
                using (var writer = new XmlTextWriter(fs, Encoding.Unicode))
                {
                    //Add spaces between next tags
                    writer.Formatting = Formatting.Indented;
                    writer.Indentation = 4;
                    serializer.Serialize(writer, entityList);
                }
            }
            if (password != null)
                _encryptor.EncryptFileWithPassword(filename, password);
            MessageBox.Show("Pomyślnie zapisano plik");
        }
    }
}
