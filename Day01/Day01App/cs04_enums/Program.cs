using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs04_enums
{
    internal class Program
    {
        enum HomeTown
        {
            // CTRL + SHIFT + U -> 대문자 변환 , CTRL + U -> 소문자 변환
            SEOUL   = 1, 
            DAEJEON = 2,
            DAEGU   = 3,
            BUSAN   = 4,
            JEJU    = 5 // 1, 2까지만 적어놓고 뒤에는 번호 안적어도 알아서 번호 지정됨
        }
        static void Main(string[] args)
        {
            HomeTown myHomeTown;

            myHomeTown = HomeTown.BUSAN;
            if(myHomeTown == HomeTown.SEOUL) 
            {
                Console.WriteLine("서울 출신이시군요!");
            }
            else if (myHomeTown == HomeTown.DAEJEON)
            {
                Console.WriteLine("충청도예유~");
            }
            else if (myHomeTown == HomeTown.DAEGU)
            {
                Console.WriteLine("대구여~");
            }
            else if (myHomeTown == HomeTown.BUSAN)
            {
                Console.WriteLine("부산이라예~~");
            }
        }
    }
}
