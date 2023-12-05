namespace UI;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        EncryptFileButton = new Button();
        DecryptFileButton = new Button();
        CancelButton = new Button();
        PauseButton = new Button();
        ProgressBar = new ProgressBar();
        ProcessBackgroundWorker = new System.ComponentModel.BackgroundWorker();
        TimerLabel = new Label();
        SuspendLayout();
        // 
        // EncryptFileButton
        // 
        EncryptFileButton.Location = new Point(68, 328);
        EncryptFileButton.Name = "EncryptFileButton";
        EncryptFileButton.Size = new Size(121, 35);
        EncryptFileButton.TabIndex = 0;
        EncryptFileButton.Text = "Encrypt File";
        EncryptFileButton.UseVisualStyleBackColor = true;
        EncryptFileButton.Click += EncryptFileButton_Click;
        // 
        // DecryptFileButton
        // 
        DecryptFileButton.Location = new Point(207, 328);
        DecryptFileButton.Name = "DecryptFileButton";
        DecryptFileButton.Size = new Size(121, 35);
        DecryptFileButton.TabIndex = 1;
        DecryptFileButton.Text = "Decrypt File";
        DecryptFileButton.UseVisualStyleBackColor = true;
        DecryptFileButton.Click += DecryptFileButton_Click;
        // 
        // CancelButton
        // 
        CancelButton.Location = new Point(608, 328);
        CancelButton.Name = "CancelButton";
        CancelButton.Size = new Size(121, 35);
        CancelButton.TabIndex = 3;
        CancelButton.Text = "Cancel";
        CancelButton.UseVisualStyleBackColor = true;
        CancelButton.Click += CancelButton_Click;
        // 
        // PauseButton
        // 
        PauseButton.Location = new Point(469, 328);
        PauseButton.Name = "PauseButton";
        PauseButton.Size = new Size(121, 35);
        PauseButton.TabIndex = 2;
        PauseButton.Text = "Pause";
        PauseButton.UseVisualStyleBackColor = true;
        PauseButton.Click += PauseButton_Click;
        // 
        // ProgressBar
        // 
        ProgressBar.Location = new Point(68, 175);
        ProgressBar.Name = "ProgressBar";
        ProgressBar.Size = new Size(661, 22);
        ProgressBar.TabIndex = 4;
        // 
        // ProcessBackgroundWorker
        // 
        ProcessBackgroundWorker.WorkerReportsProgress = true;
        ProcessBackgroundWorker.WorkerSupportsCancellation = true;
        // 
        // TimerLabel
        // 
        TimerLabel.AutoSize = true;
        TimerLabel.Location = new Point(68, 200);
        TimerLabel.Name = "TimerLabel";
        TimerLabel.Size = new Size(83, 20);
        TimerLabel.TabIndex = 5;
        TimerLabel.Text = "TimerLabel";
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.LightBlue;
        ClientSize = new Size(800, 450);
        Controls.Add(TimerLabel);
        Controls.Add(ProgressBar);
        Controls.Add(CancelButton);
        Controls.Add(PauseButton);
        Controls.Add(DecryptFileButton);
        Controls.Add(EncryptFileButton);
        Name = "MainForm";
        Text = "File Encryptor";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button EncryptFileButton;
    private Button DecryptFileButton;
    private Button CancelButton;
    private Button PauseButton;
    private ProgressBar ProgressBar;
    private System.ComponentModel.BackgroundWorker ProcessBackgroundWorker;
    private Label TimerLabel;
}
