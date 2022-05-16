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
using System.Net;
using System.IO;

namespace Homework8
{
    public partial class Form2 : Form
    {
        private bool ISMAXSCREEN = false;
        public string TEXTDATA1;

        public Form2()
        {
            InitializeComponent();
            richTextBox1.Text = TEXTDATA1;
            richTextBox2.Text = getResault(TEXTDATA1);
            richTextBox3.Text = getResault(TEXTDATA1);
        }

        //全屏和取消全屏
        private void button3_Click(object sender, EventArgs e)
        {
            if (ISMAXSCREEN == false)
            {
                this.WindowState = FormWindowState.Maximized;
                ISMAXSCREEN = true;

                //控件大小设置
                button1.Size = new System.Drawing.Size(180, 70);
                richTextBox1.Size = new System.Drawing.Size(600, 70);
            }
            else 
            {
                this.WindowState = FormWindowState.Normal;
                ISMAXSCREEN = false;

                //控件大小设置
                button1.Size = new System.Drawing.Size(180, 70);
                richTextBox1.Size = new System.Drawing.Size(600, 70);
            }
        }

        //关闭窗口
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //窗口最小化
        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private string getResault (string key){
            string url = "https://m.baidu.com/ssid=1296636c6576657232303230g7a2701000000/s?word="+key;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream resStream = response.GetResponseStream();
            StreamReader sr = new StreamReader(resStream, Encoding.GetEncoding("UTF-8"));
            string strfile = sr.ReadToEnd();
            strfile = strfile.Substring(0, 2000);
            sr.Close();

            return strfile;
        }
        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            TEXTDATA1 = richTextBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = getResault(TEXTDATA1);
            richTextBox3.Text = getResault(TEXTDATA1);
        }

    }
}
