using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wf04_filecopy
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void BtnFindSource_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            var result = dialog.ShowDialog(); // 모달창
            if (result == DialogResult.OK)
            {
                TxtSource.Text = dialog.FileName;
            }
        }

        private void BtnFindTarget_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                TxtTarget.Text = dialog.FileName;
            }
        }

        // 일반적인 동기식 파일 복사
        private void BtnSyncCopy_Click(object sender, EventArgs e)
        {
            long totalCopied = CopySync(TxtSource.Text, TxtTarget.Text);
        }

        private long CopySync(string fromFile, string toFile)
        {
            BtnAsyncCopy.Enabled = false; // 비동기 버튼 비활성화
            long totalCopied = 0;

            using (FileStream fromStream = new FileStream(fromFile, FileMode.Open))
            {  // 원본 파일 열기
                using (FileStream toStream = new FileStream(toFile, FileMode.Create))
                {  // 복사할 타겟파일 생성
                    byte[] buffer = new byte[1024 * 1024]; // 1MB 버퍼 생성
                    int nRead = 0;
                    while ((nRead = fromStream.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        toStream.Write(buffer, 0, nRead); // 버퍼를 0부터 읽은 갯수까지 toStream에 넣기
                        totalCopied += nRead;

                        // 프로그래스바에 진행상황 표시
                        PgbCopy.Value = (int)((double)totalCopied / (double)fromStream.Length) * PgbCopy.Maximum;
                    }
                }
            }

            BtnAsyncCopy.Enabled = true;
            return totalCopied;
        }

        // 비동기는 호출할 때는 awake 키워드 사용, 구현할 때는 async 사용
        private async Task<long> CopyASync(string fromFile, string toFile)
        {
            BtnSyncCopy.Enabled = false; // 동기복사 버튼 비활성화
            long totalCopied = 0;

            using (FileStream fromStream = new FileStream(fromFile, FileMode.Open))
            {  // 원본 파일 열기
                using (FileStream toStream = new FileStream(toFile, FileMode.Create))
                {  // 복사할 타겟파일 생성
                    byte[] buffer = new byte[1024 * 1024]; // 1MB 버퍼 생성
                    int nRead = 0;
                    while ((nRead = await fromStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
                        // 동기, 비동기 다른점 -> await와 Read뒤에 Async/ Write뒤에 Async가 필요함
                    {
                        await toStream.WriteAsync(buffer, 0, nRead); 
                        // 버퍼를 0부터 읽은 갯수까지 toStream에 넣기
                        totalCopied += nRead;

                        // 프로그래스바에 진행상황 표시
                        PgbCopy.Value = (int)((double)totalCopied / (double)fromStream.Length) * PgbCopy.Maximum;
                    }
                }
            }

            BtnSyncCopy.Enabled = true;
            return totalCopied;
        }

        private async void BtnAsyncCopy_Click(object sender, EventArgs e)
        {
            long totalCopied = await CopyASync(TxtSource.Text, TxtTarget.Text);
        }
        // async와 await는 세트임,,

        
    }
}
