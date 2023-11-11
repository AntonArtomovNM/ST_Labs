namespace UI.Forms;

partial class WaiterSelectionForm
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
        GridMenuStrip = new ContextMenuStrip(components);
        DataGridView = new DataGridView();
        selectToolStripMenuItem = new ToolStripMenuItem();
        GridMenuStrip.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)DataGridView).BeginInit();
        SuspendLayout();
        // 
        // GridMenuStrip
        // 
        GridMenuStrip.ImageScalingSize = new Size(20, 20);
        GridMenuStrip.Items.AddRange(new ToolStripItem[] { selectToolStripMenuItem });
        GridMenuStrip.Name = "GridMenuStrip";
        GridMenuStrip.Size = new Size(211, 56);
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
        DataGridView.Size = new Size(1375, 722);
        DataGridView.TabIndex = 1;
        // 
        // selectToolStripMenuItem
        // 
        selectToolStripMenuItem.Name = "selectToolStripMenuItem";
        selectToolStripMenuItem.Size = new Size(210, 24);
        selectToolStripMenuItem.Text = "Select";
        selectToolStripMenuItem.Click += On_SelectToolStripMenuItem_Click;
        // 
        // WaiterSelectionForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.LightBlue;
        ClientSize = new Size(1375, 722);
        Controls.Add(DataGridView);
        Name = "WaiterSelectionForm";
        Text = "Breedy Slowbear Pizzeria - Waiters";
        Load += On_Load;
        GridMenuStrip.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)DataGridView).EndInit();
        ResumeLayout(false);
    }

    #endregion
    private ContextMenuStrip GridMenuStrip;
    private DataGridView DataGridView;
    private ToolStripMenuItem selectToolStripMenuItem;
}