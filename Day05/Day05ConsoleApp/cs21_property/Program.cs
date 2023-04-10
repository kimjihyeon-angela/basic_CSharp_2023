using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Schema;

namespace cs21_property
{
    class Boiler
    {
        private int temp; // 멤버변수

        public int Temp  // 프로퍼티(속성)
        {
            get { return temp; }
            set
            {
                if (value <= 10 || value >= 70)
                {
                    temp = 10; // 제일 낮은 온도로 변경 설정
                }
                else
                {
                    temp = value;
                }
            }
        }

        // 위의 get; set;과 비교
        // 아래의 Get 메서드와 Set 메서드는 Java에서만 사용 (C#에서는 거의 사용하지 않음)

        public void SetTemp(int temp)
        {
            if (temp <= 10 || temp >= 70)
            {
                Console.WriteLine("수온설정값이 너무 낮거나 높습니다. 10도에서 70도 사이로 지정해주세요.");
                // return;
                this.temp = 10;
            }
            this.temp = temp;
        }

        public int GetTemp()
        {
            return this.temp;
        }
    }

    class Car
    {
        //string name;
        // string color;
        int year;
        string fuelType;
        // int door;
        // string tireType;
        // string company;
        int price;
        // string carIdNumber;
        // string carPlateNumber;

        public string Name { get; set; } // 필터링이 필요 없을 경우 멤버변수 없이 프로퍼티로 대체 가능
        public string Color { get; set; }
        public int Year
        {
            get { return year; } // get => year; 람다식
            set
            {
                if (value <= 1990 || value >= 2023)
                {
                    year = 2023;
                }
                else
                {
                    year = value;
                }
            }
        }
        public string FuelType 
        { get => fuelType; 
          set
          { 
            if(value != "휘발유"|| value !="경유")
            {
                value = "휘발유";
            }
          }
        }
        public int Door { get; set; }
        public string TireType { get; set; }
        public string Company { get; set; } = "현대자동차";
        public int Price { get => price; set => price = value; }
        public string CarIdNumber { get; set; }
        public string CarPlateNumber { get; set; }
    }

    interface IProduct
    {
        string ProductName { get; set; }

        void Produce();
    }

    class MyProduct : IProduct
    {
        private string productName;
        public string ProductName 
        { get { return productName; }
          set { productName = value; }
        }

        public void Produce()
        {
            Console.WriteLine("{0}을(를) 생산합니다.", ProductName);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Boiler kitturami = new Boiler();
            /*
            kitturami.temp = 60;
            kitturami.temp = 300000; // 보일러 물 수온이 30만도?
            kitturami.temp = -120;
            kitturami.temp에 값 직접 넣기 불가능해짐
            temp가 private이기 때문
            */
            kitturami.SetTemp(50);
            Console.WriteLine(kitturami.GetTemp()); // 구식방법

            Boiler navien = new Boiler();
            navien.Temp = 5000;
            Console.WriteLine(navien.Temp);

            Car ionic = new Car();
            ionic.Name = "아이오닉"; 
            // Car.Name{get;set;}에서 set;을 지우면 데이터를 출력만 할 수 있게 만드는 것임
            // set;을 지울 경우 초기화할때 이름을 입력해 줘야함
            // Car.Name{get; set;}에서 get;을 지울 경우 error 발생

            Console.WriteLine(ionic.Name);

            // 생성할 때 프로퍼티로 초기화
            Car genesis = new Car() {
                // 스패너 모양의 아이콘 -> 프로퍼티를 의미함
                Name = "제네시스",
                FuelType = "휘발유",
                Color = "흰색",
                Door = 4,
                TireType = "광폭",
                Year = 0,
            };

            Console.WriteLine("자동차 제조회사는 {0}", genesis.Company);
            Console.WriteLine("자동차 제조년도는 {0}년", genesis.Year);
        }
    }
}
