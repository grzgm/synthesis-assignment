namespace WinFormsApp
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
			this.tbEmail = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnLogIn = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.tbPassword = new System.Windows.Forms.TextBox();
			this.lbFeedback = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// tbEmail
			// 
			this.tbEmail.Location = new System.Drawing.Point(364, 173);
			this.tbEmail.Name = "tbEmail";
			this.tbEmail.Size = new System.Drawing.Size(206, 31);
			this.tbEmail.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(231, 176);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 25);
			this.label1.TabIndex = 1;
			this.label1.Text = "email:";
			// 
			// btnLogIn
			// 
			this.btnLogIn.Location = new System.Drawing.Point(275, 329);
			this.btnLogIn.Name = "btnLogIn";
			this.btnLogIn.Size = new System.Drawing.Size(200, 71);
			this.btnLogIn.TabIndex = 2;
			this.btnLogIn.Text = "Log In";
			this.btnLogIn.UseVisualStyleBackColor = true;
			this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(231, 213);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(89, 25);
			this.label2.TabIndex = 4;
			this.label2.Text = "password";
			// 
			// tbPassword
			// 
			this.tbPassword.Location = new System.Drawing.Point(364, 210);
			this.tbPassword.Name = "tbPassword";
			this.tbPassword.Size = new System.Drawing.Size(206, 31);
			this.tbPassword.TabIndex = 3;
			// 
			// lbFeedback
			// 
			this.lbFeedback.AutoSize = true;
			this.lbFeedback.Location = new System.Drawing.Point(231, 271);
			this.lbFeedback.Name = "lbFeedback";
			this.lbFeedback.Size = new System.Drawing.Size(0, 25);
			this.lbFeedback.TabIndex = 5;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(344, 78);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(61, 25);
			this.label4.TabIndex = 6;
			this.label4.Text = "Log in";
			// 
			// Login
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.lbFeedback);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tbPassword);
			this.Controls.Add(this.btnLogIn);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tbEmail);
			this.Name = "Login";
			this.Text = "Login";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private TextBox tbEmail;
		private Label label1;
		private Button btnLogIn;
		private Label label2;
		private TextBox tbPassword;
		private Label lbFeedback;
		private Label label4;
	}
}