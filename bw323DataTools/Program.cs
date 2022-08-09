using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bw323DataTools
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);






            Application.Run(new Login());

            


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
    }
}
