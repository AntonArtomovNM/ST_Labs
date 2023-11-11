using SimpleInjector;
using UI.Forms.Contracts;

namespace UI.Services.Forms;

public class FormOpener : IFormOpener
{
    private readonly Container _container;

    public FormOpener(Container container)
    {
        _container = container;
    }

    public void ShowForm<TForm>() where TForm : Form
    {
        using (var form = GetForm<TForm>())
        {
            form.ShowDialog();
        }
    }

    public async Task ShowModelViewForm<TForm>(int id) where TForm : Form, IModelViewForm
    {
        using (var form = GetForm<TForm>())
        {
            await form.SetModel(id);

            form.ShowDialog();
        }
    }

    private TForm GetForm<TForm>() where TForm : Form
    {
        return _container.GetInstance<TForm>();
    }
}
