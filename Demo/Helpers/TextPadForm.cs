using System.Windows.Automation;
using NUnit.Framework;
using Winium.Cruciatus.Core;
using Winium.Cruciatus.Extensions;

namespace Demo
{
    class TextPadForm
    {
        const string WINDOWS_TITLE_TEXTPAD = "TextPad - ";
        const string EDIT_FIELD_ID = "59648";

        Winium.Cruciatus.Application textPad;
        Winium.Cruciatus.Elements.CruciatusElement win;

        public TextPadForm(Winium.Cruciatus.Application textPad, string nameDoc)
        {
            this.textPad = textPad;
            var winFinder = By.Name(WINDOWS_TITLE_TEXTPAD + nameDoc).AndType(ControlType.Window);
            win = Winium.Cruciatus.CruciatusFactory.Root.FindElement(winFinder);

        }

        public void EditTextAndSave(string text)
        {
            win.FindElementByUid(EDIT_FIELD_ID).SetText(text);
            var barHelper = new BarHelper(win);
            barHelper.SaveClick();
        }

    }
}
