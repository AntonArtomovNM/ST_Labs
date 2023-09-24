namespace WinFormsApp;

partial class MainMenuForm
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
        ShowBalanceButton = new Button();
        TransactionHistoryButton = new Button();
        ClosestAtmButton = new Button();
        InternalTransferButton = new Button();
        DepositTransferButton = new Button();
        WithdrawalTransferButton = new Button();
        ExitButton = new Button();
        Title = new Label();
        toolStripMenuItem1 = new ToolStripMenuItem();
        tableLayoutPanel1.SuspendLayout();
        SuspendLayout();
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.BackColor = SystemColors.GradientActiveCaption;
        tableLayoutPanel1.ColumnCount = 5;
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
        tableLayoutPanel1.Controls.Add(ShowBalanceButton, 0, 1);
        tableLayoutPanel1.Controls.Add(TransactionHistoryButton, 0, 2);
        tableLayoutPanel1.Controls.Add(ClosestAtmButton, 0, 3);
        tableLayoutPanel1.Controls.Add(InternalTransferButton, 4, 1);
        tableLayoutPanel1.Controls.Add(DepositTransferButton, 4, 2);
        tableLayoutPanel1.Controls.Add(WithdrawalTransferButton, 4, 3);
        tableLayoutPanel1.Controls.Add(ExitButton, 4, 4);
        tableLayoutPanel1.Controls.Add(Title, 2, 0);
        tableLayoutPanel1.Dock = DockStyle.Fill;
        tableLayoutPanel1.Location = new Point(0, 0);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 6;
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
        tableLayoutPanel1.Size = new Size(1023, 724);
        tableLayoutPanel1.TabIndex = 0;
        // 
        // ShowBalanceButton
        // 
        ShowBalanceButton.Dock = DockStyle.Fill;
        ShowBalanceButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
        ShowBalanceButton.Location = new Point(3, 123);
        ShowBalanceButton.Name = "ShowBalanceButton";
        ShowBalanceButton.Size = new Size(198, 114);
        ShowBalanceButton.TabIndex = 0;
        ShowBalanceButton.Text = "Show Balance";
        ShowBalanceButton.UseVisualStyleBackColor = true;
        ShowBalanceButton.Click += ShowBalanceButton_Click;
        // 
        // TransactionHistoryButton
        // 
        TransactionHistoryButton.Dock = DockStyle.Fill;
        TransactionHistoryButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
        TransactionHistoryButton.Location = new Point(3, 243);
        TransactionHistoryButton.Name = "TransactionHistoryButton";
        TransactionHistoryButton.Size = new Size(198, 114);
        TransactionHistoryButton.TabIndex = 1;
        TransactionHistoryButton.Text = "Transaction History";
        TransactionHistoryButton.UseVisualStyleBackColor = true;
        TransactionHistoryButton.Click += TransactionHistoryButton_Click;
        // 
        // ClosestAtmButton
        // 
        ClosestAtmButton.Dock = DockStyle.Fill;
        ClosestAtmButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
        ClosestAtmButton.Location = new Point(3, 363);
        ClosestAtmButton.Name = "ClosestAtmButton";
        ClosestAtmButton.Size = new Size(198, 114);
        ClosestAtmButton.TabIndex = 3;
        ClosestAtmButton.Text = "Closest ATM";
        ClosestAtmButton.UseVisualStyleBackColor = true;
        ClosestAtmButton.Click += ClosestAtmButton_Click;
        // 
        // InternalTransferButton
        // 
        InternalTransferButton.Dock = DockStyle.Fill;
        InternalTransferButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
        InternalTransferButton.Location = new Point(820, 123);
        InternalTransferButton.Name = "InternalTransferButton";
        InternalTransferButton.Size = new Size(200, 114);
        InternalTransferButton.TabIndex = 4;
        InternalTransferButton.Text = "Internal Transfer";
        InternalTransferButton.UseVisualStyleBackColor = true;
        InternalTransferButton.Click += InternalTransferButton_Click;
        // 
        // DepositTransferButton
        // 
        DepositTransferButton.Dock = DockStyle.Fill;
        DepositTransferButton.Enabled = false;
        DepositTransferButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
        DepositTransferButton.Location = new Point(820, 243);
        DepositTransferButton.Name = "DepositTransferButton";
        DepositTransferButton.Size = new Size(200, 114);
        DepositTransferButton.TabIndex = 6;
        DepositTransferButton.Text = "Deposit Transfer";
        DepositTransferButton.UseVisualStyleBackColor = true;
        DepositTransferButton.Visible = false;
        DepositTransferButton.Click += DepositTransferButton_Click;
        // 
        // WithdrawalTransferButton
        // 
        WithdrawalTransferButton.Dock = DockStyle.Fill;
        WithdrawalTransferButton.Enabled = false;
        WithdrawalTransferButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
        WithdrawalTransferButton.Location = new Point(820, 363);
        WithdrawalTransferButton.Name = "WithdrawalTransferButton";
        WithdrawalTransferButton.Size = new Size(200, 114);
        WithdrawalTransferButton.TabIndex = 7;
        WithdrawalTransferButton.Text = "Withdrawal Transfer";
        WithdrawalTransferButton.UseVisualStyleBackColor = true;
        WithdrawalTransferButton.Visible = false;
        WithdrawalTransferButton.Click += WithdrawalTransferButton_Click;
        // 
        // ExitButton
        // 
        ExitButton.Dock = DockStyle.Fill;
        ExitButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
        ExitButton.Location = new Point(820, 483);
        ExitButton.Name = "ExitButton";
        ExitButton.Size = new Size(200, 114);
        ExitButton.TabIndex = 8;
        ExitButton.Text = "Exit";
        ExitButton.UseVisualStyleBackColor = true;
        ExitButton.Click += ExitButton_Click;
        // 
        // Title
        // 
        Title.AutoSize = true;
        Title.BackColor = SystemColors.Control;
        Title.Dock = DockStyle.Top;
        Title.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
        Title.Location = new Point(299, 0);
        Title.Name = "Title";
        Title.Padding = new Padding(0, 5, 0, 5);
        Title.Size = new Size(423, 42);
        Title.TabIndex = 9;
        Title.Text = "Select your option";
        Title.TextAlign = ContentAlignment.TopCenter;
        // 
        // toolStripMenuItem1
        // 
        toolStripMenuItem1.Name = "toolStripMenuItem1";
        toolStripMenuItem1.Size = new Size(210, 22);
        // 
        // MainMenuForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = SystemColors.ActiveCaption;
        ClientSize = new Size(1023, 724);
        ControlBox = false;
        Controls.Add(tableLayoutPanel1);
        Name = "MainMenuForm";
        Text = "MainMenuForm";
        FormClosed += MainMenuForm_FormClosed;
        Load += MainMenuForm_Load;
        tableLayoutPanel1.ResumeLayout(false);
        tableLayoutPanel1.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel1;
    private Button ShowBalanceButton;
    private Button TransactionHistoryButton;
    private Button ClosestAtmButton;
    private Button InternalTransferButton;
    private Button DepositTransferButton;
    private Button WithdrawalTransferButton;
    private Button ExitButton;
    private ToolStripMenuItem toolStripMenuItem1;
    private Label Title;
}