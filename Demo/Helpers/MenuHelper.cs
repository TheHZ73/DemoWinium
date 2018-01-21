using System.Windows.Automation;
using NUnit.Framework;
using Winium.Cruciatus.Core;
using Winium.Cruciatus.Extensions;

namespace Demo
{
    class MenuHelper
    {
        Winium.Cruciatus.Elements.CruciatusElement win;
        Winium.Cruciatus.Elements.Menu menu;
        const string MENU = "Menu Bar";

        public MenuHelper(Winium.Cruciatus.Elements.CruciatusElement win)
        {
            this.win = win;
            menu = win.FindElementByName(MENU).ToMenu();
        }

        public void Press_File_SafeAs()
        {
            menu.SelectItem("File$Safe As...");

        }
    }
}
