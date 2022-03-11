using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fractions
{
    class Program
    {
        static void Main(string[] args)
        {
            Drobi drob1 = new Drobi(2);
            Drobi drob2 = new Drobi(3, 2);
            Drobi drob2 = new Drobi(3, 2, 5);
            Console.WriteLine(Drobi.Desyat(a.ch, a.zn));
            Console.WriteLine(Fractions.ToDouble(a1.ch, a1.zn));
            Console.WriteLine(Fractions.ToDouble(a2.ch, a2.zn));
            drob1.GetDrobe(drob1);
            drob1.PlusOrMinus();

            Console.WriteLine(drob2[0]);

            double deciatChicl = drob1.Desyat();
            Console.WriteLine(deciatChicl);


            Drobi drobResult = drob1 + drob2;
            Console.WriteLine($"{ drobResult.Ch}/{drobResult.Zn}");


            drob1.EventChanger += Method.MyMethod;
            drob1.Ch = 7;

            Console.ReadKey();
        }
    }

    class Drobi
    {
        int ch;
        int zn;

        public Drobi(int a)
        {
            ch = a;
            zn = 1;
        }
        public Drobi(int a, int b)
        {
            ch = a;
            zn = b;
        }
        public Drobi(int a, int b, int z)
        {
            ch = z * b + a;
            zn = b;
        }
        public double Desyat()
        {
            return (double)(ch) / zn;
        }
        public static Drobi operator +(Drobi x, Drobi y)
        {
            return new Drobi(x.ch * y.zn + y.ch * x.zn, x.zn * y.zn);
        }
        public static Drobi operator -(Drobi x, Drobi y)
        {
            return new Drobi(x.ch * y.zn - y.ch * x.zn, x.zn * y.zn);
        }
        public static Drobi operator *(Drobi x, Drobi y)
        {
            return new Drobi(x.ch * y.ch, x.zn * y.zn);
        }
        public static Drobi operator /(Drobi x, Drobi y)
        {
            return new Drobi(x.ch * y.zn, x.zn * y.ch);
        }
        public override string ToString() => $"{ch} / {zn}";
        public static bool PlusOrMinus(int ch, int zn)
        {
            double result = ((double)ch / zn);
            if (result >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public delegate void Changed(Drobi a, int b);

        public event Changed EventChanger;
        public event Changed EventChangerZn;
        public int Ch
        {
            get { return ch; }
            set
            {
                EventChanger(this, value);
                ch = value;
            }
        }

        public int Zn
        {
            get { return zn; }
            set
            {
                EventChangerZn(this, value);
                zn = value;
            }
        }

        public int this[int index]
        {
            get { return (index == 0) ? ch : zn; }
        }
    }
    class Method
    {
        public static void MyMethod(Drobi a, int x)
        {
            Console.WriteLine("Дробь изменена");
        }
    }
}
