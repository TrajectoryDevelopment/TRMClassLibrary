//Copyright ©, 2017, Donald G Fletcher
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms; 

namespace TRMClassLibrary 
{
    public partial class TRJMenuDataForm : TRMClassLibrary.TRMForm
    {
        public TRJMenuDataForm()
        {
            InitializeComponent();
            NavMode = "Both";
        }
        private bool showMessage;
        public bool ShowMessage
        {
            get { return showMessage; }
            set
            {
                showMessage = value;
            }

        }
        private bool requireBaseDeleteConfirmation;
        public bool RequireBaseDeleteConfirmation
        {
            get { return requireBaseDeleteConfirmation; }
            set { requireBaseDeleteConfirmation = value; }
        }

        private bool deleteBtnVisible = true;
        public bool DeleteBtnVisible
        {
            get { return deleteBtnVisible; }
            set
            {
                deleteBtnVisible = value;
                this.deleteToolStripMenuItem.Visible = deleteBtnVisible;
            }
        }
        private bool doneBtnVisible = true;
        public bool DoneBtnVisible
        {
            get { return doneBtnVisible; }
            set
            {
                doneBtnVisible = value;
                this.doneToolStripMenuItem.Visible = doneBtnVisible;
            }
        }
        private bool searchTextBoxVisible = true;
        public bool SearchTextBoxVisible
        {
            get { return searchTextBoxVisible; }
            set
            {
                searchTextBoxVisible = value;
                this.searchToolStripTextBox.Visible = searchTextBoxVisible;
            }
        }

        private bool addBtnVisible = true;
        public bool AddBtnVisible
        {
            get { return addBtnVisible; }
            set
            {
                addBtnVisible = value;
                this.addToolStripMenuItem.Visible = addBtnVisible;
            }
        }
        private bool searchBtnVisible = true;
        public bool SearchBtnVisible
        {
            get { return searchBtnVisible; }
            set
            {
                searchBtnVisible = value;
                this.searchToolStripMenuItem.Visible = searchBtnVisible;
            }
        }

        protected string navMode = "";

        public string NavMode
        {
            get
            {
                return navMode;
            }
            set
            {
                navMode = value;
            }
        }

        protected string visMode = "View";  // other option is "Edit"
        protected string editMode = "View";
 
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

        private BindingSource navBindingSource;
        public BindingSource NavBindingSource
        {
            get
            {
                return navBindingSource;
            }
            set
            {
                navBindingSource = value; 
            }
        }
        

