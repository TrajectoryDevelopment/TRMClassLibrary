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
    public partial class TRMDataForm : TRMClassLibrary.TRMForm
    {
        public TRMDataForm()
        {
            InitializeComponent();
        }
        protected string editMode = "View";  // other options "Edit" and "Add"
        protected string visMode = "View";  // other option is "Edit"
        public string VisMode
        {
             get
            {
                return visMode;
            }
            set
            {
                visMode = value;
            }
        }
        public virtual void SetVisMode(string vmode)
        {
           
            SetVisMode(vmode, this);
        }
        public virtual  void SetVisMode(string vmode, Control ctrl)
        {
            if (ctrl==this)
            {
                this.visMode = vmode;
                this.btnOK.Enabled = (visMode.ToUpper() != "EDIT");
                this.btnSave.Enabled = (visMode.ToUpper() == "EDIT");
                this.btnCancel.Enabled = (visMode.ToUpper() == "EDIT");
                this.btnEdit.Enabled = (visMode.ToUpper() != "EDIT");
                this.btnAdd.Enabled = (visMode.ToUpper() != "EDIT");
                this.btnDelete.Enabled = (visMode.ToUpper() != "EDIT");
            }
            foreach (Control c in ctrl.Controls)
            {
                if (c is TextBox)
                {
                    c.Enabled = (visMode.ToUpper() == "EDIT");
                }
                if (c is CheckBox )
                {
                    c.Enabled = (visMode.ToUpper() == "EDIT");
                }
                if (c is Panel )
                {
                    SetVisMode(vmode, c);
                }
            //    foreach (Control childc in c.Controls)
            //    {
            //        if (childc is TextBox)
            //        {
            //            childc.Enabled = (visMode.ToUpper() == "EDIT");
            //        }
            //    }
            }
        }

  //      protected delegate void SetControlAutoSize(Control c) ;
    
        public virtual void SetControlAutoSize(Control c, bool state)
        {
            if (c is Button)
            {
                Button b = (Button)c;
                SetButtonAutoSize(b, state);
            }
            else 
            {

            }
        }
        public void SetButtonAutoSize(Button b, bool state)
        {
            b.AutoSize = state;
        } 
        //public virtual void NoButtonAutoSize()
        //{

        //}

        public  bool GetControlAutoSize(Control c)
        {
            if (c.AutoSize.GetType().Equals("Boolean"))
            {
                Button b = (Button)c;
                return GetButtonAutoSize(b);
            }
            return false;
        }
        public virtual bool GetButtonAutoSize(Button b)
        {
            return b.AutoSize;
        }
        public virtual void ChangeAllFontSize(int amt, string amtType, Control ctrl)
        {
            foreach (Control c in ctrl.Controls)
            {
                System.Type asm = c.AutoSize.GetType()  ;
                bool asmode ; 
                //= GetButtonAutoSize(c);
                if(asm.Name.Equals("Boolean"))
                {
                    asmode = GetControlAutoSize(c);
                    SetControlAutoSize(c, true);
                    
                }
                    

                float newfont;
                newfont = c.Font.Size;
                float factor = 1 + ((float)amt / 100);
                if(amtType.Equals("Pct"))
                {
                    newfont *= factor;
                }
                else
                {
                    newfont+=amt;
                }
                c.Font = new Font(c.Font.FontFamily, newfont, c.Font.Style);
                SetControlAutoSize(c, false);
                if (c is Panel  || c.HasChildren )
                {
                    ChangeAllFontSize(amt,amtType,c);
                }
            }
        }
 public virtual void ChangeAllFontSize()
        {
           ChangeAllFontSize(10,"Pct",this);
        }

        override protected void btnCancel_Click(object sender, EventArgs e)
        {
            {
                CancelDataChangesRoutine();
                this.editMode = "View";
                SetVisMode("View");
            }
        }
        virtual protected void CancelDataChangesRoutine()
        {
            
        }

        virtual public void SaveRoutine()
        {
           
            // Save 
        }
        virtual public void btnSave_Click(object sender, EventArgs e)
        {
           
            this.SaveRoutine();
            this.editMode = "View";
            SetVisMode("View");
        }

        virtual protected void EditRoutine()
        {
            // Save 
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.EditRoutine();
            SetVisMode("Edit");
            this.editMode = "Edit";
        }

        virtual protected void DeleteRoutine()
        {
            // Delete Code from child
        }

 
        /*
        virtual public void btnDelete_Click(object sender, EventArgs e)
        { 
            string message = "Continue to delete this record?";
            string caption = "Data Deletion Confirmation";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show(this, message, caption, buttons);

            if (result == DialogResult.Yes)
            {
                this.DeleteRoutine();
            }
        }

         */
        virtual protected void AddRoutine()
        {
            // Add Data code here
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            SetVisMode("Edit");
            this.editMode = "Add";
            this.AddRoutine();
        }

        private void TRMDataForm_Load(object sender, EventArgs e)
        {
            SetVisMode(this.visMode);

        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Delete Clicked");
        }

       virtual public void btnDelete_Click(object sender, EventArgs e)
        {
            string message = "Continue to delete this record?";
            string caption = "Data Deletion Confirmation";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show(this, message, caption, buttons);

            if (result == DialogResult.Yes)
            {
                this.DeleteRoutine();
            }
        }

       private void button1_Click(object sender, EventArgs e)
       {
           ChangeAllFontSize(10, "Pct", this);
       }

       private void btnFontPlus_Click(object sender, EventArgs e)
       {
           {
               ChangeAllFontSize(10, "Pct", this);
           }
       }

       private void btnFontMinus_Click(object sender, EventArgs e)
       {
           {
               ChangeAllFontSize(-10, "Pct", this);
           }
       }

       private void btnOK_Click_1(object sender, EventArgs e)
       {

       }

       private void btnCancel_Click_1(object sender, EventArgs e)
       {

       }
        
    }
}
