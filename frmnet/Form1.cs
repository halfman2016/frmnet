using banma.Properties;
using System;

using System.Windows.Forms;

namespace frmnet
{
    public partial class Form1 : Form
    {
        
    
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (Program.flieseled.Length==0)
            {
                MessageBox.Show(this, "请选取文本文件（ANSI格式）", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            { 
            display dis = new display();
            Hide();
            dis.Show();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()) 
            {
                openFileDialog.Filter = "txt files (*.txt)|*.txt";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                   
                    fileseled.Text = openFileDialog.FileName;
                    Program.flieseled = openFileDialog.FileName;
                    Settings.Default.selfilename = Program.flieseled;
                    Settings.Default.Save();
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void GroupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void RadioButton12_CheckedChanged(object sender, EventArgs e)
        {
            // 9 10 11 12 一个方法 小 10 中 15 大 25 超大35

            if (radioButton9.Checked == true) Program.readfontsize = 35;
            if (radioButton10.Checked == true) Program.readfontsize = 25;
            if (radioButton11.Checked == true) Program.readfontsize = 15;
            if (radioButton12.Checked == true) Program.readfontsize = 10;
            Settings.Default.readfontsize = Program.readfontsize;

            Settings.Default.Save();
            sampletxt.Font = new System.Drawing.Font("Arial", Program.readfontsize);
        }

        private void RadioButton8_CheckedChanged(object sender, EventArgs e)
        {
            // 8 7 6 5 一个方法 节奏 8 60拍  7  90拍 6 120拍 5 180拍

            if (radioButton8.Checked == true) Program.readbite = 1000;
            if (radioButton7.Checked == true) Program.readbite = 666;
            if (radioButton6.Checked == true) Program.readbite = 500;
            if (radioButton5.Checked == true) Program.readbite = 333;
            Settings.Default.readbite = Program.readbite;
            Settings.Default.Save();
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            // 1  三目一行  2 两目一行 3 一目一行 4 一目两行 

            if (radioButton1.Checked == true) Program.readmode = 3;
            if (radioButton2.Checked == true) Program.readmode = 5;
            if (radioButton3.Checked == true) Program.readmode = 10;
            if (radioButton4.Checked == true) Program.readmode = 20;
            Settings.Default.readmode = Program.readmode;
            Settings.Default.Save();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Program.flieseled = "C:\\Users\\jiang\\Documents\\tteeansi.txt";
            //read set
            Program.readmode = Settings.Default.readmode;
            Program.readfontsize = Settings.Default.readfontsize;
            Program.readbite = Settings.Default.readbite;
            Program.flieseled = Settings.Default.selfilename;

            Program.forcecolor = Settings.Default.forecolor;
            Program.backcolor = Settings.Default.backcolor;
            Program.selbackcolor = Settings.Default.selbackcolor;
            Program.selforcecolor = Settings.Default.selforecolor;



            //display set

            if (Program.readfontsize * Program.readmode * Program.readbite != 0)
            {
                switch (Program.readbite)
                {
                    case 1000:
                        radioButton8.Checked = true;
                        break;
                    case 666:
                        radioButton7.Checked = true;
                        break;
                    case 500:
                        radioButton6.Checked = true;
                        break;
                    case 333:
                        radioButton5.Checked = true;
                        break;
                        
                }
                switch (Program.readmode)
                {
                    case 3:
                        radioButton1.Checked = true;
                        break;
                    case 5:
                        radioButton2.Checked = true;
                        break;
                    case 10:
                        radioButton3.Checked = true;
                        break;
                    case 20:
                        radioButton4.Checked = true;
                        break;

                }

                switch (Program.readfontsize)
                {
                    case 10:
                        radioButton12.Checked = true;
                        break;
                    case 15:
                        radioButton11.Checked = true;
                        break;
                    case 25:
                        radioButton10.Checked = true;
                        break;
                    case 35:
                        radioButton9.Checked = true;
                        break;

                }

                fileseled.Text = Program.flieseled;
            }

            //样例赋值

            

            
           
            }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            sampletxt.ForeColor = Program.forcecolor;
            sampletxt.BackColor = Program.backcolor;
            sampletxt.SelectionColor = Program.selforcecolor;
            sampletxt.SelectionBackColor = Program.selbackcolor;

            btnbackcol.BackColor = Program.backcolor;
            btnforecol.BackColor = Program.forcecolor;
            btnselfore.BackColor = Program.selforcecolor;
            btnselback.BackColor = Program.selbackcolor;
            sampletxt.Select(2, 4);
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }
    }
    }

