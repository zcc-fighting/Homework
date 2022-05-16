using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;

namespace Homework8
{
    public partial class Form1 : Form
    {
        private bool ISMAXSCREEN = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //弹出新窗口
            Form2 form2 = new Form2();
            form2.Show();

            form2.TEXTDATA1 = this.richTextBox1.Text;

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        //关闭窗口                 
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //全屏和取消全屏
        private void button3_Click(object sender, EventArgs e)
        {
            if (ISMAXSCREEN == false)
            {
                this.WindowState = FormWindowState.Maximized;
                ISMAXSCREEN = true;

                //控件大小设置
                pictureBox2.Size = new System.Drawing.Size(500,350);
                button1.Size = new System.Drawing.Size(180,70);
                richTextBox1.Size = new System.Drawing.Size(600,70);

                //控件位置设置
                Rectangle rect = new Rectangle();    //Rectangle 存储一组整数，共四个，表示一个矩形的位置和大小
                rect = Screen.GetWorkingArea(this);
                pictureBox2.Location = new System.Drawing.Point(rect.Width / 2 - 250, rect.Height / 6);
                button1.Location = new System.Drawing.Point((rect.Width + 420) / 2, rect.Height/2);
                richTextBox1.Location = new System.Drawing.Point((rect.Width - 780) / 2, rect.Height / 2);
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                ISMAXSCREEN = false;

                //控件大小设置
                pictureBox2.Size = new System.Drawing.Size(500, 350);
                button1.Size = new System.Drawing.Size(180, 70);
                richTextBox1.Size = new System.Drawing.Size(600, 70);

                //控件位置设置
                pictureBox2.Location = new System.Drawing.Point(350, 93);
                button1.Location = new System.Drawing.Point(809, 348);
                richTextBox1.Location = new System.Drawing.Point(212, 348);
            }
        }

        //窗口最小化
        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
