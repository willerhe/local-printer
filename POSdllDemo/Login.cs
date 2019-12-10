using POSdllDemo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

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
            try
            {
                string LoginUrl = "http://192.168.1.103:8900/api/v1/web/login";
                string UserInfoUrl = "http://192.168.1.103:8900/api/v1/web/sysUser/info";
                String account, password;
                account = this.textBox_account.Text;
                password = this.textBox_password.Text;
                // todo implement,request remote method
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("username", account);
                parameters.Add("password", password);
                Dictionary<string, object> responseResult = String2Dict(Post(LoginUrl, parameters));
                Console.WriteLine("第一次登录得到的令牌" + responseResult["token"]);
                // 接下来获取个人信息
                Dictionary<string, object> UserInfo = String2Dict(GetHttpResponse(UserInfoUrl, (string)responseResult["token"]));
                string ShopId = (string)UserInfo["shopId"];
                Console.WriteLine(ShopId);
                // todo 更新json "mtms/prod/localprinte/shop/" + ShopId
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            
        }

        private Dictionary<string,object> String2Dict(string str)
        {
            Dictionary<string, object> responseResult = new Dictionary<string, object>();
            responseResult = JsonConvert.DeserializeObject<Dictionary<string, object>>(str);
            return responseResult;
        }

        public  string Post(string url, Dictionary<string, string> dic)
        {
            string result = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            #region 添加Post 参数
            StringBuilder builder = new StringBuilder();
            int i = 0;
            foreach (var item in dic)
            {
                if (i > 0)
                    builder.Append("&");
                builder.AppendFormat("{0}={1}", item.Key, item.Value);
                i++;
            }
            byte[] data = Encoding.UTF8.GetBytes(builder.ToString());
            req.ContentLength = data.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
            }
            #endregion
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            //获取响应内容
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }

        public  string GetHttpResponse(string url, string AccessToken)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";
            request.UserAgent = null;
            request.Timeout = 5000;
            request.Headers.Set("Access-Token", AccessToken);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }


        // 清除所有的textbox 内容
        internal void EmptyAllTextBoxs()
        {
            this.textBox_account.Clear();
            this.textBox_password.Clear();

        }
    }
}
