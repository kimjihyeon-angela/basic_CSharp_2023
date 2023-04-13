using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs29_filehandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 특정 경로에 하위 폴더, 하위 파일 조회하기

            // Directory == Folder
            //string curDirectory = "."; 
            // 현재 디렉토리 (상대경로) -> debug 폴더에는 파일들밖에 없기 때문에 폴더는 나오지 않음
            //string curDirectory = ".."; // 부모 디렉토리 (상대경로)
            string curDirectory = "C:\\Temp"; // 절대 경로 지정
            // 역슬래스 쓸경우 두개를 동시에 써줘야 인식할 수 있음
            // string curDirectory = @"C:\Dev"; // 경로 지정
            // 역슬래스 한개만 쓸 경우 앞에 @ 사용하면 인식 됨



            Console.WriteLine("현재 디렉토리 정보");

            var dirs = Directory.GetDirectories(curDirectory); // string의 배열을 받음
            foreach (var dir in dirs)
            {
                var dirInfo = new DirectoryInfo(dir);

                Console.Write("- {0}", dirInfo.Name);
                Console.WriteLine(" [{0}]",dirInfo.Attributes);
            }
            Console.WriteLine();
            Console.WriteLine("현재 디렉토리 파일 정보");
            var files = Directory.GetFiles(curDirectory);
            foreach(var file in files)
            {
                var fileInfo = new FileInfo(file); 
                Console.Write("- {0}", fileInfo.Name);
                Console.WriteLine(" [{0}]", fileInfo.Attributes);
            }

            // 특정 경로에 하위 폴도, 하위 파일 생성

            string path = @"C:\Temp\Csharp_Bank";
            // string path = @"C:/Temp/Csharp_Bank"; 
            // 역슬래시 대신 슬래시 사용해도 가능 but 역슬래시가 기본
            string sfile = "Test2.log";

            if (Directory.Exists(path)) // path의 디렉토리가 있으면 test2.log 생성
            {
                Console.WriteLine("경로가 존재하여 파일을 바로 생성합니다.");
                File.Create(path + @"\" + sfile);
                //File.Create(path); 
                // 폴더안에 파일 생성하기 위해서는 C:\Temp\Csharp_Bank\Test.log를 적어야함
                // path - > \Test.log가 없음
                // => 뒤에 더 적어줘야함
            }
            else
            {
                Console.WriteLine($"해당 경로가 없습니다. {path}, 만듭니다.");
                //Console.WriteLine("해당 경로가 없습니다. {0}", path);
                // string format 활용하는 법
                // 파이썬에서 f"해당 경로가 없습니다. {path}"한 것과 같은 방법
                Directory.CreateDirectory(path);

                Console.WriteLine("경로를 생성하여 파일을 생성합니다.");
                File.Create(path + @"\" + sfile);
            }

        }
    }
}
