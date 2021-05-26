using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace numMethod4
{
    struct dot : IComparable<dot>
    {
        public decimal x;
        public decimal y;

        int IComparable<dot>.CompareTo(dot other)
        {
            int res=0;
            if (this.x < other.x)
            {
                res = -1;
            } else if (this.x > other.x)
            {
                res = 1;
            }
            return res;
        }

        public static bool operator < (dot c1, dot c2)
        {
            return c1.x < c2.x;
        }
        public static bool operator >(dot c1, dot c2)
        {
            return c1.x > c2.x;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<dot> func = new List<dot>();
            /*try
            {
                do
                {
                    Console.WriteLine("Введите точки ");
                    Console.Write("х= ");
                    decimal a = Convert.ToDecimal(Console.ReadLine());
                    Console.Write("у= ");
                    decimal b = Convert.ToDecimal(Console.ReadLine());
                    func.Add(new dot() { x = a, y = b });

                } while (true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Больше точки не принимаю");
            }*/
            func.Add(new dot() { x = (decimal)3.50, y = (decimal)33.1154});
            func.Add(new dot() { x = (decimal)3.55, y = (decimal)34.8133 });
            func.Add(new dot() { x = (decimal)3.60, y = (decimal)36.5982 });
            func.Add(new dot() { x = (decimal)3.65, y = (decimal)38.4747 });
            func.Add(new dot() { x = (decimal)3.70, y = (decimal)40.4473 });
            func.Add(new dot() { x = (decimal)3.75, y = (decimal)42.5211 });
            func.Add(new dot() { x = (decimal)3.80, y = (decimal)44.7012 });
            func.Add(new dot() { x = (decimal)3.85, y = (decimal)46.9931 });
            func.Add(new dot() { x = (decimal)3.90, y = (decimal)49.4012 });
            func.Add(new dot() { x = (decimal)3.95, y = (decimal)51.9354 });
            func.Add(new dot() { x = (decimal)4.00, y = (decimal)54.5982 });
            func.Add(new dot() { x = (decimal)4.05, y = (decimal)57.3975 });
            func.Add(new dot() { x = (decimal)4.10, y = (decimal)60.3403 });
            func.Add(new dot() { x = (decimal)4.15, y = (decimal)63.4340 });
            func.Add(new dot() { x = (decimal)4.20, y = (decimal)66.6863 });
            func.Sort();
            Console.WriteLine("Вы ввели точки:");
            for (int i = 0; i < func.Count; i++)
            {
                Console.WriteLine(func[i].x + ";" + func[i].y);
            }
            Console.WriteLine("");
            Console.WriteLine("Введите интерполируемый x");
            decimal x =0;
            try
            {
                x = Convert.ToDecimal(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Не могу распознать число с запятой, перзапустите");
            }
           

            Console.WriteLine("результат интерполирования методом лагранжа : f(" + 3.522 + ")=" + lagrange((decimal)3.522, func));
            Console.WriteLine("результат интерполирования методом лагранжа : f(" + 4.176 + ")=" + lagrange((decimal)4.176, func));
            Console.WriteLine("результат интерполирования методом лагранжа : f(" + 3.475 + ")=" + lagrange((decimal)3.475, func));
            Console.WriteLine("результат интерполирования методом лагранжа : f(" + 4.25 + ")=" + lagrange((decimal)4.25, func));


            Console.WriteLine("результат интерполирования методом лагранжа : f("+x+")="+lagrange(x, func));
            Console.ReadKey();
        }
        static decimal lagrange(decimal x, List<dot> dots)
        {
            decimal y = 0;
            
            for(int i = 0; i < dots.Count; i++)
            {
                decimal chis = 1;
                decimal znam = 1;
                for(int j=0;j<dots.FindIndex(n => n.x == dots[i].x); j++)
                {
                    chis *= x - dots[j].x;
                }
                for (int j = dots.FindIndex(n => n.x == dots[i].x) + 1; j < dots.Count; j++)
                {
                    chis *= x - dots[j].x;
                }

                for (int j = 0; j < dots.FindIndex(n => n.x == dots[i].x); j++)
                {
                    znam *= dots[i].x - dots[j].x;
                }
                for (int j = dots.FindIndex(n => n.x == dots[i].x) + 1; j < dots.Count; j++)
                {
                    znam *= dots[i].x - dots[j].x;
                }
                y += dots[i].y * (chis / znam);
                //Console.WriteLine(dots[i].y+" * ("+chis+" / "+znam+")   "+ dots[i].y * (chis / znam));
            }
            return y;
        }
    }
}
