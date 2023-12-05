namespace Library.Models;

public struct WaitingToken
{
    private readonly WaitingTokenSource? _waitingSource;
    private readonly CancellationTokenSource? _cancellationSource;

    public bool IsPausedRequested => _waitingSource is not null && _waitingSource.IsPausedRequested;

    public bool IsCancellationRequested => _cancellationSource is not null && _cancellationSource.IsCancellationRequested;

    public WaitingToken(WaitingTokenSource? waitingSource, CancellationTokenSource? cancellationSource)
    {
        _waitingSource = waitingSource;
        _cancellationSource = cancellationSource;
    }
}
