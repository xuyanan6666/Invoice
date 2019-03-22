using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Invoice
{
    public class Ini
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(
            string lpAppName, string lpKeyName, string lpString, string lpFileName);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(
            string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString,
            int nSize, string lpFileName);

        private string _path;

        public Ini(string ls_path)
        {
            _path = ls_path;
        }

        public void WriteIni(string section, string Key, string value)
        {
            WritePrivateProfileString(section, Key, value, _path);
        }

        public string ReadIni(string section, string Key)
        {
            StringBuilder buffer = new StringBuilder();
            GetPrivateProfileString(section, Key, "", buffer, 255, _path);
            return buffer.ToString();
        }


        public override string ToString()
        {
            return "Hello World!";
        }

    }
}
