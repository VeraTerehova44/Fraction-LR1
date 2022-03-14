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
            Drobi drob3 = new Drobi(3, 2, 5);

            Console.WriteLine(drob1.Desyat());
            Console.WriteLine(drob2.Desyat());
            Console.WriteLine(drob3.Desyat());

            Console.WriteLine(drob1.PlusOrMinus(drob1.Ch, drob1.Zn));

            Console.WriteLine("Числитель {0}", drob2[0]);
            Console.WriteLine("Знаменатель {0}", drob2[1]);

            Console.WriteLine("Сложение: {0}", drob1 + drob2);
            Console.WriteLine("Сложение: {0}", drob2 + drob3);
            Console.WriteLine("Сложение: {0}", drob3 + drob1);

            Console.WriteLine("Вычитание: {0}", drob1 - drob2);
            Console.WriteLine("Вычитание: {0}", drob2 - drob3);
            Console.WriteLine("Вычитание: {0}", drob3 - drob1);

            Console.WriteLine("Деление: {0}", drob1 / drob2);
            Console.WriteLine("Деление: {0}", drob2 / drob3);
            Console.WriteLine("Деление: {0}", drob3 / drob1);

            Console.WriteLine("Умножение: {0}", drob1 * drob2);
            Console.WriteLine("Умножение: {0}", drob2 * drob3);
            Console.WriteLine("Умножение: {0}", drob3 * drob1);

            drob1.EventChanger += Method.MyMethod;
            drob1.EventChangerZn += Method.MyMethod2;            
            drob1.Zn = 7;
            drob1.Ch = 9;

            

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


        public bool PlusOrMinus(int ch, int zn)
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
            Console.WriteLine("Знаменатель изменен");
        }
        public static void MyMethod2(Drobi a, int x)
        {
            Console.WriteLine("Числитель изменен");
        }

    }
}
