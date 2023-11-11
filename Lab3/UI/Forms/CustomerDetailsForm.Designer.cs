namespace UI.Forms;

partial class CustomerDetailsForm
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
        splitContainer1 = new SplitContainer();
        DeleteButton = new Button();
        label5 = new Label();
        UpdateButton = new Button();
        label4 = new Label();
        Customer_DateOfBirthPicker = new DateTimePicker();
        label3 = new Label();
        Customer_PhoneNumberBox = new TextBox();
        label2 = new Label();
        Customer_LastNameBox = new TextBox();
        label1 = new Label();
        Customer_FirstNameBox = new TextBox();
        label12 = new Label();
        Waiter_RatingInput = new NumericUpDown();
        Waiter_FirstNameBox = new TextBox();
        label6 = new Label();
        label11 = new Label();
        Waiter_SalaryInput = new NumericUpDown();
        Waiter_LastNameBox = new TextBox();
        label7 = new Label();
        label10 = new Label();
        SelectWaiterButton = new Button();
        Waiter_PhoneNumberBox = new TextBox();
        label8 = new Label();
        label9 = new Label();
        Waiter_DateOfBirthPicker = new DateTimePicker();
        RefreshButton = new Button();
        ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
        splitContainer1.Panel1.SuspendLayout();
        splitContainer1.Panel2.SuspendLayout();
        splitContainer1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)Waiter_RatingInput).BeginInit();
        ((System.ComponentModel.ISupportInitialize)Waiter_SalaryInput).BeginInit();
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
        splitContainer1.Panel1.Controls.Add(RefreshButton);
        splitContainer1.Panel1.Controls.Add(DeleteButton);
        splitContainer1.Panel1.Controls.Add(label5);
        splitContainer1.Panel1.Controls.Add(UpdateButton);
        splitContainer1.Panel1.Controls.Add(label4);
        splitContainer1.Panel1.Controls.Add(Customer_DateOfBirthPicker);
        splitContainer1.Panel1.Controls.Add(label3);
        splitContainer1.Panel1.Controls.Add(Customer_PhoneNumberBox);
        splitContainer1.Panel1.Controls.Add(label2);
        splitContainer1.Panel1.Controls.Add(Customer_LastNameBox);
        splitContainer1.Panel1.Controls.Add(label1);
        splitContainer1.Panel1.Controls.Add(Customer_FirstNameBox);
        // 
        // splitContainer1.Panel2
        // 
        splitContainer1.Panel2.Controls.Add(label12);
        splitContainer1.Panel2.Controls.Add(Waiter_RatingInput);
        splitContainer1.Panel2.Controls.Add(Waiter_FirstNameBox);
        splitContainer1.Panel2.Controls.Add(label6);
        splitContainer1.Panel2.Controls.Add(label11);
        splitContainer1.Panel2.Controls.Add(Waiter_SalaryInput);
        splitContainer1.Panel2.Controls.Add(Waiter_LastNameBox);
        splitContainer1.Panel2.Controls.Add(label7);
        splitContainer1.Panel2.Controls.Add(label10);
        splitContainer1.Panel2.Controls.Add(SelectWaiterButton);
        splitContainer1.Panel2.Controls.Add(Waiter_PhoneNumberBox);
        splitContainer1.Panel2.Controls.Add(label8);
        splitContainer1.Panel2.Controls.Add(label9);
        splitContainer1.Panel2.Controls.Add(Waiter_DateOfBirthPicker);
        splitContainer1.Size = new Size(1089, 730);
        splitContainer1.SplitterDistance = 544;
        splitContainer1.TabIndex = 0;
        // 
        // DeleteButton
        // 
        DeleteButton.Location = new Point(96, 494);
        DeleteButton.Name = "DeleteButton";
        DeleteButton.Size = new Size(116, 35);
        DeleteButton.TabIndex = 19;
        DeleteButton.Text = "Delete";
        DeleteButton.UseVisualStyleBackColor = true;
        DeleteButton.Click += On_DeleteButton_Click;
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
        label5.Location = new Point(182, 112);
        label5.Name = "label5";
        label5.Size = new Size(181, 35);
        label5.TabIndex = 18;
        label5.Text = "Customer Data";
        // 
        // UpdateButton
        // 
        UpdateButton.Location = new Point(333, 494);
        UpdateButton.Name = "UpdateButton";
        UpdateButton.Size = new Size(116, 35);
        UpdateButton.TabIndex = 17;
        UpdateButton.Text = "Update";
        UpdateButton.UseVisualStyleBackColor = true;
        UpdateButton.Click += On_UpdateButton_Click;
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(96, 402);
        label4.Name = "label4";
        label4.Size = new Size(94, 20);
        label4.TabIndex = 16;
        label4.Text = "Date of Birth";
        // 
        // Customer_DateOfBirthPicker
        // 
        Customer_DateOfBirthPicker.Location = new Point(96, 425);
        Customer_DateOfBirthPicker.Name = "Customer_DateOfBirthPicker";
        Customer_DateOfBirthPicker.Size = new Size(353, 27);
        Customer_DateOfBirthPicker.TabIndex = 15;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(96, 331);
        label3.Name = "label3";
        label3.Size = new Size(108, 20);
        label3.TabIndex = 14;
        label3.Text = "Phone Number";
        // 
        // Customer_PhoneNumberBox
        // 
        Customer_PhoneNumberBox.Location = new Point(96, 354);
        Customer_PhoneNumberBox.Name = "Customer_PhoneNumberBox";
        Customer_PhoneNumberBox.Size = new Size(353, 27);
        Customer_PhoneNumberBox.TabIndex = 13;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(96, 261);
        label2.Name = "label2";
        label2.Size = new Size(79, 20);
        label2.TabIndex = 12;
        label2.Text = "Last Name";
        // 
        // Customer_LastNameBox
        // 
        Customer_LastNameBox.Location = new Point(96, 284);
        Customer_LastNameBox.Name = "Customer_LastNameBox";
        Customer_LastNameBox.Size = new Size(353, 27);
        Customer_LastNameBox.TabIndex = 11;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(96, 193);
        label1.Name = "label1";
        label1.Size = new Size(80, 20);
        label1.TabIndex = 10;
        label1.Text = "First Name";
        // 
        // Customer_FirstNameBox
        // 
        Customer_FirstNameBox.Location = new Point(96, 216);
        Customer_FirstNameBox.Name = "Customer_FirstNameBox";
        Customer_FirstNameBox.Size = new Size(353, 27);
        Customer_FirstNameBox.TabIndex = 9;
        // 
        // label12
        // 
        label12.AutoSize = true;
        label12.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
        label12.Location = new Point(188, 112);
        label12.Name = "label12";
        label12.Size = new Size(175, 35);
        label12.TabIndex = 19;
        label12.Text = "Related Waiter";
        // 
        // Waiter_RatingInput
        // 
        Waiter_RatingInput.Enabled = false;
        Waiter_RatingInput.Location = new Point(100, 564);
        Waiter_RatingInput.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
        Waiter_RatingInput.Name = "Waiter_RatingInput";
        Waiter_RatingInput.Size = new Size(353, 27);
        Waiter_RatingInput.TabIndex = 31;
        // 
        // Waiter_FirstNameBox
        // 
        Waiter_FirstNameBox.Enabled = false;
        Waiter_FirstNameBox.Location = new Point(100, 216);
        Waiter_FirstNameBox.Name = "Waiter_FirstNameBox";
        Waiter_FirstNameBox.Size = new Size(353, 27);
        Waiter_FirstNameBox.TabIndex = 19;
        // 
        // label6
        // 
        label6.AutoSize = true;
        label6.Location = new Point(100, 541);
        label6.Name = "label6";
        label6.Size = new Size(52, 20);
        label6.TabIndex = 30;
        label6.Text = "Rating";
        // 
        // label11
        // 
        label11.AutoSize = true;
        label11.Location = new Point(100, 193);
        label11.Name = "label11";
        label11.Size = new Size(80, 20);
        label11.TabIndex = 20;
        label11.Text = "First Name";
        // 
        // Waiter_SalaryInput
        // 
        Waiter_SalaryInput.DecimalPlaces = 2;
        Waiter_SalaryInput.Enabled = false;
        Waiter_SalaryInput.Increment = new decimal(new int[] { 50, 0, 0, 0 });
        Waiter_SalaryInput.Location = new Point(100, 497);
        Waiter_SalaryInput.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
        Waiter_SalaryInput.Name = "Waiter_SalaryInput";
        Waiter_SalaryInput.Size = new Size(353, 27);
        Waiter_SalaryInput.TabIndex = 29;
        // 
        // Waiter_LastNameBox
        // 
        Waiter_LastNameBox.Enabled = false;
        Waiter_LastNameBox.Location = new Point(100, 284);
        Waiter_LastNameBox.Name = "Waiter_LastNameBox";
        Waiter_LastNameBox.Size = new Size(353, 27);
        Waiter_LastNameBox.TabIndex = 21;
        // 
        // label7
        // 
        label7.AutoSize = true;
        label7.Location = new Point(100, 474);
        label7.Name = "label7";
        label7.Size = new Size(71, 20);
        label7.TabIndex = 28;
        label7.Text = "Salary ($)";
        // 
        // label10
        // 
        label10.AutoSize = true;
        label10.Location = new Point(100, 261);
        label10.Name = "label10";
        label10.Size = new Size(79, 20);
        label10.TabIndex = 22;
        label10.Text = "Last Name";
        // 
        // SelectWaiterButton
        // 
        SelectWaiterButton.Location = new Point(221, 622);
        SelectWaiterButton.Name = "SelectWaiterButton";
        SelectWaiterButton.Size = new Size(116, 35);
        SelectWaiterButton.TabIndex = 27;
        SelectWaiterButton.Text = "Select Waiter";
        SelectWaiterButton.UseVisualStyleBackColor = true;
        SelectWaiterButton.Click += On_SelectWaiterButton_Click;
        // 
        // Waiter_PhoneNumberBox
        // 
        Waiter_PhoneNumberBox.Enabled = false;
        Waiter_PhoneNumberBox.Location = new Point(100, 354);
        Waiter_PhoneNumberBox.Name = "Waiter_PhoneNumberBox";
        Waiter_PhoneNumberBox.Size = new Size(353, 27);
        Waiter_PhoneNumberBox.TabIndex = 23;
        // 
        // label8
        // 
        label8.AutoSize = true;
        label8.Location = new Point(100, 402);
        label8.Name = "label8";
        label8.Size = new Size(94, 20);
        label8.TabIndex = 26;
        label8.Text = "Date of Birth";
        // 
        // label9
        // 
        label9.AutoSize = true;
        label9.Location = new Point(100, 331);
        label9.Name = "label9";
        label9.Size = new Size(108, 20);
        label9.TabIndex = 24;
        label9.Text = "Phone Number";
        // 
        // Waiter_DateOfBirthPicker
        // 
        Waiter_DateOfBirthPicker.Enabled = false;
        Waiter_DateOfBirthPicker.Location = new Point(100, 425);
        Waiter_DateOfBirthPicker.Name = "Waiter_DateOfBirthPicker";
        Waiter_DateOfBirthPicker.Size = new Size(353, 27);
        Waiter_DateOfBirthPicker.TabIndex = 25;
        // 
        // RefreshButton
        // 
        RefreshButton.Location = new Point(0, 0);
        RefreshButton.Name = "RefreshButton";
        RefreshButton.Size = new Size(77, 28);
        RefreshButton.TabIndex = 32;
        RefreshButton.Text = "Refresh";
        RefreshButton.UseVisualStyleBackColor = true;
        RefreshButton.Click += On_RefreshButton_Click;
        // 
        // CustomerDetailsForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.LightSteelBlue;
        ClientSize = new Size(1089, 730);
        Controls.Add(splitContainer1);
        Name = "CustomerDetailsForm";
        Text = "Breedy Slowbear Pizzeria - Customer Details";
        splitContainer1.Panel1.ResumeLayout(false);
        splitContainer1.Panel1.PerformLayout();
        splitContainer1.Panel2.ResumeLayout(false);
        splitContainer1.Panel2.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
        splitContainer1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)Waiter_RatingInput).EndInit();
        ((System.ComponentModel.ISupportInitialize)Waiter_SalaryInput).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private SplitContainer splitContainer1;
    private Button UpdateButton;
    private Label label4;
    private DateTimePicker Customer_DateOfBirthPicker;
    private Label label3;
    private TextBox Customer_PhoneNumberBox;
    private Label label2;
    private TextBox Customer_LastNameBox;
    private Label label1;
    private TextBox Customer_FirstNameBox;
    private Label label5;
    private Label label12;
    private NumericUpDown Waiter_RatingInput;
    private TextBox Waiter_FirstNameBox;
    private Label label6;
    private Label label11;
    private NumericUpDown Waiter_SalaryInput;
    private TextBox Waiter_LastNameBox;
    private Label label7;
    private Label label10;
    private Button SelectWaiterButton;
    private TextBox Waiter_PhoneNumberBox;
    private Label label8;
    private Label label9;
    private DateTimePicker Waiter_DateOfBirthPicker;
    private Button DeleteButton;
    private Button RefreshButton;
}