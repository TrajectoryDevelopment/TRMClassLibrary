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
        private void TRJTextBox1()
        {
            this.TextChanged += new
            EventHandler(TRJTextBox1_TextChanged);
            this.Enter += new EventHandler(TRJTextBox1_TextChanged);
            
        }
        private void
           TRJTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (TrimText == true)
            {
                this.Text.Trim();
            }
        }
        private void TRJTextBox1_Enter(object sender, EventArgs e)
        {
            this.Text.Trim();
            this.SelectAll();
        }
    }
}
