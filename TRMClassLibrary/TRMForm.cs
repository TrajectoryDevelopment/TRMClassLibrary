//Copyright ©, 2017, Donald G Fletcher
//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRMClassLibrary
{ 
    
    public partial class TRMForm : Form
    { 
           // Make btnOK's dialog result OK.
        public TRMForm()
        {
            InitializeComponent();

            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);

   //         SetWindowSize();
        }
    
        private BindingSource navBindingSource;
        public BindingSource NavBindingSource
        {
            get
            {
                return navBindingSource;
            }
            set
            {
                navBindingSource = value;
            }
        }

        protected PrintDocument printDocument1 = new PrintDocument();

        //virtual protected void SetWindowSize()
        //{
        //    this.Width = btnOK.Left + btnOK.Width + (this.Width - this.ClientSize.Width) + 20;
        //    this.Height = btnOK.Height + btnOK.Top + (this.Height - this.ClientSize.Height) + 20;
        //   // btnOK.Text = this.ClientSize.Height.ToString();
           
        //}

       virtual protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        
       virtual protected void btnOK_Click(object sender, EventArgs e)
       {
           this.DialogResult = DialogResult.OK;
           this.Close();

       }

       private void TRMForm_Load(object sender, EventArgs e)
       {
          

       }
      // Bitmap memoryImage;
       Bitmap bmp;
       protected void CaptureScreen(Control ctrl)
       {
       //    Graphics myGraphics = ctrl.CreateGraphics();
        //   Size s = ctrl.Size;
       //    memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
    //       Graphics memoryGraphics = Graphics.FromImage(memoryImage);
      //     memoryGraphics.CopyFromScreen(this.Location.X+ctrl.Location.X, this.Location.Y+ctrl.Location.Y, 0, 0, s);
           bmp = new Bitmap(ctrl.Width, ctrl.Height);
           ctrl.DrawToBitmap(bmp, new Rectangle(0, 0, ctrl.Width, ctrl.Height));
       }

       protected void printDocument1_PrintPage(System.Object sender,
              System.Drawing.Printing.PrintPageEventArgs e)
       {
           e.Graphics.DrawImage(bmp, 0, 0);
       }

        protected void printForm(Control ctrl)
       {
             CaptureScreen(ctrl);
             PrintDialog printDialog = new PrintDialog();
             printDialog.Document = printDocument1;
             if (printDialog.ShowDialog() == DialogResult.OK)
             {
                 printDocument1.Print();
             }
             else
             {
                 //MessageBox.Show("Print Cancelled");
             }
       }

        private void TRMForm_Shown(object sender, EventArgs e)
        {
            int h = this.RestoreBounds.Height;
            int w = this.RestoreBounds.Width;
            foreach(Control c in this.Controls)
            {
                w = Math.Max(w, c.Right);
                h = Math.Max(h,c.Bottom); 
                this.Width=w;
                this.Height=h;
            }

        }

    }
}
