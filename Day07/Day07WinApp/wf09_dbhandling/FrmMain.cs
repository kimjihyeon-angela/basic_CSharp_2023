using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient; // SQL Server용 DB연결 클라이언트 네임스페이스
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wf09_dbhandling
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // 1. 연결문자열 생성
            // 서버탐색기에서 연결 문자열 가져다 쓰기
            // password 별표 확인하고 바꿔주기
            string connectionString = "Data Source=localhost;Initial Catalog=Northwind;Persist Security Info=True;User ID=sa;Password=12345;";
            
            // 2. DB 연결위해 Connection 객체 생성
            // 연결 문자열 없이 객체 생성 불가능
            SqlConnection conn = new SqlConnection(connectionString);
            //conn.ConnectionString = connectionString;
            // 두가지 방법이 있지만 첫번째 방법을 더 많이 사용함

            // 3. 객체를 통해서 DB 연결
            conn.Open();

            // 4. DB 처리를 위한 쿼리 작성
            string selQuery =  @"SELECT CustomerID
                                      , CompanyName
                                      , ContactName
                                      , ContactTitle
                                      , Address
                                      , City
                                      , Region
                                      , PostalCode
                                      , Country
                                      , Phone
                                      , Fax
                                   FROM Customers";
            SqlCommand selCmd = new SqlCommand(selQuery, conn);
            // selCmd.Connection = conn;
            // -> 위에 하는 일과 같지만 가능하면 위에 방법으로 사용하기

            // 5. sqlDataAdapter 생성
            SqlDataAdapter adapter = new SqlDataAdapter(selQuery, conn);


            // 5. 리더 객체 생성하고 값 넘겨줌
            // SqlDataReader reader = selCmd.ExecuteReader();

            // 6. 데이터리더에 있는 데이터를 데이터셋으로 보내기
            // DataSet ds = new DataSet();

            // 6. 데이터셋으로 전달
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            // 7. 데이터그리드뷰에 바인딩하기 위한 BindingSource 생성
            BindingSource source = new BindingSource();

            // 8. 데이터그리드뷰의 DataSource에 데이터셋을 할당
            source.DataSource = ds.Tables[0];
            DgvNorthwind.DataSource = source;

            // 9. DB Close
            conn.Close();
        }
    }
}
