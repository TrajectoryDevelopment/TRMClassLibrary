using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRMClassLibrary
{
    public partial class TRMForm : Form
    { 
           // Make button1's dialog result OK.
        public TRMForm()
        {
            InitializeComponent();
           
        }


       protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        
       protected void btnOK_Click(object sender, EventArgs e)
       {
           this.DialogResult = DialogResult.OK;
           this.Close();

       }

       private void TRMForm_Load(object sender, EventArgs e)
       {

       }
    }
}
