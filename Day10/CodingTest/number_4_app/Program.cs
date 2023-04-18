using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace number_5_app
{
    class Animal
    {
        string name;
        int age;

        public int Age { get; set; }

        public string Name { get; set; }

    }

    interface IAnimal
    {
        void Eat();
        void Sleep();
        void Sound();
    }


    class Dog : Animal, IAnimal
    {
        public void Eat()
        {
            Console.WriteLine($"{Name}은(는) 사료를 먹습니다.");
        }
        public void Sleep()
        {
            Console.WriteLine($"{Name}은(는) 잠을 잡니다.");
        }
        public void Sound()
        {
            Console.WriteLine("멍멍");
        }
    }

    class Cat : Animal, IAnimal
    {
        public void Eat()
        {
            Console.WriteLine($"{Name}은(는) 사료를 먹습니다.");
        }
        public void Sleep()
        {
            Console.WriteLine($"{Name}은(는) 잠을 잡니다.");
        }
        public void Sound()
        {
            Console.WriteLine("야옹");
        }
    }
    class Horse : Animal, IAnimal
    {
        public void Eat()
        {
            Console.WriteLine($"{Name}은(는) 건초를 먹습니다.");
        }
        public void Sleep()
        {
            Console.WriteLine($"{Name}은(는) 잠을 잡니다.");
        }
        public void Sound()
        {
            Console.WriteLine("히잉");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog { Name = "강아지", Age = 12 };
            dog.Eat();
            dog.Sleep();
            dog.Sound();

            Cat cat = new Cat { Name = "고양이", Age = 3 };
            cat.Eat();
            cat.Sleep();
            cat.Sound();

            Horse horse = new Horse { Name = "말", Age = 5 };
            horse.Eat();
            horse.Sleep();
            horse.Sound();
        }
    }
}