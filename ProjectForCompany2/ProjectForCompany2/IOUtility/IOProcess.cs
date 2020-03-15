using ProjectForCompany2.Data;
using ProjectForCompany2.Encryption;
using ProjectForCompany2.IOUtility.CSV;
using ProjectForCompany2.IOUtility.Resx;
using ProjectForCompany2.IOUtility.XML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ProjectForCompany2.IOUtility
{
    public class IOProcess
    {
        public IFileReader FileReader { get; set; }
        public IFileWriter FileWriter { get; set; }

        public IOProcess(IFileReader fileReader, IFileWriter fileWriter)
        {
            FileReader = fileReader;
            FileWriter = fileWriter;
        }

        /// <summary>
        /// Reades resx files and converts them to custom list
        /// </summary>
        /// <param name="openFileDialog">file dialog for providing file's location</param>
        /// <returns>List with all values from resx file</returns>
        public IEnumerable<Entity> ReadFiles(FileDialog openFileDialog, IEnumerable<Entity> currentEntityInView)
        {
            IEnumerable<Entity> tempList = new List<Entity>();

            DialogResult dr = openFileDialog.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                // Read the files
                foreach (String file in openFileDialog.FileNames)
                {
                    //Check for file extenstions and set proper algorithm for dealing with file
                    switch (System.IO.Path.GetExtension(file))
                    {
                        case ".resx":
                            FileReader = new ResxFileReader(Program.container.GetInstance<IEntityComparer>());
                            break;
                        case ".xml":
                            FileReader = new XmlFileReader(Program.container.GetInstance<IEntityComparer>());
                            break;
                        case ".csv":
                            FileReader = new CsvFileReader(Program.container.GetInstance<IEntityComparer>());
                            break;
                        default:
                            MessageBox.Show("Proszę wskazać plik resx, xml lub csv");
                            return tempList;
                    }
                    tempList = tempList.Concat(FileReader.Read(file, tempList)).ToList();
                }
            }
            else if (dr == System.Windows.Forms.DialogResult.Cancel)
            {
                return currentEntityInView;
            }
            return tempList;
        }

        /// <summary>
        /// Writes list of resx to csv
        /// </summary>
        /// <param name="listToSave">List of resxNode which will be saved to file</param>
        /// <param name="password">Exceptional password for securing zip null if not creating zip file</param>
        public void SaveListToCsvFile(IEnumerable<Entity> listToSave, string fileType, string password = null)
        {
            if (listToSave == null || listToSave.Count() < 1)
            {
                MessageBox.Show("Pusta tabela");
                return;
            }

            string filter = "";
            string defaultExt = "";

            //Check for file extenstions and set proper algorithm for dealing with file
            //Also filter objects and set default extension id file dialog
            switch (fileType)
            {
                case "CSV":
                    FileWriter = new CsvFileWriter(Program.container.GetInstance<IEncryptor>());
                    filter = "CSV file (*.csv)|*.csv";
                    defaultExt = "csv";
                    break;
                case "RESX":
                    FileWriter = new ResxFileWriter(Program.container.GetInstance<IEncryptor>());
                    filter = "RESX file (*.resx)|*.resx";
                    defaultExt = "resx";
                    break;
                case "XML":
                    FileWriter = new XmlFileWriter(Program.container.GetInstance<IEncryptor>());
                    filter = "XML file (*.xml)|*.xml";
                    defaultExt = "xml";
                    break;
                default:
                    MessageBox.Show("Nie poprawny format pliku proszę zmienić");
                    return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Filter = filter,
                DefaultExt = defaultExt
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileWriter.Write(listToSave, saveFileDialog.FileName, password);
            }


        }
    }
}
