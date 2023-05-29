using System.Windows.Forms;

namespace SchulteGrid
{
    partial class MainForm
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
            this.title = new System.Windows.Forms.Label();
            this.difficultyBox = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.historyButton = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Location = new System.Drawing.Point(100, 100);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(168, 15);
            this.title.TabIndex = 0;
            this.title.Text = "请选择难度等级(3-10):";
            // 
            // difficultyBox
            // 
            this.difficultyBox.Location = new System.Drawing.Point(275, 96);
            this.difficultyBox.Name = "difficultyBox";
            this.difficultyBox.Size = new System.Drawing.Size(172, 25);
            this.difficultyBox.TabIndex = 1;
            this.difficultyBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DifficultyBox_KeyDown);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(103, 208);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(110, 60);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "开始测试";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // historyButton
            // 
            this.historyButton.Location = new System.Drawing.Point(337, 208);
            this.historyButton.Name = "historyButton";
            this.historyButton.Size = new System.Drawing.Size(110, 60);
            this.historyButton.TabIndex = 3;
            this.historyButton.Text = "历史记录";
            this.historyButton.UseVisualStyleBackColor = true;
            this.historyButton.Click += new System.EventHandler(this.HistoryButton_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(275, 138);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(89, 19);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "消除模式";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 453);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.historyButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.difficultyBox);
            this.Controls.Add(this.title);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "舒尔特方格";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.TextBox difficultyBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button historyButton;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

