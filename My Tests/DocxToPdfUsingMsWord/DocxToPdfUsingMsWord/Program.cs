using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocxToPdfUsingMsWord
{
    class Program
    {
        static void Main(string[] args)
        {
             Convert(@"D:\DocFlowFiles\test4.docx", @"d:\DocFlowFiles\test4_1.pdf", WdSaveFormat.wdFormatPDF); 
             Convert(@"D:\DocFlowFiles\test4.docx", @"d:\DocFlowFiles\test4_2.pdf", WdSaveFormat.wdFormatPDF); 
             Convert(@"D:\DocFlowFiles\test4.docx", @"d:\DocFlowFiles\test4_3.pdf", WdSaveFormat.wdFormatPDF); 
             Convert(@"D:\DocFlowFiles\test4.docx", @"d:\DocFlowFiles\test4_4.pdf", WdSaveFormat.wdFormatPDF); 
             Convert(@"D:\DocFlowFiles\test4.docx", @"d:\DocFlowFiles\test4_5.pdf", WdSaveFormat.wdFormatPDF); 
             Convert(@"D:\DocFlowFiles\test4.docx", @"d:\DocFlowFiles\test4_6.pdf", WdSaveFormat.wdFormatPDF); 
             Convert(@"D:\DocFlowFiles\test4.docx", @"d:\DocFlowFiles\test4_7.pdf", WdSaveFormat.wdFormatPDF); 
             Convert(@"D:\DocFlowFiles\test4.docx", @"d:\DocFlowFiles\test4_8.pdf", WdSaveFormat.wdFormatPDF); 
             Convert(@"D:\DocFlowFiles\test4.docx", @"d:\DocFlowFiles\test4_9.pdf", WdSaveFormat.wdFormatPDF); 
             Convert(@"D:\DocFlowFiles\test4.docx", @"d:\DocFlowFiles\test4_10.pdf", WdSaveFormat.wdFormatPDF); 
            
            Console.ReadLine();
        }
        public static void Convert(string input, string output, WdSaveFormat format)
        {
            // Create an instance of Word.exe
            Microsoft.Office.Interop.Word.Application oWord = new Microsoft.Office.Interop.Word.Application();

            // Make this instance of word invisible (Can still see it in the taskmgr).
            try
            {
                oWord.Visible = false;
                // Interop requires objects.
                object oMissing = System.Reflection.Missing.Value;
                object isVisible = true;
                object readOnly = true;
                object oInput = input;
                object oOutput = output;
                object oFormat = format;

                // Load a document into our instance of word.exe
                Microsoft.Office.Interop.Word.Document oDoc = oWord.Documents.Open(ref oInput, ref oMissing, ref readOnly, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref isVisible, ref oMissing, ref oMissing, ref oMissing, ref oMissing);

                // Make this document the active document.
                oDoc.Activate();
                // Save this document in Word 2003 format.
                oDoc.SaveAs(ref oOutput, ref oFormat, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);

                // Always close Word.exe.
                oWord.Quit(ref oMissing, ref oMissing, ref oMissing);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
