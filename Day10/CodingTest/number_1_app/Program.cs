using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace number_1_app
{
    class Boiler
    {
        private string brand; // 브랜드
        private int voltage; // 볼트
        private int temperature; // 멤버변수

        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }

        public int Voltage
        {
            get { return voltage; }
            set
            {
                if (value == 110 || value == 220)
                {
                    voltage = value;
                }
                else
                {
                    Console.WriteLine($"{brand} 볼트 설정을 110V 혹은 220V로 다시 해주세요");
                }
            }
        }

        public int Temperature  // 프로퍼티(속성)
        {
            get { return temperature; }
            set
            {
                if (value <= 5)
                {
                    Console.WriteLine($"{brand}온도가 너무 낮게 설정되어 5도로 제한합니다.");
                    temperature = 5; // 5도 이하인 경우 5도로 설정
                }
                else if (value >= 70)
                {
                    Console.WriteLine($"{brand}온도가 너무 높게 설정되어 70도로 제한합니다.");
                    temperature = 70; // 70도 이상인 경우 70도로 제한
                }
                else
                {
                    temperature = value;
                }
            }
        }

        public void PrintAll()
        {
            Console.WriteLine($"브랜드 : {brand} / 볼트 : {voltage} / 온도 : {temperature}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Boiler kitturami = new Boiler { Brand = "귀뚜라미", Voltage = 220, Temperature = 45 };
            kitturami.PrintAll();

            Boiler navien = new Boiler();
            navien.Brand = "나비엔";
            navien.Voltage = 150;
            navien.Temperature = 100;
            navien.PrintAll();
        }
    }
}
