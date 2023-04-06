using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs13_class
{
    
    internal class Cat // private이어도 같은 cs13_class 안에 있기 때문에 접근 가능 + internal 있어도 되고 없어도 됨
    {
        #region
        /// <summary>
        /// 기본 생성자
        /// </summary>
        public Cat()
        {
            Name = string.Empty;
            Color = string.Empty;
            Age = 0;
        }

        /// <summary>
        /// 사용자 지정 생성자
        /// </summary>
        /// <param name="name"></param>
        /// <param name="color"></param>
        /// <param name="age"></param>
        public Cat(string name, string color = "흰색", sbyte age = 1)
        {
            Name = name;
            Color = color;
            Age = age;
        }



        #endregion
        #region < 멤버변수 - 속성 >
        public string Name;  // 고양이 이름
        public string Color; // 고양이 색
        public sbyte Age;    // 고양이 나이  sbyte : 0~255
        #endregion

        #region < 멤버 메서드 - 기능 >
        public void Meow() // private -> 기본 설정으로 생략 가능 /but, 밖에서 접근 불가능 => public설정해줘야함
        {
            Console.WriteLine("{0} - 야옹~!!", this.Name);
            // this.Name 이렇게 적어도 되지만 this 크게 필요하지 않음
        }

        public void Run()
        {
            Console.WriteLine("{0} 달린다.", Name);
        }
        #endregion
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Cat helloKitty = new Cat(); // helloKitty라는 이름의 객체 생성
            helloKitty.Name = "헬로키티";
            helloKitty.Color = "흰색";
            helloKitty.Age = 50;
            helloKitty.Meow();
            helloKitty.Run();

            // 객체 생성하면서 속성 초기화 {} 안에서 ctrl + space
            Cat nero = new Cat() 
            { 
                Name = "검은고양이 네로",
                Color = "검은색",
                Age = 27,
            };
            nero.Meow();
            nero.Run();

            Console.WriteLine("{0}의 색상은 {1}, 나이는 {2} 입니다.", 
                               helloKitty.Name, helloKitty.Color, helloKitty.Age);

            Console.WriteLine("{0}의 색상은 {1}, 나이는 {2} 입니다.",
                               nero.Name, nero.Color, nero.Age);

            Cat yaongi = new Cat();
            Console.WriteLine("{0}의 색상은 {1}, 나이는 {2} 입니다.",
                               yaongi.Name, yaongi.Color, yaongi.Age);
            // 결과 ->  의 색상은 , 나이는  입니다. 

            Cat norangi = new Cat("노랑이","노란색");
            Console.WriteLine("{0}의 색상은 {1}, 나이는 {2} 입니다.",
                               norangi.Name, norangi.Color, norangi.Age);
            // 결과 -> 노랑이의 색상은 노란색, 나이는 1입니다.

        }
    }
}
