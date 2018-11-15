using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRMClassLibrary
{
    public class TRJDataGridView : DataGridView
    {
        public TRJDataGridView()
        {
            this.InitializeComponent();
        }

        
        protected override void OnColumnStateChanged(DataGridViewColumnStateChangedEventArgs e)
        {
            base.OnColumnStateChanged(e);
        }
        protected override void OnColumnAdded(DataGridViewColumnEventArgs e)
        {
            base.OnColumnAdded(e);
            //DataGridViewColumn col = (DataGridViewColumn)this.Columns[Columns.Count - 1];
            //if (col.ReadOnly == true)
            //{
            //    col.Tag = "ReadOnly";
            //}
            //else
            //{
            //    col.Tag = "Editable";
            //}
        }
        public void AddReadOnlyTags()
        {
            for (int i = 0; i < this.Columns.Count; i++)
            {
                if( this.Columns[i].ReadOnly == true)
                {
                    // the tag is used to govern editability in SetVisMode of the TRJMEnuData Form 
                    this.Columns[i].Tag = "ReadOnly";
                }
                else
                {
                    this.Columns[i].Tag = "Editable";
                }
            }
        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // TRJDataGridView
            // 
            this.ColumnNameChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.TRJDataGridView_ColumnNameChanged);
            this.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.TRJDataGridView_DataBindingComplete);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        private void TRJDataGridView_ColumnNameChanged(object sender, DataGridViewColumnEventArgs e)
        {
           

        }

        private void TRJDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }
    }

}
