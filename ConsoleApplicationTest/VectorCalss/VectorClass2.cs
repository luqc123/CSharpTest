using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Collections;

namespace VectorClass
{
    [LastModified("23 Nov 2019","Add IFormattor")]
    [LastModified("22 Nov 2019","Create class Vector")]
    public class Vector : IFormattable,IEnumerable<double>
    {
        public double X { get; }
        public double Y { get; }
        public double Z { get; }

        public override bool Equals(object obj)
        {
            return this == obj as Vector;
        }

        public override int GetHashCode()
        {
            return (int)X | (int)Y | (int)Z;
        }

        public override string ToString()
        {
            return $"({X},{Y},{Z})";
        }

        public Vector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        [LastModified("23 Nov 2019","Applying to Constructor")]
        public Vector(Vector vector) : this(vector.X, vector.Y, vector.Z) { }



        public double this[uint i]
        {
            get
            {
                switch (i)
                {
                    case 0:
                        return X;
                    case 1:
                        return Y;
                    case 2:
                        return Z;
                    default:
                        throw new IndexOutOfRangeException("Attempt to retrieve Vector element" + i);
                }
            }
        }

        public static bool operator ==(Vector left, Vector right) =>
            Math.Abs(left.X - right.X) < double.Epsilon &&
            Math.Abs(left.Y - right.Y) < double.Epsilon &&
            Math.Abs(left.Z - right.Z) < double.Epsilon;
        public static bool operator !=(Vector left, Vector right) => !(left == right);

        public static Vector operator *(double left, Vector right) => new Vector(left * right.X,
            left * right.Y, left * right.Z);
        public static Vector operator *(Vector left, double right) => (right * left);

        public static double operator *(Vector left, Vector right) => left.X * right.X +
            left.Y * left.Y + left.Z * left.Z;
        public double Norm() => X * X + Y * Y + Z * Z;

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (format == null)
                return ToString();
            switch (format.ToUpper())
            {
                case "N":
                    return "||" + Norm().ToString() + "||";
                case "VE":
                    return $"({X:E}),({Y:E}),({Z:E})";
                case "IJK":
                    return $"{X} i + {Y} j + {Z} k";
                default:
                    return ToString();
            }
        }

        [LastModified("23 Nov 2019","Add IEnumerator")]
        public IEnumerator<double> GetEnumerator()
        {
            return new VectorEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }


    [LastModified("23 Nov 2019","Change to implement the generic version of IEnumerator<T>")]
    [LastModified("22 Nov 2019","Created class Vector")]
    public class VectorEnumerator : IEnumerator<double>
    {
        readonly Vector _theVector;
        int _location;

        public VectorEnumerator(Vector vector)
        {
            _theVector = vector;
            _location = -1;
        }

        public object Current => Current;

        double IEnumerator<double>.Current
        {
            get
            {
                if (_location < 0 || _location > 2)
                    throw new InvalidOperationException("the enumerator is either before the first element or " +
                        "after the last element of the vector");
                return _theVector[(uint)_location];
            }
        } 

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            ++_location;
            return (_location <= 2);
        }

        public void Reset()
        {
            _location = -1;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class DefaultValueAttribute : Attribute
    {
        public Int32 DefaultValue { get; set; }
        public DefaultValueAttribute(Int32 defValue)
        {
            DefaultValue = defValue;
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Constructor, AllowMultiple = true, Inherited = false)]
    public class LastModifiedAttribute : Attribute
    {
        private readonly DateTime _dateModified;
        private readonly string _changes;

        public LastModifiedAttribute(string dateModified, string changes)
        {
            _dateModified = DateTime.Parse(dateModified);
            _changes = changes;
        }

        public DateTime DateModified => _dateModified;
        public string Changes => _changes;
        public string Issues { get; set; }
    }

    [AttributeUsage(AttributeTargets.Assembly)]
    public class SupportsWhatsNewAttribute : Attribute
    {

    }
}
