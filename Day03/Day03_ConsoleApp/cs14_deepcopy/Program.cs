using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs14_deepcopy
{
    class SomeClass
    {
        public int SomeField1;
        public int SomeField2;
        // 2개의 멤버변수 가지고 있음

        public SomeClass DeepCopy()
        {
            SomeClass newCopy = new SomeClass();
            newCopy.SomeField1 = this.SomeField1; // Call by value
            newCopy.SomeField2 = SomeField2;
            // 위 아래 두 개 같음

            return newCopy;
        }
        // 1개의 메소드를 가지고 있음

        // this 사용법
        class Employee
        {
            private string Name;

            public void SetName(string Name)
            {
                this.Name = Name; 
                // 멤버변수(속성)와 메서드의 매개변수 이름이 대소문자까지 같은 경우 비교할 때 this 사용
            }
        }

        class ThisClass
        {
            int a, b, c;

            public ThisClass()
            {
                this.a = 1;
            }

            public ThisClass(int b) : this() // 이 클래스는 위의 this를 호출한다~
            {
                this.b = 2;
            }

            public ThisClass(int b, int c) : this(b)
            {
                this.c = 3;
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("얕은 복사 시작"); // source와 target이 (주소복사) => 값이 쉐어됨

            SomeClass source = new SomeClass();
            source.SomeField1 = 100;
            source.SomeField2 = 200;

            SomeClass target = source;
            target.SomeField2 = 300;

            Console.WriteLine("s.SomeField1 => {0}, s.SomeField2 => {1}", 
                               source.SomeField1, source.SomeField2);
            Console.WriteLine("t.SomeField1 => {0}, t.SomeField2 => {1}",
                               target.SomeField1, target.SomeField2);

            Console.WriteLine("깊은 복사!!");

            SomeClass s = new SomeClass();
            s.SomeField1 = 100;
            s.SomeField2 = 200;

            SomeClass t = s.DeepCopy(); // 깊은 복사
            t.SomeField2 = 300;

            Console.WriteLine("s.SomeField1 => {0}, s.SomeField2 => {1}",
                               s.SomeField1, s.SomeField2);
            Console.WriteLine("t.SomeField1 => {0}, t.SomeField2 => {1}",
                               t.SomeField1, t.SomeField2);


        }
    }
}
