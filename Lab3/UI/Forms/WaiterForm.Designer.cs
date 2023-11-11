namespace UI.Forms;

partial class WaiterForm
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
        components = new System.ComponentModel.Container();
        splitContainer1 = new SplitContainer();
        panel1 = new Panel();
        DataGridView = new DataGridView();
        GridMenuStrip = new ContextMenuStrip(components);
        deleteToolStripMenuItem = new ToolStripMenuItem();
        panel2 = new Panel();
        RatingInput = new NumericUpDown();
        label6 = new Label();
        SalaryInput = new NumericUpDown();
        label5 = new Label();
        AddButton = new Button();
        label4 = new Label();
        DateOfBirthPicker = new DateTimePicker();
        label3 = new Label();
        PhoneNumberBox = new TextBox();
        label2 = new Label();
        LastNameBox = new TextBox();
        label1 = new Label();
        FirstNameBox = new TextBox();
        ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
        splitContainer1.Panel1.SuspendLayout();
        splitContainer1.Panel2.SuspendLayout();
        splitContainer1.SuspendLayout();
        panel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)DataGridView).BeginInit();
        GridMenuStrip.SuspendLayout();
        panel2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)RatingInput).BeginInit();
        ((System.ComponentModel.ISupportInitialize)SalaryInput).BeginInit();
        SuspendLayout();
        // 
        // splitContainer1
        // 
        splitContainer1.Dock = DockStyle.Fill;
        splitContainer1.Location = new Point(0, 0);
        splitContainer1.Name = "splitContainer1";
        // 
        // splitContainer1.Panel1
        // 
        splitContainer1.Panel1.Controls.Add(panel1);
        // 
        // splitContainer1.Panel2
        // 
        splitContainer1.Panel2.Controls.Add(panel2);
        splitContainer1.Size = new Size(1595, 722);
        splitContainer1.SplitterDistance = 1080;
        splitContainer1.TabIndex = 0;
        // 
        // panel1
        // 
        panel1.Controls.Add(DataGridView);
        panel1.Dock = DockStyle.Fill;
        panel1.Location = new Point(0, 0);
        panel1.Name = "panel1";
        panel1.Size = new Size(1080, 722);
        panel1.TabIndex = 0;
        // 
        // DataGridView
        // 
        DataGridView.BackgroundColor = Color.SlateGray;
        DataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        DataGridView.ContextMenuStrip = GridMenuStrip;
        DataGridView.Dock = DockStyle.Fill;
        DataGridView.Location = new Point(0, 0);
        DataGridView.MultiSelect = false;
        DataGridView.Name = "DataGridView";
        DataGridView.ReadOnly = true;
        DataGridView.RowHeadersWidth = 51;
        DataGridView.RowTemplate.Height = 29;
        DataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        DataGridView.Size = new Size(1080, 722);
        DataGridView.TabIndex = 0;
        // 
        // GridMenuStrip
        // 
        GridMenuStrip.ImageScalingSize = new Size(20, 20);
        GridMenuStrip.Items.AddRange(new ToolStripItem[] { deleteToolStripMenuItem });
        GridMenuStrip.Name = "GridMenuStrip";
        GridMenuStrip.Size = new Size(123, 28);
        // 
        // deleteToolStripMenuItem
        // 
        deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
        deleteToolStripMenuItem.Size = new Size(122, 24);
        deleteToolStripMenuItem.Text = "Delete";
        deleteToolStripMenuItem.Click += On_DeleteToolStripMenuItem_Click;
        // 
        // panel2
        // 
        panel2.Controls.Add(RatingInput);
        panel2.Controls.Add(label6);
        panel2.Controls.Add(SalaryInput);
        panel2.Controls.Add(label5);
        panel2.Controls.Add(AddButton);
        panel2.Controls.Add(label4);
        panel2.Controls.Add(DateOfBirthPicker);
        panel2.Controls.Add(label3);
        panel2.Controls.Add(PhoneNumberBox);
        panel2.Controls.Add(label2);
        panel2.Controls.Add(LastNameBox);
        panel2.Controls.Add(label1);
        panel2.Controls.Add(FirstNameBox);
        panel2.Dock = DockStyle.Fill;
        panel2.Location = new Point(0, 0);
        panel2.Name = "panel2";
        panel2.Size = new Size(511, 722);
        panel2.TabIndex = 0;
        // 
        // RatingInput
        // 
        RatingInput.Location = new Point(85, 506);
        RatingInput.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
        RatingInput.Name = "RatingInput";
        RatingInput.Size = new Size(353, 27);
        RatingInput.TabIndex = 13;
        // 
        // label6
        // 
        label6.AutoSize = true;
        label6.Location = new Point(85, 483);
        label6.Name = "label6";
        label6.Size = new Size(52, 20);
        label6.TabIndex = 12;
        label6.Text = "Rating";
        // 
        // SalaryInput
        // 
        SalaryInput.DecimalPlaces = 2;
        SalaryInput.Increment = new decimal(new int[] { 50, 0, 0, 0 });
        SalaryInput.Location = new Point(85, 439);
        SalaryInput.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
        SalaryInput.Name = "SalaryInput";
        SalaryInput.Size = new Size(353, 27);
        SalaryInput.TabIndex = 11;
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Location = new Point(85, 416);
        label5.Name = "label5";
        label5.Size = new Size(71, 20);
        label5.TabIndex = 10;
        label5.Text = "Salary ($)";
        // 
        // AddButton
        // 
        AddButton.Location = new Point(322, 561);
        AddButton.Name = "AddButton";
        AddButton.Size = new Size(116, 35);
        AddButton.TabIndex = 8;
        AddButton.Text = "Add";
        AddButton.UseVisualStyleBackColor = true;
        AddButton.Click += On_AddButton_Click;
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(85, 344);
        label4.Name = "label4";
        label4.Size = new Size(94, 20);
        label4.TabIndex = 7;
        label4.Text = "Date of Birth";
        // 
        // DateOfBirthPicker
        // 
        DateOfBirthPicker.Location = new Point(85, 367);
        DateOfBirthPicker.Name = "DateOfBirthPicker";
        DateOfBirthPicker.Size = new Size(353, 27);
        DateOfBirthPicker.TabIndex = 6;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(85, 273);
        label3.Name = "label3";
        label3.Size = new Size(108, 20);
        label3.TabIndex = 5;
        label3.Text = "Phone Number";
        // 
        // PhoneNumberBox
        // 
        PhoneNumberBox.Location = new Point(85, 296);
        PhoneNumberBox.Name = "PhoneNumberBox";
        PhoneNumberBox.Size = new Size(353, 27);
        PhoneNumberBox.TabIndex = 4;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(85, 203);
        label2.Name = "label2";
        label2.Size = new Size(79, 20);
        label2.TabIndex = 3;
        label2.Text = "Last Name";
        // 
        // LastNameBox
        // 
        LastNameBox.Location = new Point(85, 226);
        LastNameBox.Name = "LastNameBox";
        LastNameBox.Size = new Size(353, 27);
        LastNameBox.TabIndex = 2;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(85, 135);
        label1.Name = "label1";
        label1.Size = new Size(80, 20);
        label1.TabIndex = 1;
        label1.Text = "First Name";
        // 
        // FirstNameBox
        // 
        FirstNameBox.Location = new Point(85, 158);
        FirstNameBox.Name = "FirstNameBox";
        FirstNameBox.Size = new Size(353, 27);
        FirstNameBox.TabIndex = 0;
        // 
        // WaiterForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.LightBlue;
        ClientSize = new Size(1595, 722);
        Controls.Add(splitContainer1);
        Name = "WaiterForm";
        Text = "Breedy Slowbear Pizzeria - Waiters";
        Load += On_Load;
        splitContainer1.Panel1.ResumeLayout(false);
        splitContainer1.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
        splitContainer1.ResumeLayout(false);
        panel1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)DataGridView).EndInit();
        GridMenuStrip.ResumeLayout(false);
        panel2.ResumeLayout(false);
        panel2.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)RatingInput).EndInit();
        ((System.ComponentModel.ISupportInitialize)SalaryInput).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private SplitContainer splitContainer1;
    private Panel panel1;
    private Panel panel2;
    private DataGridView DataGridView;
    private Label label1;
    private TextBox FirstNameBox;
    private Label label3;
    private TextBox PhoneNumberBox;
    private Label label2;
    private TextBox LastNameBox;
    private Button AddButton;
    private Label label4;
    private DateTimePicker DateOfBirthPicker;
    private ContextMenuStrip GridMenuStrip;
    private ToolStripMenuItem deleteToolStripMenuItem;
    private NumericUpDown SalaryInput;
    private Label label5;
    private NumericUpDown RatingInput;
    private Label label6;
}