namespace UI.Utils;

public static class ProgressBarExtentions
{
    public static void SetValue(this ProgressBar progressBar, int value)
    {
        if (progressBar.InvokeRequired)
        {
            progressBar.Invoke(() => SetValue(progressBar, value));
        }
        else
        {
            progressBar.Value = value;
        }
    }
}
