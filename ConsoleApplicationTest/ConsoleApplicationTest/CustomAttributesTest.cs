using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ConsoleApplicationTest
{
    public enum Color { Red }

    [AttributeUsage(AttributeTargets.All)]
    internal sealed class SomeAttribute:Attribute
    {
        public SomeAttribute(String name, Object o, Type[] types)
        {
        }
    }

    [Some("Luqc", Color.Red, new Type[] { typeof(Math),typeof(Console)})]
    internal sealed class SomeType { }
       
}
