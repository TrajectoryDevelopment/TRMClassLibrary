using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Runtime.InteropServices;
namespace TRMClassLibrary
{
    [ClassInterface(ClassInterfaceType.AutoDispatch), DefaultBindingProperty("Rtf"), Description("DescriptionRichTextBox"), ComVisible(true), Docking(DockingBehavior.Ask), Designer("System.Windows.Forms.Design.RichTextBoxDesigner, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]

    public class TRJRichTextBox : RichTextBox
    {
        private RichTextBox rtb1;

        public TRJRichTextBox()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            //Update the graphics on the toolbar
            //   UpdateToolbar();
        }
        private void InitializeComponent()
        {

                 this.KeyDown += new System.Windows.Forms.KeyEventHandler(rtb1_KeyDown);

            
        }
        //new public string Rtf
        //{
        //    get
        //    {
        //        return base.Rtf;
        //    }
        //    set
        //    {
        //        base.Rtf = value;
        //    }
        //}
        private void rtb1_KeyDown(object sender, KeyEventArgs e)
        {
            //    if (e.Control == true)
            if (e.Modifiers == Keys.Control)
            {
                if  (e.KeyCode == Keys.B)
                {
                    ToggleBold();
                    e.Handled = true; // disable Ctrl+B
                }

                if (e.KeyCode==Keys.I)
                {
                    ToggleItalic();
                    e.Handled = true;
                }
            }
        }

        public void ToggleBold()
        {
            if (this.SelectionFont != null)
            {
                System.Drawing.Font currentFont = this.SelectionFont;
                System.Drawing.FontStyle newFontStyle;

                if (this.SelectionFont.Bold == true)
                {
                    newFontStyle = FontStyle.Regular;
                }
                else
                {
                    newFontStyle = FontStyle.Bold;
                }

                this.SelectionFont = new Font(
                   currentFont.FontFamily,
                   currentFont.Size,
                   newFontStyle
                );
            }
        }
        // comment
        public void ToggleItalic()
        {
            if (this.SelectionFont != null)
            {
                System.Drawing.Font currentFont = this.SelectionFont;
                System.Drawing.FontStyle newFontStyle;

                if (this.SelectionFont.Italic == true)
                {
                    newFontStyle = FontStyle.Regular;
                }
                else
                {
                    newFontStyle = FontStyle.Italic;
                }

                this.SelectionFont = new Font(
                   currentFont.FontFamily,
                   currentFont.Size,
                   newFontStyle
                );
            }
        }
        // comment
    }
}
