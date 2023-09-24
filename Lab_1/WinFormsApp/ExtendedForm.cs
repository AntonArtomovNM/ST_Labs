namespace WinFormsApp;

public class ExtendedForm : Form
{
    protected static DialogResult ConfirmAction(string action, string text)
    {
        return MessageBox.Show(
            text: text,
            caption: action,
            MessageBoxButtons.YesNo);
    }

    protected static DialogResult ShowInfo(string text, string? caption = null)
    {
        return MessageBox.Show(
            text: text,
            caption: caption ?? string.Empty,
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }

    protected static DialogResult ShowError(string text, string? caption = null)
    {
        return MessageBox.Show(
            text: text,
            caption: caption ?? "An error has occurred",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
    }
}
