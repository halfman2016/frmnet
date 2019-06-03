namespace frmnet
{
    partial class display
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.distxt = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // distxt
            // 
            this.distxt.Location = new System.Drawing.Point(0, 34);
            this.distxt.Margin = new System.Windows.Forms.Padding(0);
            this.distxt.Name = "distxt";
            this.distxt.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.distxt.Size = new System.Drawing.Size(791, 322);
            this.distxt.TabIndex = 0;
            this.distxt.Text = "";
            this.distxt.SizeChanged += new System.EventHandler(this.Distxt_SizeChanged);
            this.distxt.TextChanged += new System.EventHandler(this.Distxt_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(695, 382);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // display
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.distxt);
            this.Name = "display";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "display";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Display_FormClosed);
            this.Load += new System.EventHandler(this.Display_Load);
            this.ClientSizeChanged += new System.EventHandler(this.Display_ClientSizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox distxt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
    }
}