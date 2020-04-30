using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeProtect.Client.BL.AppBLs.Exceptions;

namespace WeProtect.Client.BL.AppBLs
{
    public class DemoAppModel : BuyOnlyModel
    {
        public DemoAppModel()
        {
            LicenseEndTime = null;
        }
        override public int Subtraction(int a, int b)
        {
            throw new LicenseNotFoundException("Вы используете демо версию программы");
        }
        override public int Multiplication(int a, int b)
        {
            throw new LicenseNotFoundException("Вы используете демо версию программы");
        }
        override public int Division(int a, int b)
        {
            throw new LicenseNotFoundException("Вы используете демо версию программы");
        }
    }
}
