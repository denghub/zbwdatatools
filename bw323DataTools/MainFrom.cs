using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Sdk.Sfc;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
//using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using bw323DataTools.Core;
using System.IO.Compression;
using RestSharp;
using System.Threading;
using System.Diagnostics;
using OfficeOpenXml;

namespace bw323DataTools
{
    public partial class MainFrom : Form
    {


        public static string conString;
        public MainFrom()
        {
            InitializeComponent();
            conString = DatabaseLogin._conString;
        }

        private void MainFrom_FormClosed(object sender, FormClosedEventArgs e)
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

        private void hopeButton_excute_sqltoexcel_Click(object sender, EventArgs e)
        {
            //string dirs = PathTos.GetPath();
            //System.Windows.Forms.MessageBox.Show(dirs);
            try
            {
                string selstr = this.aloneComboBox_setotherver.SelectedItem.ToString();

                if (selstr == "商云系列未导入档案导出")
                {
                    this.listBox1.Items.Clear();

                    this.listBox1.Items.Add("未导入的基本单位商品");
                    this.listBox1.Items.Add("未导入的多包装单位商品");
                    Thread.Sleep(500);
                    Tools_for_sixunsywdr();
                }
                else if (selstr == "泰格至尊商业(暂不支持)")
                {
                    this.listBox1.Items.Clear();

                    MessageBox.Show("请使用自带百威工具箱导入");
                }
                else if (selstr == "海信")
                {


                    this.listBox1.Items.Clear();
                    this.listBox1.Items.Add("[货商档案]");
                    this.listBox1.Items.Add("[商品类别]");
                    this.listBox1.Items.Add("[商品档案]");

                    Thread.Sleep(500);
                    Tools_for_haixin();
                }
                else if (selstr == "泰格商霸")
                {


                    this.listBox1.Items.Clear();
                    this.listBox1.Items.Add("货商档案");
                    this.listBox1.Items.Add("商品类别");
                    this.listBox1.Items.Add("商品档案");
                    this.listBox1.Items.Add("未导入重复的商品档案");
                    this.listBox1.Items.Add("未导入的商品档案数据异常");
                    
                    this.listBox1.Items.Add("会员档案");
                    this.listBox1.Items.Add("会员类别");
                    this.listBox1.Items.Add("会员积分充值单");

                    Thread.Sleep(500);
                    Tools_for_taigesb();
                }

            }
            catch (Exception)
            {

                MessageBox.Show("请选择软件版本！");
            }

           
            


        }

        private void hopeButton1_Click(object sender, EventArgs e)
        {
            // PatchCard();
            // Getinid();
            MessageBox.Show("OK!");

        }


        private void Getinid()
        {
            string sqlConnectionString = conString;

            MessageBox.Show(sqlConnectionString);

            string path = PathTos.GetPath_Init();    




            //if (!path.EndsWith(@"\"))
            //{
            //    path += @"\";
            //}
            //path += "dbo.sql";   



            string script = File.ReadAllText(path);

        //   SqlConnection conn = new SqlConnection(sqlConnectionString);

            Server server = new Server(new ServerConnection(sqlConnectionString));



            SqlConnection con = new SqlConnection(sqlConnectionString);

             Server srv = new Server(new ServerConnection(con));

            srv.ConnectionContext.ExecuteNonQuery(script);


        }


        //private void PatchCard()
        //{
        //    string path = System.Environment.CurrentDirectory;
        //    //  string connectonstring = ConfigurationManager.AppSettings["connectionString "].ToString();
        //    string connectonstring = conString;

        //    // string path = PathTos.GetPath();     // 获取脚本位置




        //    if (!path.EndsWith(@"\"))
        //    {
        //        path += @"\";
        //    }
        //    path += "dbo.sql";    //获取脚本位置
        //    if (File.Exists(path))
        //    {
        //        FileInfo file = new FileInfo(path);
        //        string script = file.OpenText().ReadToEnd();
        //        try
        //        {
        //            //执行脚本
        //            SqlConnection conn = new SqlConnection(connectonstring);
        //            Server server = new Server(new ServerConnection(conn));
        //            int i = server.ConnectionContext.ExecuteNonQuery(script);

        //            if (i == 1)
        //            {
        //                MessageBox.Show(" 恭喜!\n " + "  操作成功! ", " 请进行下一步 ");

        //            }
        //            else
        //            {
        //                MessageBox.Show(" @_@ 再试一次吧! ", " 失败 ");
        //            }
        //        }

        //        catch (Exception es)
        //        {
        //            MessageBox.Show(es.Message);

        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show(" 资源不存在! ");
        //        return;
        //    }
        //}





