using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenXmlTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //CreateDocx();
            //EditDocx();
            //ReplaceField();
            ReplaceField2();
        }


        private static void ReplaceField2()
        {
            Dictionary<string, string> docInfo = new Dictionary<string, string>();

            docInfo["From"] = "الادارة العامة لتقنية المعلومات";
            docInfo["Subject"] = "تجربة متابعة المعاملات 1 مكرر";
            docInfo["DocRef"] = "123-456";

            File.Copy(@"D:\DocFlowFiles\test1.docx", @"D:\DocFlowFiles\test.docx", true);
            using (WordprocessingDocument doc = WordprocessingDocument.Open(@"D:\DocFlowFiles\test.docx", true))
            {
                
                List<Text> textList = doc.MainDocumentPart.RootElement.Descendants<Text>().ToList();

                foreach (var field in textList)
                {
                    if(field.Text.StartsWith("%") && field.Text.EndsWith("%") && field.Text.Length > 2)
                    {
                        var fieldName = field.Text.Replace("%", "").Trim();
                        var testFields = textList.FindAll(f => f.Text == fieldName);
                        if (testFields != null)
                        {
                            if (docInfo.ContainsKey(fieldName))
                            {
                                //((RunProperties)txtField.Parent.ChildElements[0]).RunFonts = new RunFonts() { Ascii = "AL-Mohanad", Hint = FontTypeHintValues.ComplexScript, ComplexScript = "AL-Mohanad" };
                                field.Text = "";
                                var textParts = docInfo[fieldName].Split(' ');
                                var prnt = field.Parent;
                                foreach (var txtPart in textParts)
                                {
                                    Run newRun = prnt.AppendChild<Run>(new Run());
                                    RunProperties runProp = newRun.AppendChild<RunProperties>(new RunProperties());
                                    runProp.RunFonts = new RunFonts() { Ascii = "AL-Mohanad", Hint = FontTypeHintValues.EastAsia, ComplexScript = "AL-Mohanad" };
                                    runProp.FontSizeComplexScript = new FontSizeComplexScript() { Val = "44" };
                                    runProp.RightToLeftText = new RightToLeftText() { Val = true };
                                    Text newTextField = new Text() { Text = ToArabicNumbers(txtPart), Space = SpaceProcessingModeValues.Preserve };
                                    newRun.AppendChild(newTextField);

                                    Run newRun2 = prnt.AppendChild<Run>(new Run());
                                    RunProperties runProp2 = newRun2.AppendChild<RunProperties>(new RunProperties());
                                    runProp2.RunFonts = new RunFonts() { Ascii = "AL-Mohanad", Hint = FontTypeHintValues.EastAsia, ComplexScript = "AL-Mohanad" };
                                    runProp2.FontSizeComplexScript = new FontSizeComplexScript() { Val = "44" };
                                    runProp2.RightToLeftText = new RightToLeftText() { Val = true };
                                    Text newTextField2 = new Text() { Text = " ", Space = SpaceProcessingModeValues.Preserve };
                                    newRun2.AppendChild(newTextField2);

                                }
                            }
                        }
                    }
                }
                doc.Close();
            }
        }

        private static void ReplaceField()
        {
            Dictionary<string, string> docInfo = new Dictionary<string, string>();
            
            docInfo["Subject"] = "متابعة 1 معاملات مكتب الامين";
            docInfo["DocRef"] = "123-456";

            File.Copy(@"D:\DocFlowFiles\test1.docx", @"D:\DocFlowFiles\test.docx", true);
            using (WordprocessingDocument doc = WordprocessingDocument.Open(@"D:\DocFlowFiles\test.docx", true))
            {
                List<FieldCode> fieldList = doc.MainDocumentPart.RootElement.Descendants<FieldCode>().ToList();
                List<Text> textList = doc.MainDocumentPart.RootElement.Descendants<Text>().ToList();

                foreach (var field in fieldList)
                {
                    //((RunProperties)field.Parent.ChildElements[0]).RunFonts = new RunFonts() { Ascii = "AL-Mohanad" };
                    var fieldName = field.Text.Replace("TITLE", "").Replace("\\* MERGEFORMAT","").Trim();
                    var testFields = textList.FindAll(f => f.Text == fieldName);
                    if(testFields != null)
                    {
                        foreach (var txtField in testFields)
                        {
                            if(docInfo.ContainsKey(fieldName))
                            {
                                //((RunProperties)txtField.Parent.ChildElements[0]).RunFonts = new RunFonts() { Ascii = "AL-Mohanad", Hint = FontTypeHintValues.ComplexScript, ComplexScript = "AL-Mohanad" };
                                txtField.Text = "";
                                var textParts = docInfo[fieldName].Split(' ');
                                var prnt = txtField.Parent;
                                foreach(var txtPart in textParts)
                                {
                                    Run newRun = prnt.AppendChild<Run>(new Run());
                                    RunProperties runProp = newRun.AppendChild<RunProperties>(new RunProperties() );
                                    runProp.RunFonts = new RunFonts() { Ascii = "AL-Mohanad", Hint = FontTypeHintValues.EastAsia,  ComplexScript = "AL-Mohanad" };
                                    runProp.FontSizeComplexScript = new  FontSizeComplexScript() { Val = "44" };
                                    runProp.RightToLeftText = new RightToLeftText() { Val = true };
                                    Text newTextField = new Text() { Text = ToArabicNumbers(txtPart), Space = SpaceProcessingModeValues.Preserve };
                                    newRun.AppendChild(newTextField);

                                    Run newRun2 = prnt.AppendChild<Run>(new Run() );
                                    RunProperties runProp2 = newRun2.AppendChild<RunProperties>(new RunProperties() );
                                    runProp2.RunFonts = new RunFonts() { };
                                    runProp2.FontSizeComplexScript = new FontSizeComplexScript() { Val = "44" };
                                    //runProp2.RightToLeftText = new RightToLeftText() { Val = true };
                                    Text newTextField2 = new Text() { Text = " ", Space = SpaceProcessingModeValues.Preserve };
                                    newRun2.AppendChild(newTextField2);

                                }
                                //var newRun= txtField.AppendChild<Run>(new Run());
                               
                            }
                        }
                    }
                }
                doc.Close();
            }
        }

        private static string ToArabicNumbers(string str)
        {
            Dictionary<char, char> codes = new Dictionary<char, char>();
            codes['0'] = '\u0660'; //1632
            codes['1'] = '\u0661';
            codes['2'] = '\u0662';
            codes['3'] = '\u0663';
            codes['4'] = '\u0664';
            codes['5'] = '\u0665';
            codes['6'] = '\u0666';
            codes['7'] = '\u0667';
            codes['8'] = '\u0668';
            codes['9'] = '\u0669';
            codes['-'] = '-';
            //codes[' '] = '0';

            string newStr = "";

            foreach (char crChar in str.ToCharArray())
            {
                if (codes.ContainsKey(crChar))
                    newStr += codes[crChar];
                else
                    newStr += crChar;
            }
            return newStr;
            //return "OK1";
        }
        private static void EditDocx()
        {
            using (WordprocessingDocument wordprocessingDocument = WordprocessingDocument.Open(@"D:\DocFlowFiles\test.docx", true))
            {
                // Assign a reference to the existing document body.
                Body body = wordprocessingDocument.MainDocumentPart.Document.Body;

                // Add new text.
                Paragraph para = body.AppendChild(new Paragraph());
                Run run = para.AppendChild(new Run());
                run.AppendChild(new Text("اهلا 1"));
                
                // Close the handle explicitly.
                wordprocessingDocument.Close();
            }
        }

        private static void CreateDocx()
        {
            using (WordprocessingDocument doc = WordprocessingDocument.Create(@"D:\DocFlowFiles\test.docx", DocumentFormat.OpenXml.WordprocessingDocumentType.Document))
            {
                // Add a main document part.
                MainDocumentPart mainPart = doc.AddMainDocumentPart();

                // Create the document structure and add some text.
                mainPart.Document = new Document();
                Body body = mainPart.Document.AppendChild(new Body());
                Paragraph para = body.AppendChild(new Paragraph());
                Run run = para.AppendChild(new Run());

                // String msg contains the text, "Hello, Word!"
                run.AppendChild(new Text("New text in document"));
            }
        }
    }
}
