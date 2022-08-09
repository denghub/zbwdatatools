using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bw323DataTools
{
    public partial class InfoDataFix01 : Form
    {

        public static string conString;
        public InfoDataFix01()
        {
            InitializeComponent();
            conString = DatabaseLogin._conString;

        }

        private void InfoDataFix01_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
            System.Environment.Exit(0);
        }

        private void hopeButton1_Click(object sender, EventArgs e)
        {
            ToolsInit();
        }






        private void ToolsInit()
        {
            string path = PathTos.GetPath_Fixsxsy();
            //  string connectonstring = ConfigurationManager.AppSettings["connectionString "].ToString();
            string connectonstring = conString;

          //  MessageBox.Show(connectonstring);

            // string path = PathTos.GetPath();     // 获取脚本位置


            if (File.Exists(path))
            {
                FileInfo file = new FileInfo(path);
                string script = file.OpenText().ReadToEnd();
                try
                {
                    ////执行脚本
                    //SqlConnection conn = new SqlConnection(connectonstring);
                    //Server server = new Server(new ServerConnection(conn));
                    //int i = server.ConnectionContext.ExecuteNonQuery(script);



                    Server server = new Server(new ServerConnection(connectonstring));



                    SqlConnection con = new SqlConnection(connectonstring);

                    Server srv = new Server(new ServerConnection(con));

                    int i = srv.ConnectionContext.ExecuteNonQuery(script);
                    //  MessageBox.Show(i.ToString());
                    if (i.ToString() != "" | i.ToString() != null)
                    {
                        MessageBox.Show(" 恭喜!\n " + "  操作成功! ", " 请进行下一步 ");

                    }
                    else
                    {
                        MessageBox.Show(" @_@ 再试一次吧! ", " 失败 ");
                    }
                }

                catch (Exception es)
                {
                    MessageBox.Show(" @_@ 再试一次吧! ", " 失败 ");

                }
            }
            else
            {
                MessageBox.Show(" 资源不存在! ");
                return;
            }
        }



        private void InfoDataFix01_Load(object sender, EventArgs e)
        {
            try
            {
                string dir = PathTos.GetPath_rulesdir();
                DelectDir(dir);
            }
            catch (Exception)
            {

                MessageBox.Show("发生错误！请重启软件");
            }


            try
            {
                downruletsql();
            }
            catch (Exception)
            {

                MessageBox.Show("发生错误！请重启软件");
            }


            downruletsql();



            Thread.Sleep(1200);

            try
            {
                unzip_rules();
            }
            catch (Exception)
            {

                MessageBox.Show("发生错误！请重启软件");
            }
        }







        private void unzip_rules()
        {

            //  Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            string Paths = PathTos.GetPath_rules();
            string zipFilePath = Paths;
            string extractionPath = PathTos.GetPath_rulesdir();
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








    }
}
