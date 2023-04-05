using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs11_logiccondition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region < If구문 >
            int a = 20;
            if (a == 20) 
            {
                Console.WriteLine("20입니다.");
                Console.WriteLine("두번째 줄입니다.");
            }
            else 
            {
                Console.WriteLine("20이 아닙니다.");
            }
            if (a == 30) return; // 메서드를 완전히 빠져나가는 구문은 한줄로 적어도 되지만 가능하면 { } 사용하기
            #endregion

            #region < 데이터타입 비교 Switch 구문>
            // 데이터타입 비교하는 switch 문 (C# 7.0 부터)
            object obj = null;

            string inputs = Console.ReadLine(); // 콘솔에서 입력
            if (int.TryParse(inputs, out int iouput)) // 예외 발생 -> 0, 0아닌경우 -> True
            {
                obj = iouput; // 입력한 값 = 정수 -> 문자열을 정수로 변환
            }
            else if (float.TryParse(inputs, out float foutput))
            {
                obj = foutput; // 입력한 값 = 실수 -> 문자열을 실수로 변환
            }
            else
            { 
                obj = inputs;
            }
            Console.WriteLine(obj);

            switch (obj) 
            {
                case int i: // 들어간 값이 정수인 경우
                    Console.WriteLine("{0}는 int 형식입니다.",i);
                    break;
                case float f: // 들어간 값이 실숭ㄴ 경우
                    Console.WriteLine("{0}는 float 형식입니다.",f);
                    break;
                case string s:
                    Console.WriteLine("{0}은 string 형식입니다.",s);
                    break;
                default:
                    Console.WriteLine("몰라요");
                    break;
            }
            #endregion

            #region < 이중 For문 >

            for (int x = 2; x <= 9; x++)
            {
                for (int y = 1; y <= 9; y++)
                {
                    Console.WriteLine("{0} X {1} = {2}", x, y, x * y);
                }
            }

            #endregion

            #region < Foreach문 >

            int[] ary = { 2, 4, 6, 8, 10 };

            foreach (int i in ary)
            {
                Console.WriteLine("{0} * 2 = {1}", i, i*2);
            }

            for (int i = 0; i < ary.Length; i++)
            {
                Console.WriteLine("{0} * 2 = {1}", ary[i], ary[i]*2);
            }

            #endregion
        }
    }
}
