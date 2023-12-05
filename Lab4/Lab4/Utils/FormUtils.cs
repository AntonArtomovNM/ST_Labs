namespace UI.Utils;

public static class FormUtils
{
    public static DialogResult ConfirmAction(string action, string text)
    {
        return MessageBox.Show(
            text: text,
            caption: action,
            MessageBoxButtons.YesNo);
    }

    public static DialogResult ShowInfo(string text, string? caption = null)
    {
        return MessageBox.Show(
            text: text,
            caption: caption ?? string.Empty,
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }

    public static DialogResult ShowError(string text, string? caption = null)
    {
        return MessageBox.Show(
            text: text,
            caption: caption ?? "An error has occurred",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
    }
}
