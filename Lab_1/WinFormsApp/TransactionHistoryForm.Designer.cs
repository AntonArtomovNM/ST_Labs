namespace WinFormsApp;

partial class TransactionHistoryForm
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
        tableLayoutPanel1 = new TableLayoutPanel();
        TransactionHistoryList = new ListBox();
        TimeRangeBox = new GroupBox();
        TimeRangeRadioButton_Month = new RadioButton();
        TimeRangeRadioButton_Week = new RadioButton();
        TimeRangeRadioButton_Day = new RadioButton();
        TimeRangeRadioButton_None = new RadioButton();
        tableLayoutPanel1.SuspendLayout();
        TimeRangeBox.SuspendLayout();
        SuspendLayout();
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.ColumnCount = 3;
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 90F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
        tableLayoutPanel1.Controls.Add(TransactionHistoryList, 1, 1);
        tableLayoutPanel1.Controls.Add(TimeRangeBox, 1, 0);
        tableLayoutPanel1.Dock = DockStyle.Fill;
        tableLayoutPanel1.Location = new Point(0, 0);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 2;
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
        tableLayoutPanel1.Size = new Size(771, 561);
        tableLayoutPanel1.TabIndex = 0;
        // 
        // TransactionHistoryList
        // 
        TransactionHistoryList.BackColor = SystemColors.ActiveCaption;
        TransactionHistoryList.Dock = DockStyle.Fill;
        TransactionHistoryList.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        TransactionHistoryList.ForeColor = SystemColors.Window;
        TransactionHistoryList.FormattingEnabled = true;
        TransactionHistoryList.HorizontalScrollbar = true;
        TransactionHistoryList.ItemHeight = 20;
        TransactionHistoryList.Location = new Point(41, 227);
        TransactionHistoryList.Name = "TransactionHistoryList";
        TransactionHistoryList.Size = new Size(687, 331);
        TransactionHistoryList.TabIndex = 2;
        // 
        // TimeRangeBox
        // 
        TimeRangeBox.Anchor = AnchorStyles.Left;
        TimeRangeBox.Controls.Add(TimeRangeRadioButton_Month);
        TimeRangeBox.Controls.Add(TimeRangeRadioButton_Week);
        TimeRangeBox.Controls.Add(TimeRangeRadioButton_Day);
        TimeRangeBox.Controls.Add(TimeRangeRadioButton_None);
        TimeRangeBox.Location = new Point(41, 36);
        TimeRangeBox.Name = "TimeRangeBox";
        TimeRangeBox.Size = new Size(250, 152);
        TimeRangeBox.TabIndex = 4;
        TimeRangeBox.TabStop = false;
        TimeRangeBox.Text = "Time Range Options";
        // 
        // TimeRangeRadioButton_Month
        // 
        TimeRangeRadioButton_Month.AutoSize = true;
        TimeRangeRadioButton_Month.Location = new Point(6, 116);
        TimeRangeRadioButton_Month.Name = "TimeRangeRadioButton_Month";
        TimeRangeRadioButton_Month.Size = new Size(73, 24);
        TimeRangeRadioButton_Month.TabIndex = 6;
        TimeRangeRadioButton_Month.TabStop = true;
        TimeRangeRadioButton_Month.Text = "Month";
        TimeRangeRadioButton_Month.UseVisualStyleBackColor = true;
        TimeRangeRadioButton_Month.CheckedChanged += TimeRangeRadioButton_CheckedChanged;
        // 
        // TimeRangeRadioButton_Week
        // 
        TimeRangeRadioButton_Week.AutoSize = true;
        TimeRangeRadioButton_Week.Location = new Point(6, 86);
        TimeRangeRadioButton_Week.Name = "TimeRangeRadioButton_Week";
        TimeRangeRadioButton_Week.Size = new Size(66, 24);
        TimeRangeRadioButton_Week.TabIndex = 5;
        TimeRangeRadioButton_Week.TabStop = true;
        TimeRangeRadioButton_Week.Text = "Week";
        TimeRangeRadioButton_Week.UseVisualStyleBackColor = true;
        TimeRangeRadioButton_Week.CheckedChanged += TimeRangeRadioButton_CheckedChanged;
        // 
        // TimeRangeRadioButton_Day
        // 
        TimeRangeRadioButton_Day.AutoSize = true;
        TimeRangeRadioButton_Day.Location = new Point(6, 56);
        TimeRangeRadioButton_Day.Name = "TimeRangeRadioButton_Day";
        TimeRangeRadioButton_Day.Size = new Size(56, 24);
        TimeRangeRadioButton_Day.TabIndex = 4;
        TimeRangeRadioButton_Day.TabStop = true;
        TimeRangeRadioButton_Day.Text = "Day";
        TimeRangeRadioButton_Day.UseVisualStyleBackColor = true;
        TimeRangeRadioButton_Day.CheckedChanged += TimeRangeRadioButton_CheckedChanged;
        // 
        // TimeRangeRadioButton_None
        // 
        TimeRangeRadioButton_None.AutoSize = true;
        TimeRangeRadioButton_None.Location = new Point(6, 26);
        TimeRangeRadioButton_None.Name = "TimeRangeRadioButton_None";
        TimeRangeRadioButton_None.Size = new Size(66, 24);
        TimeRangeRadioButton_None.TabIndex = 3;
        TimeRangeRadioButton_None.TabStop = true;
        TimeRangeRadioButton_None.Text = "None";
        TimeRangeRadioButton_None.UseVisualStyleBackColor = true;
        TimeRangeRadioButton_None.CheckedChanged += TimeRangeRadioButton_CheckedChanged;
        // 
        // TransactionHistoryForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = SystemColors.GradientActiveCaption;
        ClientSize = new Size(771, 561);
        Controls.Add(tableLayoutPanel1);
        MaximumSize = new Size(789, 608);
        Name = "TransactionHistoryForm";
        Text = "TransactionHistoryForm";
        tableLayoutPanel1.ResumeLayout(false);
        TimeRangeBox.ResumeLayout(false);
        TimeRangeBox.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel1;
    private ListBox TransactionHistoryList;
    private RadioButton TimeRangeRadioButton_None;
    private GroupBox TimeRangeBox;
    private RadioButton TimeRangeRadioButton_Day;
    private RadioButton TimeRangeRadioButton_Week;
    private RadioButton TimeRangeRadioButton_Month;
}