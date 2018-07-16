using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRMClassLibrary
{
    class TRJTabControl : TabControl
    {
        private bool allowTabChange;
        public bool AllowTabChange
        {
            get;
            set;
            
        }
       
        private void TRJTabControl1()
        {
            object o = new object();
            TabPage tp = this.SelectedTab;
            int i = this.SelectedIndex;
           // TabControlAction tca = TabControlAction.Selecting;
            TabControlCancelEventArgs e = new TabControlCancelEventArgs(tp,i,allowTabChange, TabControlAction.Selecting);
           this.Deselecting += new TabControlCancelEventHandler(TRJTabControl1_Deselecting);

        }
        private void TRJTabControl1_Deselecting(object sender,  TabControlCancelEventArgs  e)
        {
            if( allowTabChange== false)
            {
                e.Cancel = true;
            }
           
        }
    }
}
