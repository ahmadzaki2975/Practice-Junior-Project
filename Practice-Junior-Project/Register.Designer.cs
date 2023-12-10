namespace Practice_Junior_Project
{
    partial class Register
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            tbPassword = new TextBox();
            tbUsername = new TextBox();
            btnRegister = new Button();
            btnToLogin = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 0;
            label1.Text = "Register";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 39);
            label2.Name = "label2";
            label2.Size = new Size(59, 15);
            label2.TabIndex = 1;
            label2.Text = "username";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 73);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 2;
            label3.Text = "password";
            // 
            // tbPassword
            // 
            tbPassword.Location = new Point(75, 70);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(100, 23);
            tbPassword.TabIndex = 3;
            // 
            // tbUsername
            // 
            tbUsername.Location = new Point(75, 36);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(100, 23);
            tbUsername.TabIndex = 4;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(12, 118);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(75, 23);
            btnRegister.TabIndex = 5;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // btnToLogin
            // 
            btnToLogin.Location = new Point(100, 118);
            btnToLogin.Name = "btnToLogin";
            btnToLogin.Size = new Size(75, 23);
            btnToLogin.TabIndex = 6;
            btnToLogin.Text = "To Login";
            btnToLogin.UseVisualStyleBackColor = true;
            btnToLogin.Click += btnToLogin_Click;
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnToLogin);
            Controls.Add(btnRegister);
            Controls.Add(tbUsername);
            Controls.Add(tbPassword);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Register";
            Text = "Register";
            Load += Register_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox tbPassword;
        private TextBox tbUsername;
        private Button btnRegister;
        private Button btnToLogin;
    }
}