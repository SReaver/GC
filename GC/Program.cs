using System;
using System.Reflection;
using System.Threading;


namespace GC
{
    class MyTestClass
    {
        double d, f;
        public MyTestClass(double d, double f)
        {
            this.d = d;
            this.f = f;
        }
        public double Sum()
        {
            return d + f;
        }
        public void Info()
        {
            Console.WriteLine(@"d = {0} f = {1}", d, f);
        }
        public void Set(int a, int b)
        {
            d = (double)a;
            f = (double)b;
        }
        public void Sum(double a, double b)
        {
            f = a;
            d = b;
        }
        public override string ToString()
        {
            return "MyTestClass";
        }
    }
    class Reflect
    {
        public static void MethodReflectInfo<T>(T obj) where T : class
        {
            Type t = typeof(T);
            MethodInfo[] MArr = t.GetMethods();
            Console.WriteLine("*** Список методов класса {0} ***\n", obj.ToString());

            foreach  (MethodInfo m in MArr)
            {
                Console.Write("--> "+m.ReturnType.Name + " \t" + m.Name + "(");

                ParameterInfo[] p = m.GetParameters();
                for (int i = 0; i < p.Length; i++)
                {
                    Console.Write(p[i].ParameterType.Name+" " + p[i].Name);
                    if (i+1<p.Length)
                    {
                        Console.Write(", ");
                    }
                }
                Console.Write(")\n");
            }


        }
    }

    class MyClass
    {


        ~MyClass()
        {

            for (int i = 0; i < 40; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(1000);
            }
            Console.WriteLine("Убил!");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //MyClass m = new MyClass();

            MyTestClass mtc = new MyTestClass(12.0,3.5);
            Reflect.MethodReflectInfo<MyTestClass>(mtc);
            Console.ReadLine();
        }
    }
}
