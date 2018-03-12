using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TRMClassLibrary
{
    public partial class TRMEditForm : TRMClassLibrary.TRMForm
    {
        private string editMode = "View" ;  // other options "Edit" and "Add"
        private string visMode = "View" ;  // other option is "Edit"
        public TRMEditForm()
        {
            InitializeComponent();
        }
        private void SaveRoutine()
        {
            // Save 
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.SaveRoutine();
        }

        private void AddRoutine()
        {
            // Add Data code here
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
        private EditRoutine()
        {
            // Save 
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }
                private void DeleteRoutine()
        {
            // Save 
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {

        }

        private void btnOK_Click_1(object sender, EventArgs e)
        {

        }
    }
}
