using UI.Utils;

namespace UI.Forms;

public partial class EncryptionKeyForm : Form
{
    public string EncryptionKey { get; private set; }

    public EncryptionKeyForm()
    {
        InitializeComponent();
    }

    private void EnterButton_Click(object sender, EventArgs e)
    {
        string key = KeyTextBox.Text;

        if (string.IsNullOrWhiteSpace(key))
        {
            FormUtils.ShowError("The key is empty");
            return;
        }

        EncryptionKey = key;
        DialogResult = DialogResult.OK;

        Close();
    }
}
