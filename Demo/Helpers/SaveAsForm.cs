using System.IO;
using System.Windows.Automation;
using NUnit.Framework;
using Winium.Cruciatus.Core;
using Winium.Cruciatus.Extensions;

namespace Demo
{
    class SaveAsForm
    {
        Winium.Cruciatus.Application textPad;
        Winium.Cruciatus.Elements.CruciatusElement win;
        const string TITLE_DIALOG = "Save As";
        const string EDIT_FILE_NAME_ID = "1001";
        const string BUTTON_SAVE_ID = "1";

        public SaveAsForm(Winium.Cruciatus.Application textPad)
        {
            this.textPad = textPad;
            var winFinder = By.Name(TITLE_DIALOG).AndType(ControlType.Window);
            win = Winium.Cruciatus.CruciatusFactory.Root.FindElement(winFinder);
        }

        public bool SaveNameDocument(string nameDocument)
        {
            win.FindElementByUid(EDIT_FILE_NAME_ID).SetText(nameDocument);

            var winFinder = By.Name("Save").AndType(ControlType.Button);
            Winium.Cruciatus.CruciatusFactory.Root.FindElement(winFinder).Click();

            string puthFile = @"D:\Users\arjun\Documents\" + nameDocument + ".txt";

            return File.Exists(puthFile);
        }



    }
}
