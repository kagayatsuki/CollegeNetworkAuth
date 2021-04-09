
namespace College_Network_Auth
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.studentID = new System.Windows.Forms.TextBox();
            this.pwd_text = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.login_button = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox_ErrorIgnore = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // studentID
            // 
            this.studentID.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.studentID.Location = new System.Drawing.Point(106, 52);
            this.studentID.MaxLength = 12;
            this.studentID.Name = "studentID";
            this.studentID.Size = new System.Drawing.Size(201, 23);
            this.studentID.TabIndex = 1;
            // 
            // pwd_text
            // 
            this.pwd_text.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pwd_text.Location = new System.Drawing.Point(106, 124);
            this.pwd_text.MaxLength = 64;
            this.pwd_text.Name = "pwd_text";
            this.pwd_text.PasswordChar = '*';
            this.pwd_text.Size = new System.Drawing.Size(201, 23);
            this.pwd_text.TabIndex = 2;
            this.pwd_text.KeyUp += new System.Windows.Forms.KeyEventHandler(this.pwd_text_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(70, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "学号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(70, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "密码";
            // 
            // login_button
            // 
            this.login_button.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.login_button.Location = new System.Drawing.Point(138, 194);
            this.login_button.Name = "login_button";
            this.login_button.Size = new System.Drawing.Size(103, 39);
            this.login_button.TabIndex = 5;
            this.login_button.Text = "登录";
            this.login_button.UseVisualStyleBackColor = true;
            this.login_button.Click += new System.EventHandler(this.login_button_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox1.Location = new System.Drawing.Point(248, 193);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(75, 21);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "自动登录";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(0, 252);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(375, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "云南大学滇池学院 20届计科  Copyright shinsya";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBox_ErrorIgnore
            // 
            this.checkBox_ErrorIgnore.AutoSize = true;
            this.checkBox_ErrorIgnore.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox_ErrorIgnore.Location = new System.Drawing.Point(248, 212);
            this.checkBox_ErrorIgnore.Name = "checkBox_ErrorIgnore";
            this.checkBox_ErrorIgnore.Size = new System.Drawing.Size(123, 21);
            this.checkBox_ErrorIgnore.TabIndex = 8;
            this.checkBox_ErrorIgnore.Text = "链接错误忽视模式";
            this.checkBox_ErrorIgnore.UseVisualStyleBackColor = true;
            this.checkBox_ErrorIgnore.CheckedChanged += new System.EventHandler(this.checkBox_ErrorIgnore_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(241, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "(仅对后台线程错误有效)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 269);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkBox_ErrorIgnore);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.login_button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pwd_text);
            this.Controls.Add(this.studentID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Network Auth";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox studentID;
        private System.Windows.Forms.TextBox pwd_text;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button login_button;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox_ErrorIgnore;
        private System.Windows.Forms.Label label4;
    }
}

