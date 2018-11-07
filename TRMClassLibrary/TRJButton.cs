using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRMClassLibrary
{
    public class TRJButton : Button
    {

        private AutoScaleMode _autoscaleMode = AutoScaleMode.Dpi;

        public AutoScaleMode AutoScaleMode

        {

            get

            {

                return _autoscaleMode;

            }

            set

            {

                _autoscaleMode = value;

            }

        }
    }
}
