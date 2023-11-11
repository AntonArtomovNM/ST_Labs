using UI.Services.Forms;

namespace UI.Forms;
public partial class MainForm : Form
{
    private readonly IFormOpener _formOpener;

    public MainForm(IFormOpener formOpener)
    {
        _formOpener = formOpener;

        InitializeComponent();
    }

    private void CustomersButton_Click(object sender, EventArgs e)
    {
        _formOpener.ShowForm<CustomerForm>();
    }

    private void WaitersButton_Click(object sender, EventArgs e)
    {
        _formOpener.ShowForm<WaiterForm>();
    }
}
