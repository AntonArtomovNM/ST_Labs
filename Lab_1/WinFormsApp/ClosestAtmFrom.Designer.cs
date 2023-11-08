namespace WinFormsApp;

partial class ClosestAtmFrom
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
        FindClosestAtmButton = new Button();
        Title = new Label();
        XLAbel = new Label();
        YLabel = new Label();
        XCoordinate = new NumericUpDown();
        YCoordinate = new NumericUpDown();
        ((System.ComponentModel.ISupportInitialize)XCoordinate).BeginInit();
        ((System.ComponentModel.ISupportInitialize)YCoordinate).BeginInit();
        SuspendLayout();
        // 
        // FindClosestAtmButton
        // 
        FindClosestAtmButton.Dock = DockStyle.Bottom;
        FindClosestAtmButton.Location = new Point(0, 532);
        FindClosestAtmButton.Name = "FindClosestAtmButton";
        FindClosestAtmButton.Size = new Size(771, 29);
        FindClosestAtmButton.TabIndex = 0;
        FindClosestAtmButton.Text = "Find Closest ATM";
        FindClosestAtmButton.UseVisualStyleBackColor = true;
        FindClosestAtmButton.Click += FindClosestAtmButton_Click;
        // 
        // Title
        // 
        Title.AutoSize = true;
        Title.BackColor = SystemColors.Control;
        Title.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
        Title.Location = new Point(261, 1);
        Title.Name = "Title";
        Title.Padding = new Padding(0, 5, 0, 5);
        Title.Size = new Size(258, 42);
        Title.TabIndex = 10;
        Title.Text = "Enter Your Coordinates";
        Title.TextAlign = ContentAlignment.TopCenter;
        // 
        // XLAbel
        // 
        XLAbel.AutoSize = true;
        XLAbel.Location = new Point(300, 181);
        XLAbel.Name = "XLAbel";
        XLAbel.Size = new Size(96, 20);
        XLAbel.TabIndex = 13;
        XLAbel.Text = "X Coordinate";
        // 
        // YLabel
        // 
        YLabel.AutoSize = true;
        YLabel.Location = new Point(300, 284);
        YLabel.Name = "YLabel";
        YLabel.Size = new Size(95, 20);
        YLabel.TabIndex = 14;
        YLabel.Text = "Y Coordinate";
        // 
        // XCoordinate
        // 
        XCoordinate.DecimalPlaces = 17;
        XCoordinate.Location = new Point(300, 204);
        XCoordinate.Maximum = new decimal(new int[] { 90, 0, 0, 0 });
        XCoordinate.Minimum = new decimal(new int[] { 90, 0, 0, int.MinValue });
        XCoordinate.Name = "XCoordinate";
        XCoordinate.Size = new Size(176, 27);
        XCoordinate.TabIndex = 15;
        XCoordinate.ValueChanged += XCoordinate_ValueChanged;
        // 
        // YCoordinate
        // 
        YCoordinate.DecimalPlaces = 17;
        YCoordinate.Location = new Point(300, 307);
        YCoordinate.Maximum = new decimal(new int[] { 180, 0, 0, 0 });
        YCoordinate.Minimum = new decimal(new int[] { 180, 0, 0, int.MinValue });
        YCoordinate.Name = "YCoordinate";
        YCoordinate.Size = new Size(176, 27);
        YCoordinate.TabIndex = 16;
        YCoordinate.ValueChanged += YCoordinate_ValueChanged;
        // 
        // ClosestAtmFrom
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = SystemColors.GradientActiveCaption;
        ClientSize = new Size(771, 561);
        Controls.Add(YCoordinate);
        Controls.Add(XCoordinate);
        Controls.Add(YLabel);
        Controls.Add(XLAbel);
        Controls.Add(Title);
        Controls.Add(FindClosestAtmButton);
        MaximumSize = new Size(789, 608);
        Name = "ClosestAtmFrom";
        Text = "ClosestAtmFrom";
        ((System.ComponentModel.ISupportInitialize)XCoordinate).EndInit();
        ((System.ComponentModel.ISupportInitialize)YCoordinate).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button FindClosestAtmButton;
    private Label Title;
    private TextBox XBox;
    private TextBox YBox;
    private Label XLAbel;
    private Label YLabel;
    private NumericUpDown XCoordinate;
    private NumericUpDown YCoordinate;
}