using System.Windows.Forms;

namespace GraphicsDecoding
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
            this.startButton = new System.Windows.Forms.Button();
            this.historyButton = new System.Windows.Forms.Button();
            this.textBoxN = new System.Windows.Forms.TextBox();
            this.textBoxM = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(89, 240);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(110, 60);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "开始测试";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // historyButton
            // 
            this.historyButton.Location = new System.Drawing.Point(473, 240);
            this.historyButton.Name = "historyButton";
            this.historyButton.Size = new System.Drawing.Size(110, 60);
            this.historyButton.TabIndex = 3;
            this.historyButton.Text = "历史记录";
            this.historyButton.UseVisualStyleBackColor = true;
            this.historyButton.Click += new System.EventHandler(this.HistoryButton_Click);
            // 
            // textBoxN
            // 
            this.textBoxN.Location = new System.Drawing.Point(348, 125);
            this.textBoxN.Name = "textBoxN";
            this.textBoxN.Size = new System.Drawing.Size(235, 25);
            this.textBoxN.TabIndex = 5;
            // 
            // textBoxM
            // 
            this.textBoxM.Location = new System.Drawing.Point(367, 178);
            this.textBoxM.Name = "textBoxM";
            this.textBoxM.Size = new System.Drawing.Size(216, 25);
            this.textBoxM.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "设定n个图形(取值范围[5, 20]):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(86, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(260, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "图片方阵的边长m(取值范围[5, 20]):";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 453);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxM);
            this.Controls.Add(this.textBoxN);
            this.Controls.Add(this.historyButton);
            this.Controls.Add(this.startButton);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图形译码";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button historyButton;
        private TextBox textBoxN;
        private TextBox textBoxM;
        private Label label1;
        private Label label2;
    }
}

