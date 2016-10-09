using System;
using System.Windows.Forms;

/// <summary>
/// Code By muyunyan
/// 2016/10/9 Git Ver 1.0
/// </summary>
namespace _1KeyMoePic
{
    /// <summary>
    /// 窗口类
    /// </summary>
    public partial class Form1 : Form
    {
        private string picurl = "";
        private string picDir = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\萌图壁纸";
        private bool isSaved = false; //标识是否保存
        private string jpgFilePath = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Utils.createPicDic(picDir);
            loadImgToPic();
        }

        /// <summary>
        /// 这是一个载入图片到控件的方法
        /// 应该只需要微博图片一个选项
        /// </summary>
        private void loadImgToPic()
        {
            string jsonres = Utils.loadImgJson();
            string picid = Utils.loadJsonPicid(jsonres);
            picurl = Utils.createWeiboImgUrl(picid);
            pbx_main.ImageLocation = picurl;
            return;
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            btn_refresh.Enabled = false;
            loadImgToPic();
            btn_refresh.Enabled = true;
            isSaved = false;
        }

        private void btn_toWallpaper_Click(object sender, EventArgs e)
        {
            if (!isSaved)
            {
                jpgFilePath = picDir + "\\JPG\\MoePic" + Utils.random6nums() + ".jpg";
                //下载文件到本地
                Utils.SaveFileFromUrl(jpgFilePath, picurl);
            }
            //设置壁纸
            Utils.SetDestPicture(picDir, jpgFilePath);
            MessageBox.Show("设置完成！");
            isSaved = true;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (!isSaved)
            {
                jpgFilePath = picDir + "\\JPG\\MoePic" + Utils.random6nums() + ".jpg";
                Utils.SaveFileFromUrl(jpgFilePath, picurl);
                MessageBox.Show("保存完成！");
                isSaved = true;
            } else
            {
                MessageBox.Show("你已经保存过啦！");
            }
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/e," + picDir + "\\JPG";
            System.Diagnostics.Process.Start(psi);
        }

        private void pbx_main_Click(object sender, EventArgs e)
        {
            if (!isSaved)
            {
                jpgFilePath = picDir + "\\JPG\\MoePic" + Utils.random6nums() + ".jpg";
                Utils.SaveFileFromUrl(jpgFilePath, picurl);
                isSaved = true;
            }
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = jpgFilePath;
            System.Diagnostics.Process.Start(psi);
        }
    }
}
