using UI.Forms.Contracts;

namespace UI.Services.Forms;

public interface IFormOpener
{
    void ShowForm<TForm>() where TForm : Form;

    Task ShowModelViewForm<TForm>(int id) where TForm : Form, IModelViewForm;
}
