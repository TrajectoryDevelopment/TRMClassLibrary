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
            AddReadOnlyTags();
        }
        private void AddReadOnlyTags()
        {
            for (int i = 0; i < this.Columns.Count; i++)
            {
                if( this.Columns[i].ReadOnly == true)
                {
                    // the tag is used to govern editability in SetVisMode of the TRJMEnuData Form 
                    this.Columns[i].Tag = "ReadOnly";
                }
            }
        }

        

    }

}
