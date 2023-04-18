using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace number_3_app
{
   
    internal class Program
    {
        static void Main(string[] args)
        {
            var Rainbow = new Dictionary<string, string>();
            Rainbow.Add("Red", "빨간색");
            Rainbow.Add("Orange", "주황색");
            Rainbow.Add("Yellow", "노란색");
            Rainbow.Add("Green", "초록색");
            Rainbow.Add("Blue", "파란색");
            Rainbow.Add("Navy", "남색");
            Rainbow.Add("Purple", "보라색");

            List<string> rainbow = new List<string>(Rainbow.Values);

            Console.Write("무지개의 색은 ");
            foreach (string value in rainbow)
            {
                Console.Write($"{value},");
            }
            Console.WriteLine("입니다.");

            Console.WriteLine("");
            Console.WriteLine("Key와 Value 확인");

            string color = "Purple";
            Console.WriteLine($"{color}은 {Rainbow[color]} 입니다.");
        }
    }
}
