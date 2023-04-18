using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace number_2_app
{
    class Car
    {
        string name;
        string maker;
        string color;
        int yearmodel;
        int maxspeed;
        string uniquenumber;
        

        public string Name 
        { 
            get { return name; }
            set { name = value; } 
        } 
        public string Maker { get; set; }

        public string Color { get; set; }

        public int YearModel
        {
            get { return yearmodel; } 
            set
            {
                if (value <= 1990 || value >= 2023)
                {
                    yearmodel = 2023;
                }
                else
                {
                    yearmodel = value;
                }
            }
        }
        
        public int Maxspeed 
        {
            get { return maxspeed; }
            set { maxspeed = value; }
        }
        public string UniqueNumber { get; set; }

        public void Start()
        {
            Console.WriteLine($"{name}의 시동을 겁니다.");
        }
        public void Accelerate()
        {
            Console.WriteLine($"최대시속 {maxspeed}로 가속합니다.");
        }
        public void Recharge()
        {
            Console.WriteLine("배터리를 충전합니다.");
        }
        public void TurnRight()
        {
            Console.WriteLine($"{name}을 우회전합니다.");
        }
        public void Brake()
        {
            Console.WriteLine($"{name}의 브레이크를 밟습니다.");
        }
    }


    class ElectricCar : Car
    {
       
        public void Recharge()
        {
            Console.WriteLine("전기로 배터리를 충전합니다.");
        }


    }

    class HybridCar : ElectricCar
    {
        public void Recharge()
        {
            Console.WriteLine("달리면서 배터리를 충전합니다.");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            HybridCar ioniq = new HybridCar();
            ioniq.Name = "아이오닉";
            ioniq.Maker = "현대자동차";
            ioniq.Color = "White";
            ioniq.YearModel = 2018;
            ioniq.Maxspeed = 220;
            ioniq.UniqueNumber = "54라 3346";

            ioniq.Start();
            ioniq.Accelerate();
            ioniq.Recharge();
            ioniq.TurnRight();
            ioniq.Brake();
        }
    }
}
