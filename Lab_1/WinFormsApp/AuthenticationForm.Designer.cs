namespace WinFormsApp;

partial class AuthenticationForm
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
        AuthenticateButton = new Button();
        CardNumberBox = new TextBox();
        CardNumberLabel = new Label();
        PincodeLabel = new Label();
        PincodeBox = new MaskedTextBox();
        SuspendLayout();
        // 
        // AuthenticateButton
        // 
        AuthenticateButton.Dock = DockStyle.Bottom;
        AuthenticateButton.Location = new Point(0, 524);
        AuthenticateButton.Name = "AuthenticateButton";
        AuthenticateButton.Size = new Size(771, 37);
        AuthenticateButton.TabIndex = 0;
        AuthenticateButton.Text = "Authenticate";
        AuthenticateButton.UseVisualStyleBackColor = true;
        AuthenticateButton.Click += AuthenticateButton_Click;
        // 
        // CardNumberBox
        // 
        CardNumberBox.Location = new Point(312, 204);
        CardNumberBox.Name = "CardNumberBox";
        CardNumberBox.Size = new Size(155, 27);
        CardNumberBox.TabIndex = 1;
        CardNumberBox.TextChanged += CardNumberBox_TextChanged;
        // 
        // CardNumberLabel
        // 
        CardNumberLabel.AutoSize = true;
        CardNumberLabel.Location = new Point(312, 181);
        CardNumberLabel.Name = "CardNumberLabel";
        CardNumberLabel.Size = new Size(98, 20);
        CardNumberLabel.TabIndex = 2;
        CardNumberLabel.Text = "Card Number";
        // 
        // PincodeLabel
        // 
        PincodeLabel.AutoSize = true;
        PincodeLabel.Location = new Point(312, 285);
        PincodeLabel.Name = "PincodeLabel";
        PincodeLabel.Size = new Size(32, 20);
        PincodeLabel.TabIndex = 4;
        PincodeLabel.Text = "PIN";
        // 
        // PincodeBox
        // 
        PincodeBox.HidePromptOnLeave = true;
        PincodeBox.Location = new Point(312, 308);
        PincodeBox.Mask = "0000";
        PincodeBox.Name = "PincodeBox";
        PincodeBox.PasswordChar = '*';
        PincodeBox.Size = new Size(155, 27);
        PincodeBox.TabIndex = 5;
        PincodeBox.ValidatingType = typeof(int);
        PincodeBox.TextChanged += PincodeBox_TextChanged;
        // 
        // AuthenticationForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = SystemColors.GradientActiveCaption;
        ClientSize = new Size(771, 561);
        ControlBox = false;
        Controls.Add(PincodeBox);
        Controls.Add(PincodeLabel);
        Controls.Add(CardNumberLabel);
        Controls.Add(CardNumberBox);
        Controls.Add(AuthenticateButton);
        MaximumSize = new Size(789, 608);
        Name = "AuthenticationForm";
        Text = "AuthenticationForm";
        FormClosed += AuthenticationForm_FormClosed;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button AuthenticateButton;
    private TextBox CardNumberBox;
    private Label CardNumberLabel;
    private Label PincodeLabel;
    private MaskedTextBox PincodeBox;
}