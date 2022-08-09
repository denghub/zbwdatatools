using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bw323DataTools
{
    public class PathTos
    {


        public static string GetPath_rules()
        {

            string dirs = System.Environment.CurrentDirectory;
            string path1 = @"\data";
            string path2 = @"\rule.zip";
            string paths = dirs + path1 + path2;

            return paths;
        }
        public static string GetUpdate_files()
        {

            string dirs = System.Environment.CurrentDirectory;
            string path1 = @"\data";
            string path2 = @"\updatefile.zip";
            string paths = dirs + path2;

            return paths;
        }

        public static string GetPath_rulesdir()
        {

            string dirs = System.Environment.CurrentDirectory;
            string path1 = @"\data";

            string paths = dirs + path1;

            return paths;
        }

        public static string GetPath_Init()
        {

            string dirs = System.Environment.CurrentDirectory;
            string path1 = @"\data";
            string path2 = @"\dbo.sql";
            string paths = dirs + path1 + path2;

            return paths;
        }


        public static string GetPath_Fixsxsy()
        {

            string dirs = System.Environment.CurrentDirectory;
            string path1 = @"\data";
            string path2 = @"\fixsxsy.sql";
            string paths = dirs + path1 + path2;

            return paths;
        }


        public static string GetPath_Out_HaiXin()
        {

            string dirs = System.Environment.CurrentDirectory;
            string path1 = @"\data";
            string path2 = @"\outhaixin.sql";
            string paths = dirs + path1 + path2;

            return paths;
        }

        public static string GetPath_Out_TaiGeSb()
        {

            string dirs = System.Environment.CurrentDirectory;
            string path1 = @"\data";
            string path2 = @"\outTaiGeSb.sql";
            string paths = dirs + path1 + path2;

            return paths;
        }

        public static string GetPath_Out_SiXunwdr()
        {

            string dirs = System.Environment.CurrentDirectory;
            string path1 = @"\data";
            string path2 = @"\outsxsy10.sql";
            string paths = dirs + path1 + path2;

            return paths;
        }

        public static string GetPath_Out_Access()
        {

            string dirs = System.Environment.CurrentDirectory;
            string path1 = @"\data";
            string path2 = @"\outaccess.sql";
            string paths = dirs + path1 + path2;

            return paths;
        }

    }
}
