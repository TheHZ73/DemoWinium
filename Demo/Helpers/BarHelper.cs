using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class BarHelper
    {
        Winium.Cruciatus.Elements.CruciatusElement win;
        const string SAFE_BAR = "Save\tCtrl+S";

        public BarHelper(Winium.Cruciatus.Elements.CruciatusElement win)
        {
            this.win = win;
        }

        public void SaveClick()
        {
            win.FindElementByName(SAFE_BAR).Click();
        }
    }
}
