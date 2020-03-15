using Microsoft.VisualBasic;
using ProjectForCompany2.Data;
using ProjectForCompany2.IOUtility;
using ProjectForCompany2.Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectForCompany2.Views
{
    public partial class EntityConverterForm : Form, IEntityConverterView
    {
        private IOProcess iOProcess;

        public EntityConverterForm()
        {
            InitializeComponent();
            InitializeOpenFileDialog();
            InitializeDataGridProperites();
            this.MinimumSize = new Size(350, 350);
            iOProcess = Program.container.GetInstance<IOProcess>();
        }

        private void InitializeOpenFileDialog()
        {
            this.openFileDialog1.Multiselect = true;
            this.FileTypesComboBox.Items.Add("CSV");
            this.FileTypesComboBox.Items.Add("RESX");
            this.FileTypesComboBox.Items.Add("XML");
            this.FileTypesComboBox.SelectedIndex = 0;
        }

        private void InitializeDataGridProperites()
        {
            TableDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            TableDataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        public IEnumerable<Entity> Entities
        {
            get { return (IList<Entity>)this.TableDataGrid.DataSource; }
            set { this.TableDataGrid.DataSource = value; }
        }

        public EntityConverterPresenter Presenter { private get; set; }

        public string FileType
        {
            get { return this.FileTypesComboBox.SelectedItem.ToString(); }
            set { this.FileTypesComboBox.SelectedItem = value; }
        }

        private void ReadFilesButton_Click(object sender, EventArgs e)
        {
            Presenter.AddEntity(iOProcess.ReadFiles(openFileDialog1, Entities));
        }

        private void ClearTableButton_Click(object sender, EventArgs e)
        {
            Presenter.RemoveEntitesFromList();
        }

        private void ExportToFileButton_Click(object sender, EventArgs e)
        {
            iOProcess.SaveListToCsvFile(Presenter.GetAllEntites(), FileType, null);
        }

        private void ExportToFileWithPasswordButton_Click(object sender, EventArgs e)
        {
            var list = Presenter.GetAllEntites();
            if (list.Count() < 1)
            {
                MessageBox.Show("Pusta tabela");
                return;
            }

            string password = Interaction.InputBox("Podaj hasło", "Export pliku z hasłem", "");
            if (password != String.Empty)
                iOProcess.SaveListToCsvFile(Presenter.GetAllEntites(), FileType, password);
            else
                MessageBox.Show("Nie wprowadzono hasła");
        }
    }
}
