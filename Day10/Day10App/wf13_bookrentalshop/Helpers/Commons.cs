using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wf13_bookrentalshop.Helpers
{
    internal class Commons
    {
        // 모든 프로그램상에서 다 사용가능
        public static readonly string ConnString = "Server=localhost;" + 
                                                   "Port=3306;" +
                                                   "Database=bookrentalshop;" + 
                                                   "Uid=root;" +
                                                   "Pwd=12345";

        // 로그인 사용자 아이디 저장 변수
        // 프로그램전체에서 이 데이터를 공유
        public static string LoginId = string.Empty;
    }
}
