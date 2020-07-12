using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationTest
{
    public class InterfaceTest
    {
        public static void Main()
        {
            Type1 type1 = new Type1();
            IBaseName baseName = type1 as IBaseName;
            if (baseName != null)
                Console.WriteLine("type1 is based on ibasename");
            IType3Name type3Name = type1 as IType3Name;
            if (type3Name == null)
                Console.WriteLine("type1 is not based on type3name");
        }
    }

    public interface IBaseName {
    }

    public interface IType1Name : IBaseName { }
    public interface IType2Name : IBaseName { }
    public interface IType3Name : IBaseName { }

    public class BaseType
    {
        public virtual void Print()
        {
            Console.WriteLine("BaseType");
        }
    }

    public class Type1 : BaseType,IType1Name
    {
        public override void Print()
        {
            Console.WriteLine("Type1");
        }
    }
    public class Type2 : BaseType,IType2Name
    {
        public override void Print()
        {
            Console.WriteLine("Type2");
        }
    }
    public class Type3:BaseType,IType3Name
    {
        public override void Print()
        {
            Console.WriteLine("Type3");
        }
    }
}
