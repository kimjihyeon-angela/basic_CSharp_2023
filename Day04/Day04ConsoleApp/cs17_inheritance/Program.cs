using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs17_inheritance
{
    // 상속해줄 부모 클래스
    class Parent
    {
        public string Name;
        // private을 쓸 경우 자식 클래스에서 접근이 불가능함
        // private 대신 protected 사용하기

        public Parent (string Name)
        {
            this.Name = Name;
            Console.WriteLine("{0} from Parent 생성자", Name);
        }

        public void ParentMethod()
        {
            Console.WriteLine("{0} from Parent 메서드", Name);
        }
    }

    // 상속받을 자식 클래스 -> 상속받을 클래스를 콜론(:)과 함께 적어줘야 함
    class Child : Parent
    {
        public Child(string Name) : base(Name) 
        // 부모 클래스에 있는 부모 생성자 먼저 실행 -> 그 후 자신 생성자 실행함
        {
            Console.WriteLine("{0} from Child 생성자", Name);
        }

        public void ChildMethod()
        {
            Console.WriteLine("{0} from Child 메서드", Name);
        }
    }

    // 클래스간 형변환 (DB처리, DI(Dependendy Injection))
    class Mammal // 포유류 클래스
    {
        public void Nurse() // 젖을 먹이다
        {
            Console.WriteLine("포유류 기르다");
        }
    }

    class Dogs : Mammal
    {
        public void Bark()
        {
            Console.WriteLine("멍멍!");
        }
    }

    class Cats : Mammal
    {
        public void Meow()
        {
            Console.WriteLine("야옹!");
        }
    }

    class Elephant : Mammal
    {
        public void Poo()
        {
            Console.WriteLine("뿌우우~");
        }
    }

    class ZooKeeper
    {
        public void Wash(Mammal mammal)
        {
            if (mammal is Elephant)
            {
                var animal = mammal as Elephant;
                Console.WriteLine("코끼리를 씻깁니다.");
                animal.Poo();
            }
            else if (mammal is Dogs)
            {
                var animal = mammal as Dogs;
                Console.WriteLine("강아지를 씻깁니다.");
                animal.Bark();
            }
            else if (mammal is Cats)
            {
                var animal = mammal as Cats;
                Console.WriteLine("고양이를 씻깁니다.");
                animal.Meow();
                animal.Meow();
                animal.Meow();
                animal.Meow();
                animal.Meow();
            }
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            #region <기본 상속 개념 >
            Parent p = new Parent("p");
            p.ParentMethod();

            Console.WriteLine("자식 클래스 생성");
            Child c = new Child("c");
            /*
            c from Parent 생성자
            c from Child 생성자

           위의 결과가 나옴
            => public Child(string Name) : base(Name)
            => 부모 클래스에 있는 부모 생성자가 먼저 실행되고 자신 생성자가 실행되기 때문
           */

            c.ParentMethod();
            // child 는 parent를 상속받았기 때문에 (public인) ParentMethod 사용 가능
            // 상속 받을 수 있는 메소드는 public, protected인 경우에만 가능
            c.ChildMethod();
            #endregion

            #region < 클래스 간 형식 변환 >

            // Mammal mammal = new Mammal(); 기본 형식
            Mammal mammal = new Dogs();


            // Dogs dogs = new Mammal(); 안됨
            // 부모 클래스가 자식 클래스로 변환은 불가
            // Mammal 클래스가 가지고 있는 것을 Dog가 다 가지고 있지만
            // Dog가 가지고 있는 것이 Mammal이 가지고 있지 않기 때문

            // mammal.Bark();
            // 부모 클래스에는 Bark가 없기 때문에 바로 안됨
            // mammal.Bark()를 할 수 있게 하기 위한 방법
            if (mammal is Dogs)
            {
                //Dogs midDog = (Dogs)mammal; -> 구식 방법
                Dogs midDog = mammal as Dogs; // 
                midDog.Bark();
            }

            Dogs dog2 = new Dogs();
            Cats cat2 = new Cats();
            Elephant elephant2 = new Elephant();

            ZooKeeper keeper = new ZooKeeper();
            keeper.Wash(dog2);
            keeper.Wash(cat2);
            keeper.Wash(elephant2);



            #endregion
        }
    }
}
