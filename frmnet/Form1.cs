using banma.Properties;
using System;

using System.Windows.Forms;

namespace frmnet
{
    public partial class Form1 : Form
    {

        //height /width  297/210


        public Form1()
        {
            InitializeComponent();           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Program.flieseled = "C:\\Users\\jiang\\Documents\\tteeansi.txt";
            //read set

            Program.readmode = Settings.Default.readmode;
            Program.readfontsize = Settings.Default.readfontsize;
            Program.sizecustim = Settings.Default.sizecustime;
            Program.windowheight = Settings.Default.windowheight;
            Program.windowwidth = Settings.Default.windowwidth;
            Program.isA4 = Settings.Default.isA4;
            isA4check.Checked = Program.isA4;
            trackBar1.Value = Program.sizecustim;
            heightbox.Text = Program.windowheight.ToString();
            if (Program.isA4 == true)
            {
                //保持比例

                isA4check.Checked = Program.isA4;
                widthbox.ReadOnly = true;
                widthbox.Text = ((Program.windowheight * 210) / 297).ToString();

            }
            else
            {
                //不保持
                isA4check.Checked = Program.isA4;
                widthbox.ReadOnly = false;
                widthbox.Text = Program.windowwidth.ToString();

            }
           
            radioButton13.Text = "自定义大小：（" + trackBar1.Value + "）";

            System.Console.WriteLine("first load :" + Program.readfontsize);
            Program.readbite = Settings.Default.readbite;
            Program.flieseled = Settings.Default.selfilename;


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
                    default:
                        radioButton13.Checked = true;
                        break;

                }

                fileseled.Text = Program.flieseled;
            }

            //样例赋值



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
                Settings.Default.windowwidth = Program.windowwidth;
                Settings.Default.windowheight = Program.windowheight;
                Settings.Default.Save();

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
                    Settings.Default.windowwidth = Program.windowwidth;
                    Settings.Default.windowheight = Program.windowheight;

                    Settings.Default.Save();
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.windowwidth = Program.windowwidth;
            Settings.Default.windowheight = Program.windowheight;
            Settings.Default.Save();
            Application.Exit();
        }


       

        private void RadioButton12_CheckedChanged(object sender, EventArgs e)
        {
            // 9 10 11 12 一个方法 小 10 中 15 大 25 超大35

            if (radioButton9.Checked == true) Program.readfontsize = 35;
            if (radioButton10.Checked == true) Program.readfontsize = 25;
            if (radioButton11.Checked == true) Program.readfontsize = 15;
            if (radioButton12.Checked == true) Program.readfontsize = 10;
            if (radioButton13.Checked == true) 
            {
                trackBar1.Visible = true;
                radioButton13.Text= "自定义大小：（" + trackBar1.Value + "）";
                Program.sizecustim = trackBar1.Value;
                Program.readfontsize = trackBar1.Value;
                Settings.Default.sizecustime = Program.sizecustim;

                System.Console.WriteLine("idingyi");

            }
            else
            {
                //Program.sizecustim = trackBar1.Value;
                //radioButton13.Text = "自定义大小：（" + Program.sizecustim + "）";
                //Settings.Default.sizecustime = Program.sizecustim;
                trackBar1.Visible = false;        
                

            }

            Settings.Default.readfontsize = Program.readfontsize;
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

        

      

        private void Sampletxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
            sampletxt.Font=new System.Drawing.Font("Arial",trackBar1.Value);
            Program.readfontsize = trackBar1.Value;
            Settings.Default.readfontsize = Program.readfontsize;
            Settings.Default.sizecustime = Program.readfontsize;
            radioButton13.Text = "自定义大小：（" + trackBar1.Value + "）";

        }

        private void IsA4check_CheckedChanged(object sender, EventArgs e)
        {
            //保存现在的值

            Program.isA4 = isA4check.Checked;
            Settings.Default.isA4 = Program.isA4;
            Settings.Default.Save();


            if (Program.isA4 == true)
            {
                widthbox.ReadOnly = true;   //不能写
                widthbox.Text = (int.Parse(heightbox.Text)*210/297).ToString();
                Program.windowwidth = int.Parse(widthbox.Text);

            }
            else
            {
                widthbox.ReadOnly = false;
                Program.windowwidth = int.Parse(widthbox.Text);

            }

           

        }

        private void Widthbox_TextChanged(object sender, EventArgs e)
        {
            if (widthbox.Text != "")
            {
                if (Program.isA4 == false)
                {
                    Program.windowwidth = int.Parse(widthbox.Text);

                }
                else

                {
                    Console.Out.WriteLine("no");

                }
            }
        }

        private void Heightbox_TextChanged(object sender, EventArgs e)
        {
            if (heightbox.Text != "")
            {
                if (Program.isA4 == true)
                {
                    Program.windowheight = int.Parse(heightbox.Text);
                    Program.windowwidth = (Program.windowheight * 210) / 297;
                    widthbox.Text = Program.windowwidth.ToString();
                }
            }
            }

        private void Heightbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void Widthbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }
    }
    }

