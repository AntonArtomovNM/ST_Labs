using Domain.Models.ValueObjects;
using Domain.Services.Accounts;
using Domain.Services.ATMs;
using Domain.TestData;

namespace WinFormsApp;

public partial class MainMenuForm : ExtendedFormWithEvents
{
    private const string UnathorizedErrorMessage = "You are not authenticated";
    private const string AtmRequiredErrorMessage = "You need to find closest ATM first";

    private readonly IAccountManagementService _accountManagementService;
    private readonly IAtmManagementService _atmManagementService;

    private CardNumber? _cardNumber;
    private Guid? _atmId;

    public MainMenuForm()
    {
        InitializeComponent();

        _accountManagementService = FakeContainer.AccountManagementService;
        _atmManagementService = FakeContainer.AtmManagementService;

        SubscribeToEvents();
    }

    protected override void SubscribeToEvents()
    {
        _accountManagementService.BalanceRetrivalCompletedEvent += OnBalanceRetrivalCompleted;
        _accountManagementService.BalanceRetrivalFailedEvent += OnBalanceRetrivalFailed;

        _atmManagementService.BalanceRetrivalCompletedEvent += OnBalanceRetrivalCompleted;
        _atmManagementService.BalanceRetrivalFailedEvent += OnBalanceRetrivalFailed;
    }

    protected override void UnsubscribeFromEvents()
    {
        _accountManagementService.BalanceRetrivalCompletedEvent -= OnBalanceRetrivalCompleted;
        _accountManagementService.BalanceRetrivalFailedEvent -= OnBalanceRetrivalFailed;

        _atmManagementService.BalanceRetrivalCompletedEvent -= OnBalanceRetrivalCompleted;
        _atmManagementService.BalanceRetrivalFailedEvent -= OnBalanceRetrivalFailed;
    }

    private void OnBalanceRetrivalCompleted(object? _, string e)
    {
        ShowInfo(e);
        SendEmailNotification("Balance retrived", e);
    }

    private void OnBalanceRetrivalFailed(object? _, string e)
    {
        ShowError(e);
        SendEmailNotification("Balance retrival has failed", e);
    }

    private void MainMenuForm_Load(object? sender, EventArgs e)
    {
        var authenticationForm = new AuthenticationForm();
        authenticationForm.AuthenticationCompletedEvent += (_, e) => SetUserCardNumber(e);
        authenticationForm.ShowDialog();
    }

    private void MainMenuForm_FormClosed(object sender, FormClosedEventArgs e)
    {
        UnsubscribeFromEvents();
    }

    private void ExitButton_Click(object sender, EventArgs e)
    {
        DialogResult answer = ConfirmAction("Exit", "Are you sure you want to exit the application?");

        if (answer is DialogResult.Yes)
        {
            Application.Exit();
        }
    }

    private void ShowBalanceButton_Click(object sender, EventArgs e)
    {
        if (!_cardNumber.HasValue)
        {
            ShowError(UnathorizedErrorMessage);
            return;
        }

        _accountManagementService.GetAccountBalance(_cardNumber.Value);

        if (_atmId.HasValue)
        {
            _atmManagementService.GetAtmBalance(_atmId.Value);
        }
    }

    private void TransactionHistoryButton_Click(object sender, EventArgs e)
    {
        if (!_cardNumber.HasValue)
        {
            ShowError(UnathorizedErrorMessage);
            return;
        }

        var transactionHistoryForm = new TransactionHistoryForm(_cardNumber.Value);
        transactionHistoryForm.ShowDialog();
    }

    private void ClosestAtmButton_Click(object sender, EventArgs e)
    {
        var closestAtmForm = new ClosestAtmFrom();
        closestAtmForm.ClosestAtmFoundEvent += (_, e) => SetUserAtmId(e);
        closestAtmForm.ShowDialog();
    }

    private void InternalTransferButton_Click(object sender, EventArgs e)
    {
        if (!_cardNumber.HasValue)
        {
            ShowError(UnathorizedErrorMessage);
            return;
        }

        var transactionForm = TransactionForm.CreateForInternal(_cardNumber.Value);
        transactionForm.ShowDialog();
    }

    private void DepositTransferButton_Click(object sender, EventArgs e)
    {
        if (!_cardNumber.HasValue)
        {
            ShowError(UnathorizedErrorMessage);
            return;
        }

        if (!_atmId.HasValue)
        {
            ShowError(AtmRequiredErrorMessage);
            return;
        }

        var transactionForm = TransactionForm.CreateForDeposit(_cardNumber.Value, _atmId.Value);
        transactionForm.ShowDialog();
    }

    private void WithdrawalTransferButton_Click(object sender, EventArgs e)
    {
        if (!_cardNumber.HasValue)
        {
            ShowError(UnathorizedErrorMessage);
            return;
        }

        if (!_atmId.HasValue)
        {
            ShowError(AtmRequiredErrorMessage);
            return;
        }

        var transactionForm = TransactionForm.CreateForWithdrawal(_cardNumber.Value, _atmId.Value);
        transactionForm.ShowDialog();
    }

    public void SetUserCardNumber(CardNumber cardNumber)
    {
        _cardNumber = cardNumber;
    }

    public void SetUserAtmId(Guid atmId)
    {
        _atmId = atmId;

        DepositTransferButton.Enabled = true;
        DepositTransferButton.Visible = true;

        WithdrawalTransferButton.Enabled = true;
        WithdrawalTransferButton.Visible = true;
    }
}
