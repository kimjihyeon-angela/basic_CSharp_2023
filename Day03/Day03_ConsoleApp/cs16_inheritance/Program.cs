using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs16_inheritance
{
    #region < 기반 또는 부모 클래스>
    class Base // 기반 또는 부모 클래스
        // 자식 클래스에서 상속받으려면 private은 안써야 함
    {
        protected string Name;
        private string Color; // 만약 상속을 할꺼면 private을 protected로 변경해줘야 함
        public int Age;

        public Base(string Name, string Color, int Age) 
        { 
            this.Name = Name;
            this.Color = Color;
            this.Age = Age;

            Console.WriteLine("{0}.Base()", Name);
        }

        public void BaseMethod()
        {
            Console.WriteLine("{0}.BaseMethod()", Name);
        }

        public void GetColor()
        {
            Console.WriteLine("{0}.Base {1}", Name, Color);
        }
    }
    #endregion

    #region < 자식 클래스, 상속 >
    class Child : Base // 상속받은 이후 Base의 Name, Color, Age를 새로 만들지 않음
    {
        public Child(string Name, string Color, int Age) : base(Name, Color, Age) 
        {
            Console.WriteLine("{0}.Child()", Name);
        }

        public void ChildMethod()
        {
            Console.WriteLine("{0}.ChildMethod()", Name);
        }

        /*
         public string GetColor()
        {
            return Color;
            // Base 클래스에서는 return Color 가능
            // 자식 클래스에서는 부모 클래스에서 private인 Color 접근 불가
            // 부모 클래스에서 Color를 public, protected으로 변경해주면 접근 가능해짐
        }
        */

    }
    #endregion


    internal class Program
    {
        static void Main(string[] args)
        {
            Base b = new Base("NameB", "White", 1);
            b.BaseMethod();
            b.GetColor();

            Child c = new Child("NameC", "Black", 2);
            c.BaseMethod();
            c.ChildMethod();
            c.GetColor(); // Base 클래스의 GetColor
                          // c에서 Color 접근 불가
            // NameC.Color Base Black 으로 출력됨
            
            // Child 클래스 실행할 경우 부모 클래스 생성자를 불러내고 Child 클래스 생성자 생성됨
            // 
        }
    }
}
