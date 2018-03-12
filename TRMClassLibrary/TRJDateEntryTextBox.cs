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
    public partial class TRJDateEntryTextBox : System.Windows.Forms.TextBox 
    {
        public TRJDateEntryTextBox()
        {
            InitializeComponent();
        }
        protected override void OnValidating(CancelEventArgs e)
        {
  //          base.OnValidating(e);
        }
        protected override void OnValidated(EventArgs e)
        {
  //          base.OnValidated(e);
        }
      
    }
}
