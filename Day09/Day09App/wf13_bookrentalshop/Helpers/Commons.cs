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
    }
}
