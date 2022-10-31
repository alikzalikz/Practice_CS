using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace ExtensionMethod_Example
{
    public static class MyClass
    {
        public static string ToTooman(this int value)
        {
            return value.ToString("#,0 Tooman");
        }

        public static string ToShamsi(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(value)+"/"+pc.GetMonth(value).ToString("00")+"/"+pc.GetDayOfMonth(value).ToString("00");
        }
    }
}
