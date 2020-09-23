using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Reflection;

namespace WindowsFormsTest
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //[STAThread]
        static void Main()
        {
            //    Application.EnableVisualStyles();
            //    Application.SetCompatibleTextRenderingDefault(false);
            //Button button1 = new Button();
            FieldInfo[] buttonFieldInfo;
            Type buttonType = typeof(Button);
            buttonFieldInfo = buttonType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            for(int i = 0;i<buttonFieldInfo.Length;i++)
            {
                Console.WriteLine("name: {0}", buttonFieldInfo[i].Name);
                Console.WriteLine("Declaring Type: {0}", buttonFieldInfo[i].DeclaringType);
                Console.WriteLine("Is Public: {0}", buttonFieldInfo[i].IsPublic);
                Console.WriteLine("Member Type: {0}", buttonFieldInfo[i].MemberType);
                Console.WriteLine("Field Type: {0}", buttonFieldInfo[i].FieldType);
                Console.WriteLine("IsFamily: {0}", buttonFieldInfo[i].IsFamily);
            }
        }
    }
}
