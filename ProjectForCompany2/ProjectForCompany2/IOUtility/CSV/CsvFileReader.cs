using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
using ProjectForCompany2.Data;

namespace ProjectForCompany2.IOUtility.CSV
{
    /// <summary>
    /// Class for reading csv file and converting data to Entity List
    /// </summary>
    public class CsvFileReader : IFileReader
    {
        private IEntityComparer _comparer;

        public CsvFileReader(IEntityComparer entityComparer)
        {
            _comparer = entityComparer;
        }

        /// <summary>
        /// Reads csv file and returns data in entites
        /// </summary>
        /// <param name="filename">Csv filename from which data will be taken</param>
        /// <param name="currentList">Current list in view</param>
        /// <returns>All data from file</returns>
        public IEnumerable<Entity> Read(string filename, IEnumerable<Entity> currentList)
        {
            List<Entity> elements = new List<Entity>();

            using (TextFieldParser ParserCsv = new TextFieldParser(filename))
            {
                //Sets attributes for sepereting lines
                ParserCsv.CommentTokens = new string[] { "#" };
                ParserCsv.SetDelimiters(new string[] { ";" });
                ParserCsv.HasFieldsEnclosedInQuotes = true;

                ParserCsv.ReadLine(); //ignore header

                while (!ParserCsv.EndOfData)
                {
                    string[] entites = ParserCsv.ReadFields(); //Each line will be first converted to string array
                    var newEntityObject = CsvEntityToDataEntity(entites);

                    if (!(_comparer.CompareEntityListWithObject(currentList, newEntityObject)))
                        elements.Add(newEntityObject);
                }
            }

            return elements;
        }

        /// <summary>
        /// Converts an array of strings (current line in csv file) to Entity Object
        /// </summary>
        /// <param name="entites">Current line</param>
        /// <returns>Object from line</returns>
        public Entity CsvEntityToDataEntity(string[] entites)
        {
            if (entites.Count() < 0)
                return new Entity();

            return new Entity()
            {
                Name = entites.ElementAtOrDefault(0),
                Value = entites.ElementAtOrDefault(1),
                Comment = entites.ElementAtOrDefault(2),
            };

        }
    }
}
