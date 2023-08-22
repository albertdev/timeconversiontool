namespace Timetool;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void txtInput_TextChanged(object sender, EventArgs e)
    {
        var regularFont = txtOutput.SelectionFont;
        txtOutput.Clear();
        txtOutput.DeselectAll();
        txtOutput.AppendText("Got: ");
        using (var boldFont = new Font(regularFont, FontStyle.Bold))
        {
            txtOutput.SelectionFont = boldFont;
            txtOutput.AppendText(txtInput.Text);
        }
        txtOutput.SelectionFont = regularFont;
    }
}
