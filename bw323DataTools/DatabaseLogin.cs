using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReaLTaiizor.Forms;
using bw323DataTools;
using System.Net;
using System.ServiceProcess;
using System.IO;
using RestSharp;
using System.IO.Compression;
using Midea.Mes.Update;

namespace bw323DataTools
{
    public partial class DatabaseLogin : Form
    {


        public static MainFrom DatabaseLogins = null;
        public static string _conString;
        int version = 202006;





        public DatabaseLogin()
        {
            InitializeComponent();
        }

        private void dungeonLabel1_Click(object sender, EventArgs e)
        {

        }

        private void foreverButton_logintest_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkDb() < 0)
                {
                    return;
                }
                else
                {
                    IList<string> _DataBaseList = new List<string>();

                    DBConfig.db.ServerName = dungeonComboBox_serveradd.Text.ToString();

                    if (dungeonComboBox_renzhengfs.Text == "Windows身份认证")
                    {
                        DBConfig.db.ValidataType = "Windows身份认证";
                    }
                    else
                    {
                        hopeTextBox_loginuser.Enabled = true;
                        hopeTextBox_passwd.Enabled = true;
                        DBConfig.db.ValidataType = "SQL Server身份认证";
                        DBConfig.db.UserName = hopeTextBox_loginuser.Text.ToString();
                        DBConfig.db.UserPwd = hopeTextBox_passwd.Text.ToString();

                    }

                    DBConfig.db.ProviderName = "SQL";
                    _conString = DBConfig.db.GetSQLmasterConstring();

                    DBConfig.db.DBProvider = new bw323DataTools.DBUtility.DbHelperSQL(_conString);
                    _DataBaseList = DBConfig.db.DBProvider.GetDataBaseInfo();
                    if (_DataBaseList.Count > 0)
                    {
                        dungeonComboBox_databaselistcbx.DataSource = _DataBaseList;
                        dungeonComboBox_databaselistcbx.Enabled = true;
                        dungeonComboBox_databaselistcbx.SelectedIndex = 0;
                    }

                }

            }
            catch (Exception)
            {

                MessageBox.Show("数据库登录失败!,请检查输入的账号信息！");
            }
        }

        private void foreverButton_logindatabase_Click(object sender, EventArgs e)
        {


            try
            {
                if (checkDb() < 0)
                {
                    return;
                }
                else
                {
                    IList<string> _DataBaseList = new List<string>();

                    DBConfig.db.ServerName = dungeonComboBox_serveradd.Text.ToString();



                    DBConfig.db.ProviderName = "SQL";
                    _conString = DBConfig.db.GetSQLmasterConstring();

                    DBConfig.db.DBProvider = new bw323DataTools.DBUtility.DbHelperSQL(_conString);
                    _DataBaseList = DBConfig.db.DBProvider.GetDataBaseInfo();
                    if (_DataBaseList.Count > 0)
                    {
                        DBConfig.db.ProviderName = "SQL";
                        DBConfig.db.DataBase = dungeonComboBox_databaselistcbx.Text.ToString();
                        _conString = DBConfig.db.GetConstring();
                        DBConfig.db.DBProvider = new bw323DataTools.DBUtility.DbHelperSQL(_conString);
                        //MessageBox.Show(_conString.ToString());
                        //MainfromShow();

                        _conString+="TrustServerCertificate=true";
                        
                        MainFrom frm = new MainFrom();
                        frm.Show();
                        this.Hide();

                       
                    }

                }

            }
            catch (Exception)
            {

                MessageBox.Show("数据库登录失败!,请检查输入的账号信息！");
            }

        }




        private int checkDb()
        {
            System.ServiceProcess.ServiceController sc = new System.ServiceProcess.ServiceController();
            sc.ServiceName = "MSSQLSERVER";
            if (sc == null)
            {
                MessageBox.Show("您的机器上没有安装SQL SERVER！", "提示信息");
                return -1;
            }
            else if (sc.Status != System.ServiceProcess.ServiceControllerStatus.Running)
            {
                MessageBox.Show("SQL数据库服务未启动，请点击开启SQL服务！", "提示信息");
                return -2;
            }

            return 0;

        }


        public void GetLocalServerIP()
        {
            dungeonComboBox_serveradd.Items.Clear();
            dungeonComboBox_serveradd.Items.Add("(local)");
            string strHostName = Dns.GetHostName();   //得到本机的主机名
            IPHostEntry ipEntry = Dns.GetHostEntry(strHostName); //取得本机IP

            for (int i = 0; i < ipEntry.AddressList.Count(); i++)
            {
                dungeonComboBox_serveradd.Items.Add(ipEntry.AddressList[i].ToString());
            }
        }

        private void hopeButton_startsql_Click(object sender, EventArgs e)
        {
            System.ServiceProcess.ServiceController sc = new System.ServiceProcess.ServiceController();
            sc.ServiceName = "MSSQLSERVER";
            if (sc == null)
            {
                MessageBox.Show("您的机器上没有安装SQL SERVER！", "提示信息");
                return;
            }
            else if (sc.Status != System.ServiceProcess.ServiceControllerStatus.Running)
            {
                sc.Start();
                MessageBox.Show("SQL数据库服务启动成功！", "提示信息");
            }
        }

        private void hopeButton_stopsql_Click(object sender, EventArgs e)
        {
            System.ServiceProcess.ServiceController sc = new System.ServiceProcess.ServiceController();
            sc.ServiceName = "MSSQLSERVER";
            if (!sc.Status.Equals(System.ServiceProcess.ServiceControllerStatus.Stopped))
            {
                sc.Stop();
                MessageBox.Show("SQL数据库服务已经关闭！", "提示信息");
            }
        }



        private void DataPieOnLoad()
        {
            GetLocalServerIP();
            dungeonComboBox_renzhengfs.SelectedIndex = 0;
            dungeonComboBox_serveradd.SelectedIndex = 0;
            hopeTextBox_loginuser.Enabled = true;
            hopeTextBox_passwd.Enabled = true;

        }

        static void updater_UpdatesFound(object sender, EventArgs e)
        {

        }

        static void updater_NoUpdatesFound(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("没有找到更新");
        }

        static void updater_Error(object sender, EventArgs e)
        {
            MessageBox.Show("更新发生错误！");
        }
        private void DatabaseLogin_Load(object sender, EventArgs e)
        {
            DataPieOnLoad();




            Updates();





        }

        private void Updates() {


            //检查系统更新
            var objUpdateManager = new UpdateManger();
            try
            {
                if (!objUpdateManager.IsUpdate)
                {
                  //MessageBox.Show("当前版本已经是最新的，不需要升级!!!", "提示信息");
                    return;
                }
                if (MessageBox.Show("为了更新系统,将退出当前程序,请确保数据已保存,确认退出吗?", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                   
                    System.Diagnostics.Process.Start("Midea.Mes.Update.exe");
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("无法连接服务器,请检查问题,原因" + ex.Message);
            }
        }

        private void unzip_rules()
        {

          //  Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            string Paths = PathTos.GetPath_rules();
            string zipFilePath = Paths;
            string extractionPath =PathTos.GetPath_rulesdir();
           ZipFile.ExtractToDirectory(zipFilePath, extractionPath, Encoding.GetEncoding("GBK"));
        }

        private void downruletsql()
        {

            string Paths = PathTos.GetPath_rules();
            var client = new RestClient("http://update.bw.wpgood.net/datas/bw323dts");
            var request = new RestRequest("rule.zip");
            byte[] response = client.DownloadData(request);
            File.WriteAllBytes(Paths, response);

        }

        private void dungeonComboBox_renzhengfs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dungeonComboBox_renzhengfs.Text.ToString() == "Windows身份认证")
            {
                hopeTextBox_loginuser.Enabled = false;
                hopeTextBox_passwd.Enabled = false;
            }
            else
            {
                hopeTextBox_loginuser.Enabled = true;
                hopeTextBox_passwd.Enabled = true;
            }
        }


        public static void DelectDir(string srcPath)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(srcPath);
                FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();  //返回目录中所有文件和子目录
                foreach (FileSystemInfo i in fileinfo)
                {
                    if (i is DirectoryInfo)            //判断是否文件夹
                    {
                        DirectoryInfo subdir = new DirectoryInfo(i.FullName);
                        subdir.Delete(true);          //删除子目录和文件
                    }
                    else
                    {
                        File.Delete(i.FullName);      //删除指定文件
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private void DatabaseLogin_FormClosed(object sender, FormClosedEventArgs e)
        {

            try
            {
                string dir = PathTos.GetPath_rulesdir();
                DelectDir(dir);
            }
            catch (Exception)
            {

                Application.Exit();
                System.Environment.Exit(0);
            }


            Application.Exit();
            System.Environment.Exit(0);

     



        }

        private void foreverButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkDb() < 0)
                {
                    return;
                }
                else
                {
                    IList<string> _DataBaseList = new List<string>();

                    DBConfig.db.ServerName = dungeonComboBox_serveradd.Text.ToString();



                    DBConfig.db.ProviderName = "SQL";
                    _conString = DBConfig.db.GetSQLmasterConstring();

                    DBConfig.db.DBProvider = new bw323DataTools.DBUtility.DbHelperSQL(_conString);
                    _DataBaseList = DBConfig.db.DBProvider.GetDataBaseInfo();
                    if (_DataBaseList.Count > 0)
                    {
                        DBConfig.db.ProviderName = "SQL";
                        DBConfig.db.DataBase = dungeonComboBox_databaselistcbx.Text.ToString();
                        _conString = DBConfig.db.GetConstring();
                        DBConfig.db.DBProvider = new bw323DataTools.DBUtility.DbHelperSQL(_conString);
                        MessageBox.Show(_conString.ToString());
                        //MainfromShow();

                        _conString += "TrustServerCertificate=true";

                        InfoDataFix01 frm = new InfoDataFix01();
                        frm.Show();
                        this.Hide();


                    }

                }

            }
            catch (Exception)
            {

                MessageBox.Show("数据库登录失败!,请检查输入的账号信息！");
            }

        }

        private void foreverButton3_Click(object sender, EventArgs e)
        {
            infoimports frm = new infoimports();
            frm.Show();
            this.Hide();
        }
    }
}
