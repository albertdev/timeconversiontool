namespace Timetool;

partial class Form1
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
        tableLayoutPanel1 = new TableLayoutPanel();
        label1 = new Label();
        txtInput = new TextBox();
        panel1 = new Panel();
        txtOutput = new RichTextBox();
        label2 = new Label();
        tableLayoutPanel1.SuspendLayout();
        panel1.SuspendLayout();
        SuspendLayout();
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.ColumnCount = 2;
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.7777777F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 87.22222F));
        tableLayoutPanel1.Controls.Add(label1, 0, 0);
        tableLayoutPanel1.Controls.Add(txtInput, 1, 0);
        tableLayoutPanel1.Controls.Add(panel1, 0, 2);
        tableLayoutPanel1.Controls.Add(label2, 0, 1);
        tableLayoutPanel1.Location = new Point(12, 12);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 3;
        tableLayoutPanel1.RowStyles.Add(new RowStyle());
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 184F));
        tableLayoutPanel1.Size = new Size(360, 237);
        tableLayoutPanel1.TabIndex = 0;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Dock = DockStyle.Fill;
        label1.Location = new Point(3, 0);
        label1.Name = "label1";
        label1.Size = new Size(40, 29);
        label1.TabIndex = 0;
        label1.Text = "Input:";
        label1.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // txtInput
        // 
        txtInput.Dock = DockStyle.Fill;
        txtInput.Location = new Point(49, 3);
        txtInput.Name = "txtInput";
        txtInput.Size = new Size(308, 23);
        txtInput.TabIndex = 1;
        txtInput.TextChanged += txtInput_TextChanged;
        // 
        // panel1
        // 
        tableLayoutPanel1.SetColumnSpan(panel1, 2);
        panel1.Controls.Add(txtOutput);
        panel1.Dock = DockStyle.Fill;
        panel1.Location = new Point(3, 56);
        panel1.Name = "panel1";
        panel1.Size = new Size(354, 178);
        panel1.TabIndex = 2;
        // 
        // txtOutput
        // 
        txtOutput.Dock = DockStyle.Fill;
        txtOutput.Location = new Point(0, 0);
        txtOutput.Name = "txtOutput";
        txtOutput.ReadOnly = true;
        txtOutput.Size = new Size(354, 178);
        txtOutput.TabIndex = 0;
        txtOutput.Text = "";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Dock = DockStyle.Fill;
        label2.Location = new Point(3, 29);
        label2.Name = "label2";
        label2.Size = new Size(40, 24);
        label2.TabIndex = 3;
        label2.Text = "Result:";
        label2.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(384, 261);
        Controls.Add(tableLayoutPanel1);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "Form1";
        SizeGripStyle = SizeGripStyle.Hide;
        Text = "Timetool";
        tableLayoutPanel1.ResumeLayout(false);
        tableLayoutPanel1.PerformLayout();
        panel1.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel1;
    private Label label1;
    private TextBox txtInput;
    private Panel panel1;
    private Label label2;
    private RichTextBox txtOutput;
}
