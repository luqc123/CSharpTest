//define Test
#define VERIFY

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Diagnostics;

#region Possible Target

[assembly:MyAttr(1)]
[module:MyAttr(2)]
[type:MyAttr(3)]
internal sealed class SomeType<[typevar:MyAttr(4)] T> //applied to generic type variable
{
    [field:MyAttr(5)]
    public Int32 SomeFiled = 0;

    [return:MyAttr(6)]
    [method:MyAttr(7)]
    public Int32 SomeMethod(
        [param:MyAttr(8)]
        Int32 SomeParam)
    {
        return SomeParam;
    }

    [property:MyAttr(9)]
    public String SomeProp
    {
        [method:MyAttr(10)] //applied to get accessor method
        get { return null; }
    }

    [event:MyAttr(11)]
    [field:MyAttr(12)]
    [method:MyAttr(13)]
    public event EventHandler SomeEvent;
}

[AttributeUsage(AttributeTargets.All)]
public class MyAttr : Attribute
{
    public MyAttr(Int32 x) { }
}
#endregion

#region Applying Attributes

internal sealed class OSVERSIONINFO
{
    public OSVERSIONINFO()
    {
        OSVersionInfoSize = (UInt32)Marshal.SizeOf(this);
    }
    public UInt32 OSVersionInfoSize = 0;
    public UInt32 MajorVersion = 0;
    public UInt32 MinorVersion = 0;
    public UInt32 BuildNumber = 0;
    public UInt32 PlatformId = 0;

    [MarshalAs(UnmanagedType.ByValTStr,SizeConst =128)]
    public String CSDVersion = null;
}

