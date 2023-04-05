using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs12_methods
{
    
    class Calculator
    {
        public static int Plus(int a, int b)
        {
            return a + b;
        }
        public int Minus(int a, int b)
        {
            return a - b;
        }
    }
    internal class Program
    /// <summary>
    /// 실행시 메모리에 최초 올라가야 하기 때문에 static이 되어야 하고
    /// 메서드 이름이 Main이면 실행될 때 알아서 제일 처음에 시작됨
    /// </summary>
    {
        static void Main(string[] args)
        {
            #region < static 메서드 >
            int result = Calculator.Plus(1 , 2);
            Console.WriteLine(result);
            // static은 최초 실행 시 메모리에 바로 올라가기 때문에 class 객체를 만들 필요 없음
            // like new Calculator();
            // Calculator.Minus(2, 1); // 불가능 static이 아니기 때문
            result = new Calculator().Minus(3, 2); // static이 아닌 경우 접근 방법
            Console.WriteLine(result);
            #endregion

            #region < Call by reference vs Call by vallue >
            int x = 5, y = 10;
            Swap(ref x, ref y); // x, y가 가지고 있는 주소를 전달하라 Call by reference == pointer
            // ref가 없으면 Call by Vallue -> 값이 변하지 않음
            Console.WriteLine("x={0}, y={1}", x, y);

            Console.WriteLine(GetNumber());
            #endregion

            #region < out 매개변수 >

            int divid = 10;
            int divor = 3;

            int rem = 0;
            //Divide(divid, divor);
            //Console.WriteLine(result);
            //int rem = Reminder(divid, divor);
            //Console.WriteLine(rem);

            //Divide(divid, divor, ref result, ref rem);
            //Console.WriteLine("나누기 값 {0}, 나머지 {1}", result, rem);

            Divide(divid, divor, out result, out rem);
            Console.WriteLine("나누기 값 {0}, 나머지 {1}", result, rem);

            (result, rem) = Divide(20, 6);
            Console.WriteLine("나누기 값 {0}, 나머지 {1}", result, rem);

            #endregion

            #region < 가변길이 매개변수 >

            int resSum = Sum(1, 3, 5, 7, 9);
            Console.WriteLine(resSum);

            //Console.WriteLine(Sum(1, 3, 5, 7, 9));

            #endregion
        }

        /*
        static int Divide(int x , int y)
        {
            return x / y;
        }

        static int Reminder(int x, int y)
        {
            return (x % y);
        }
        */
        // 위의 메소드 2개를 아래 메소드 1개로 변경
        //static void Divide(int x, int y, ref int val, ref int rem)
        //{
        //    val = x / y;
        //    rem = x % y;
        //}

        static void Divide(int x, int y, out int val, out int rem)
        {
            val = x / y;
            rem = x % y;
        }

        static (int result, int rem) Divide(int x, int y)
        {
            return (x / y, x % y); // C# 7.0 부터 새로나온 방식
        }

        static (float result, float rem) Divide (float x, float y)
        {
            return (x/y, (int)x % y);
        }

        // Main 메서드와 같은 레벨에 있는 메서드들은 전부 static이 되어야 함
        public static void Swap(ref int a, ref int b)
        {
            int temp = 0;
            temp = a;
            a = b;
            b = temp;
        }

        static int val = 100;

        public static ref int GetNumber()
        {
            return ref val; // static 메서드에 접근할 수 있는 변수는 static 밖에 없음
        }

        public static int Sum(params int[] args) // Python 가변길이 매개변수랑 비교
        {
            int sum = 0;

            foreach (var item in args)
            {
                sum += item;
            }
            return sum;
        }
    }
}
