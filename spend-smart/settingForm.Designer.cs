namespace spend_smart
{
    partial class settingForm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel4 = new Guna.UI2.WinForms.Guna2Panel();
            this.changeTheme = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.selectLan = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnChangePin = new Guna.UI2.WinForms.Guna2Button();
            this.txtCNewPin = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtNewPin = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtCurrentPin = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel5 = new Guna.UI2.WinForms.Guna2Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPin = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnDelData = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel4.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.guna2Panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.BorderRadius = 15;
            this.guna2Panel1.Controls.Add(this.guna2Panel4);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Controls.Add(this.guna2Panel2);
            this.guna2Panel1.Controls.Add(this.guna2Panel3);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(1157, 704);
            this.guna2Panel1.TabIndex = 0;
            // 
            // guna2Panel4
            // 
            this.guna2Panel4.Controls.Add(this.changeTheme);
            this.guna2Panel4.Controls.Add(this.selectLan);
            this.guna2Panel4.Controls.Add(this.label4);
            this.guna2Panel4.Controls.Add(this.label3);
            this.guna2Panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel4.Location = new System.Drawing.Point(0, 469);
            this.guna2Panel4.Name = "guna2Panel4";
            this.guna2Panel4.ShadowDecoration.Parent = this.guna2Panel4;
            this.guna2Panel4.Size = new System.Drawing.Size(1157, 235);
            this.guna2Panel4.TabIndex = 13;
            // 
            // changeTheme
            // 
            this.changeTheme.Animated = true;
            this.changeTheme.AutoRoundedCorners = true;
            this.changeTheme.BackColor = System.Drawing.Color.Transparent;
            this.changeTheme.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.changeTheme.CheckedState.BorderRadius = 18;
            this.changeTheme.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.changeTheme.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.changeTheme.CheckedState.InnerBorderRadius = 14;
            this.changeTheme.CheckedState.InnerColor = System.Drawing.Color.White;
            this.changeTheme.CheckedState.Parent = this.changeTheme;
            this.changeTheme.Location = new System.Drawing.Point(276, 103);
            this.changeTheme.Name = "changeTheme";
            this.changeTheme.ShadowDecoration.Parent = this.changeTheme;
            this.changeTheme.Size = new System.Drawing.Size(87, 38);
            this.changeTheme.TabIndex = 13;
            this.changeTheme.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.changeTheme.UncheckedState.BorderRadius = 18;
            this.changeTheme.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.changeTheme.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.changeTheme.UncheckedState.InnerBorderRadius = 14;
            this.changeTheme.UncheckedState.InnerColor = System.Drawing.Color.White;
            this.changeTheme.UncheckedState.Parent = this.changeTheme;
            this.changeTheme.Click += new System.EventHandler(this.changeTheme_Click);
            // 
            // selectLan
            // 
            this.selectLan.BackColor = System.Drawing.Color.Transparent;
            this.selectLan.BorderColor = System.Drawing.Color.Transparent;
            this.selectLan.BorderRadius = 8;
            this.selectLan.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.selectLan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectLan.FillColor = System.Drawing.Color.DimGray;
            this.selectLan.FocusedColor = System.Drawing.Color.Empty;
            this.selectLan.FocusedState.Parent = this.selectLan;
            this.selectLan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.selectLan.ForeColor = System.Drawing.Color.White;
            this.selectLan.FormattingEnabled = true;
            this.selectLan.HoverState.Parent = this.selectLan;
            this.selectLan.ItemHeight = 30;
            this.selectLan.ItemsAppearance.Parent = this.selectLan;
            this.selectLan.Location = new System.Drawing.Point(276, 31);
            this.selectLan.Name = "selectLan";
            this.selectLan.ShadowDecoration.Parent = this.selectLan;
            this.selectLan.Size = new System.Drawing.Size(179, 36);
            this.selectLan.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(44, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(201, 25);
            this.label4.TabIndex = 11;
            this.label4.Text = "Change Color Theme";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(44, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 25);
            this.label3.TabIndex = 11;
            this.label3.Text = "Change Language";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(44, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 29);
            this.label1.TabIndex = 11;
            this.label1.Text = "Settings";
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Controls.Add(this.guna2Panel5);
            this.guna2Panel2.Controls.Add(this.btnChangePin);
            this.guna2Panel2.Controls.Add(this.txtCNewPin);
            this.guna2Panel2.Controls.Add(this.txtNewPin);
            this.guna2Panel2.Controls.Add(this.txtCurrentPin);
            this.guna2Panel2.Controls.Add(this.label2);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel2.Location = new System.Drawing.Point(0, 100);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.Parent = this.guna2Panel2;
            this.guna2Panel2.Size = new System.Drawing.Size(1157, 369);
            this.guna2Panel2.TabIndex = 12;
            // 
            // btnChangePin
            // 
            this.btnChangePin.BorderRadius = 10;
            this.btnChangePin.CheckedState.Parent = this.btnChangePin;
            this.btnChangePin.CustomImages.Parent = this.btnChangePin;
            this.btnChangePin.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.btnChangePin.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangePin.ForeColor = System.Drawing.Color.White;
            this.btnChangePin.HoverState.Parent = this.btnChangePin;
            this.btnChangePin.Location = new System.Drawing.Point(49, 288);
            this.btnChangePin.Margin = new System.Windows.Forms.Padding(4);
            this.btnChangePin.Name = "btnChangePin";
            this.btnChangePin.ShadowDecoration.Parent = this.btnChangePin;
            this.btnChangePin.Size = new System.Drawing.Size(187, 55);
            this.btnChangePin.TabIndex = 13;
            this.btnChangePin.Text = "Submit";
            this.btnChangePin.Click += new System.EventHandler(this.btnChangePin_Click);
            // 
            // txtCNewPin
            // 
            this.txtCNewPin.BorderColor = System.Drawing.Color.DimGray;
            this.txtCNewPin.BorderRadius = 8;
            this.txtCNewPin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCNewPin.DefaultText = "";
            this.txtCNewPin.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCNewPin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCNewPin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCNewPin.DisabledState.Parent = this.txtCNewPin;
            this.txtCNewPin.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCNewPin.FillColor = System.Drawing.Color.DimGray;
            this.txtCNewPin.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCNewPin.FocusedState.Parent = this.txtCNewPin;
            this.txtCNewPin.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCNewPin.ForeColor = System.Drawing.Color.White;
            this.txtCNewPin.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCNewPin.HoverState.Parent = this.txtCNewPin;
            this.txtCNewPin.Location = new System.Drawing.Point(49, 210);
            this.txtCNewPin.Margin = new System.Windows.Forms.Padding(5);
            this.txtCNewPin.Name = "txtCNewPin";
            this.txtCNewPin.PasswordChar = '\0';
            this.txtCNewPin.PlaceholderForeColor = System.Drawing.Color.White;
            this.txtCNewPin.PlaceholderText = "Confirm New PIN";
            this.txtCNewPin.SelectedText = "";
            this.txtCNewPin.ShadowDecoration.Parent = this.txtCNewPin;
            this.txtCNewPin.Size = new System.Drawing.Size(438, 55);
            this.txtCNewPin.TabIndex = 12;
            // 
            // txtNewPin
            // 
            this.txtNewPin.BorderColor = System.Drawing.Color.DimGray;
            this.txtNewPin.BorderRadius = 8;
            this.txtNewPin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNewPin.DefaultText = "";
            this.txtNewPin.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNewPin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNewPin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNewPin.DisabledState.Parent = this.txtNewPin;
            this.txtNewPin.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNewPin.FillColor = System.Drawing.Color.DimGray;
            this.txtNewPin.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNewPin.FocusedState.Parent = this.txtNewPin;
            this.txtNewPin.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPin.ForeColor = System.Drawing.Color.White;
            this.txtNewPin.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNewPin.HoverState.Parent = this.txtNewPin;
            this.txtNewPin.Location = new System.Drawing.Point(49, 145);
            this.txtNewPin.Margin = new System.Windows.Forms.Padding(5);
            this.txtNewPin.Name = "txtNewPin";
            this.txtNewPin.PasswordChar = '\0';
            this.txtNewPin.PlaceholderForeColor = System.Drawing.Color.White;
            this.txtNewPin.PlaceholderText = "New PIN";
            this.txtNewPin.SelectedText = "";
            this.txtNewPin.ShadowDecoration.Parent = this.txtNewPin;
            this.txtNewPin.Size = new System.Drawing.Size(438, 55);
            this.txtNewPin.TabIndex = 12;
            // 
            // txtCurrentPin
            // 
            this.txtCurrentPin.BorderColor = System.Drawing.Color.DimGray;
            this.txtCurrentPin.BorderRadius = 8;
            this.txtCurrentPin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCurrentPin.DefaultText = "";
            this.txtCurrentPin.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCurrentPin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCurrentPin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCurrentPin.DisabledState.Parent = this.txtCurrentPin;
            this.txtCurrentPin.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCurrentPin.FillColor = System.Drawing.Color.DimGray;
            this.txtCurrentPin.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCurrentPin.FocusedState.Parent = this.txtCurrentPin;
            this.txtCurrentPin.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrentPin.ForeColor = System.Drawing.Color.White;
            this.txtCurrentPin.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCurrentPin.HoverState.Parent = this.txtCurrentPin;
            this.txtCurrentPin.Location = new System.Drawing.Point(49, 80);
            this.txtCurrentPin.Margin = new System.Windows.Forms.Padding(5);
            this.txtCurrentPin.Name = "txtCurrentPin";
            this.txtCurrentPin.PasswordChar = '\0';
            this.txtCurrentPin.PlaceholderForeColor = System.Drawing.Color.White;
            this.txtCurrentPin.PlaceholderText = "Current PIN";
            this.txtCurrentPin.SelectedText = "";
            this.txtCurrentPin.ShadowDecoration.Parent = this.txtCurrentPin;
            this.txtCurrentPin.Size = new System.Drawing.Size(438, 55);
            this.txtCurrentPin.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(44, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 25);
            this.label2.TabIndex = 11;
            this.label2.Text = "Change Password";
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel3.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.ShadowDecoration.Parent = this.guna2Panel3;
            this.guna2Panel3.Size = new System.Drawing.Size(1157, 100);
            this.guna2Panel3.TabIndex = 13;
            // 
            // guna2Panel5
            // 
            this.guna2Panel5.Controls.Add(this.btnDelData);
            this.guna2Panel5.Controls.Add(this.label5);
            this.guna2Panel5.Controls.Add(this.txtPin);
            this.guna2Panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.guna2Panel5.Location = new System.Drawing.Point(640, 0);
            this.guna2Panel5.Name = "guna2Panel5";
            this.guna2Panel5.ShadowDecoration.Parent = this.guna2Panel5;
            this.guna2Panel5.Size = new System.Drawing.Size(517, 369);
            this.guna2Panel5.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(205, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 25);
            this.label5.TabIndex = 11;
            this.label5.Text = "Reset App";
            // 
            // txtPin
            // 
            this.txtPin.BorderColor = System.Drawing.Color.DimGray;
            this.txtPin.BorderRadius = 8;
            this.txtPin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPin.DefaultText = "";
            this.txtPin.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPin.DisabledState.Parent = this.txtPin;
            this.txtPin.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPin.FillColor = System.Drawing.Color.DimGray;
            this.txtPin.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPin.FocusedState.Parent = this.txtPin;
            this.txtPin.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPin.ForeColor = System.Drawing.Color.White;
            this.txtPin.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPin.HoverState.Parent = this.txtPin;
            this.txtPin.Location = new System.Drawing.Point(105, 100);
            this.txtPin.Margin = new System.Windows.Forms.Padding(5);
            this.txtPin.Name = "txtPin";
            this.txtPin.PasswordChar = '\0';
            this.txtPin.PlaceholderForeColor = System.Drawing.Color.White;
            this.txtPin.PlaceholderText = "Enter your current PIN";
            this.txtPin.SelectedText = "";
            this.txtPin.ShadowDecoration.Parent = this.txtPin;
            this.txtPin.Size = new System.Drawing.Size(295, 55);
            this.txtPin.TabIndex = 12;
            // 
            // btnDelData
            // 
            this.btnDelData.BorderColor = System.Drawing.Color.Red;
            this.btnDelData.BorderRadius = 10;
            this.btnDelData.BorderThickness = 2;
            this.btnDelData.CheckedState.Parent = this.btnDelData;
            this.btnDelData.CustomImages.Parent = this.btnDelData;
            this.btnDelData.FillColor = System.Drawing.Color.Transparent;
            this.btnDelData.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelData.ForeColor = System.Drawing.Color.White;
            this.btnDelData.HoverState.Parent = this.btnDelData;
            this.btnDelData.Location = new System.Drawing.Point(105, 188);
            this.btnDelData.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelData.Name = "btnDelData";
            this.btnDelData.ShadowDecoration.Parent = this.btnDelData;
            this.btnDelData.Size = new System.Drawing.Size(295, 55);
            this.btnDelData.TabIndex = 13;
            this.btnDelData.Text = "Delete All data";
            this.btnDelData.Click += new System.EventHandler(this.btnDelData_Click);
            // 
            // settingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(44)))));
            this.Controls.Add(this.guna2Panel1);
            this.Name = "settingForm";
            this.Size = new System.Drawing.Size(1157, 704);
            this.Load += new System.EventHandler(this.settingForm_load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.guna2Panel4.ResumeLayout(false);
            this.guna2Panel4.PerformLayout();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.guna2Panel5.ResumeLayout(false);
            this.guna2Panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel4;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2TextBox txtCNewPin;
        private Guna.UI2.WinForms.Guna2TextBox txtNewPin;
        private Guna.UI2.WinForms.Guna2TextBox txtCurrentPin;
        private Guna.UI2.WinForms.Guna2Button btnChangePin;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2ComboBox selectLan;
        private Guna.UI2.WinForms.Guna2ToggleSwitch changeTheme;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel5;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2TextBox txtPin;
        private Guna.UI2.WinForms.Guna2Button btnDelData;
    }
}