internal static class MyClass
{
    [DllImport("Kernel32", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern Boolean GetVersionEx([In, Out] OSVERSIONINFO ver);
}
#endregion

#region Attribute Parameter Types

public enum Color { Red }
[AttributeUsage(AttributeTargets.All)]
internal sealed class SomeAttribute : Attribute
{
    public SomeAttribute(String name, Object o, Type[] types)
    {
        // 'name' refers to a String
        // 'o' refers to one of the legal types (boxing if necessary)
        // 'types' refers to a 1-dimension,0-based array of Types
    }
}
[Some("Jeff",Color.Red,new Type[] { typeof(Math),typeof(double)})]
internal sealed class SomeType { }
#endregion


namespace ConsoleApplicationTest
{
    public class AttributeTest
    {
        public static void Main()
        {
            //DetectingAttributes.Go();
            MatchingAttributes.Go();
            MatchingAttributes.ConditionalAttributeDemo.Go();
        }
    }

    [Serializable]
    [DefaultMemberAttribute("Main")]
    [DebuggerDisplayAttribute("Richter",Name="Jeff",Target=typeof(DetectingAttributes))]
    public  sealed class DetectingAttributes
    {
        [Conditional("Debug")]
        [Conditional("Release")]
        public void DoSomething() { }
        
        public DetectingAttributes() { }

        [MethodImpl(MethodImplOptions.NoInlining)]
        [STAThread]
        public static void Go()
        {
            //Go(ShowAttributes);
            Go(ShowAttributesReflectionOnly);
        }

        private static void Go(Action<MemberInfo> showAttributes)
        {
            showAttributes(typeof(DetectingAttributes));

            var members = from m in typeof(DetectingAttributes).GetTypeInfo().DeclaredMembers.OfType<MethodBase>() where m.IsPublic select m;

            foreach (MemberInfo member in members)
            {
                showAttributes(member);
            }
        }

        private static void ShowAttributes(MemberInfo attributeTarget)
        {
            var attributes = attributeTarget.GetCustomAttributes<Attribute>();
            Console.WriteLine("Attributes applied to {0}:{1}", attributeTarget.Name,
                (attributes.Count() == 0 ? "None" : String.Empty));

            foreach (Attribute attribute in attributes)
            {
                Console.WriteLine("{0}", attribute.GetType().ToString());

                if (attribute is DefaultMemberAttribute)
                    Console.WriteLine(" MemberName={0}", ((DefaultMemberAttribute)attribute).MemberName);

                if (attribute is ConditionalAttribute)
                    Console.WriteLine(" ConditionString={0}", ((ConditionalAttribute)attribute).ConditionString);

                if (attribute is CLSCompliantAttribute)
                    Console.WriteLine(" IsCompliant={0}",((CLSCompliantAttribute)attribute).IsCompliant);

                DebuggerDisplayAttribute dda = attribute as DebuggerDisplayAttribute;
                if(dda != null)
                {
                    Console.WriteLine(" Value={0},Name={1},Target={2}", dda.Value, dda.Name, dda.Target);
                }
            }
            Console.WriteLine();
        }

        private static void ShowAttributesReflectionOnly(MemberInfo attributeTarget)
        {
            IList<CustomAttributeData> attributes = CustomAttributeData.GetCustomAttributes(attributeTarget);

            Console.WriteLine("Attributes applied to {0}: {1}", attributeTarget.Name, (attributes.Count == 0 ? "None" : String.Empty));

            foreach(CustomAttributeData attribute in attributes)
            {
                Type t = attribute.Constructor.DeclaringType;
                Console.WriteLine("  {0}", t.ToString());
                Console.WriteLine("  Constructor called={0}", attribute.Constructor);

                IList<CustomAttributeTypedArgument> posArgs = attribute.ConstructorArguments;
                Console.WriteLine("  Positional arguments passed to constructor:" + ((posArgs.Count == 0) ? "None" : String.Empty));

                foreach(CustomAttributeTypedArgument pa in posArgs)
                {
                    Console.WriteLine("  Type={0},Value={1}", pa.ArgumentType, pa.Value);
                }

                IList<CustomAttributeNamedArgument> namedArgs = attribute.NamedArguments;
                Console.WriteLine("  Named arguments set after constructor:" + ((namedArgs.Count == 0) ? "None" : String.Empty));
                foreach(CustomAttributeNamedArgument na in namedArgs)
                {
                    Console.WriteLine(" Name={0},Type={1},Value={2}", na.MemberInfo.Name, na.TypedValue.ArgumentType, na.TypedValue.Value);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }

    internal sealed class MatchingAttributes
    {
        public static void Go()
        {
            CanWriteCheck(new ChildAccount());
            CanWriteCheck(new AdultAccount());
            CanWriteCheck(new MatchingAttributes());
        }

        private static void CanWriteCheck(Object obj)
        {
            Attribute checking = new AccountsAttribute(Accounts.Checking);

            Attribute validAccounts = obj.GetType().GetCustomAttribute<AccountsAttribute>(false);

            if ((validAccounts != null) && checking.Match(validAccounts))
            {
                Console.WriteLine("{0} types can write checks.",obj.GetType());
            }
            else
            {
                Console.WriteLine("{0} types can not write checks,", obj.GetType());
            }
        }

        [Flags]
        private enum Accounts
        {
            Savings = 0x0001,
            Checking = 0x0002,
            Brokerage = 0x0004
        }

        [AttributeUsage(AttributeTargets.Class)]
        private sealed class AccountsAttribute : Attribute
        {
            private Accounts m_accounts;
            public AccountsAttribute(Accounts accounts)
            {
                m_accounts = accounts;
            }

            public override bool Match(object obj)
            {
                if (obj == null) return false;

                if (this.GetType() != obj.GetType()) return false;

                AccountsAttribute other = (AccountsAttribute)obj;

                if ((other.m_accounts & m_accounts) != m_accounts)
                    return false;
                return true;
            }

            public override bool Equals(object obj)
            {
                if (obj == null) return false;
                if (this.GetType() != obj.GetType()) return false;

                AccountsAttribute other = (AccountsAttribute)obj;

                if (other.m_accounts != m_accounts) return false;

                return true;
            }

            public override Int32 GetHashCode()
            {
                return (Int32)m_accounts;
            }
        }

        [Accounts(Accounts.Savings)]
        private sealed class ChildAccount { }

        [Accounts(Accounts.Savings | Accounts.Checking | Accounts.Brokerage)]
        private sealed class AdultAccount { }

        [Cond]
        public static class ConditionalAttributeDemo
        {
            [Conditional("TEST")]
            [Conditional("VERIFY")]
            public sealed class CondAttribute : Attribute { }

            public static void Go()
            {
                Console.WriteLine("CondAttribute is {0} applied to Program type.",
                    Attribute.IsDefined(typeof(ConditionalAttributeDemo), typeof(CondAttribute)) ? "" : "not ");
            }
        }

    }
}

