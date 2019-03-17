﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace TRMClassLibrary
{
    public class TRJComboBox : ComboBox
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
            //this.Text = this.Text.Trim();
            //if (this.Text.Length > this.MaxLength)
            //{
            //    this.Text.Substring(0, this.MaxLength - 1);

            //}
            if (endEditOnLeave == true)
            {
                //this.DataBindings[0].BindingMemberInfo.

                BindingSource source = (BindingSource)this.DataBindings["SelectedValue"].DataSource;
                source.EndEdit();

            }
        }

    }
}
