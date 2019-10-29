using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Word;
using System.IO;

namespace WordAddIn1
{
    public partial class ThisAddIn
    {
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            
            this.Application.DocumentBeforeSave += new Word.ApplicationEvents4_DocumentBeforeSaveEventHandler(Application_DocumentBeforeSave);
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            //var count = Globals.ThisAddIn.Application.Documents.Count;
            
        }

        void Application_DocumentBeforeSave(Word.Document Doc, ref bool SaveAsUI, ref bool Cancel)
        {
            
            string path = new FileInfo(Doc.FullName).Directory.FullName;
            if(path.Contains("DocFlowFiles"))
            {
                string filename = Path.GetFileNameWithoutExtension(Doc.FullName) + ".pdf";
                string newFileName = path + "\\" + filename;

                File.AppendAllText(@"c:\temp\WordAddIn1.txt ", Environment.CommandLine);
                //File.AppendAllText(@"c:\temp\WordAddIn1.txt ", filename);

                Doc.ExportAsFixedFormat(newFileName,
                    Word.WdExportFormat.wdExportFormatPDF, false, Word.WdExportOptimizeFor.wdExportOptimizeForOnScreen,
                    Word.WdExportRange.wdExportAllDocument, 0, 0, Word.WdExportItem.wdExportDocumentWithMarkup,
                    true, true, Word.WdExportCreateBookmarks.wdExportCreateWordBookmarks,
                    true, true, false);
            }
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