        private void ToolsInit()
        {
            string path = PathTos.GetPath_Init();
            //  string connectonstring = ConfigurationManager.AppSettings["connectionString "].ToString();
            string connectonstring = conString;
           

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

                   int i= srv.ConnectionContext.ExecuteNonQuery(script);
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







        public void Tools_for_haixin()
        {
            string path = PathTos.GetPath_Out_HaiXin();
            //  string connectonstring = ConfigurationManager.AppSettings["connectionString "].ToString();
            string connectonstring = conString;


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
                    //MessageBox.Show(i.ToString());
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



        public void Tools_for_taigesb()
        {
            string path = PathTos.GetPath_Out_TaiGeSb();
            //  string connectonstring = ConfigurationManager.AppSettings["connectionString "].ToString();
            string connectonstring = conString;


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
                    //MessageBox.Show(i.ToString());
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



        public void Tools_for_sixunsywdr()
        {
            string path = PathTos.GetPath_Out_SiXunwdr();

            string connectonstring = conString;


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
                   // MessageBox.Show(i.ToString());
                    if (i.ToString()!=""|i.ToString()!=null)
                    {
                        MessageBox.Show(" 恭喜!\n " + "  操作成功! ", " 请进行下一步 ");

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










        private void ShowMessage(object o, System.EventArgs e)
        {
            foreverStatusBar1.Text = o.ToString();
            foreverStatusBar1.ForeColor = Color.Red;
        }

        private void ShowErr(object o, System.EventArgs e)
        {
            foreverStatusBar1.Text = "发生错误！";
            foreverStatusBar1.ForeColor = Color.Red;
            Exception ee = o as Exception;
            throw ee;
        }

        //异步方式导出EXCEL
        public async void TaskExportExcelAsync(IList<string> SheetNames, string filename, string[] whereSQLArr)
        {
            try
            {
                this.BeginInvoke(new System.EventHandler(ShowMessage), "导数中…");
                Task<int> t = null;
                if (whereSQLArr == null)
                {
                    t = DBToExcel.ExportExcelAsync(SheetNames.ToArray(), filename);
                }
                else
                {
                    t = DBToExcel.ExportExcelAsync(SheetNames.ToArray(), filename, whereSQLArr);
                }
                await t;
                string s = string.Format("导出成功！耗时:{0}秒", t.Result);
                this.BeginInvoke(new System.EventHandler(ShowMessage), s);
                //MessageBox.Show("导数已完成！");
                GC.Collect();
            }
            catch (Exception ee)
            {
                this.BeginInvoke(new System.EventHandler(ShowErr), ee);
                return;
            }
        }



        public async void TaskExportExcelAsyncdbg(string SheetNames, string filename,string whereSQLArr)
        {
            try
            {
                this.BeginInvoke(new System.EventHandler(ShowMessage), "导数中…");
                Task<int> t = null;
                if (whereSQLArr == null)
                {
                    t = DBToExcel.ExportExcelAsync2(SheetNames, filename);
                }
                else
                {
                    t = DBToExcel.ExportExcelAsync2(SheetNames, filename);
                }
                await t;
                string s = string.Format("导出成功！耗时:{0}秒", t.Result);
                this.BeginInvoke(new System.EventHandler(ShowMessage), s);
                //MessageBox.Show("导数已完成！");
                GC.Collect();
            }
            catch (Exception ee)
            {
                this.BeginInvoke(new System.EventHandler(ShowErr), ee);
                return;
            }
        }





        //private void hopeButton2_Click(object sender, EventArgs e)
        //{

        //    try
        //    {
        //        if (listBox1.Items.Count < 1)
        //        {
        //            MessageBox.Show("请选择需要导入的表名！");
        //            return;

        //        }

        //        IList<string> SheetNames = new List<string>();
        //        foreach (var item in listBox1.Items)
        //        {
        //            SheetNames.Add(item.ToString());
        //        }

        //        string filename = Common.ShowFileDialog(SheetNames[0], ".xlsx");
        //        if (filename != null)
        //        {
        //            TaskExportExcelAsync(SheetNames, filename, null);
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        MessageBox.Show("未找到数据源!请联系开发者");

        //    }


        //}

        private async void hopeButton2_Click(object sender, EventArgs e)
        {


           
                if (listBox1.Items.Count < 1)
                {
                    MessageBox.Show("请选择需要导入的表名！");
                    return;

                }





                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                   string iss= listBox1.Items[i].ToString();
                    MessageBox.Show(iss);

                        

                    string filename = Common.ShowFileDialog(iss, ".xlsx");
                    await DBToExcel.ExportExcelAsync2(iss, filename);
                    

                }












           
           





        }



        private void foxButton1_Click(object sender, EventArgs e)
        {
            ToolsInit();
        }

        private void aloneComboBox_set_other_cj_SelectedIndexChanged(object sender, EventArgs e)
        {
            string setstr = this.aloneComboBox_set_other_cj.SelectedItem.ToString();
            if (setstr == "思迅")
            {

                aloneComboBox_setotherver.Items.Clear();
                //aloneComboBox_setotherver.Items.Add("思迅e店通");
               // aloneComboBox_setotherver.Items.Add("商云8");
               // aloneComboBox_setotherver.Items.Add("商慧7");
                aloneComboBox_setotherver.Items.Add("商云系列未导入档案导出");
            }
            if (setstr == "泰格")

            {
                aloneComboBox_setotherver.Items.Clear();
                aloneComboBox_setotherver.Items.Add("泰格至尊商业(暂不支持)");
                aloneComboBox_setotherver.Items.Add("泰格商霸");

            }
            if (setstr == "科脉")

            {
                aloneComboBox_setotherver.Items.Clear();
                aloneComboBox_setotherver.Items.Add("无");

            }
            if (setstr == "海信")

            {
                aloneComboBox_setotherver.Items.Clear();
                aloneComboBox_setotherver.Items.Add("海信");

            }

            aloneComboBox_setotherver.Focus();
        }

        private void MainFrom_Load(object sender, EventArgs e)
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



    }
}
