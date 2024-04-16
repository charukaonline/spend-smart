namespace spend_smart
{
    partial class registerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(registerForm));
            this.label1 = new System.Windows.Forms.Label();
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.pinValidationLbl = new System.Windows.Forms.Label();
            this.usernameValidationLbl = new System.Windows.Forms.Label();
            this.loginLbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.registerBtn = new Guna.UI2.WinForms.Guna2Button();
            this.regUserNameTxt = new Guna.UI2.WinForms.Guna2TextBox();
            this.regPasswordTxt = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.conPinValidationLbl = new System.Windows.Forms.Label();
            this.regConPassTxt = new Guna.UI2.WinForms.Guna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.conNumValidationLbl = new System.Windows.Forms.Label();
            this.contactNumber = new Guna.UI2.WinForms.Guna2TextBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(304, 66);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(328, 42);
            this.label1.TabIndex = 3;
            this.label1.Text = "Create an Account";
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.guna2CirclePictureBox1.Image = global::spend_smart.Properties.Resources.logo;
            this.guna2CirclePictureBox1.Location = new System.Drawing.Point(44, 41);
            this.guna2CirclePictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.ShadowDecoration.Parent = this.guna2CirclePictureBox1;
            this.guna2CirclePictureBox1.Size = new System.Drawing.Size(107, 98);
            this.guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2CirclePictureBox1.TabIndex = 2;
            this.guna2CirclePictureBox1.TabStop = false;
            // 
            // pinValidationLbl
            // 
            this.pinValidationLbl.AutoSize = true;
            this.pinValidationLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pinValidationLbl.ForeColor = System.Drawing.Color.Red;
            this.pinValidationLbl.Location = new System.Drawing.Point(172, 551);
            this.pinValidationLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pinValidationLbl.Name = "pinValidationLbl";
            this.pinValidationLbl.Size = new System.Drawing.Size(232, 20);
            this.pinValidationLbl.TabIndex = 13;
            this.pinValidationLbl.Text = "*Enter minimum 8 characters ";
            // 
            // usernameValidationLbl
            // 
            this.usernameValidationLbl.AutoSize = true;
            this.usernameValidationLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameValidationLbl.ForeColor = System.Drawing.Color.Red;
            this.usernameValidationLbl.Location = new System.Drawing.Point(172, 294);
            this.usernameValidationLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.usernameValidationLbl.Name = "usernameValidationLbl";
            this.usernameValidationLbl.Size = new System.Drawing.Size(139, 20);
            this.usernameValidationLbl.TabIndex = 14;
            this.usernameValidationLbl.Text = "*Enter user name";
            // 
            // loginLbl
            // 
            this.loginLbl.AutoSize = true;
            this.loginLbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.loginLbl.Location = new System.Drawing.Point(477, 843);
            this.loginLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.loginLbl.Name = "loginLbl";
            this.loginLbl.Size = new System.Drawing.Size(132, 25);
            this.loginLbl.TabIndex = 11;
            this.loginLbl.Text = "Login here...";
            this.loginLbl.Click += new System.EventHandler(this.loginLbl_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(236, 843);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(247, 25);
            this.label4.TabIndex = 12;
            this.label4.Text = "Already have an Account? ";
            // 
            // registerBtn
            // 
            this.registerBtn.BorderRadius = 10;
            this.registerBtn.CheckedState.Parent = this.registerBtn;
            this.registerBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.registerBtn.CustomImages.Parent = this.registerBtn;
            this.registerBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.registerBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerBtn.ForeColor = System.Drawing.Color.White;
            this.registerBtn.HoverState.Parent = this.registerBtn;
            this.registerBtn.Location = new System.Drawing.Point(315, 750);
            this.registerBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.registerBtn.Name = "registerBtn";
            this.registerBtn.ShadowDecoration.Parent = this.registerBtn;
            this.registerBtn.Size = new System.Drawing.Size(240, 55);
            this.registerBtn.TabIndex = 10;
            this.registerBtn.Text = "Register";
            this.registerBtn.Click += new System.EventHandler(this.registerBtn_Click);
            // 
            // regUserNameTxt
            // 
            this.regUserNameTxt.BorderColor = System.Drawing.Color.Transparent;
            this.regUserNameTxt.BorderRadius = 10;
            this.regUserNameTxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.regUserNameTxt.DefaultText = "";
            this.regUserNameTxt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.regUserNameTxt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.regUserNameTxt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.regUserNameTxt.DisabledState.Parent = this.regUserNameTxt;
            this.regUserNameTxt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.regUserNameTxt.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.regUserNameTxt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.regUserNameTxt.FocusedState.Parent = this.regUserNameTxt;
            this.regUserNameTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regUserNameTxt.ForeColor = System.Drawing.Color.White;
            this.regUserNameTxt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.regUserNameTxt.HoverState.Parent = this.regUserNameTxt;
            this.regUserNameTxt.Location = new System.Drawing.Point(176, 238);
            this.regUserNameTxt.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.regUserNameTxt.Name = "regUserNameTxt";
            this.regUserNameTxt.PasswordChar = '\0';
            this.regUserNameTxt.PlaceholderText = "";
            this.regUserNameTxt.SelectedText = "";
            this.regUserNameTxt.ShadowDecoration.Parent = this.regUserNameTxt;
            this.regUserNameTxt.Size = new System.Drawing.Size(520, 50);
            this.regUserNameTxt.TabIndex = 8;
            this.regUserNameTxt.TextChanged += new System.EventHandler(this.regUserNameTxt_TextChanged);
            this.regUserNameTxt.Enter += new System.EventHandler(this.regUserNameTxt_Enter);
            // 
            // regPasswordTxt
            // 
            this.regPasswordTxt.BorderColor = System.Drawing.Color.Transparent;
            this.regPasswordTxt.BorderRadius = 10;
            this.regPasswordTxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.regPasswordTxt.DefaultText = "";
            this.regPasswordTxt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.regPasswordTxt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.regPasswordTxt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.regPasswordTxt.DisabledState.Parent = this.regPasswordTxt;
            this.regPasswordTxt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.regPasswordTxt.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.regPasswordTxt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.regPasswordTxt.FocusedState.Parent = this.regPasswordTxt;
            this.regPasswordTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regPasswordTxt.ForeColor = System.Drawing.Color.White;
            this.regPasswordTxt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.regPasswordTxt.HoverState.Parent = this.regPasswordTxt;
            this.regPasswordTxt.Location = new System.Drawing.Point(176, 494);
            this.regPasswordTxt.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.regPasswordTxt.Name = "regPasswordTxt";
            this.regPasswordTxt.PasswordChar = '*';
            this.regPasswordTxt.PlaceholderText = "";
            this.regPasswordTxt.SelectedText = "";
            this.regPasswordTxt.ShadowDecoration.Parent = this.regPasswordTxt;
            this.regPasswordTxt.Size = new System.Drawing.Size(520, 50);
            this.regPasswordTxt.TabIndex = 9;
            this.regPasswordTxt.TextChanged += new System.EventHandler(this.regPasswordTxt_TextChanged);
            this.regPasswordTxt.Enter += new System.EventHandler(this.regPasswordTxt_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(171, 459);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "PIN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(171, 208);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "User Name";
            // 
            // conPinValidationLbl
            // 
            this.conPinValidationLbl.AutoSize = true;
            this.conPinValidationLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conPinValidationLbl.ForeColor = System.Drawing.Color.Red;
            this.conPinValidationLbl.Location = new System.Drawing.Point(172, 683);
            this.conPinValidationLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.conPinValidationLbl.Name = "conPinValidationLbl";
            this.conPinValidationLbl.Size = new System.Drawing.Size(134, 20);
            this.conPinValidationLbl.TabIndex = 17;
            this.conPinValidationLbl.Text = "*Confirm the PIN";
            // 
            // regConPassTxt
            // 
            this.regConPassTxt.BorderColor = System.Drawing.Color.Transparent;
            this.regConPassTxt.BorderRadius = 10;
            this.regConPassTxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.regConPassTxt.DefaultText = "";
            this.regConPassTxt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.regConPassTxt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.regConPassTxt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.regConPassTxt.DisabledState.Parent = this.regConPassTxt;
            this.regConPassTxt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.regConPassTxt.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.regConPassTxt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.regConPassTxt.FocusedState.Parent = this.regConPassTxt;
            this.regConPassTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regConPassTxt.ForeColor = System.Drawing.Color.White;
            this.regConPassTxt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.regConPassTxt.HoverState.Parent = this.regConPassTxt;
            this.regConPassTxt.Location = new System.Drawing.Point(176, 626);
            this.regConPassTxt.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.regConPassTxt.Name = "regConPassTxt";
            this.regConPassTxt.PasswordChar = '*';
            this.regConPassTxt.PlaceholderText = "";
            this.regConPassTxt.SelectedText = "";
            this.regConPassTxt.ShadowDecoration.Parent = this.regConPassTxt;
            this.regConPassTxt.Size = new System.Drawing.Size(520, 50);
            this.regConPassTxt.TabIndex = 16;
            this.regConPassTxt.TextChanged += new System.EventHandler(this.regConPassTxt_TextChanged);
            this.regConPassTxt.Enter += new System.EventHandler(this.regConPassTxt_Enter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(171, 590);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 25);
            this.label6.TabIndex = 15;
            this.label6.Text = "Confirm PIN";
            // 
            // conNumValidationLbl
            // 
            this.conNumValidationLbl.AutoSize = true;
            this.conNumValidationLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conNumValidationLbl.ForeColor = System.Drawing.Color.Red;
            this.conNumValidationLbl.Location = new System.Drawing.Point(172, 420);
            this.conNumValidationLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.conNumValidationLbl.Name = "conNumValidationLbl";
            this.conNumValidationLbl.Size = new System.Drawing.Size(221, 20);
            this.conNumValidationLbl.TabIndex = 20;
            this.conNumValidationLbl.Text = "*Enter valid Contact Number";
            // 
            // contactNumber
            // 
            this.contactNumber.BorderColor = System.Drawing.Color.Transparent;
            this.contactNumber.BorderRadius = 10;
            this.contactNumber.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.contactNumber.DefaultText = "";
            this.contactNumber.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.contactNumber.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.contactNumber.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.contactNumber.DisabledState.Parent = this.contactNumber;
            this.contactNumber.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.contactNumber.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.contactNumber.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.contactNumber.FocusedState.Parent = this.contactNumber;
            this.contactNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contactNumber.ForeColor = System.Drawing.Color.White;
            this.contactNumber.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.contactNumber.HoverState.Parent = this.contactNumber;
            this.contactNumber.Location = new System.Drawing.Point(176, 362);
            this.contactNumber.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.contactNumber.Name = "contactNumber";
            this.contactNumber.PasswordChar = '\0';
            this.contactNumber.PlaceholderText = "";
            this.contactNumber.SelectedText = "";
            this.contactNumber.ShadowDecoration.Parent = this.contactNumber;
            this.contactNumber.Size = new System.Drawing.Size(520, 50);
            this.contactNumber.TabIndex = 19;
            this.contactNumber.TextChanged += new System.EventHandler(this.contactNumber_TextChanged);
            this.contactNumber.Enter += new System.EventHandler(this.contactNumber_Enter);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(171, 327);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(154, 25);
            this.label8.TabIndex = 18;
            this.label8.Text = "Contact Number";
            // 
            // registerForm
            // 
            this.AcceptButton = this.registerBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(867, 882);
            this.Controls.Add(this.conNumValidationLbl);
            this.Controls.Add(this.contactNumber);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.conPinValidationLbl);
            this.Controls.Add(this.regConPassTxt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pinValidationLbl);
            this.Controls.Add(this.usernameValidationLbl);
            this.Controls.Add(this.loginLbl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.registerBtn);
            this.Controls.Add(this.regUserNameTxt);
            this.Controls.Add(this.regPasswordTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.guna2CirclePictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "registerForm";
            this.Padding = new System.Windows.Forms.Padding(40, 37, 40, 37);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "registerForm";
            this.Load += new System.EventHandler(this.registerForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouse_Down);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mouse_Move);
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private System.Windows.Forms.Label pinValidationLbl;
        private System.Windows.Forms.Label usernameValidationLbl;
        private System.Windows.Forms.Label loginLbl;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2Button registerBtn;
        private Guna.UI2.WinForms.Guna2TextBox regUserNameTxt;
        private Guna.UI2.WinForms.Guna2TextBox regPasswordTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label conPinValidationLbl;
        private Guna.UI2.WinForms.Guna2TextBox regConPassTxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label conNumValidationLbl;
        private Guna.UI2.WinForms.Guna2TextBox contactNumber;
        private System.Windows.Forms.Label label8;
    }
}