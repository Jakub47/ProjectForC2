using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjectForCompany2.Encryption
{
    /// <summary>
    /// Class responsible for saving file into zip file with password
    /// </summary>
    public class FileEncryptor : IEncryptor
    {
        /// <summary>
        /// Generates Zip file from provided filename and securiting it with password
        /// </summary>
        /// <param name="filename">File which will be saved to zip file</param>
        /// <param name="pwd">Password for securiting file</param>
        public void EncryptFileWithPassword(string filename, string pwd)
        {
            string zipFileName;
            string fileExt;

            try
            {
                fileExt = Path.GetExtension(filename);
                zipFileName = filename.Replace(fileExt, ".zip");
                using (ZipOutputStream s = new ZipOutputStream(File.Create(zipFileName)))
                {
                    s.Password = pwd;
                    s.SetLevel(4); // 0 - store only to 9 - means best compression

                    byte[] buffer = new byte[4096];

                    ZipEntry entry = new ZipEntry(Path.GetFileName(filename));
                    entry.DateTime = DateTime.Now;
                    s.PutNextEntry(entry);

                    using (FileStream fs = File.OpenRead(filename))
                    {
                        int sourceBytes;
                        do
                        {
                            sourceBytes = fs.Read(buffer, 0, buffer.Length);
                            s.Write(buffer, 0, sourceBytes);
                        } while (sourceBytes > 0);
                    }
                    s.Finish();

                    s.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception during processing {0}", ex);
            }
        }
    }
}
