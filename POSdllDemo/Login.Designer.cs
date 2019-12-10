namespace GprinterDEMO
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.button_login = new System.Windows.Forms.Button();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.textBox_account = new System.Windows.Forms.TextBox();
            this.checkBox_remember_me = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_exit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_login
            // 
            this.button_login.Location = new System.Drawing.Point(314, 368);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(89, 34);
            this.button_login.TabIndex = 0;
            this.button_login.Text = "登录";
            this.button_login.UseVisualStyleBackColor = true;
            this.button_login.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox_password
            // 
            this.textBox_password.Location = new System.Drawing.Point(314, 271);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(235, 21);
            this.textBox_password.TabIndex = 1;
            this.textBox_password.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox_account
            // 
            this.textBox_account.Location = new System.Drawing.Point(314, 226);
            this.textBox_account.Name = "textBox_account";
            this.textBox_account.Size = new System.Drawing.Size(235, 21);
            this.textBox_account.TabIndex = 2;
            // 
            // checkBox_remember_me
            // 
            this.checkBox_remember_me.AutoSize = true;
            this.checkBox_remember_me.Location = new System.Drawing.Point(331, 326);
            this.checkBox_remember_me.Name = "checkBox_remember_me";
            this.checkBox_remember_me.Size = new System.Drawing.Size(72, 16);
            this.checkBox_remember_me.TabIndex = 3;
            this.checkBox_remember_me.Text = "自动登录";
            this.checkBox_remember_me.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(261, 229);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "账号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(261, 274);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "密码";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-1, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(799, 178);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // button_exit
            // 
            this.button_exit.Location = new System.Drawing.Point(460, 368);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(89, 34);
            this.button_exit.TabIndex = 7;
            this.button_exit.Text = "退出";
            this.button_exit.UseVisualStyleBackColor = true;
            this.button_exit.Click += new System.EventHandler(this.button2_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox_remember_me);
            this.Controls.Add(this.textBox_account);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(this.button_login);
            this.Name = "Login";
            this.Text = "新疆电信点菜平台 - 本地助手";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_login;
        private System.Windows.Forms.TextBox textBox_account;
        private System.Windows.Forms.CheckBox checkBox_remember_me;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.TextBox textBox_password;
    }
}