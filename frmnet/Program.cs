using System;
using System.Windows.Forms;

namespace frmnet
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        /// 

        public static int readbite=666;
        public static int readmode=10;
        public static int readfontsize=15;
        public static string flieseled;
        public static System.Drawing.Color forcecolor;
        public static System.Drawing.Color backcolor;
        public static System.Drawing.Color selforcecolor;
        public static System.Drawing.Color selbackcolor;




        [STAThread]

        
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

     
    }
}
