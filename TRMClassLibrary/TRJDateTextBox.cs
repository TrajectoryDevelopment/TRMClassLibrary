using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace TRMClassLibrary
{
    public class TRJDateTextBox : TextBox
    {

 
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }

        private void TRJTextBox1_TextChanged(object sender, EventArgs e)
        {
        //    var dataSource = this.DataBindings["Text"].DataSource["DataField"];
   ;
         //   string dataMember = dataSource["DataMember"] ;

            string bindingMember = this.DataBindings["Text"].BindingMemberInfo.BindingMember;
      //    CheckForNullDate(this.DataBindings[0].DataSource);
               
        }
        protected override void OnValidating(System.ComponentModel.CancelEventArgs e)
        {
            base.OnValidating(e);
            if (this.Text.Length==0 || this.Text.Substring(0,8)=="1/1/1900") 
            {
                var bs = (BindingSource)this.DataBindings["Text"].DataSource;
                var db = this.DataBindings["Text"];
                string bindingField = db.BindingMemberInfo.BindingField;
                var drv = (DataRowView)bs.Current;
                string fs = db.BindingManagerBase.Bindings[0].FormatString;
                drv[bindingField] = DBNull.Value;
                e.Cancel = false; 
            }
        }
        protected override void OnValidated(EventArgs e)
        {
            base.OnValidated(e);
        }
        private void CheckForNullDate(BindingSource bs, String fldname)
        {
           CheckForNullDate(bs, fldname, "01-01-1900");

        }
        private void CheckForNullDate(BindingSource bs, String fldname, String baddate)
        {
            DataRowView bwdr = (DataRowView)bs.Current;
            if (bwdr != null)
            {
                if (bwdr[fldname] != null && bwdr[fldname] != DBNull.Value)
                {
                    DateTime dt = (DateTime)bwdr[fldname];

                    if (dt <= DateTime.Parse(baddate))
                    {
                        bwdr[fldname] = DBNull.Value;
                    }
                }

            }
        }

    }
}
