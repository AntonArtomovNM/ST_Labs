using System.ComponentModel;
using System.Timers;
using Library.Models;
using Library.Models.Events;
using Library.Services;
using UI.Forms;
using UI.Models;
using UI.Models.Enums;
using UI.Utils;
using Timer = System.Timers.Timer;

namespace UI;

public partial class MainForm : Form
{
    private const string StartFolder = @"D:\";
    private const int TimerInterval = 10;

    private readonly IFileEncryptor _fileEncryptor;
    private CancellationTokenSource? _encryptionCancellationTokenSource;
    private WaitingTokenSource? _encryptionWaitingTokenSource;

    private Timer? _timer;
    private DateTime? _startingTime;

    public MainForm()
    {
        InitializeComponent();

        InitializeBackgroundWorker();

        ResetProgress();

        _fileEncryptor = new FileEncryptor();
        _fileEncryptor.EncryptionProgressChanged += FileEncryptor_ProgressChanged;
        _fileEncryptor.DecryptionProgressChanged += FileEncryptor_ProgressChanged;
    }

    private void InitializeBackgroundWorker()
    {
        ProcessBackgroundWorker.DoWork += BackgroundWorker_DoWork;
        ProcessBackgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
        ProcessBackgroundWorker.ProgressChanged += BackgroundWorker_ProgressChanged;
    }

    private void EncryptFileButton_Click(object? sender, EventArgs e)
    {
        ProcessFile(OperationType.Encryption);
    }

    private void DecryptFileButton_Click(object? sender, EventArgs e)
    {
        ProcessFile(OperationType.Decryption);
    }

    private void PauseButton_Click(object? sender, EventArgs e)
    {
        if (_timer is null)
        {
            FormUtils.ShowError("Timer is not set");
            return;
        }

        if (_timer.Enabled)
        {
            StopProgress();
            PauseButton.SetText("Continue");

            _encryptionWaitingTokenSource?.Pause();
        }
        else
        {
            ContinueProgress();
            PauseButton.SetText("Pause");

            _encryptionWaitingTokenSource?.Resume();
        }
    }

    private void CancelButton_Click(object? sender, EventArgs e)
    {
        StopProgress();
        _encryptionWaitingTokenSource?.Pause();

        DialogResult result = FormUtils.ConfirmAction("Cancel encryption", "Do you want to cancel the process?");

        ContinueProgress();
        _encryptionWaitingTokenSource?.Resume();

        if (result is not DialogResult.Yes)
        {
            return;
        }

        _encryptionCancellationTokenSource?.Cancel();
        ProcessBackgroundWorker.CancelAsync();
    }

    private void BackgroundWorker_DoWork(object? sender, DoWorkEventArgs e)
    {
        var encryptionModel = e.Argument as EncryptionModel;
        if (encryptionModel is null)
        {
            throw new ArgumentNullException(nameof(encryptionModel));
        }

        ResetProgress();
        StartProgress();
        SetProcessButtons(true);

        _encryptionCancellationTokenSource = new CancellationTokenSource();
        _encryptionWaitingTokenSource = new WaitingTokenSource();

        WaitingToken waitingToken = new WaitingToken(_encryptionWaitingTokenSource, _encryptionCancellationTokenSource);

        Task<EncryptionReport> fileTask = encryptionModel.OperationType switch
        {
            OperationType.Encryption => _fileEncryptor.EncryptFile(encryptionModel.FileInfo, encryptionModel.EncryptionKey, waitingToken),
            OperationType.Decryption => _fileEncryptor.DecryptFile(encryptionModel.FileInfo, encryptionModel.EncryptionKey, waitingToken),
            _ => throw new ArgumentOutOfRangeException(nameof(encryptionModel.OperationType), encryptionModel.OperationType, "Operation type is invalid"),
        };

        e.Result = fileTask.GetAwaiter().GetResult();
    }

    private void BackgroundWorker_ProgressChanged(object? sender, ProgressChangedEventArgs e)
    {
        ProgressBar.SetValue(e.ProgressPercentage);
    }

    private void BackgroundWorker_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
    {
        StopProgress();
        SetFileButtons(true);
        SetProcessButtons(false);

        _encryptionCancellationTokenSource = null;
        _encryptionWaitingTokenSource = null;

        if (e.Error is not null)
        {
            FormUtils.ShowError(e.Error.Message, "File encryption failed");
            return;
        }

        if (e.Cancelled)
        {
            FormUtils.ShowInfo("Operation cancelled");
            return;
        }

        var report = e.Result as EncryptionReport;
        if (report is null)
        {
            FormUtils.ShowError("Encryption report not found");
            return;
        }

        string timeSpent = TimerLabel.Text;

        FormUtils.ShowInfo(
            $@"File name: {report.FileName}
File size: {report.FileByteSize} bytes
Time spent: {timeSpent}",
            "Encryption report");

    }

    private void FileEncryptor_ProgressChanged(object? sender, EncryptionProgressChangedEventArgs e)
    {
        if (!ProcessBackgroundWorker.IsBusy)
        {
            return;
        }

        int progressPercent = (int)(100 * e.ProcessedBytes / e.TotalBytes);
        ProcessBackgroundWorker.ReportProgress(progressPercent);
    }

    private void Timer_Elapsed(object? sender, ElapsedEventArgs e)
    {
        string timeSpan = _startingTime is null
            ? string.Empty
            : (e.SignalTime - _startingTime).Value.TotalSeconds.ToString();

        TimerLabel.SetText($"{timeSpan} seconds");
    }

    private string? GetEncryptionKey()
    {
        var keyForm = new EncryptionKeyForm();

        DialogResult dialogResult = keyForm.ShowDialog();
        string encryptionKey = keyForm.EncryptionKey;

        if (dialogResult is not DialogResult.OK)
        {
            return null;
        }

        return encryptionKey;
    }

    private void ProcessFile(OperationType operationType)
    {
        SetFileButtons(false);

        var openFileDialog = new OpenFileDialog
        {
            InitialDirectory = StartFolder,
        };

        DialogResult dialogResult = openFileDialog.ShowDialog();
        string fileName = openFileDialog.FileName;

        if (dialogResult is not DialogResult.OK || string.IsNullOrWhiteSpace(fileName))
        {
            FormUtils.ShowError("The file name is empty");

            SetFileButtons(true);
            return;
        }

        string? encryptionKey = GetEncryptionKey();

        if (encryptionKey is null)
        {
            FormUtils.ShowError("The key is empty");

            SetFileButtons(true);
            return;
        }

        var encryptionModel = new EncryptionModel(
            new FileInfo(fileName),
            encryptionKey,
            operationType);

        ProcessBackgroundWorker.RunWorkerAsync(encryptionModel);
    }

    private void SetFileButtons(bool areEnabled)
    {
        EncryptFileButton.SetEnabled(areEnabled);
        DecryptFileButton.SetEnabled(areEnabled);
    }

    private void SetProcessButtons(bool areEnabled)
    {
        PauseButton.SetEnabled(areEnabled);
        CancelButton.SetEnabled(areEnabled);
    }

    private void StartProgress()
    {
        TimerLabel.SetText("0");

        _timer = new Timer(TimerInterval);
        _timer.Elapsed += Timer_Elapsed;
        _timer.AutoReset = true;

        _startingTime = DateTime.Now;
        _timer.Start();
    }

    private void StopProgress()
    {
        _timer?.Stop();
    }

    private void ContinueProgress()
    {
        _timer?.Start();
    }

    private void ResetProgress()
    {
        _startingTime = null;

        TimerLabel.SetText(string.Empty);
        ProgressBar.SetValue(0);
    }
}
