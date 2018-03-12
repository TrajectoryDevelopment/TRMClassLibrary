namespace JEO.UserControls
{
    partial class CompanyPicker
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.companyComboBox = new System.Windows.Forms.ComboBox();
            this.vwCompanyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet_Company = new JEO.DataSet_Company();
            this.activeCompCheckBox = new System.Windows.Forms.CheckBox();
            this.vwCompanyTableAdapter = new JEO.DataSet_CompanyTableAdapters.vwCompanyTableAdapter();
            this.tableAdapterManager1 = new JEO.DataSet_CompanyTableAdapters.TableAdapterManager();
            this.companyPickerLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.vwCompanyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Company)).BeginInit();
            this.SuspendLayout();
            // 
            // companyComboBox
            // 
            this.companyComboBox.DataSource = this.vwCompanyBindingSource;
            this.companyComboBox.DisplayMember = "Company_Name";
            this.companyComboBox.FormattingEnabled = true;
            this.companyComboBox.Location = new System.Drawing.Point(61, 2);
            this.companyComboBox.Name = "companyComboBox";
            this.companyComboBox.Size = new System.Drawing.Size(300, 21);
            this.companyComboBox.TabIndex = 1;
            this.companyComboBox.Tag = "Navigation";
            this.companyComboBox.ValueMember = "Company_ID";
            this.companyComboBox.SelectedIndexChanged += new System.EventHandler(this.companyComboBox_SelectedIndexChanged);
            // 
            // vwCompanyBindingSource
            // 
            this.vwCompanyBindingSource.DataMember = "vwCompany";
            this.vwCompanyBindingSource.DataSource = this.dataSet_Company;
            // 
            // dataSet_Company
            // 
            this.dataSet_Company.DataSetName = "DataSet_Company";
            this.dataSet_Company.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // activeCompCheckBox
            // 
            this.activeCompCheckBox.AutoSize = true;
            this.activeCompCheckBox.Checked = true;
            this.activeCompCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.activeCompCheckBox.Location = new System.Drawing.Point(375, 4);
            this.activeCompCheckBox.Name = "activeCompCheckBox";
            this.activeCompCheckBox.Size = new System.Drawing.Size(135, 17);
            this.activeCompCheckBox.TabIndex = 68;
            this.activeCompCheckBox.Tag = "Navigation";
            this.activeCompCheckBox.Text = "Active Companies Only";
            this.activeCompCheckBox.UseVisualStyleBackColor = true;
            this.activeCompCheckBox.CheckedChanged += new System.EventHandler(this.activeCompCheckBox_CheckedChanged);
            // 
            // vwCompanyTableAdapter
            // 
            this.vwCompanyTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.Connection = null;
            this.tableAdapterManager1.UpdateOrder = JEO.DataSet_CompanyTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // companyPickerLabel
            // 
            this.companyPickerLabel.AutoSize = true;
            this.companyPickerLabel.Location = new System.Drawing.Point(4, 6);
            this.companyPickerLabel.Name = "companyPickerLabel";
            this.companyPickerLabel.Size = new System.Drawing.Size(51, 13);
            this.companyPickerLabel.TabIndex = 69;
            this.companyPickerLabel.Tag = "Navigation";
            this.companyPickerLabel.Text = "Company";
            this.companyPickerLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // CompanyPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.companyPickerLabel);
            this.Controls.Add(this.activeCompCheckBox);
            this.Controls.Add(this.companyComboBox);
            this.Name = "CompanyPicker";
            this.Size = new System.Drawing.Size(538, 26);
            this.Tag = "Navigation";
            this.Load += new System.EventHandler(this.CompanyPicker_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vwCompanyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Company)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource vwCompanyBindingSource;
        private DataSet_Company dataSet_Company;
        private DataSet_CompanyTableAdapters.vwCompanyTableAdapter vwCompanyTableAdapter;
        private DataSet_CompanyTableAdapters.TableAdapterManager tableAdapterManager1;
        private System.Windows.Forms.Label companyPickerLabel;
        public System.Windows.Forms.ComboBox companyComboBox;
        public System.Windows.Forms.CheckBox activeCompCheckBox;
    }
}
