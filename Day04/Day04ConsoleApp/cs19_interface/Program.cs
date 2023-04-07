using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs19_interface
{
    interface ILogger
    {
        void Writelog(string log); // 무조건 구현해야 하는 것
    }

    interface IFormattableLogger : ILogger
    {
        void WriteLog(string format, params object[] args); // args 다중 파라미터
    }

    class ConsoleLogger : ILogger
    {
        public void Writelog(string log)
        {
            Console.WriteLine("{0} {1}", DateTime.Now.ToLocalTime(), log);
        }
    }

    class ConsoleLogger2 : IFormattableLogger
    {
        public void WriteLog(string format, params object[] args)
        {
            string message = string.Format(format, args);
            Console.WriteLine("{0}, {1}", DateTime.Now.ToLocalTime(), message);
        }

        public void Writelog(string log)
        {
            Console.WriteLine("{0} {1}", DateTime.Now.ToLocalTime(), log);
            
        }
    }

    class Car
    {
        public string Name { get; set; }
        public string Color { get; set; }

        public void Stop()
        {
            Console.WriteLine("정지!");
        }
    }

    interface IHoverable
    {
        void Hover(); // 수륙양용 자동차
    }

    interface IFlyable
    {
        void Fly(); // 나는 자동차
    }

    // C#은 다중 상속 안됨 => 클래스, 인터페이스로 다중 상속 할 수 있게 만들었음
    class FlyHoverCar : Car, IFlyable, IHoverable // Car 상속, IFlyabe, IHoverable 구현
    {
        public void Fly()
        {
            Console.WriteLine("날다");
        }

        public void Hover()
        {
            Console.WriteLine("물에서 달립니다.");

        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new ConsoleLogger();
            // 인터페이스는 생성하지 않음 / 값을 받을때만 사용
            // -> ILogger logger = new ILogger 하지 않음
            logger.Writelog("안녕~!!!");

            IFormattableLogger logger2 = new ConsoleLogger2 ();
            logger2.WriteLog("{0} X {1} = {2}", 6, 5, 6 * 5);
        }
    }
}
