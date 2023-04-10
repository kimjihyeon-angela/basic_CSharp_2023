using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs20_abstractClass
{
    abstract class AbstractParent // abstract -> 클래스, 인터페이스의 역할 모두 수행
    {
        protected void MethodA()
        {
            Console.WriteLine("AbstractParent.MethodA()");
        }
        
        public void MethodB() // 클래스랑 만드는 법 동일
        {
            Console.WriteLine("AbstractParent.MethodB()");
        }

        public abstract void MethodC(); // 인터페이스랑 기능 동일, 추상메서드
    }

    class Child : AbstractParent
    {
        public override void MethodC() // 재정의(사실은 인터페이스처럼 구현)
        {
            Console.WriteLine("Child.MethodC() - 추상클래스 구현");
            MethodA();
        }
    }

    abstract class Mammal // 포유류 최상위 클래스
    {
        public void Nurse()
        {
            Console.WriteLine("포유한다");
        }
        public abstract void Sound();
    }

    class Dogs : Mammal
    {
        public override void Sound()
        {
            Console.WriteLine("멍멍!!");
        }
    }

    class Cats : Mammal
    {
        public override void Sound()
        {
            Console.WriteLine("야옹!!");
        }
    }



    internal class Program
    {
        static void Main(string[] args)
        {
            AbstractParent parent = new Child();
            parent.MethodC();
            parent.MethodB();
            // parent.MethodA();
            // -> protected이기 때문에 사용불가
            // => protected는 자기 자신, 자식 클래스 내에서만 사용가능
        }
    }
}
