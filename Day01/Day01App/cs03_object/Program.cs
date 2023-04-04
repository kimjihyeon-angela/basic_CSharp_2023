using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs03_object
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // object 형식
            // int == System.Int32
            // long == System.Int64
            long idata = 1024;
            Console.WriteLine(idata);

            Console.WriteLine(idata.GetType());

            object iobj = (object)idata; // 박싱 : 데이터타입의 값을 object로 담아라
            // object iobj = idata; 이렇게 해도 됨
            Console.WriteLine(iobj);
            Console.WriteLine(iobj.GetType());

            long udata = (long)iobj;    // 언박싱 : object를 원래 데이터타입으로 변경
            Console.WriteLine(udata);
            Console.WriteLine(udata.GetType());

            double ddata = 3.141593;
            object pobj = (object)ddata;
            double pdata = (double)pobj;
            Console.WriteLine(pobj);
            Console.WriteLine(pobj.GetType());
            Console.WriteLine(pdata);
            Console.WriteLine(pdata.GetType());

            short sdata = 32000;
            int indata = sdata;
            Console.WriteLine(indata);

            long lndata = long.MaxValue;
            Console.WriteLine(lndata); // 9223372036854775807
            indata = (int)lndata;
            Console.WriteLine(indata); // -1 출력됨 => overflow

            //float double 간 형변환
            float fval = 3.141592f; // float형은 마지막에 f써줘야함
            Console.WriteLine("fval = " + fval);
            double dval = (double)fval;
            Console.WriteLine("dval = " + dval);
            Console.WriteLine(fval == dval);
            Console.WriteLine(dval == 3.141592);

            // 실무에서 많이 사용하는 것 중 하나
            // 숫자->문자열
            int numival = 1024;
            string strival = numival.ToString();
            // Console.WriteLine(numival == strival);
            Console.WriteLine(strival);
            Console.WriteLine(strival.GetType());

            double numdval = 3.14159265358979;
            string strdval = numdval.ToString();
            Console.WriteLine(strdval);

            // 문자열 -> 숫자
            // 문자열에 숫자가 아닌 특수문자나 정수인데 .이 있는 경우를 조심해야함
            string originstr = "34567890"; // 소수점있는 경우 error 발생함
            int convval = Convert.ToInt32(originstr);
            //int convval = int.Parse(originstr);
            Console.WriteLine(convval);

            originstr = "1.2345";
            float convfloat = float.Parse(originstr);
            Console.WriteLine(convfloat);

            // 예외발생하지 않도록 형변환 방법
            originstr = "123.4";
            float ffval;
            // TryParse -> 예외가 발생하면 값은 0으로 대체, 예외 없으면 원래값으로 대체
            float.TryParse(originstr, out ffval); // 예외가 발생하지 않게 숫자 변환 -> 형변환할 수 없으면 0으로 출력
            Console.WriteLine(ffval);

            const double pi = 3.14159265358979;
            Console.WriteLine(pi);

            //pi = 4.56; -> 상수는 값 변경이 불가능함

        }
    }
}
