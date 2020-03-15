using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectForCompany2.Data;
using ProjectForCompany2.Encryption;

namespace ProjectForCompany2.IOUtility.CSV
{
    public class CsvFileWriter : IFileWriter
    {
        private IEncryptor _encryptor;

        public CsvFileWriter(IEncryptor encryptor)
        {
            _encryptor = encryptor;
        }

        /// <summary>
        /// Writes elements to file
        /// </summary>
        /// <param name="list">List which will be saved</param>
        /// <param name="writer">Streamer for writing</param>
        /// <param name="header">First line in file</param>
        public void SaveListToFile(IEnumerable<Entity> list, StreamWriter writer, string header)
        {
            writer.WriteLine(header);

            foreach (var ele in list)
            {
                writer.WriteLine(ele.ToString());
            }
        }

        /// <summary>
        /// Writes Entity list to csv file
        /// </summary>
        /// <param name="listToSave">List which will be saved</param>
        /// <param name="filename">Filename to which data will be saved</param>
        /// <param name="password">Optional password for saving file</param>
        public void Write(IEnumerable<Entity> listToSave, string filename, string password = null)
        {
            const string header = "Nazwa,Wartość,Komentarz";

            using (StreamWriter writer = new StreamWriter(filename))
            {
                if (listToSave.Count() > 0)
                {
                    SaveListToFile(listToSave, writer, header);
                }
            }
            if (password != null)
                _encryptor.EncryptFileWithPassword(filename, password);
            MessageBox.Show("Pomyślnie zapisano plik");
        }
    }
}
