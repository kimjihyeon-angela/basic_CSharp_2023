using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wf07_myexplorer
{
    public partial class FrmExplorer : Form
    {
        public FrmExplorer()
        {
            InitializeComponent();
        }

        private void FrmExplorer_Load(object sender, EventArgs e)
        {
            // 현재 사용자 출력
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            LblPath.Text = identity.Name;

            // 현재 컴퓨터에 존재하는 드라이브 정보 검색, 트리뷰에 입력
            DriveInfo[] drives = DriveInfo.GetDrives();

            // 트리뷰에 전부 추가
            foreach (DriveInfo drive in drives)
            {
                // 실제 존재하는 하드드라이브만 가져오는 방법
                if (drive.DriveType == DriveType.Fixed)
                {
                    TreeNode rootNode = new TreeNode(drive.Name);
                    rootNode.ImageIndex = 0;
                    rootNode.SelectedImageIndex = 0;
                    TrvDrive.Nodes.Add(rootNode);
                    FillNodes(rootNode);
                }
            }

            TrvDrive.Nodes[0].Expand();

            // 리스트뷰 설정
            LsvFolder.View = View.Details;

            LsvFolder.Columns.Add("이름", (LsvFolder.Width / 2), HorizontalAlignment.Left);
            LsvFolder.Columns.Add("날짜", (LsvFolder.Width / 4), HorizontalAlignment.Left);
            LsvFolder.Columns.Add("유형", (LsvFolder.Width / 5), HorizontalAlignment.Left);
            LsvFolder.Columns.Add("크기", (LsvFolder.Width / 5), HorizontalAlignment.Right);

            LsvFolder.FullRowSelect = true; // 한 행을 전부 선택
        }
        /// <summary>
        /// 하위 폴더 채워주기 함수
        /// </summary>
        /// <param name="curNode"></param>
        private void FillNodes(TreeNode curNode)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(curNode.FullPath);
                // 드라이브 하위 폴더
                foreach (DirectoryInfo  item in dir.GetDirectories())
                {
                    TreeNode newNode = new TreeNode(item.Name);
                    newNode.ImageIndex = 1;
                    newNode.SelectedImageIndex = 2;
                    curNode.Nodes.Add(newNode);
                    newNode.Nodes.Add("*");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("트리뷰 오류발생!", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        /// <summary>
        /// 트리뷰 노드 확장하기 전 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        // sender : 자기자신에 대한 객체 내용이 들어있음
        // e : event(beforeexpand)와 관련된 속성들이 들어있음
        private void TrvDrive_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes[0].Text == "*")
            {
                e.Node.Nodes.Clear();
                e.Node.ImageIndex = 1; // folder-normal
                e.Node.SelectedImageIndex= 2; // folder-open
                FillNodes(e.Node); // 하위 폴더 만들어줌
            }
        }

        /// <summary>
        /// 트리뷰 접기 직전 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrvDrive_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            e.Node.ImageIndex = 1;
            e.Node.SelectedImageIndex = 1;
        }

        /// <summary>
        /// 트리노드를 마우스로 클릭했을 때 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrvDrive_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            SetLsvFolder(e.Node.FullPath);
        }

        private void SetLsvFolder(string fullPath)
        {
            try
            {
                LsvFolder.Items.Clear(); // 기존 리스트 삭제
                DirectoryInfo dir = new DirectoryInfo(fullPath);
                int dirCount = 0;

                foreach (DirectoryInfo item in  dir.GetDirectories()) 
                { 
                    ListViewItem lvi = new ListViewItem();

                    lvi.ImageIndex = 1;
                    lvi.Text = item.Name; // 0번 인덱스 -> 이름

                    LsvFolder.Items.Add(lvi);
                    LsvFolder.Items[dirCount].SubItems.Add(item.CreationTime.ToString());
                    LsvFolder.Items[dirCount].SubItems.Add("폴더");
                    LsvFolder.Items[dirCount].SubItems.Add
                        (string.Format("{0} files",item.GetFiles().Length.ToString()) );

                    dirCount++;
                } // 폴더 내 디렉토리 리스트뷰에 리스트업

                // 디렉토리에 있는 파일목록 리스트업
                FileInfo[] files = dir.GetFiles();
                int fileCount = dirCount; // 이전 카운트 승계돼야 유형, 사이즈가 나옴

                foreach( FileInfo file in files )
                {
                    LsvFolder.Items.Add(file.Name);
                    if (file.LastWriteTime != null)
                    {
                        LsvFolder.Items[fileCount].SubItems.Add (file.LastWriteTime.ToString());
                    }
                    else
                    {
                        LsvFolder.Items[fileCount].SubItems.Add(file.CreationTime.ToString());
                    }
                    LsvFolder.Items[fileCount].SubItems.Add(file.Attributes.ToString());
                    LsvFolder.Items[fileCount].SubItems.Add(file.Length.ToString());

                    fileCount++;
                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("리스트뷰 오류발생!", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
