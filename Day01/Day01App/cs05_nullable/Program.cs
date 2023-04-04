using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs05_nullable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // int a; // int a -> null값을 담을 수 없음
            int? a = null; // nullable
            
            Console.WriteLine(a == null);
            //Console.WriteLine(a.GetType()); 예외 발생

            int b = 0;
            Console.WriteLine(b == null);
            Console.WriteLine(b.GetType());

            // 값 형식 byte short, int, long, float, double, char 등은 null을 할당 받을 수 없음
            // but, null을 할당 할 수 있도록 만드는 방식 : type?

            float? c = null;
            Console.WriteLine(c.HasValue);

            c = 3.14f;
            Console.WriteLine(c.HasValue);
            Console.WriteLine(c.Value);
            Console.WriteLine(c);
        }
    }
}
