//Copyright ©, 2017, Donald G Fletcher
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Xml;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;
using Microsoft.Office.Interop.Word;

namespace TRMClassLibrary
{
    public class TRM
    {
        public static void CheckForNullDate(BindingSource bs, String fldname)
        {
            DataRowView bwdr = (DataRowView)bs.Current;
            if (bwdr != null)
            {
                if (bwdr[fldname] != null && bwdr[fldname] != DBNull.Value)
                {
                    DateTime dt = (DateTime)bwdr[fldname];

                    if (dt <= DateTime.Parse("01/01/1900"))
                    {
                        bwdr[fldname] = DBNull.Value;
                    }
                }

            }
        }

        public static int?  ConvertTextToNullableInt(string s)
        {
            int i;
            int? retint = int.TryParse(s, out i) ? (int?)i : null;
            return retint;
        }
  
        //public virtual void EnableControls(string vmode)
        //{

        //    EnableControls(vmode, this, navBindingSource);
        //}
        //public virtual void EnableControls(string vmode, Control ctrl)
        //{

        //    EnableControls(vmode, ctrl, navBindingSource);
        //}
        public  static void WriteCaptionAndValue(Paragraph para, string caption, string value)
        {
            object rstrt;
            object rend;
            para.Range.InsertParagraphAfter();
            para.SpaceAfter = 6 ;
            para.Range.Text = caption + value;
            para.Range.Font.Bold = 1;
            Range r = para.Range;
            rstrt = r.Start;
            rend = r.End;
            rstrt = (int)rstrt + caption.Length;
            //     object sloc=rstrt;
            //     object eloc= rend; 
            r.Start = (int)rstrt;
            r.End = (int)rend;
            r.Font.Bold = 0;

        }
        public static void WriteCaptionAndValue(Paragraph para, string caption, string value, BindingSource bs)
        {
            WriteCaptionAndValue(para, caption, value, bs, 6);
        }
        public static void WriteCaptionAndValue(Paragraph para, string caption, string value, BindingSource bs, int pointsAfterPara)
        {
            object rstrt;
            object rend;
            para.Range.InsertParagraphBefore();
            para.SpaceAfter = pointsAfterPara;
            DataRowView drv = (DataRowView)bs.Current;
            para.Range.Text = caption + drv[value];
            para.Range.Font.Bold = 1;
            Range r = para.Range;
            rstrt = r.Start;
            rend = r.End;
            rstrt = (int)rstrt + caption.Length;
            //     object sloc=rstrt;
            //     object eloc= rend; 
            r.Start = (int)rstrt;
            r.End = (int)rend;
            r.Font.Bold = 0;

 
        }
 
        public static void PrintDocWithDialog(string documentname)
        {

            PrintDialog printDlg = new PrintDialog();
            PrintDocument printDoc = new PrintDocument();
            printDoc.DocumentName = documentname;
            printDlg.Document = printDoc;
            printDlg.AllowSelection = true;
            printDlg.AllowSomePages = true;
            //Call ShowDialog
            if (printDlg.ShowDialog() == DialogResult.OK)
                printDoc.Print();

        }


