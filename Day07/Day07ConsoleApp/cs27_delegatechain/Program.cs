using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs27_delegatechain
{
    delegate void ThereIsAFire(string location); // 불났을 때 대신해주는 대리자

    delegate int Calc (int a, int b);

    delegate string Concatenate(string[] args);
    internal class Program
    {
        #region < 클래스 Sample 람다식 > 
        class Sample
        {
            private int valueA; // 멤버변수 -> 외부에서 접근 불가하게 만들기 위함

            public int ValueA // 프로퍼티
            {
                //get { return valueA; }
                //set { valueA = value; }
                
                // 람다식 활용
                get => valueA; 
                //set => valueA = value;
                set { valueA = value;}
                // => get은 람다식, set은 일반식으로 적어도 상관 없음
            }
        }
        #endregion

        #region < 대리자 - 불났어요 >
        static void Call119(string location)
        {
            Console.WriteLine("소방서죠? {0}에 불났어요",location);
        }

        static void ShoutOut(string location)
        {
            Console.WriteLine("{0}에 불났어요", location);
        }

        static void Escape(string location)
        {
            Console.WriteLine("{0}에서 탈출합니다.", location);
        }

        #endregion

        static string ProcConcate(string[] args)
        {
            string result = string.Empty; // == "";
            foreach (string s in args)
            {
                result += s + "/";
            }

            return result;
        }
        static void Main(string[] args)
        {
            #region < 대리자 체인 영역 - 불났어요 >
            //var loc = "우리집";
            //Call119(loc);
            //ShoutOut(loc);
            //Escape(loc);

            //// 불이 날 수 있으니까 미리 준비
            //// -> 대리자 ThereIsAFire에 Call119, ShoutOut, Escape 한번에 수행하도록 하기
            //// 대리자에 메서드 추가
            //var otherloc = "경찰서";
            //ThereIsAFire fire = new ThereIsAFire(Call119);
            //fire += new ThereIsAFire(ShoutOut);
            //fire += new ThereIsAFire(Escape);

            //// 실행만 하기
            //fire(otherloc);

            //// 대리자에서 shoutout 메소드를 하지 않게 만들기 (삭제하기)
            //fire -= new ThereIsAFire(ShoutOut);

            //fire("다른 집");
            #endregion

            #region < 대리자 >
            // 익명함수
            //Calc plus = delegate (int a, int b)
            //{
            //    return a + b;
            //};
            //Console.WriteLine(plus(6, 7));
            
            //// 람다식 활용 Calc plus = delegate (int a, int b) 와 같음
            //Calc minus = (a, b) => { return a - b; };

            //Console.WriteLine(minus(67, 9));

            //// 람다식
            //Calc simpleMinus = (a, b) => a - b;
            #endregion

            Concatenate concat = new Concatenate(ProcConcate);
            var result = concat(args);

            Console.WriteLine(result);

            Console.WriteLine("람다식으로");
            Concatenate concat2 = (arr) =>
            {
                string res = string.Empty; // == "";
                foreach (string s in args)
                {
                    res += s + "/";
                }

                return res;
            };

            Console.WriteLine(concat2(args));

        }
    }
}
