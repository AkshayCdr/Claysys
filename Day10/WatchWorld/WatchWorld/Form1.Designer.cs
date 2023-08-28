namespace WatchWorld
{
    partial class Form1
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
            this.btnLogin = new System.Windows.Forms.Button();
            this.ContactUS = new System.Windows.Forms.Button();
            this.Registration = new System.Windows.Forms.Button();
            this.Reset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(84, 154);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(99, 42);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // ContactUS
            // 
            this.ContactUS.Location = new System.Drawing.Point(197, 154);
            this.ContactUS.Name = "ContactUS";
            this.ContactUS.Size = new System.Drawing.Size(99, 42);
            this.ContactUS.TabIndex = 2;
            this.ContactUS.Text = "ContactUs";
            this.ContactUS.UseVisualStyleBackColor = true;
            this.ContactUS.Click += new System.EventHandler(this.ContactUS_Click);
            // 
            // Registration
            // 
            this.Registration.Location = new System.Drawing.Point(310, 154);
            this.Registration.Name = "Registration";
            this.Registration.Size = new System.Drawing.Size(99, 42);
            this.Registration.TabIndex = 2;
            this.Registration.Text = "Registration";
            this.Registration.UseVisualStyleBackColor = true;
            this.Registration.Click += new System.EventHandler(this.Registration_Click);
            // 
            // Reset
            // 
            this.Reset.Location = new System.Drawing.Point(423, 154);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(99, 42);
            this.Reset.TabIndex = 2;
            this.Reset.Text = "Reset";
            this.Reset.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 450);
            this.Controls.Add(this.Reset);
            this.Controls.Add(this.Registration);
            this.Controls.Add(this.ContactUS);
            this.Controls.Add(this.btnLogin);
            this.Name = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button ContactUS;
        private System.Windows.Forms.Button Registration;
        private System.Windows.Forms.Button Reset;
    }
}

