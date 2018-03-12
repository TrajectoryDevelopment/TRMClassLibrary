//Copyright ©, 2017, Donald G Fletcher
//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TRMClassLibrary;

namespace TRMClassLibrary
{
    public partial class TRMEditForm : TRMClassLibrary.TRMForm
    {
        private string editMode = "View";  // other options "Edit" and "Add"
        private string visMode = "View";  // other option is "Edit"
        public TRMEditForm()
        {
            InitializeComponent();
        }
        private void SetVisMode(string vmode)
        {
            this.visMode = vmode;
            this.btnOK.Enabled = (visMode.ToUpper()  !="EDIT");
            this.btnSave.Enabled = (visMode.ToUpper() == "EDIT");
            this.btnCancel.Enabled = (visMode.ToUpper() == "EDIT");
            this.btnEdit.Enabled = (visMode.ToUpper() != "EDIT");
            this.btnAdd.Enabled = (visMode.ToUpper() != "EDIT");
            this.btnDelete.Enabled = (visMode.ToUpper() != "EDIT");
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    c.Enabled = (visMode.ToUpper() != "EDIT");
                }
                foreach (Control childc in c.Controls)
                {
                    if (childc is TextBox)
                    {
                        childc.Enabled = (visMode.ToUpper() != "EDIT");
                    }
                }
            }

            for (int i = 0; i < this.Controls.Count; i++ )
            {
               // System.Type ot;
               
                if(this.Controls[i].GetType().ToString() == "TextBox")
                {
                    ;
                }
                ;
            }
        }

        private void SaveRoutine()
        {
            // Save 
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            SetVisMode("View");
            this.editMode = "View";
            this.SaveRoutine();
        }

        private void AddRoutine()
        {
             // Add Data code here
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            SetVisMode("Edit");
            this.editMode = "Add";
            this.AddRoutine();
        }
        private void EditRoutine()
        {
            // Save 
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SetVisMode("Edit");
            this.editMode = "Edit";
            this.EditRoutine();
        }
       private void DeleteRoutine()
        {
            //Delete code here
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string message = "Continue to delete this record?";
			string caption = "Data Deletion Confirmation";
			MessageBoxButtons buttons = MessageBoxButtons.YesNo;
			DialogResult result;

			result = MessageBox.Show(this, message, caption, buttons);

			if(result == DialogResult.Yes)
			{
                this.DeleteRoutine();
			}
        }

        private void CancelDataChangesRoutine()
        {
            // Save 
        }
        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            SetVisMode("View");
            this.editMode = "View";
            CancelDataChangesRoutine();
        }

        //private void btnOK_Click_1(object sender, EventArgs e)
        //{
            
        //}

        private void TRMEditForm_Load(object sender, EventArgs e)
        {
            this.SetVisMode("VIEW");
        }
    }
}
