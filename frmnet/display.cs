using System;
using System.Drawing;

using System.Windows.Forms;

namespace frmnet
{
    public partial class display : Form
    {
        int linewidth = 0;
        int start = 0;
        int readspeed; //char per miniute
        int inlineid = 0; //行内标记
        int end = 0;
        int step = 0;
        string[] lines;
       

        string inlinestr;
      
       
        Font font;
        SolidBrush solidBrush = new SolidBrush(Color.Black);

         int totaline;

        public display()
        {
            InitializeComponent();
        }

        private void Display_Load(object sender, EventArgs e)
        {
           //读取配置


            //设置配置生效


            font = new Font("Arial", Program.readfontsize);
            string text = System.IO.File.ReadAllText(Program.flieseled, System.Text.Encoding.Default);
            string temp="";
            lines = text.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string ll in lines)
               {
                temp = temp + ll.Replace(" ","");
                
            }
            richTextBox1.Font = font;
           
            richTextBox1.Text = temp;
         
           
            totaline = richTextBox1.GetLineFromCharIndex(richTextBox1.Text.Length);
            richTextBox1.Select(0, 0);
            linewidth = richTextBox1.Text.Length / totaline;
            //computer reading speed
            switch (Program.readmode)
            {
                case 3:
                    readspeed = (linewidth / 3) * (60000 / Program.readbite);
                    this.Text = Program.flieseled + " " + Program.readfontsize + " " + Program.readbite + " " + Program.readmode + " " + readspeed + "c/min";
                    break;
                case 5:
                    readspeed = (linewidth / 2) * (60000 / Program.readbite);
                    this.Text = Program.flieseled + " " + Program.readfontsize + " " + Program.readbite + " " + Program.readmode + " " + readspeed + "c/min";
                    break;
                case 10:
                    readspeed = (linewidth ) * (60000 / Program.readbite);
                    this.Text = Program.flieseled + " " + Program.readfontsize + " " + Program.readbite + " " + Program.readmode + " " + readspeed + "c/min";
                    break;
                case 20:
                    readspeed = (linewidth *2) * (60000 / Program.readbite);
                    this.Text = Program.flieseled + " " + Program.readfontsize + " " + Program.readbite + " " + Program.readmode+" "+readspeed+"c/min";
                    break;
                default:
                    break;
            }

                        
           timer1.Interval = Program.readbite;
           timer1.Start();

           
        }



        private void Display_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();

        }





        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (step <= totaline)
            {
                switch (Program.readmode)
                {
                case 3:
                    //当前行号step
                    start = richTextBox1.GetFirstCharIndexFromLine(step);
                    end = linewidth / 3;
                    if (inlineid > 2) inlineid = 0;
                    if (inlineid != 2)
                    {
                        richTextBox1.Select(start+end*inlineid, end);
                    }
                    else if(inlineid==2)
                    {
                        richTextBox1.Select(start + 2 * end, linewidth - 2 * end);
                        step++;
                    }

                    inlineid++;
                                        break;
                case 5:
                    start = richTextBox1.GetFirstCharIndexFromLine(step);
                    end = linewidth / 2;
                    if (inlineid > 1) inlineid = 0;
                        if (inlineid == 0)
                        {
                            richTextBox1.Select(start,end);

                        }
                        else if (inlineid == 1)
                        {
                            richTextBox1.Select(start+end, linewidth-end);
                            step++;
                        }
                        inlineid++;
                        break;
                case 10:
                    richTextBox1.Select(richTextBox1.GetFirstCharIndexFromLine(step), linewidth);
                    step++;
                    break;
                case 20:

                    
                        if (step + 1 <= totaline)
                        {
                            richTextBox1.Select(richTextBox1.GetFirstCharIndexFromLine(step), (richTextBox1.GetFirstCharIndexFromLine(step + 1) + linewidth) - richTextBox1.GetFirstCharIndexFromLine(step));
                        }
                        else
                        {
                            richTextBox1.Select(richTextBox1.GetFirstCharIndexFromLine(step), linewidth*2);
                        }
                    step = step + 2;
                     break;
                
                }
      
            }
            else
            {
                timer1.Stop();
                step = 0;

            }

           

        }

        private void Display_ResizeEnd(object sender, EventArgs e)
        {
           

        }

        private void Display_Shown(object sender, EventArgs e)
        {
           

        }

       
        private void Display_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
