using System.Drawing;
using System.Windows.Forms;

namespace SchulteGrid
{
    partial class HistoryForm
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
            this.historyView = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.queryBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.queryButton = new System.Windows.Forms.Button();
            this.openDbButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // historyView
            // 
            this.historyView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.historyView.HideSelection = false;
            this.historyView.Location = new System.Drawing.Point(47, 104);
            this.historyView.Name = "historyView";
            this.historyView.Size = new System.Drawing.Size(463, 334);
            this.historyView.TabIndex = 0;
            this.historyView.UseCompatibleStateImageBehavior = false;
            this.historyView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "难度";
            this.columnHeader3.Width = 70;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "开始时间";
            this.columnHeader4.Width = 180;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "用时";
            this.columnHeader5.Width = 99;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "查询难度历史记录(3-10):";
            // 
            // queryBox
            // 
            this.queryBox.Location = new System.Drawing.Point(237, 28);
            this.queryBox.Name = "queryBox";
            this.queryBox.Size = new System.Drawing.Size(273, 25);
            this.queryBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(156, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(235, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "tips: 查询不同难度请用逗号分隔";
            // 
            // queryButton
            // 
            this.queryButton.Location = new System.Drawing.Point(435, 56);
            this.queryButton.Name = "queryButton";
            this.queryButton.Size = new System.Drawing.Size(75, 36);
            this.queryButton.TabIndex = 4;
            this.queryButton.Text = "查询";
            this.queryButton.UseVisualStyleBackColor = true;
            this.queryButton.Click += new System.EventHandler(this.QueryButton_Click);
            // 
            // openDbButton
            // 
            this.openDbButton.Location = new System.Drawing.Point(47, 56);
            this.openDbButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.openDbButton.Name = "openDbButton";
            this.openDbButton.Size = new System.Drawing.Size(92, 40);
            this.openDbButton.TabIndex = 5;
            this.openDbButton.Text = "打开数据库文件夹";
            this.openDbButton.UseVisualStyleBackColor = true;
            this.openDbButton.Click += new System.EventHandler(this.OpenDbButton_Click);
            // 
            // historyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 472);
            this.Controls.Add(this.openDbButton);
            this.Controls.Add(this.queryButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.queryBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.historyView);
            this.Name = "historyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "历史记录";
            this.Load += new System.EventHandler(this.HistoryForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListView historyView;
        private Label label1;
        private TextBox queryBox;
        private Label label2;
        private Button queryButton;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private Button openDbButton;
    }
}