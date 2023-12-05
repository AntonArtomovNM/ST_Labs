namespace Library.Models;

public class WaitingTokenSource
{
    public bool IsPausedRequested { get; private set; }

    public void Pause() => IsPausedRequested = true;

    public void Resume() => IsPausedRequested = false;
}
