using System.IO;
using System.Threading;
using System.Windows.Automation;
using NUnit.Framework;
using Winium.Cruciatus.Core;
using System.Configuration;
using Winium.Cruciatus.Extensions;

namespace Demo
{
    [Category("DemoAutosests")]
    [TestFixture]
    public class TestSuit
    {
        Winium.Cruciatus.Application textPad;

        [OneTimeSetUp]
        public void BeginMetod()
        {
            DeleteAllFileInDocuments();
            string pathBeforeTextPad = ConfigurationManager.AppSettings["pathBeforeTextPad"];
            textPad = new Winium.Cruciatus.Application(pathBeforeTextPad);
            ProcessKill("TextPad");
            textPad.Start();
        }

        [OneTimeTearDown]
        public void FinalMetod()
        {
            ProcessKill("TextPad");
            textPad.Close();
        }

        [Test]
        public void DemoTest()
        {
            var textPadForm = new TextPadForm(textPad, "Document1");
            textPadForm.EditTextAndSave("simple text");

            string nameSafeDocument = "Doctest";
            var safeAsForm = new SaveAsForm(textPad);
            Assert.True(safeAsForm.SaveNameDocument(nameSafeDocument));
        }

        [Test]
        public void TestFailed()
        {
            Assert.True(false);
        }

        private void DeleteAllFileInDocuments()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(@"D:\Users\arjun\Documents\");

            foreach (FileInfo file in dirInfo.GetFiles())
            {
                file.Delete();
            }
        }

        private void ProcessKill(string processName)
        {
            System.Diagnostics.Process[] findProcessTextPad =
                System.Diagnostics.Process.GetProcessesByName(processName);
            foreach (System.Diagnostics.Process processTextPad in findProcessTextPad)
            {
                processTextPad.Kill();
            }
        }
    }
}
