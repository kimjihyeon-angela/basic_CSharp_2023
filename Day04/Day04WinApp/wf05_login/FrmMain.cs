using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wf05_login
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (TxtId.Text == "abcd" && TxtPassword.Text == "1234")
            {
                LblResult.Visible = true;
                LblResult.Text = "로그인 성공";
                MessageBox.Show("로그인 성공!", "로그인", MessageBoxButtons.OK ,icon: MessageBoxIcon.Exclamation);
            }
            else
            {
                LblResult.Visible = true;
                LblResult.Text = "로그인 실패";
                MessageBox.Show("로그인 실패!", "로그인", MessageBoxButtons.OK, icon:MessageBoxIcon.Error);
            }
        }

        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                BtnLogin_Click(sender, e);
            }
        }
    }
}
