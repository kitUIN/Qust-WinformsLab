using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace GraphicsDecoding
{
    partial class TestForm
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
            this.components = new System.ComponentModel.Container();
            this.timeUsedTimer = new System.Windows.Forms.Timer(this.components);
            this.timeUsed = new System.Windows.Forms.Label();
            this.finishButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timeUsedTimer
            // 
            this.timeUsedTimer.Enabled = true;
            this.timeUsedTimer.Interval = 10;
            this.timeUsedTimer.Tick += new System.EventHandler(this.TimeUsedTimer_Tick);
            // 
            // timeUsed
            // 
            this.timeUsed.AutoSize = true;
            this.timeUsed.Font = new System.Drawing.Font("宋体", 10F);
            this.timeUsed.Location = new System.Drawing.Point(5, 9);
            this.timeUsed.Name = "timeUsed";
            this.timeUsed.Size = new System.Drawing.Size(95, 17);
            this.timeUsed.TabIndex = 0;
            this.timeUsed.Text = "用时: 0 秒";
            // 
            // finishButton
            // 
            this.finishButton.Location = new System.Drawing.Point(144, 3);
            this.finishButton.Name = "finishButton";
            this.finishButton.Size = new System.Drawing.Size(75, 34);
            this.finishButton.TabIndex = 1;
            this.finishButton.Text = "完成";
            this.finishButton.UseVisualStyleBackColor = true;
            this.finishButton.Click += new System.EventHandler(this.finishButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(238, 3);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(92, 34);
            this.clearButton.TabIndex = 2;
            this.clearButton.Text = "清除全部";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 679);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.finishButton);
            this.Controls.Add(this.timeUsed);
            this.Name = "TestForm";
            this.Text = "专注力训练";
            this.Load += new System.EventHandler(this.TestForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Timer timeUsedTimer;
        private Label timeUsed;
        private Button finishButton;
        private Button clearButton;
    }
}