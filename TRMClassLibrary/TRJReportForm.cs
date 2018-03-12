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
    public partial class TRJReportForm : TRMClassLibrary.TRMForm
    {
        public TRJReportForm()
        {
            InitializeComponent();
        }

  

        private void doneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void runReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.runReport();
        }
        protected virtual void runReport()
        {

        }

        private void TRJReportForm_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {

        }
    }
}
