using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frmnet
{
    public partial class Form1 : Form
    {
        public string maintxt = "";
        public int readbite = 0;
        public int readmode = 0;
        public int fontsize = 0;
        public string fileContent = string.Empty;
        public string filePath = string.Empty;
        public Form1()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            display dis = new display();
            dis.maintxt = maintxt;
            Hide();
            dis.Show();
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()) 
            {
                openFileDialog.Filter = "txt files (*.txt)|*.txt";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();
                   maintxt= File.ReadAllText(openFileDialog.FileName,Encoding.Default);
                    

                    //using (StreamReader reader = new StreamReader(fileStream))
                    //{
                    //    fileContent = reader.ReadToEnd();
                    //}
                }
            }
            //maintxt = fileContent;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
