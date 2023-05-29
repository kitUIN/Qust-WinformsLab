using System.Drawing;
using System.Windows.Forms;

namespace GraphicsDecoding
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
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.queryNBox = new System.Windows.Forms.TextBox();
            this.queryButton = new System.Windows.Forms.Button();
            this.openDbButton = new System.Windows.Forms.Button();
            this.queryMBox = new System.Windows.Forms.TextBox();
            this.labelN = new System.Windows.Forms.Label();
            this.labelM = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // historyView
            // 
            this.historyView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
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
            // columnHeader1
            // 
            this.columnHeader1.Text = "N";
            this.columnHeader1.Width = 50;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "M";
            this.columnHeader2.Width = 50;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "开始时间";
            this.columnHeader3.Width = 130;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "用时";
            this.columnHeader4.Width = 50;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "正确率%";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "查询历史记录:";
            // 
            // queryNBox
            // 
            this.queryNBox.Location = new System.Drawing.Point(79, 42);
            this.queryNBox.Name = "queryNBox";
            this.queryNBox.Size = new System.Drawing.Size(153, 25);
            this.queryNBox.TabIndex = 2;
            // 
            // queryButton
            // 
            this.queryButton.Location = new System.Drawing.Point(286, 50);
            this.queryButton.Name = "queryButton";
            this.queryButton.Size = new System.Drawing.Size(75, 36);
            this.queryButton.TabIndex = 4;
            this.queryButton.Text = "查询";
            this.queryButton.UseVisualStyleBackColor = true;
            this.queryButton.Click += new System.EventHandler(this.Query_Click);
            // 
            // openDbButton
            // 
            this.openDbButton.Location = new System.Drawing.Point(418, 48);
            this.openDbButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.openDbButton.Name = "openDbButton";
            this.openDbButton.Size = new System.Drawing.Size(92, 40);
            this.openDbButton.TabIndex = 5;
            this.openDbButton.Text = "打开数据库文件夹";
            this.openDbButton.UseVisualStyleBackColor = true;
            this.openDbButton.Click += new System.EventHandler(this.openDbButton_Click);
            // 
            // queryMBox
            // 
            this.queryMBox.Location = new System.Drawing.Point(79, 71);
            this.queryMBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.queryMBox.Name = "queryMBox";
            this.queryMBox.Size = new System.Drawing.Size(153, 25);
            this.queryMBox.TabIndex = 6;
            // 
            // labelN
            // 
            this.labelN.AutoSize = true;
            this.labelN.Location = new System.Drawing.Point(50, 47);
            this.labelN.Name = "labelN";
            this.labelN.Size = new System.Drawing.Size(23, 15);
            this.labelN.TabIndex = 7;
            this.labelN.Text = "N:";
            // 
            // labelM
            // 
            this.labelM.AutoSize = true;
            this.labelM.Location = new System.Drawing.Point(50, 75);
            this.labelM.Name = "labelM";
            this.labelM.Size = new System.Drawing.Size(23, 15);
            this.labelM.TabIndex = 8;
            this.labelM.Text = "M:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(274, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(236, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "tips: 查询不同N或M请用逗号分隔";
            // 
            // HistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 472);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelM);
            this.Controls.Add(this.labelN);
            this.Controls.Add(this.queryMBox);
            this.Controls.Add(this.openDbButton);
            this.Controls.Add(this.queryButton);
            this.Controls.Add(this.queryNBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.historyView);
            this.Name = "HistoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "历史记录";
            this.Load += new System.EventHandler(this.HistoryForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListView historyView;
        private Label label1;
        private TextBox queryNBox;
        private Button queryButton;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private Button openDbButton;
        private TextBox queryMBox;
        private Label labelN;
        private Label labelM;
        private Label label2;
    }
}