using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationTest.Interoperability
{
    public class PInvokeTest
    {
        [DllImport("kernel32",EntryPoint ="Sleep")]
        static extern void DoNothing(uint msec);

        [DllImport("kernel32", ExactSpelling = true)]
        static extern IntPtr CreateJobObjectW(IntPtr securityAttributes, string name);

        [DllImport("kernel32")]
        static extern bool CloseHandle(IntPtr handle);

        //Calling Convention
        //Most Windows API Convention is CallingConvention.StdCall
        [DllImport("msvcrt",CallingConvention=CallingConvention.Cdecl)]
        extern static int sprintf(StringBuilder buffer, string format, int id);

        //Type Conversion MarshalAs
        [DllImport("somelib")]
        extern static void DoSomeJob(
            [MarshalAs(UnmanagedType.LPWStr)] string s1,
            [MarshalAs(UnmanagedType.LPTStr)] string s2);



        public static void Main()
        {
            try
            {
                //Console.WriteLine("Wait for a while...");
                //DoNothing(2000);
                //var newJob = CreateJobObjectW(IntPtr.Zero, "myjob");
                //Console.WriteLine("Job handle: {0}", newJob);
                //CloseHandle(newJob);

                var buffer = new StringBuilder(128);
                sprintf(buffer, "Process %d is using sprintf",Process.GetCurrentProcess().Id);
                Console.WriteLine(buffer.ToString());
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
