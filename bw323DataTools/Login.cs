using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Extensions;
using System.Net;
using System.IO;
using System.IO.Compression;
using System.Threading;

namespace bw323DataTools
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();


        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void airButton_login_Click(object sender, EventArgs e)
        {
            //SignModel signModel = new SignModel();
            //signModel.username = "bw8022";
            //signModel.password = "bw8022";
            //var restclient = new RestClient("https://api.bw8848.wpgood.net");

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;

            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;
            //var request = new RestRequest("/?s=App.User_User.Login", Method.POST);
            //request.AddObject(signModel);
            //var response = restclient.Execute(request);
            //var resout = JsonConvert.DeserializeObject<Resout>(response.Content);
            //MessageBox.Show(response.Content.ToString());
            var token = "";
            var user_id = "";
            var ret = "";
            try
            {


                //  System.Net.ServicePointManager.SecurityProtocol |=SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;

                var client = new RestClient("https://api.tools.bw8848.com.cn");

           
                var request = new RestRequest("?s=App.User_User.Login");


                request.AddParameter("username", this.hopeTextBox_user.Text);
                request.AddParameter("password", this.hopeTextBox_pwd.Text);
                //var response = client.ExecuteAsPost(request, "POST");

                //var response = client.Execute(request).Content.ToString();
                //var jobjs = JObject.Parse(response);
                //ret = jobjs["ret"].ToString();
                //user_id = jobjs["data"]["user_id"].ToString();
                //token = jobjs["data"]["token"].ToString();






                var response = client.ExecutePost(request).Content.ToString();

              //  MessageBox.Show(response);


                var jobjs = JObject.Parse(response);
                ret = jobjs["ret"].ToString();
                user_id = jobjs["data"]["user_id"].ToString();
                token = jobjs["data"]["token"].ToString();



            }
            catch (Exception)
            {

                // MessageBox.Show("网络异常或账号密码输入有误！");
            }

            //MessageBox.Show(ret);
            if (ret == "200")
            {

                if (token!="")
                {

                    // MessageBox.Show("登录成功！" + " 用户名：" + user_id + "    token:" + token);
                    DatabaseLogin f2 = new DatabaseLogin();//首先将另一个窗口Form2实例化

                    f2.Visible = false;//将当前窗口设置为不可视；如果不这样处理则系统报错。

                    f2.Show();

                    f2.Visible = true;
                    this.Hide();
                }

                else if (token.Equals(""))
                {



                    MessageBox.Show("账号或密码错误！");


                }


            }


            if (ret != "200")
            {



                MessageBox.Show("账号或密码错误！");


            }

        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.airRadioButton1.Checked=true;

            try
            {
                downruletsql();
                Thread.Sleep(660);
                unzip_rules();
            }
            catch (Exception)
            {

                throw;
            }
           
            


        }

        private void unzip_rules()
        {

            //  Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            string Paths = PathTos.GetUpdate_files();
            string zipFilePath = Paths;
            string extractionPath = PathTos.GetPath_rulesdir();
            ZipFile.ExtractToDirectory(zipFilePath, extractionPath, Encoding.GetEncoding("GBK"));
        }
        private void downruletsql()
        {

            string Paths = PathTos.GetUpdate_files();
            var client = new RestClient("http://update.bw.wpgood.net/bw323dts");
            var request = new RestRequest("updatefile.zip");
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

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
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
    }
}
