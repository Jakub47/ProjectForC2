using ProjectForCompany2.Data;
using ProjectForCompany2.Encryption;
using ProjectForCompany2.IOUtility;
using ProjectForCompany2.IOUtility.CSV;
using ProjectForCompany2.IOUtility.Resx;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectForCompany2
{
    static class Program
    {
        public static Container container;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Bootstrap();
            var view = new Views.EntityConverterForm();
            var repository = new Models.EntityConverterRepository();
            var presenter = new Presenter.EntityConverterPresenter(view, repository);

            Application.Run(view);
        }

        private static void Bootstrap()
        {
            // Create the container as usual.
            container = new Container();
            container.Register<IEntityComparer, EntityComparer>();
            container.Register<IEncryptor, FileEncryptor>();
            container.Register<IFileReader, ResxFileReader>();
            container.Register<IFileWriter, CsvFileWriter>();

            // Optionally verify the container.
            container.Verify();
        }
    }
}