        public virtual void SetVisMode(string vmode)
        {

            SetVisMode(vmode, this, navBindingSource);
        }
        public virtual void SetVisMode(string vmode, Control ctrl)
        {

            SetVisMode(vmode, ctrl ,navBindingSource);
        }
        public virtual void SetVisMode(string vmode, Control ctrl, BindingSource bs)
        {
            this.visMode = vmode;
            //            if (ctrl == this & ctrl is Form )
            if (ctrl.Tag != null && ctrl.Tag.ToString()=="Exclude" && ctrl.Tag.ToString() != "ExcludeContainer")
            {
                return;
            }
            // 

            if (ctrl is Form || ctrl is Panel || ctrl is UserControl || ctrl is TabControl || ctrl is TRJTabControl 
                || ctrl is TabPage  || ctrl is GroupBox )  //|| ctrl.Controls.Count >0 
            {
                if(ctrl is Form)
                {
                    this.doneToolStripMenuItem.Enabled = (visMode.ToUpper() != "EDIT");
                    this.saveToolStripMenuItem.Enabled = (visMode.ToUpper() == "EDIT");
                    this.cancelToolStripMenuItem.Enabled = (visMode.ToUpper() == "EDIT");
                    this.editToolStripMenuItem.Enabled = (visMode.ToUpper() != "EDIT");
                    this.addToolStripMenuItem.Enabled = (visMode.ToUpper() != "EDIT");
                    this.deleteToolStripMenuItem.Enabled = (visMode.ToUpper() != "EDIT");
                    this.searchToolStripMenuItem.Enabled=(visMode.ToUpper() != "EDIT");
                    this.searchToolStripTextBox.Enabled = (visMode.ToUpper() != "EDIT");
                    if(bs !=null)
                    {
                        if(bs.Count==0)
                        {
                            editToolStripMenuItem.Enabled = false;
                            deleteToolStripMenuItem.Enabled = false;

                        }
                        
                    }
                         
                }
                if (ctrl is TabControl || ctrl is TRJTabControl)
                {
                    ctrl.Enabled = true;
                }
                if (ctrl is TabPage)
                {
                    ctrl.Enabled = true;
                }
                if (ctrl is TRJTabControl)
                {

                    TRJTabControl tc = (TRJTabControl)ctrl;
                    
                    tc.AllowTabChange = visMode != "Edit";
                    ctrl.Enabled = true;

                    for (int i = 0; i < tc.TabPages.Count; i++)
                    {
                        tc.TabPages[i].Enabled = true;
                        //if (visMode != "Edit")
                        //{

                        //    tc.TabPages[i].Enabled = true;

                        //}
                        //else
                        //{
                        //    //  We are editing so only the selected page is enabled
                        //    if (i == tc.SelectedIndex)
                        //    {
                        //        tc.TabPages[i].Enabled = true;
                        //    }
                        //    else
                        //    {
                        //        tc.TabPages[i].Enabled = false;
                        //    }

                        //}

                    }
                }
                if ((ctrl is Panel || ctrl is UserControl) &&  !(ctrl is TabPage) )
                {   if(ctrl.Tag != null)
                    {

                    string tagString = ctrl.Tag.ToString();
                    switch (tagString)
                        {
                        case "Navigation" :
                            ctrl.Enabled = (visMode.ToUpper() != "EDIT");
                            break;
                        case "ExcludeContainer" :
                            ctrl.Enabled = true;
                            break;
                        default :
                            ctrl.Enabled = (visMode.ToUpper() == "EDIT");
                            break;
                        }
                    }
                    else
                    {
                        ctrl.Enabled = (visMode.ToUpper() == "EDIT");

                    }
                    //if (ctrl.Tag != null && ctrl.Tag.ToString() == "Navigation")
                    //{
                    //    ctrl.Enabled = (visMode.ToUpper() != "EDIT");
                    //}
                    //else
                    //{
                    //    ctrl.Enabled = (visMode.ToUpper() == "EDIT");
                    //}
                }
  
               foreach(Control c in ctrl.Controls)
                {
                    bool okToProcessUserControl = (c.Tag == null || c.Tag.ToString() != "Exclude");
                    if (c is UserControl && okToProcessUserControl)
                    {

                        // FIRST FIND THE BINDING NAVIGATOR AND SEE IF IT HAS AN EDIT BUTTON
                        foreach (Control c1 in c.Controls)
                        {
                            if (c1 is Button)
                            {
                                if( c1.Text=="Edit")
                                {
                                    c1.Enabled = true; 
                                }
                            }
                        }
                    }
                    if (!(c is Label || c is TRJLabel))
                    {
                         SetVisMode(vmode,c,navBindingSource);
                    }
                }
            }

            else // We have just a single control to process
            {
                bool okToProcessControl = (ctrl.Tag == null || ctrl.Tag.ToString() != "Exclude");
                if (okToProcessControl == false)
                {
                    return;
                }
                if (ctrl is TRJDataGridView)
                {
  
                        if (ctrl.Tag != null && ctrl.Tag.ToString() == "Navigation")
                        {
                            ctrl.Enabled = (visMode.ToUpper() != "EDIT");
                        }
                        else
                        {
                        ctrl.Enabled = true; //   Unless specifically set for Navigation it is always enabled.   The code below handles the readonly business.  // (visMode.ToUpper() == "EDIT");
                            TRJDataGridView grd = (TRJDataGridView)ctrl;
                        grd.Enabled = true;
                            // Now check each column and set ReadOnly off or on depending on VisMode
                            for (int i = 0; i < grd.Columns.Count; i++)
                            {
                              //  if (grd.Columns[i].ReadOnly != true) // the ReadOnly columns stay ReadOnly regardless
                                {
                                    // If we are not editing set the grid to readonly if the Tag is NOT Readonly
                                    // The readonly Tag means it is always set to ReadOnly, so we don't process
                                 //   DataGridViewTextBoxColumn col = (DataGridViewTextBoxColumn)grd.Columns[i];
                                    if (grd.Columns[i].Tag == null || grd.Columns[i].Tag.ToString() == "Editable" )  // grd.Columns[i].Tag.ToString() != "ReadOnly")
                                    {
                                        grd.Columns[i].ReadOnly = visMode.ToUpper() != "EDIT";
                                    }
                                }
                                
                            }
                        }
                    
                }
                if ( ctrl is TRJDataGridView)
                {

                    if (ctrl.Tag != null && ctrl.Tag.ToString() == "Navigation")
                    {
                        ctrl.Enabled = (visMode.ToUpper() != "EDIT");
                    }
                    else
                    {
                        ctrl.Enabled = true; //   Unless specifically set for Navigation it is always enabled.   The code below handles the readonly business.  // (visMode.ToUpper() == "EDIT");
                       DataGridView grd = (DataGridView)ctrl;
                        grd.Enabled = true;
                        // Now check each column and set ReadOnly off or on depending on VisMode
                        for (int i = 0; i < grd.Columns.Count; i++)
                        {
                            //  if (grd.Columns[i].ReadOnly != true) // the ReadOnly columns stay ReadOnly regardless
                            {
                                // If we are not editing set the grid to readonly if the Tag is NOT Readonly
                                // The readonly Tag means it is always set to ReadOnly, so we don't process
                                //   DataGridViewTextBoxColumn col = (DataGridViewTextBoxColumn)grd.Columns[i];
                                if (grd.Columns[i].Tag == null || grd.Columns[i].Tag.ToString() == "Editable")  // grd.Columns[i].Tag.ToString() != "ReadOnly")
                                {
                                    grd.Columns[i].ReadOnly = visMode.ToUpper() != "EDIT";
                                }
                            }

                        }
                    }

                }
                else
    //            if (ctrl is TextBox || ctrl is TRJTextBox || ctrl is ComboBox || ctrl is DateTimePicker
    //|| ctrl is CheckBox || ctrl is MaskedTextBox || ctrl is Button || ctrl is )
                {
                    // var bc = Color.FromKnownColor(KnownColor.Magenta);
                    //   ctrl.Enabled = (visMode.ToUpper() == "EDIT");
                    // bc = ctrl.BackColor;
                    if ((string)ctrl.Tag != "Navigation")
                    {
                        if (visMode.ToUpper() == "EDIT")
                        {
                            ctrl.Enabled = true;
                        }
                        else
                        {
                            ctrl.Enabled = false;
                        }

                    }
                    else
                    {
                        if (visMode.ToUpper() != "EDIT")
                        {
                            ctrl.Enabled = true;
                        }
                        else
                        {
                            ctrl.Enabled = false;
                        }
                    }

                }

            }


        }

