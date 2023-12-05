namespace UI.Forms;

partial class EncryptionKeyForm
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
        KeyTextBox = new TextBox();
        label1 = new Label();
        EnterButton = new Button();
        SuspendLayout();
        // 
        // KeyTextBox
        // 
        KeyTextBox.Location = new Point(273, 206);
        KeyTextBox.Name = "KeyTextBox";
        KeyTextBox.Size = new Size(272, 27);
        KeyTextBox.TabIndex = 0;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
        label1.Location = new Point(273, 178);
        label1.Name = "label1";
        label1.Size = new Size(184, 25);
        label1.TabIndex = 1;
        label1.Text = "Enter encryption key";
        // 
        // EnterButton
        // 
        EnterButton.Location = new Point(346, 336);
        EnterButton.Name = "EnterButton";
        EnterButton.Size = new Size(121, 35);
        EnterButton.TabIndex = 2;
        EnterButton.Text = "Enter";
        EnterButton.UseVisualStyleBackColor = true;
        EnterButton.Click += EnterButton_Click;
        // 
        // EncryptionKeyForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.LightBlue;
        ClientSize = new Size(800, 450);
        Controls.Add(EnterButton);
        Controls.Add(label1);
        Controls.Add(KeyTextBox);
        Name = "EncryptionKeyForm";
        Text = "Encryption Key";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TextBox KeyTextBox;
    private Label label1;
    private Button EnterButton;
}