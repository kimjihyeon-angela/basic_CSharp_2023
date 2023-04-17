using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wf13_bookrentalshop
{
    public partial class FrmGenre : Form
    {
        bool isNew = false;  // false(UPDATE) / true(INSERT)

        #region < 생성자 >

        #endregion

        public FrmGenre()
        {
            InitializeComponent();
        }

        #region < 이벤트 핸들러 >

        private void FrmGenre_Load(object sender, EventArgs e)
        {
            isNew = true;  // 신규부터 시작
            RefreshData();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            ClaerInputs();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (CheckValidation() != true) return;

            SaveData();  // 데이터 저장 / 수정
            RefreshData();  // 데이터 재조회
            ClaerInputs();  // 입력창 클리어
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            if (isNew == true)  // 신규
            {
                MessageBox.Show("삭제할 데이터를 선택하세요", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 삭제여부를 물을 때 아니오를 누르면 삭제 진행 취소
            if (MessageBox.Show(this, "삭제하시겠습니까?", "삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            // Yes를 누르면 계속 진행  // SaveData()에 있는 로직 복사->수정
            DeleteData();  // 데이터 저장

        }

        // 그리드뷰 클릭하면 발생 이벤트
        private void DgvResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)  // 아무것도 선택안하면 -1
            {
                var selData = DgvResult.Rows[e.RowIndex];
                //Debug.WriteLine(selData.ToString());
                Debug.WriteLine(selData.Cells[0].Value);
                Debug.WriteLine(selData.Cells[1].Value);
                TxtDivision.Text = selData.Cells[0].Value.ToString();  // Tostring 숫자를 문자열로 바꿀 때
                TxtNames.Text = selData.Cells[1].Value.ToString();
                TxtDivision.ReadOnly = true;  // PK는 수정하면 안됨

                isNew = false;  // 수정

            }
        }

        #endregion


        #region < 커스텀 메서드 >

        private void RefreshData()
        {
            // DB divtbl 데이터 조회 DgvResult에 뿌림
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Helpers.Commons.ConnString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    // 쿼리 작성
                    var selQuery = @"SELECT Division
	                                      , Names
                                       FROM divtbl";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(selQuery, conn);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "divtbl");  // divtbl으로 DataSet 접근가능

                    //DgvResult.DataSource = ds.Tables[0];  // 밑에 두줄 대신 이거 한줄로 가능
                    DgvResult.DataSource = ds;
                    DgvResult.DataMember = "divtbl";

                    DgvResult.Columns[0].HeaderText = "장르코드";
                    DgvResult.Columns[1].HeaderText = "장르명";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"비정상적 오류 {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClaerInputs()
        {
            TxtDivision.Text = TxtNames.Text = string.Empty;
            TxtDivision.ReadOnly = false;  // 신규일 때는 입력 가능

            TxtDivision.Focus();
            isNew = true;  // 신규
        }

        // 입력검증
        private bool CheckValidation()
        {
            var result = true;
            var errorMsg = string.Empty;

            if (string.IsNullOrEmpty(TxtDivision.Text))
            {
                result = false;
                errorMsg += "● 장르명을 입력하세요.\r\n";
            }

            if (string.IsNullOrEmpty(TxtNames.Text))
            {
                result = false;
                errorMsg += "● 장르명을 입력하세요.\r\n";
            }

            if (result == false)
            {
                // 입력 검증 (Validation check)
                MessageBox.Show(errorMsg, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return result;
            }
            else
            {
                return result;
            }
        }

        private void DeleteData()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Helpers.Commons.ConnString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    var query = @"DELETE FROM divtbl
                                        WHERE Division = ＠Division";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlParameter prmDivision = new MySqlParameter("@Division", TxtDivision.Text);
                    cmd.Parameters.Add(prmDivision);

                    var result = cmd.ExecuteNonQuery();  // INSERT, UPDATE, DELETE

                    if (result != 0)
                    {
                        // 저장 성공
                        MessageBox.Show("삭제 성공!!", "삭제", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // 저장 실패
                        MessageBox.Show("삭제 실패!!", "삭제", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"비정상적 오류 {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // isNew = true INSERT / false UPDATE
        private void SaveData()
        {
            // INSERT부터 시작
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Helpers.Commons.ConnString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    var query = @"";

                    if (isNew)
                    {
                        query = @"INSERT INTO divtbl
                                       VALUES (@Division, @Names)";
                    }
                    else
                    {
                        query = @"UPDATE divtbl
                                     SET Names = ＠Names
                                   WHERE Division = ＠Division";
                    }


                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlParameter prmDivision = new MySqlParameter("@Division", TxtDivision.Text);
                    MySqlParameter prmNames = new MySqlParameter("@Names", TxtNames.Text);
                    cmd.Parameters.Add(prmDivision);
                    cmd.Parameters.Add(prmNames);

                    var result = cmd.ExecuteNonQuery();  // INSERT, UPDATE, DELETE

                    if (result != 0)
                    {
                        // 저장 성공
                        MessageBox.Show("저장 성공!!", "저장", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        // 저장 실패
                        MessageBox.Show("저장 실패!!", "저장", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"비정상적 오류 {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