        public static void EnableControls(string vmode, Control ctrl, BindingSource bs)
        {
   //         this.vmode = vmode;
            //            if (ctrl == this & ctrl is Form )
            if (ctrl is Form | ctrl is Panel | ctrl is UserControl)
            {
                if (ctrl is Form)
                {
                    //this.doneToolStripMenuItem.Enabled = (vmode.ToUpper() != "EDIT");
                    //this.saveToolStripMenuItem.Enabled = (vmode.ToUpper() == "EDIT");
                    //this.cancelToolStripMenuItem.Enabled = (vmode.ToUpper() == "EDIT");
                    //this.editToolStripMenuItem.Enabled = (vmode.ToUpper() != "EDIT");
                    //this.addToolStripMenuItem.Enabled = (vmode.ToUpper() != "EDIT");
                    //this.deleteToolStripMenuItem.Enabled = (vmode.ToUpper() != "EDIT");
                    //this.searchToolStripMenuItem.Enabled = (vmode.ToUpper() != "EDIT");
                    //this.searchToolStripTextBox.Enabled = (vmode.ToUpper() != "EDIT");
                    //if (bs != null)
                    ////{
                    //    if (bs.Count == 0)
                    //    {
                    //        editToolStripMenuItem.Enabled = false;
                    //        deleteToolStripMenuItem.Enabled = false;

                    //    }

                    //}

                }


                if (ctrl is Panel || ctrl is UserControl)
                {
                    if ((string)ctrl.Tag == "Navigation")
                    {
                        ctrl.Enabled = (vmode.ToUpper() != "EDIT");
                    }
                    else
                    {
                        ctrl.Enabled = (vmode.ToUpper() == "EDIT");
                    }
                }
                foreach (Control c in ctrl.Controls)
                {
                    bool okToProcessUserControl = true;
                    if (ctrl is UserControl)
                    {

                        // FIRST FIND THE BINDING NAVIGATOR AND SEE IF IT HAS AN EDIT BUTTON
                        foreach (Control c1 in ctrl.Controls)
                        {
                            if (c1 is Button)
                            {
                                if (c1.Text == "Edit")
                                {
                                    c1.Enabled = true;
                                }
                                /*                               foreach (Control c2 in c1.Controls)
                                                                   if (c2 is Button && c2.Text.ToUpper() == "EDIT")
                                                                   {
                                                                       c2.Enabled = (vmode.ToUpper() == "EDIT");
                                                                       okToProcessUserControl = false;
                                                                       break;
                                                                   }
                                 */
                            }
                        }
                    }
                    if (!okToProcessUserControl)
                    {
                        break;
                    }
                    if (!(c is Label))
                    {
                        EnableControls(vmode, c, bs);
                    }
                }
            }

            else
            {
                if (ctrl is TextBox | ctrl is ComboBox | ctrl is DateTimePicker | ctrl is System.Windows.Forms.CheckBox)
                {
                    // var bc = Color.FromKnownColor(KnownColor.Magenta);
                    //   ctrl.Enabled = (vmode.ToUpper() == "EDIT");
                    // bc = ctrl.BackColor;
                    if ((string)ctrl.Tag != "Navigation")
                    {
                        ctrl.Enabled = (vmode.ToUpper() == "EDIT");
                    }
                    else
                    {
                        if (vmode.ToUpper() != "EDIT")
                        {
                            ctrl.Enabled = true;
                        }
                        else
                        {
                            ctrl.Enabled = false;
                        }

                    }

                }
                if (ctrl is DataGridView)
                {
                    if (ctrl.Tag != null && ctrl.Tag.ToString() == "Navigation")
                    {
                        ctrl.Enabled = (vmode.ToUpper() != "EDIT");
                    }
                    else
                    {
                        ctrl.Enabled = (vmode.ToUpper() == "EDIT");
                    }
                }
            }


        }

        public static string StrTo1900(string s)
        {
            DateTime date;
            if (DateTime.TryParse(s, out date))
            {
                return s;
            }
            else
            {
                return "1900-01-01";
            }
        }
        public static void AddFontsToRdlc(string fileName, string defaultFont)
        {
            if (!File.Exists(fileName))
            {
            // Report file does not exist
            return;
            }
            XmlDocument document = new XmlDocument();
            document.Load(fileName);
            string documentNamespace = document.DocumentElement.NamespaceURI;
            XmlNodeList nodes = document.GetElementsByTagName("TextRun");
            bool foundStyle = false;
            bool foundFontFamily = false;
            foreach (XmlNode node in nodes)
            {
            foundStyle = false;
            foundFontFamily = false;
            foreach (XmlNode childNode in node.ChildNodes)
            {
                if (childNode.Name == "Style")
                {
                foundStyle = true;
                foreach (XmlNode styleNode in childNode.ChildNodes)
                {
                    if (styleNode.Name == "FontFamily")
                    {
                    // Change the font here if changing all fonts to the default font
                    // Alternatively, specify what font should change to what font with a switch
                    foundFontFamily = true;
                    break;
                    }
                }
                if (!foundFontFamily)
                {
                    XmlElement fontElement = document.CreateElement("FontFamily", documentNamespace);
                    fontElement.InnerText = defaultFont;
                    childNode.AppendChild(fontElement);
                }
                break;
                }
            }
            if (!foundStyle)
            {
                XmlNode styleElement = document.CreateElement("Style", documentNamespace);
                XmlElement fontElement = document.CreateElement("FontFamily", documentNamespace);
                fontElement.InnerText = defaultFont;
                styleElement.AppendChild(fontElement);
                node.AppendChild(styleElement);
            }
            }
            document.Save(fileName);
        }
    }

}