        //      protected delegate void SetControlAutoSize(Control c) ;
 
        private void TRJMenuDataForm_Load(object sender, EventArgs e)
        {
            this.SetVisMode(this.visMode);

        }

        public void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                CancelDataChangesRoutine();
            }
        }
        virtual public void CancelDataChangesRoutine()
        {
           
            this.editMode = "View";
            SetVisMode("View");
             
            // MessageBox.Show("Cancel Clicked");
        }

        virtual public void SaveRoutine()
        {
            this.editMode = "View";
            SetVisMode("View");

            //   MessageBox.Show("Save Clicked");
            // Save 
        }
        public void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
 
            this.SaveRoutine();
        }

        virtual protected void EditRoutine()
        {
            this.editMode = "Edit";
            SetVisMode("Edit"); 
            
            
            // Save 
            // MessageBox.Show("Edit Clicked");
        }

          public void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.EditRoutine();
        }

        virtual public bool DeleteConfirmed()
        {
            string _message = "Continue to delete this record?";
            string _caption = "Data Deletion Confirmation";
            //MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            //DialogResult result;

            //result = MessageBox.Show(this, message, caption, buttons);
            //return result == DialogResult.Yes;
            return DeleteConfirmed(_message, _caption);
        }
        virtual protected bool DeleteConfirmed(string message, string caption)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show(this, message, caption, buttons);
            return result == DialogResult.Yes;

        }
        virtual protected void DeleteRoutine()
        {
          
        }


        virtual protected int SearchRoutine() 
        {   
            int searchID = 0;
            if (showMessage == true)
            {
   
            MessageBox.Show("Search Clicked"); 
 
            }
            return searchID;
        }

        virtual protected void AddRoutine()
        {
            SetVisMode("Edit");
            this.editMode = "Add";
            // Add Data code here
            //  MessageBox.Show("Add Clicked");
        }
 
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AddRoutine();

        }

        private void TRMDataForm_Load(object sender, EventArgs e)
        {
            SetVisMode(this.visMode);

        }

        public void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // query parameter requireDeleteConfirmation
            
            if (requireBaseDeleteConfirmation != true || DeleteConfirmed() == true)
            {
                 DeleteRoutine();

            }
        }

        public void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
             this.SearchRoutine();
        
        }

        public void doneToolStripMenuItem_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        public void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

  
        
    }
}
