namespace ProjectForCompany2.Views
{
    partial class EntityConverterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TableDataGrid = new System.Windows.Forms.DataGridView();
            this.ReadFilesButton = new System.Windows.Forms.Button();
            this.ClearTableButton = new System.Windows.Forms.Button();
            this.ExportToFileButton = new System.Windows.Forms.Button();
            this.ExportToFileWithPasswordButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.FileTypesComboBox = new System.Windows.Forms.ComboBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TableDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.TableDataGrid, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ReadFilesButton, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ClearTableButton, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.ExportToFileButton, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.ExportToFileWithPasswordButton, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.FileTypesComboBox, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // TableDataGrid
            // 
            this.TableDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.TableDataGrid, 4);
            this.TableDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableDataGrid.Location = new System.Drawing.Point(3, 3);
            this.TableDataGrid.Name = "TableDataGrid";
            this.TableDataGrid.Size = new System.Drawing.Size(794, 309);
            this.TableDataGrid.TabIndex = 0;
            // 
            // ReadFilesButton
            // 
            this.ReadFilesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ReadFilesButton.Location = new System.Drawing.Point(3, 382);
            this.ReadFilesButton.Name = "ReadFilesButton";
            this.ReadFilesButton.Size = new System.Drawing.Size(194, 23);
            this.ReadFilesButton.TabIndex = 1;
            this.ReadFilesButton.Text = "Wczytaj plik";
            this.ReadFilesButton.UseVisualStyleBackColor = true;
            this.ReadFilesButton.Click += new System.EventHandler(this.ReadFilesButton_Click);
            // 
            // ClearTableButton
            // 
            this.ClearTableButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearTableButton.Location = new System.Drawing.Point(203, 382);
            this.ClearTableButton.Name = "ClearTableButton";
            this.ClearTableButton.Size = new System.Drawing.Size(194, 23);
            this.ClearTableButton.TabIndex = 2;
            this.ClearTableButton.Text = "Wyczyść tabele";
            this.ClearTableButton.UseVisualStyleBackColor = true;
            this.ClearTableButton.Click += new System.EventHandler(this.ClearTableButton_Click);
            // 
            // ExportToFileButton
            // 
            this.ExportToFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ExportToFileButton.Location = new System.Drawing.Point(403, 382);
            this.ExportToFileButton.Name = "ExportToFileButton";
            this.ExportToFileButton.Size = new System.Drawing.Size(194, 23);
            this.ExportToFileButton.TabIndex = 3;
            this.ExportToFileButton.Text = "Eskportuj tabele do wskazanego pliku";
            this.ExportToFileButton.UseVisualStyleBackColor = true;
            this.ExportToFileButton.Click += new System.EventHandler(this.ExportToFileButton_Click);
            // 
            // ExportToFileWithPasswordButton
            // 
            this.ExportToFileWithPasswordButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ExportToFileWithPasswordButton.Location = new System.Drawing.Point(603, 382);
            this.ExportToFileWithPasswordButton.Name = "ExportToFileWithPasswordButton";
            this.ExportToFileWithPasswordButton.Size = new System.Drawing.Size(194, 23);
            this.ExportToFileWithPasswordButton.TabIndex = 4;
            this.ExportToFileWithPasswordButton.Text = "Esksportuj tabele do wskazanego pliku csv z hasłem";
            this.ExportToFileWithPasswordButton.UseVisualStyleBackColor = true;
            this.ExportToFileWithPasswordButton.Click += new System.EventHandler(this.ExportToFileWithPasswordButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(403, 315);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 22);
            this.label1.TabIndex = 5;
            this.label1.Text = "Zapisz jako";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FileTypesComboBox
            // 
            this.FileTypesComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.FileTypesComboBox.FormattingEnabled = true;
            this.FileTypesComboBox.Location = new System.Drawing.Point(603, 318);
            this.FileTypesComboBox.Name = "FileTypesComboBox";
            this.FileTypesComboBox.Size = new System.Drawing.Size(194, 21);
            this.FileTypesComboBox.TabIndex = 6;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // EntityConverterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "EntityConverterForm";
            this.Text = "EntityConverterForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TableDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView TableDataGrid;
        private System.Windows.Forms.Button ReadFilesButton;
        private System.Windows.Forms.Button ClearTableButton;
        private System.Windows.Forms.Button ExportToFileButton;
        private System.Windows.Forms.Button ExportToFileWithPasswordButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox FileTypesComboBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}