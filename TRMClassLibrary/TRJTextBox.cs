using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRMClassLibrary
{
    public class TRJTextBox : TextBox
    {
        private bool trimText;
        public bool TrimText
        {
            get { return trimText; }
            set { trimText = value; }
        }

        private bool selectOnEntry;
        public bool SelectOnEntry
        {
            get; set;
        }
        private void TRJTextBox1()
        {
            //this.TextChanged += new EventHandler(TRJTextBox1_TextChanged);
            //this.Enter += new EventHandler(TRJTextBox1_OnEnter);
            //this.Validated += new EventHandler(TRJTextBox1_Validated);
           // this.Leave += new EventHandler(TRJTextBox1_OnLeave);

        }
        private bool endEditOnLeave;
        public bool EndEditOnLeave
        {
            get { return endEditOnLeave; }
            set { endEditOnLeave = value; }
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            this.Text = this.Text.Trim();
            if (this.Text.Length > this.MaxLength)
            {
                this.Text.Substring(0, this.MaxLength - 1);
               
            }
            if (endEditOnLeave == true)
            {
                //this.DataBindings[0].BindingMemberInfo.

                BindingSource source = (BindingSource)this.DataBindings["Text"].DataSource;
                source.EndEdit();

            }
        }
        protected override void OnValidated(EventArgs e)
        {
            base.OnValidated(e);
            this.Text = this.Text.Trim();
            if (this.MaxLength > 0) // dates etc are given maxlength of -1
            {
                if (this.Text.Length > this.MaxLength)
                {
                    this.Text.Substring(0, this.MaxLength - 1);
                }
            }
        }
        private void TRJTextBox1_Validated(object sender, EventArgs e)
        {
            
        }

        private void TRJTextbox1_OnEnter()
        {

        }
        private void  TRJTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (TrimText == true)
            {
                this.Text.Trim();
            }
        }
        
        
        protected override void OnEnter( EventArgs e)
        {
            base.OnEnter(e);
            this.Text = this.Text.Trim();
            this.SelectAll();
        }
    }
}
