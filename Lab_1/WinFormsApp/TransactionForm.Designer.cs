namespace WinFormsApp;

partial class TransactionForm
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransactionForm));
        CardNumberFromBox = new TextBox();
        CardNumberFromLabel = new Label();
        pictureBox1 = new PictureBox();
        AtmFromLabel = new Label();
        AtmFromBox = new TextBox();
        AtmToLabel = new Label();
        AtmToBox = new TextBox();
        CardNumberToLabel = new Label();
        CardNumberToBox = new TextBox();
        AmountLabel = new Label();
        AmountBox = new NumericUpDown();
        ExecuteButton = new Button();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)AmountBox).BeginInit();
        SuspendLayout();
        // 
        // CardNumberFromBox
        // 
        CardNumberFromBox.Enabled = false;
        CardNumberFromBox.Location = new Point(86, 208);
        CardNumberFromBox.Name = "CardNumberFromBox";
        CardNumberFromBox.Size = new Size(155, 27);
        CardNumberFromBox.TabIndex = 2;
        CardNumberFromBox.Visible = false;
        // 
        // CardNumberFromLabel
        // 
        CardNumberFromLabel.AutoSize = true;
        CardNumberFromLabel.Location = new Point(86, 185);
        CardNumberFromLabel.Name = "CardNumberFromLabel";
        CardNumberFromLabel.Size = new Size(140, 20);
        CardNumberFromLabel.TabIndex = 3;
        CardNumberFromLabel.Text = "Card  Number From";
        CardNumberFromLabel.Visible = false;
        // 
        // pictureBox1
        // 
        pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
        pictureBox1.Location = new Point(291, 183);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(200, 121);
        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        pictureBox1.TabIndex = 4;
        pictureBox1.TabStop = false;
        // 
        // AtmFromLabel
        // 
        AtmFromLabel.AutoSize = true;
        AtmFromLabel.Location = new Point(86, 254);
        AtmFromLabel.Name = "AtmFromLabel";
        AtmFromLabel.Size = new Size(77, 20);
        AtmFromLabel.TabIndex = 6;
        AtmFromLabel.Text = "ATM From";
        AtmFromLabel.Visible = false;
        // 
        // AtmFromBox
        // 
        AtmFromBox.Enabled = false;
        AtmFromBox.Location = new Point(86, 277);
        AtmFromBox.Name = "AtmFromBox";
        AtmFromBox.ReadOnly = true;
        AtmFromBox.Size = new Size(155, 27);
        AtmFromBox.TabIndex = 5;
        AtmFromBox.Visible = false;
        // 
        // AtmToLabel
        // 
        AtmToLabel.AutoSize = true;
        AtmToLabel.Location = new Point(539, 254);
        AtmToLabel.Name = "AtmToLabel";
        AtmToLabel.Size = new Size(59, 20);
        AtmToLabel.TabIndex = 10;
        AtmToLabel.Text = "ATM To";
        AtmToLabel.Visible = false;
        // 
        // AtmToBox
        // 
        AtmToBox.Enabled = false;
        AtmToBox.Location = new Point(539, 277);
        AtmToBox.Name = "AtmToBox";
        AtmToBox.ReadOnly = true;
        AtmToBox.Size = new Size(155, 27);
        AtmToBox.TabIndex = 9;
        AtmToBox.Visible = false;
        // 
        // CardNumberToLabel
        // 
        CardNumberToLabel.AutoSize = true;
        CardNumberToLabel.Location = new Point(539, 185);
        CardNumberToLabel.Name = "CardNumberToLabel";
        CardNumberToLabel.Size = new Size(122, 20);
        CardNumberToLabel.TabIndex = 8;
        CardNumberToLabel.Text = "Card  Number To";
        CardNumberToLabel.Visible = false;
        // 
        // CardNumberToBox
        // 
        CardNumberToBox.Enabled = false;
        CardNumberToBox.Location = new Point(539, 208);
        CardNumberToBox.Name = "CardNumberToBox";
        CardNumberToBox.Size = new Size(155, 27);
        CardNumberToBox.TabIndex = 7;
        CardNumberToBox.Visible = false;
        CardNumberToBox.TextChanged += CardNumberToBox_TextChanged;
        // 
        // AmountLabel
        // 
        AmountLabel.AutoSize = true;
        AmountLabel.Location = new Point(313, 347);
        AmountLabel.Name = "AmountLabel";
        AmountLabel.Size = new Size(62, 20);
        AmountLabel.TabIndex = 12;
        AmountLabel.Text = "Amount";
        // 
        // AmountBox
        // 
        AmountBox.DecimalPlaces = 2;
        AmountBox.Location = new Point(313, 370);
        AmountBox.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
        AmountBox.Name = "AmountBox";
        AmountBox.Size = new Size(155, 27);
        AmountBox.TabIndex = 13;
        AmountBox.ValueChanged += AmountBox_ValueChanged;
        // 
        // ExecuteButton
        // 
        ExecuteButton.Dock = DockStyle.Bottom;
        ExecuteButton.Location = new Point(0, 532);
        ExecuteButton.Name = "ExecuteButton";
        ExecuteButton.Size = new Size(771, 29);
        ExecuteButton.TabIndex = 14;
        ExecuteButton.Text = "Execute";
        ExecuteButton.UseVisualStyleBackColor = true;
        ExecuteButton.Click += ExecuteButton_Click;
        // 
        // TransactionForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = SystemColors.GradientActiveCaption;
        ClientSize = new Size(771, 561);
        Controls.Add(ExecuteButton);
        Controls.Add(AmountBox);
        Controls.Add(AmountLabel);
        Controls.Add(AtmToLabel);
        Controls.Add(AtmToBox);
        Controls.Add(CardNumberToLabel);
        Controls.Add(CardNumberToBox);
        Controls.Add(AtmFromLabel);
        Controls.Add(AtmFromBox);
        Controls.Add(pictureBox1);
        Controls.Add(CardNumberFromLabel);
        Controls.Add(CardNumberFromBox);
        MaximumSize = new Size(789, 608);
        Name = "TransactionForm";
        Text = "TransactionForm";
        FormClosed += TransactionForm_FormClosed;
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ((System.ComponentModel.ISupportInitialize)AmountBox).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TextBox CardNumberFromBox;
    private Label CardNumberFromLabel;
    private PictureBox pictureBox1;
    private Label AtmFromLabel;
    private TextBox AtmFromBox;
    private Label AtmToLabel;
    private TextBox AtmToBox;
    private Label CardNumberToLabel;
    private TextBox CardNumberToBox;
    private Label AmountLabel;
    private NumericUpDown AmountBox;
    private Button ExecuteButton;
}