using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs30_filereadwrite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string line = string.Empty; // 텍스트를 읽어와서 출력

            StreamReader reader = null; // 스트림리더에 파일 연결
            try
            {
                reader = new StreamReader(@".\python.py"); // 스트림리더에 파일 연결

                // StreamReader -> 글을 읽어올 때 사용
                // StreamWriter -> 글을 쓸 때 사용

                line = reader.ReadLine();

                while (line != null)
                {
                    Console.WriteLine(line); // 한줄 읽은 내용 출력한 것
                    line = reader.ReadLine(); // 다음 줄 읽기
                }
            }
            catch (Exception e)
            {

                Console.WriteLine($"예외 발생 {e}");
            }
            finally
            {
                reader.Close();
                // 파일을 읽으면 마지막은 무조건 close()가 필요
            }

            StreamWriter writer = new StreamWriter(@".\pythonsByCshap.py");
            try
            {
                writer.WriteLine("import sys");
                writer.WriteLine("");
                writer.WriteLine("print(sys.executable)");
            }
            catch (Exception e)
            {
                Console.WriteLine($"예외 발생 {e}");
            }
            finally
            {
                writer.Close();
            }
            Console.WriteLine("파일 생성 완료!");
        }
    }
}
