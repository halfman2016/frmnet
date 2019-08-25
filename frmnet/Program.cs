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

        public static int readbite;
        public static int readmode;
        public static int readfontsize;
        public static string flieseled;
        public static int sizecustim;
        public static int windowheight;
        public static int windowwidth;
        public static bool isA4;



        [STAThread]

        
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

     
    }
}
