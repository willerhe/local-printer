using POSdllDemo;
using System;
using System.Windows.Forms;

namespace GprinterDEMO
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.CanILogin())
            {
                this.DialogResult = DialogResult.OK;
                this.Dispose();
                this.Close();
            }
        }

        // canLogin login validation
        private bool CanILogin()
        {
            String account,password;
            account = this.textBox_account.Text;
            password = this.textBox_password.Text;
            // todo implement,request remote method
            return true;

        }

        // 清除所有的textbox 内容
        internal void EmptyAllTextBoxs()
        {
            this.textBox_account.Clear();
            this.textBox_password.Clear();

        }
    }
}
