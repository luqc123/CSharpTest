using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationTest
{
    public class ExplicitCastTest
    {
        public static void Main()
        {
            Currency currency = new Currency(5, 10);

            //explicit
            Currency currency1 = (Currency)5.11;

            uint i = 1;
            i += currency;
            Console.WriteLine(i);
        }
    }

    struct Currency
    {
        public uint Dollars;
        public ushort Cents;

        public Currency(uint dollars,ushort cents)
        {
            Dollars = dollars;
            Cents = cents;
        }

        public override string ToString()
        {
            return string.Format("${0}.{1,-2:00}", Dollars, Cents);
        }

        public static string GetCurrentUnit()
        {
            return "Dollar";
        }


        public static explicit operator Currency(float value)
        {
            checked
            {
                uint dollars = (uint)value;
                ushort cents = (ushort)((value - dollars) * 100);
                return new Currency(dollars, cents);
            }
        }

        public static implicit operator float(Currency value)
        {
            return value.Dollars + (value.Cents / 100.0f);
        }

        public static implicit operator Currency(uint value)
        {
            return new Currency(value, 0);
        }

        public static implicit operator uint(Currency value)
        {
            return value.Dollars;
        }
    }
}
