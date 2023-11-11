using SimpleInjector;
using UI.Forms;

namespace UI;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        var container = Bootstrap();
        var mainForm = container.GetInstance<MainForm>();

        Application.Run(mainForm);
    }

    private static Container Bootstrap()
    {
        var container = new Container();

        container.RegisterDependencies();

        container.Verify();

        return container;
    }
}