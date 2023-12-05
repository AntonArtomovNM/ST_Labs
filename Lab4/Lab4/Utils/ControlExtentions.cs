namespace UI.Utils;

public static class ControlExtentions
{
    public static void SetEnabled(this Control control, bool enabled)
    {
        if (control.InvokeRequired)
        {
            control.Invoke(() => SetEnabled(control, enabled));
        }
        else
        {
            control.Enabled = enabled;
        }
    }

    public static void SetText(this Control control, string text)
    {
        if (control.InvokeRequired)
        {
            control.Invoke(() => SetText(control, text));
        }
        else
        {
            control.Text = text;
        }
    }
}
