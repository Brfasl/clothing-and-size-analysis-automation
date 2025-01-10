namespace Login_And_Register_Page
{
    partial class LoginPage
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
            this.createAccount = new System.Windows.Forms.Label();
            this.dontHaveAccount = new System.Windows.Forms.Label();
            this.showPassword = new System.Windows.Forms.CheckBox();
            this.password = new System.Windows.Forms.TextBox();
            this.userName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.loginForCustomer = new System.Windows.Forms.Button();
            this.loginForSeller = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // createAccount
            // 
            this.createAccount.AutoSize = true;
            this.createAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.createAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createAccount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.createAccount.Location = new System.Drawing.Point(88, 479);
            this.createAccount.Name = "createAccount";
            this.createAccount.Size = new System.Drawing.Size(95, 13);
            this.createAccount.TabIndex = 17;
            this.createAccount.Text = "Create Account";
            this.createAccount.Click += new System.EventHandler(this.createAccount_Click);
            // 
            // dontHaveAccount
            // 
            this.dontHaveAccount.AutoSize = true;
            this.dontHaveAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dontHaveAccount.Location = new System.Drawing.Point(76, 453);
            this.dontHaveAccount.Name = "dontHaveAccount";
            this.dontHaveAccount.Size = new System.Drawing.Size(141, 13);
            this.dontHaveAccount.TabIndex = 18;
            this.dontHaveAccount.Text = "Don\'t Have An Account";
            // 
            // showPassword
            // 
            this.showPassword.AutoSize = true;
            this.showPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.showPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showPassword.Location = new System.Drawing.Point(133, 306);
            this.showPassword.Name = "showPassword";
            this.showPassword.Size = new System.Drawing.Size(119, 21);
            this.showPassword.TabIndex = 15;
            this.showPassword.Text = "Show Password";
            this.showPassword.UseVisualStyleBackColor = true;
            this.showPassword.CheckedChanged += new System.EventHandler(this.showPassword_CheckedChanged);
            // 
            // password
            // 
            this.password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.password.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.Location = new System.Drawing.Point(36, 264);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(216, 21);
            this.password.TabIndex = 9;
            this.password.UseSystemPasswordChar = true;
            // 
            // userName
            // 
            this.userName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.userName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.userName.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userName.Location = new System.Drawing.Point(36, 183);
            this.userName.Multiline = true;
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(216, 21);
            this.userName.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(32, 240);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 21);
            this.label4.TabIndex = 8;
            this.label4.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(32, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 21);
            this.label2.TabIndex = 10;
            this.label2.Text = "Username";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.label1.Location = new System.Drawing.Point(31, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 27);
            this.label1.TabIndex = 6;
            this.label1.Text = "Get Started";
            // 
            // closeButton
            // 
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.ForeColor = System.Drawing.Color.SlateBlue;
            this.closeButton.Location = new System.Drawing.Point(241, 12);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(32, 32);
            this.closeButton.TabIndex = 19;
            this.closeButton.Text = "X";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            this.closeButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.closeButton_MouseDown);
            this.closeButton.MouseLeave += new System.EventHandler(this.closeButton_MouseLeave);
            this.closeButton.MouseHover += new System.EventHandler(this.closeButton_MouseHover);
            this.closeButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.closeButton_MouseUp);
            // 
            // loginForCustomer
            // 
            this.loginForCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.loginForCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginForCustomer.FlatAppearance.BorderSize = 0;
            this.loginForCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginForCustomer.ForeColor = System.Drawing.Color.White;
            this.loginForCustomer.Location = new System.Drawing.Point(36, 354);
            this.loginForCustomer.Name = "loginForCustomer";
            this.loginForCustomer.Size = new System.Drawing.Size(216, 26);
            this.loginForCustomer.TabIndex = 20;
            this.loginForCustomer.Text = "LOGIN FOR CUSTOMER";
            this.loginForCustomer.UseVisualStyleBackColor = false;
            this.loginForCustomer.Click += new System.EventHandler(this.loginForCustomer_Click);
            // 
            // loginForSeller
            // 
            this.loginForSeller.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.loginForSeller.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginForSeller.FlatAppearance.BorderSize = 0;
            this.loginForSeller.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginForSeller.ForeColor = System.Drawing.Color.White;
            this.loginForSeller.Location = new System.Drawing.Point(36, 390);
            this.loginForSeller.Name = "loginForSeller";
            this.loginForSeller.Size = new System.Drawing.Size(216, 23);
            this.loginForSeller.TabIndex = 21;
            this.loginForSeller.Text = "LOGIN FOR SELLER";
            this.loginForSeller.UseVisualStyleBackColor = false;
            this.loginForSeller.Click += new System.EventHandler(this.loginForSeller_Click);
            // 
            // LoginPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(285, 544);
            this.Controls.Add(this.loginForCustomer);
            this.Controls.Add(this.loginForSeller);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.createAccount);
            this.Controls.Add(this.dontHaveAccount);
            this.Controls.Add(this.showPassword);
            this.Controls.Add(this.password);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LoginPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login Page";
            this.Load += new System.EventHandler(this.LoginPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label createAccount;
        private System.Windows.Forms.Label dontHaveAccount;
        private System.Windows.Forms.CheckBox showPassword;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button loginForCustomer;
        private System.Windows.Forms.Button loginForSeller;
    }
}