using System;
using System.Text.RegularExpressions;

namespace lab7
{
    class Fraction : IComparable<Fraction>, IFormattable, IConvertible, ICloneable
    {
        private long numerator;
        private long denominator;
        public long Numerator
        {
            get
            {
                return numerator;
            }
            set
            {
                SetNumerator(value);
            }
        }
        public long Denominator
        {
            get
            {
                return denominator;
            }
            set
            {
                SetDenominator(value);
            }
        }
        public Fraction()
        {
        }
        public Fraction(long num)
        {
            Numerator = num;
            Denominator = 1;
        }
        public Fraction(long num, long den)
        {
            Numerator = num;
            Denominator = den;
        }
        public Fraction(double x)
        {
            Fraction fraction = GetFraction(x.ToString());
            Numerator = fraction.numerator;
            Denominator = fraction.denominator;
            Simplify();
        }
        public void SetNumerator(long num)
        {
            numerator = num;
            if (numerator != 0 && denominator != 0)
            {
                Simplify();
            }
        }
        private void Simplify()
        {
            long gcd = Gcd(numerator, denominator);
            numerator /= gcd;
            denominator /= gcd;
        }
        private static long Gcd(long a, long b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            while (a != 0 && b != 0)
            {
                if (a > b)
                {
                    a %= b;
                }
                else
                {
                    b %= a;
                }
            }
            return a + b;
        }
        public void SetDenominator(long den)
        {
            if (den == 0)
            {
                throw new ArgumentException("Denominator can't be zero.");
            }
            else if (den < 0)
            {
                den *= -1;
                numerator *= -1;
            }
            denominator = den;
            if (numerator != 0)
            {
                Simplify();
            }
        }
        private double GetDouble() 
        {
            return (double)numerator / denominator;
        }
        public static Fraction GetFraction(string s)
        {
            if (TryParse(s, out Fraction fraction))
            {
                return fraction;
            }
            else
            {
                throw new FormatException("Unsupported string format.");
            }
        } 
        public static bool TryParse(string s, out Fraction fraction)
        {
            fraction = null;

            Regex firstPattern = new Regex(@"^(-?\d+)/(\d+)$"); //standart
            Regex secondPattern = new Regex(@"^(-?\d+)\((\d+)/(\d+)\)$"); //mixed
            Regex thirdPattern = new Regex(@"^(-?\d+)[,\.](\d+)$"); //double
            Regex fourthPattern = new Regex(@"^(-?\d+)$"); //integer
            if (firstPattern.IsMatch(s))
            {
                Match match = firstPattern.Match(s);
                long num = long.Parse(match.Groups[1].Value);
                long den = long.Parse(match.Groups[2].Value);
                fraction = new Fraction(num, den);
                return true;
            }
            else if (secondPattern.IsMatch(s))
            {
                Match match = secondPattern.Match(s);
                long integer = long.Parse(match.Groups[1].Value);
                long num = long.Parse(match.Groups[2].Value);
                long den = long.Parse(match.Groups[3].Value);
                int sign = (integer >= 0) ? 1 : -1;
                fraction = new Fraction(sign * (Math.Abs(integer) * den + num), den);
                return true;
            }
            else if (thirdPattern.IsMatch(s))
            {
                Match match = thirdPattern.Match(s);
                long integer = long.Parse(match.Groups[1].Value);
                int sign = (integer >= 0) ? 1 : -1;
                string fract = match.Groups[2].Value;
                long den = (long)Math.Pow(10, fract.Length);
                long num = (Math.Abs(integer) * den + long.Parse(fract)) * sign;
                fraction = new Fraction(num, den);
                return true;
            }
            else if (fourthPattern.IsMatch(s))
            {
                Match match = fourthPattern.Match(s);
                fraction = new Fraction(long.Parse(match.Groups[1].Value));
                return true;
            }
            return false;
        }
        public int CompareTo(Fraction fraction)
        {
            long lcm = denominator * fraction.denominator / Gcd(denominator, fraction.denominator);
            long first = numerator * (lcm / denominator);
            long second = fraction.numerator * (lcm / fraction.denominator);
            return first.CompareTo(second);
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType())
            {
                return false;
            }
            return CompareTo((Fraction)obj) == 0;
        }
        public override int GetHashCode()
        {
            int hashCode = -671859081;
            hashCode = hashCode * -1521134295 + numerator.GetHashCode();
            hashCode = hashCode * -1521134295 + denominator.GetHashCode();
            return hashCode;
        }
        public object Clone()
        {
            return new Fraction(numerator, denominator);
        }
        public static Fraction operator +(Fraction fract) 
        { 
            return fract; 
        }
        public static Fraction operator -(Fraction fract)
        {
            fract = new Fraction(-fract.numerator, fract.denominator);
            return fract;
        }
        public static Fraction operator +(Fraction a, Fraction b)
        { 
            Fraction fract = new Fraction(a.numerator * b.denominator + b.numerator * a.denominator, a.denominator * b.denominator);
            return fract;
        }
        public static Fraction operator -(Fraction a, Fraction b)
        { 
            return a + (-b);
        }
        public static Fraction operator *(Fraction a, Fraction b)
        { 
            Fraction fract = new Fraction(a.numerator * b.numerator, a.denominator * b.denominator);
            return fract;
        }
        public static Fraction operator *(Fraction a, long b)
        { 
            Fraction fract = new Fraction(a.numerator * b, a.denominator);
            return fract;
        }
        public static Fraction operator /(Fraction a, Fraction b)
        {
            if (b.numerator == 0)
            {
                throw new DivideByZeroException();
            }
            Fraction fract = new Fraction(a.numerator * b.denominator, a.denominator * b.numerator);
            return fract;
        }
        public static Fraction operator /(Fraction a, long b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException();
            }
            Fraction fract = new Fraction(a.numerator, a.denominator * b);
            return fract;
        }
        public static bool operator ==(Fraction a, Fraction b)
        {
            return a.CompareTo(b) == 0;
        }
        public static bool operator !=(Fraction a, Fraction b)
        {
            return a.CompareTo(b) != 0;
        }
        public static bool operator >(Fraction a, Fraction b)
        {
            return a.CompareTo(b) == 1;
        }
        public static bool operator <(Fraction a, Fraction b)       
        {
            return a.CompareTo(b) == -1;
        }
        public static bool operator >=(Fraction a, Fraction b)
        {
            return a.CompareTo(b) != -1;
        }
        public static bool operator <=(Fraction a, Fraction b)
        {
            return a.CompareTo(b) != 1;
        }
        public string ToString(string format) 
        {
            return ToString(format, null); 
        }
        public string ToString(string format, IFormatProvider formatProvider) //S - standart, M - mixed fraction, D - double, I - integer
        {
            if (string.IsNullOrEmpty(format))
            {
                format = "S";
            }
            if (format == "S")
            {
                return $"{numerator}/{denominator}";
            }
            else if (format == "M")
            {
                if (Math.Abs(numerator) > denominator && denominator != 1)
                {
                    long integer = numerator / denominator;
                    return $"{integer}({Math.Abs(numerator) % denominator}/{denominator})";
                }
                else
                {
                    return ToString("I");
                }
            }
            else if (format == "D")
            {
                return GetDouble().ToString();
            }
            else if (format == "I")
            {
                if (Math.Abs(numerator) > denominator)
                {
                    long integer = numerator / denominator;
                    return integer.ToString();
                }
                else
                {
                    return ToString("S");
                }
            }
            else
            {
                throw new FormatException($"The {format} format is not supported.");
            }
        }
        public TypeCode GetTypeCode()
        { 
            return TypeCode.Object; 
        }
        public bool ToBoolean(IFormatProvider provider)
        {
            return numerator != 0;
        }
        public byte ToByte(IFormatProvider provider)
        { 
            return Convert.ToByte(GetDouble(), provider); 
        }
        public char ToChar(IFormatProvider provider)
        { 
            return Convert.ToChar(GetDouble(), provider);
        }
        public DateTime ToDateTime(IFormatProvider provider)
        { 
            return Convert.ToDateTime(GetDouble(), provider); 
        }
        public decimal ToDecimal(IFormatProvider provider) 
        {
            return Convert.ToDecimal(GetDouble(), provider); 
        }
        public double ToDouble(IFormatProvider provider)
        { 
            return GetDouble();
        }
        public short ToInt16(IFormatProvider provider)
        {
            return Convert.ToInt16(GetDouble(), provider);
        }
        public int ToInt32(IFormatProvider provider)
        {
            return Convert.ToInt32(GetDouble(), provider);
        }
        public long ToInt64(IFormatProvider provider)
        {
            return Convert.ToInt64(GetDouble(), provider); 
        }
        public SByte ToSByte(IFormatProvider provider)
        {
            return Convert.ToSByte(GetDouble(), provider); 
        }
        public float ToSingle(IFormatProvider provider)
        {
            return Convert.ToSingle(GetDouble(), provider);
        }
        public string ToString(IFormatProvider provider)
        {
            return ToString("S", provider);
        }
        public object ToType(Type conversionType, IFormatProvider provider)
        {
            return Convert.ChangeType(GetDouble(), conversionType);
        }
        public UInt16 ToUInt16(IFormatProvider provider)
        {
            return Convert.ToUInt16(GetDouble(), provider); 
        }
        public UInt32 ToUInt32(IFormatProvider provider)
        {
            return Convert.ToUInt32(GetDouble(), provider);
        }
        public UInt64 ToUInt64(IFormatProvider provider)
        {
            return Convert.ToUInt64(GetDouble(), provider);
        }
        public static explicit operator sbyte(Fraction fract)
        {
            return fract.ToSByte(null);
        }
        public static explicit operator short(Fraction fract)
        {
            return fract.ToInt16(null);
        }
        public static explicit operator int(Fraction fract)
        {
            return fract.ToInt32(null);
        }
        public static explicit operator long(Fraction fract)
        {
            return fract.ToInt64(null); 
        }
        public static explicit operator float(Fraction fract)
        {
            return fract.ToSingle(null);
        }
        public static implicit operator double(Fraction fract)
        {
            return fract.ToDouble(null);
        }
        public static explicit operator decimal(Fraction fract)
        {
            return fract.ToDecimal(null);
        }
    }
}
