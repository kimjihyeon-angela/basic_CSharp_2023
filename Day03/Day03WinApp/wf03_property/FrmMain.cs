using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wf03_property
{
    public partial class FrmMain : Form
    {
        Random rnd = new Random();

        public FrmMain()
        {
            InitializeComponent();
            // 생성자에는 되도록 설정 부분 넣지 x
            // form_Load() 이벤트 핸들러에 작성할 것
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            GbxMain.Text = "컨트롤 학습";
            var fonts = FontFamily.Families.ToList(); // 내 os에 있는 폰트정보(이름) 가져오기
            foreach (var font in fonts)
            {
                CboFontFamily.Items.Add(font.Name);
            }
            // 글자 크기 최소값, 최대값  지정
            NudFontSize.Minimum = 5;
            NudFontSize.Maximum = 40;

            //텍스트박스 초기화
            TxtResult.Text = "Hello, WinForms!";
        }
        /// <summary>
        /// 글자 스타일, 크기, 글자체를 변경해 주는 메서드
        /// </summary>
        private void ChangeFontStyle()
        {
            if (CboFontFamily.SelectedIndex < 0)
            {
                CboFontFamily.SelectedIndex = 257; // 디폴트는 나눔고딕으로 지정
            }

            FontStyle style = FontStyle.Regular;
            if (ChkBold.Checked == true)
            {
                style |= FontStyle.Bold;
            }
            if (ChkItalic.Checked == true) 
            {
                style |= FontStyle.Italic;
            }

            decimal fontSize = NudFontSize.Value;

            TxtResult.Font = new Font((string)CboFontFamily.SelectedItem, (float)fontSize, style);
            //NudFontSize.Value = 9; // 글자체 첫 크기를 9로 고정
            
        }

        void ChangeIndent()
        {
            if (RdoNormal.Checked)
            {
                TxtResult.Text = TxtResult.Text.Trim();

            }
            else if (RdoIndent.Checked)
            {
                TxtResult.Text = "    " + TxtResult.Text;
            }
        }

        private void CboFontFamily_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeFontStyle();
        }

        private void ChkBold_CheckedChanged(object sender, EventArgs e)
        {
            ChangeFontStyle();

        }

        private void ChkItalic_CheckedChanged(object sender, EventArgs e)
        {
            ChangeFontStyle();

        }

        private void NudFontSize_ValueChanged(object sender, EventArgs e)
        {
            ChangeFontStyle();

        }

        private void TrbDummy_Scroll(object sender, EventArgs e)
        {
            PgbDummy.Value = TrbDummy.Value;
        }

        private void BtnModal_Click(object sender, EventArgs e)
        {
            Form frm = new Form() {
                Text = "Modal Form",
                Width = 300,
                Height = 200,
                Left = 10,
                Top = 20,
                BackColor = Color.Crimson, // 마지막 쉼표는 없어도 됨
                StartPosition = FormStartPosition.CenterParent, // parent 폼의 중앙에 화면 넣기
            };
            
            frm.ShowDialog(); // 모달 방식으로 자식창 띄우기

        }

        private void BtnModaless_Click(object sender, EventArgs e)
        {
            Form frm = new Form()
            {
                Text = "Modaless Form",
                Width = 300,
                Height = 200,
                StartPosition = FormStartPosition.CenterScreen, // 스크린 중앙에 화면 넣기
                BackColor = Color.GreenYellow,
            };
            frm.Show();
        }

        private void BtnMsgBox_Click(object sender, EventArgs e)
        {
            // MessageBox.Show(TxtResult.Text);// 기본적으로 Message Box -> Modal
            // MessageBox.Show(TxtResult.Text, caption: "메시지창"); // 캡션사용
            // MessageBox.Show(TxtResult.Text, "메시지창", MessageBoxButtons.YesNoCancel); // 버튼 추가
            // MessageBox.Show(TxtResult.Text, "메시지창", 
            //                MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Information);// 아이콘 추가
            //MessageBox.Show(TxtResult.Text, "메시지창", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
            //                MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign); // 오른쪽 정렬
            MessageBox.Show(TxtResult.Text, "메시지창", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, 
                            MessageBoxDefaultButton.Button2); // DefaultButton이 없을 경우 Yes가 기준 -> No로 기준을 바꿈

        }

        private void BtnAddRoot_Click(object sender, EventArgs e)
        {
            TrvDummy.Nodes.Add(rnd.Next(50).ToString());
            TreeToList();
        }

        private void BtnAddChild_Click(object sender, EventArgs e)
        {
            if (TrvDummy.SelectedNode != null)
            {
                TrvDummy.SelectedNode.Nodes.Add(rnd.Next(50, 100).ToString());
                TrvDummy.SelectedNode.Expand(); // 트리 노드 하위 것 펼쳐주는 것
                // TrvDummy.SelectedNode.Collapse(); // expand의 반대
                TreeToList();
            }
        }

        void TreeToList()
        {
            LsvDummy.Items.Clear();
            foreach (TreeNode item in TrvDummy.Nodes)
            {
                TreeToList(item);
            }
        }

        private void TreeToList(TreeNode item)
        {
            LsvDummy.Items.Add(new ListViewItem(new[] { item.Text, item.FullPath.ToString()}));

            foreach (TreeNode node in item.Nodes)
            {
                TreeToList(node);// 재귀호출
            }
        }

        private void RdoNormal_CheckedChanged(object sender, EventArgs e)
        {
            ChangeIndent();
        }

        private void RdoIndent_CheckedChanged(object sender, EventArgs e)
        {
            ChangeIndent();
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            PcbDummy.Image = Bitmap.FromFile("cat.png");
        }

        private void PcbDummy_Click(object sender, EventArgs e)
        {
            if (PcbDummy.SizeMode == PictureBoxSizeMode.Normal)
            {
                PcbDummy.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                PcbDummy.SizeMode = PictureBoxSizeMode.Normal;
            }
        }
    }
}
