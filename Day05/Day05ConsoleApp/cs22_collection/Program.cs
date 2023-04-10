using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs22_collection
{
    class MyList
    {
        int[] array;

        public MyList() 
        {
            array = new int[3]; // 최초 크기 : 3
        }

        public int Length
        {
            get { return array.Length;}
        }

        //인덱서
        public int this[int index] 
        { 
            get
            {
                return array[index];
            }
            set
            {
                if (index >= array.Length) // 3보다 커진 경우
                {
                    Array.Resize<int>(ref array, index + 1);
                    Console.WriteLine("MyList Resized : {0}", array.Length);
                }

                array[index] = value; // 값 할당
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[5];
            array[0] = 1;
            array[1] = 2;
            array[2] = 3;
            array[3] = 4;
            array[4] = 5;
            //array[5] = 6; // out of range error 발생함

           // Console.WriteLine(array[5]); // IndexOutOfRangException

            char[] oldString = new char[5]; // 옛날방법 (C에서만 사용)
                                            // 문자열의 길이를 지정해줘야함
            string curString = "";          // 문자열 길이에 제한이 없음

            // arraylist
            // -> 배열과의 차이점 : 원소 입력 개수 제한 없이 추가 가능
            ArrayList list = new ArrayList();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(6);

            // 여러가지 메서드
            ArrayList list2 = new ArrayList();
            list2.Add(8);
            list2.Add(4);
            list2.Add(15);
            list2.Add(10);
            list2.Add(7);
            list2.Add(2);

            foreach (var item in list2)
            {
                Console.WriteLine(item);
            }

            // list에서 데이터 삭제
            Console.WriteLine("숫자 10 삭제 후");
            list2.Remove(10);

            foreach (var item in list2)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("3번째 데이터 삭제");
            list2.RemoveAt(3);
            foreach (var item in list2)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("0번째 위치에 숫자 7 넣기");
            list2.Insert(0, 7);
            foreach (var item in list2)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("정렬 후");
            list2.Sort();
            foreach (var item in list2)
            {
                Console.WriteLine(item);
            }

            /*
            ArrayList 값 추가
             - ArrayList.Add
             - ArrayList.Insert(위치값, 값)

            ArrayList 값 삭제
             - ArrayList.Remove(값)
             - ArrayList.RemoveAt(위치값)

            ArrayList 정렬
             - ArrayList.Sort() -> 오름차순 정렬

             */

            // 새로만든 MyList
            MyList myList = new MyList();
            for (int i = 1; i <= 5; i++)
            {
                myList[i] = i * 5; // 5, 10, 15, 20, 25
            }

            for (int i = 0; i < myList.Length; i++)
            {
                Console.WriteLine(myList[i]);
            }
        }
    }
}
