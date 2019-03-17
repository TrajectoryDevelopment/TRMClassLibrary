using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRMClassLibrary
{
    public class TRJCheckBox : CheckBox 
    {
        private bool endEditOnLeave;
        public bool EndEditOnLeave
        {
            get { return endEditOnLeave; }
            set { endEditOnLeave = value; }
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
         
            if (endEditOnLeave == true)
            {
                //this.DataBindings[0].BindingMemberInfo.

                BindingSource source = (BindingSource)this.DataBindings["CheckState"].DataSource;
                source.EndEdit();

            }
        }

    }
}
