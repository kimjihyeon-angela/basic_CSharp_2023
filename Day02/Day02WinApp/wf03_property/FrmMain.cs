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
            if (CboFontFamily.SelectedIndex < 0) return;

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
            NudFontSize.Value = 9; // 글자체 첫 크기를 9로 고정
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
    }
}
