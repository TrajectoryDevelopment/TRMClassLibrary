using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JEO.UserControls
{
    public partial class CompanyPicker : UserControl
    {
        public CompanyPicker()
        {
            InitializeComponent();
            setActiveFilter(activeCompCheckBox.Checked);
            cpLabel = "Company";
            companyComboBox.SelectedIndexChanged += this.OnComboChanged;
         }
        public event EventHandler ComboChanged;

        
        protected void OnComboChanged(object sender, EventArgs e)
        {
            EventHandler handler = ComboChanged;
            if (handler != null)

                handler(this, e);


        }


       private int companyID;

        public int CompanyID
        {
            get
            {
                return companyID;
            }
            set
            {
                companyID = value;
                companyComboBox.SelectedValue = companyID;
                //if (companyComboBox.SelectedValue != null)
                //{
                //    companyID = (int)companyComboBox.SelectedValue;
                //}
                //else
                //{
                //    companyID = -1;
                //}
           }
        }
        private string cmpName;
        
        public string CmpName 
        {
            get
            {
                return cmpName;
            }
            set
            {
                cmpName = value;
            }
        }
   
        private string cpLabel;
        public string CpLabel
        {
            get
            {
                return cpLabel;
            }
            set
            {
                cpLabel = value;
                companyPickerLabel.Text = cpLabel;
                this.Width = companyPickerLabel.Width + companyComboBox.Width + 20;
                companyComboBox.Left = companyPickerLabel.Right + 5;
            }
        }
 
        private void companyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (companyComboBox.SelectedIndex > -1)
            {
                companyID = (int)companyComboBox.SelectedValue;
                cmpName = companyComboBox.Text;
//this.ComboChanged(this, e);
            //    setCompanyFilter(companyComboBox.SelectedValue.ToString());
            }

        }
 
        private void setActiveFilter(bool active)
        {
            if (active == true)
            {
                            vwCompanyBindingSource.Filter = "Active = true";
            }
            else
            {
                            vwCompanyBindingSource.RemoveFilter();
            }

        }


        private void activeCompCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            setActiveFilter(activeCompCheckBox.Checked);
//            setCompanyFilter(companyComboBox.SelectedValue.ToString());
   //         uspSelectvwJEOReferralListDataGridView.Refresh();

        }

        private void CompanyPicker_Load(object sender, EventArgs e)
        {
            dataSet_Company.EnforceConstraints = false;
            vwCompanyTableAdapter.Fill(dataSet_Company.vwCompany);
            DataRowView ccRow = (DataRowView)vwCompanyBindingSource.Current;
            CompanyID = (int)ccRow["Company_ID"];
        }

        private void label1_Click(object sender, EventArgs e)
        {
            int i = 1;
        }

    }
}
