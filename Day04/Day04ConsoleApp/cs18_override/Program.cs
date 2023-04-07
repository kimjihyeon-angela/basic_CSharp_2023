using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs18_override
{
    class ArmorSuite
    {
        public virtual void Init()
        {
            Console.WriteLine("기본 아머슈트");
        }
    }

    class IronMan : ArmorSuite
    {
        public override void Init()
        {
            // base.Init(); // 부모 글래스의 Init() 실행안함
            Console.WriteLine("리펄서 빔");
        }
    }

    class WarmMachine : ArmorSuite
    {
        public override void Init()
        {
            base.Init();
            Console.WriteLine("미니건");
            Console.WriteLine("돌격소총");
        }
    }

    class Parent
    {
        public void CurrentMethod()
        {
            Console.WriteLine("부모클래스 메서드");
        }
    }

    class Child : Parent
    {
        public new void CurrentMethod() // new -> 부모클래스의 메서드를 상속받은 것을 숨김
        {
            Console.WriteLine("자식 클래스 메서드");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("아머슈트 생산");
            ArmorSuite suite = new ArmorSuite();
            suite.Init();

            Console.WriteLine("워머신 생산");
            WarmMachine machine = new WarmMachine();
            machine.Init();

            Console.WriteLine("아이언맨 생산");
            IronMan iron = new IronMan();
            iron.Init();

            Parent parent = new Parent();
            parent.CurrentMethod();

            Child child = new Child();
            child.CurrentMethod();
        }
    }
}
