using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs26_delegate
{
    // 대리자 사용하겠다는 선언
    delegate int CalcDelegate(int a, int b);

    delegate int Compare(int a, int b); // a와 b 중 대소비교를 위한 대리자

    #region < 대리자 기본 학습 >
    class Calc
    {
        public int Plus(int a, int b)
        {
            return a + b;
        }

        // static이 붙으면 무조건 실행될 때 최초 메모리에 올라감
        // 프로그램 실행 중 언제든지 접근 가능
        // private하면 안됨
        public static int Minus(int a, int b)
        {
            return a - b;
        }
        #endregion
    }
    internal class Program
    {
        #region < 대리자 활용하여 오름차순, 내림차순 메소드 만들기 >
        // 오름차순 비교
        static int AscendCompare(int a, int b)
        {
            if (a > b)
            {
                return 1;
            }
            else if (a == b)
            { 
                return 0;
            }
            else
            {
                return -1;
            }
        }

        // 내림차순 비교
        static int DescendCompare (int a, int b)
        {
            if (a < b) return 1;
            else if (a == b) return 0;
            else return -1;
        }
        #endregion

        #region < 대리자 활용했을 때의 버블정렬, 활용하지 않았을 때의 버블 정렬 비교 >
        static void BubbleSort(int[] DataSet, Compare comparer)
        {
            int i = 0;
            int j = 0;
            int temp = 0;

            /* 대리자 사용 안할 때의 오름차순 정렬
            for (i = 0; i < DataSet.Length-1; i++)
            {
                for (j = 0; j < DataSet.Length -(i+1); j++)
                {
                    // 오름차순 정렬
                    if (DataSet[j] > DataSet[j+1])
                    {
                        temp = DataSet[j+1];
                        DataSet[j+1] = DataSet[j];
                        DataSet[j] = temp;
                    }
                }
            }
            */

            // 대리자 사용한 경우 -> 오름차순, 내림차순 정렬이 한번에 실행가능
            for (i = 0; i < DataSet.Length - 1; i++)
            {
                for (j = 0; j < DataSet.Length - (i + 1); j++)
                {
                    // 오름차순 정렬
                    if (comparer(DataSet[j], DataSet[j+1]) > 0)
                    {
                        temp = DataSet[j + 1];
                        DataSet[j + 1] = DataSet[j];
                        DataSet[j] = temp;
                    }
                }
            }
        }

        // 대리자 사용하지 않고 메소드로만 오름차순, 내림차순으로 정렬하는 방법
        // 꼭 대리자 사용하지 않아도 상관은 없으나 코드의 길이가 매우 길어짐
        static void BubbleSort2(int[] DataSet, bool isAscend)
        {
            int i = 0;
            int j = 0;
            int temp = 0;

            for (i = 0; i < DataSet.Length-1; i++)
            {
                for (j = 0; j < DataSet.Length -(i+1); j++)
                {
                    if (isAscend == true)
                    {
                        // 오름차순 정렬
                        if (DataSet[j] > DataSet[j + 1])
                        {
                            temp = DataSet[j + 1];
                            DataSet[j + 1] = DataSet[j];
                            DataSet[j] = temp;
                        }
                    }
                    else
                    {
                        // 내림차순 정렬
                        if (DataSet[j] < DataSet[j + 1])
                        {
                            temp = DataSet[j + 1];
                            DataSet[j + 1] = DataSet[j];
                            DataSet[j] = temp;
                        }
                    }
                }
            }
        }
        #endregion

        static void Main(string[] args)
        {
            #region < 대리자 기본 예시 >
            // 일반적으로 클래스 사용 방식 - 직접 호출
            Calc nomalCalc = new Calc();
            int x = 10;
            int y = 15;
            int res = nomalCalc.Plus(x, y);
            Console.WriteLine(res);
            Console.WriteLine(nomalCalc.Plus(x, y));

            // Minus는 static으로 nomalCalc.Minus 불가능
            Calc.Minus(x,y);

            // 대리자를 사용하는 방식 - 대리자가 대신 호출, 실행
            x = 30;
            y = 20;
            Calc delCalc = new Calc();
            CalcDelegate Callback;

            Callback = new CalcDelegate(delCalc.Plus);
            int res2 = Callback(x,y); // = Calc.Plus() 메소드를 대신 호출
            Console.WriteLine(res2);

            Callback = new CalcDelegate(Calc.Minus);
            res2 = Callback(x,y);
            Console.WriteLine(res2);
            #endregion

            #region < 대리자 활용하여 오름차순, 내림차순 버블정렬 >
            int[] origin = { 4, 7, 8, 2, 9, 1 };

            Console.WriteLine("오름차순 버블정렬");
            BubbleSort(origin, new Compare(AscendCompare));

            foreach (var item in origin)
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine();

            Console.WriteLine("내림차순 버블정렬");
            BubbleSort(origin, new Compare(DescendCompare));

            foreach (var item in origin)
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine();
            #endregion

        }
    }
}
