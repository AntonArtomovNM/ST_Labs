using Domain.Models.Enums;
using Domain.Models.Exceptions;
using Domain.Models.ValueObjects;
using Domain.Services.Transactions;
using Domain.TestData;

namespace WinFormsApp;

public partial class TransactionForm : ExtendedForm
{
    private readonly ITransactionManagementService _transactionManagementService;

    private TransactionType _transactionType;

    private CardNumber? _cardNumberFrom;

    private CardNumber? _cardNumberTo;

    private Guid? _atmIdFrom;

    private Guid? _atmIdTo;

    private string _cardNumberToText = string.Empty;

    private decimal _amount = 0M;

    private TransactionForm(
        TransactionType transactionType,
        CardNumber? cardNumberFrom,
        Guid? atmIdFrom,
        CardNumber? cardNumberTo,
        Guid? atmIdTo)
    {
        InitializeComponent();

        _transactionManagementService = FakeContainer.TransactionManagementService;

        _transactionType = transactionType;
        _cardNumberFrom = cardNumberFrom;
        _atmIdFrom = atmIdFrom;
        _cardNumberTo = cardNumberTo;
        _atmIdTo = atmIdTo;

        SubscribeToEvents();

        CardNumberFromBox.Text = _cardNumberFrom?.Value;
        CardNumberToBox.Text = _cardNumberTo?.Value;
        AtmFromBox.Text = _atmIdFrom?.ToString();
        AtmToBox.Text = _atmIdTo?.ToString();
    }

    public static TransactionForm CreateForInternal(CardNumber cardNumber)
    {
        TransactionForm form = new(
            TransactionType.Internal,
            cardNumberFrom: cardNumber,
            atmIdFrom: null,
            cardNumberTo: null,
            atmIdTo: null);

        form.CardNumberFromBox.Visible = true;
        form.CardNumberFromLabel.Visible = true;

        form.CardNumberToBox.Visible = true;
        form.CardNumberToLabel.Visible = true;

        form.CardNumberToBox.Enabled = true;

        return form;
    }

    public static TransactionForm CreateForDeposit(CardNumber cardNumber, Guid atmId)
    {
        TransactionForm form = new(
            TransactionType.Deposit,
            cardNumberFrom: null,
            atmIdFrom: null,
            cardNumberTo: cardNumber,
            atmIdTo: atmId);

        form.CardNumberToBox.Visible = true;
        form.CardNumberToLabel.Visible = true;

        form.AtmToBox.Visible = true;
        form.AtmToLabel.Visible = true;

        return form;
    }

    public static TransactionForm CreateForWithdrawal(CardNumber cardNumber, Guid atmId)
    {
        TransactionForm form = new(
            TransactionType.Withdrawal,
            cardNumberFrom: cardNumber,
            atmIdFrom: atmId,
            cardNumberTo: null,
            atmIdTo: null);

        form.CardNumberFromBox.Visible = true;
        form.CardNumberFromLabel.Visible = true;

        form.AtmFromBox.Visible = true;
        form.AtmFromLabel.Visible = true;

        return form;
    }

    private void TransactionForm_FormClosed(object sender, FormClosedEventArgs e)
    {
        UnsubscribeFromEvents();
    }

    private void CardNumberToBox_TextChanged(object sender, EventArgs e)
    {
        _cardNumberToText = CardNumberToBox.Text;
    }

    private void AmountBox_ValueChanged(object sender, EventArgs e)
    {
        _amount = AmountBox.Value;
    }

    private void ExecuteButton_Click(object sender, EventArgs e)
    {
        switch (_transactionType)
        {
            case TransactionType.Internal:
                ExecuteInternal();
                return;

            case TransactionType.Deposit:
                ExecuteDeposit();
                return;

            case TransactionType.Withdrawal:
                ExecuteWithdrawal();
                return;

            default:
                ShowError("Invalid transaction type");
                return;
        }
    }

    private void ExecuteInternal()
    {
        if (!_cardNumberFrom.HasValue)
        {
            ShowError("Source card number is not set");
            return;
        }

        try
        {
            _cardNumberTo = new CardNumber(_cardNumberToText);
        }
        catch (ValidationException ex)
        {
            ShowError(ex.Message);
            return;
        }

        _transactionManagementService.CreateInternalTransaction(_cardNumberFrom.Value, _cardNumberTo.Value, _amount);
    }

    private void ExecuteDeposit()
    {
        if (!_cardNumberTo.HasValue)
        {
            ShowError("Destination card number is not set");
            return;
        }

        if (!_atmIdTo.HasValue)
        {
            ShowError("Destination ATM is not set");
            return;
        }

        _transactionManagementService.CreateDepositTransaction(_cardNumberTo.Value, _atmIdTo.Value, _amount);
    }

    private void ExecuteWithdrawal()
    {
        if (!_cardNumberFrom.HasValue)
        {
            ShowError("Source card number is not set");
            return;
        }

        if (!_atmIdFrom.HasValue)
        {
            ShowError("Source ATM is not set");
            return;
        }

        _transactionManagementService.CreateWithdrawalTransaction(_cardNumberFrom.Value, _atmIdFrom.Value, _amount);
    }

    private void SubscribeToEvents()
    {
        _transactionManagementService.DepositTransactionCompletedEvent += OnTransactionCompleted;
        _transactionManagementService.DepositTransactionFailedEvent += OnTransactionFailed;

        _transactionManagementService.WithdrawalTransactionCompletedEvent += OnTransactionCompleted;
        _transactionManagementService.WithdrawalTransactionFailedEvent += OnTransactionFailed;

        _transactionManagementService.InternalTransactionCompletedEvent += OnTransactionCompleted;
        _transactionManagementService.InternalTransactionFailedEvent += OnTransactionFailed;
    }

    private void UnsubscribeFromEvents()
    {
        _transactionManagementService.DepositTransactionCompletedEvent -= OnTransactionCompleted;
        _transactionManagementService.DepositTransactionFailedEvent -= OnTransactionFailed;

        _transactionManagementService.WithdrawalTransactionCompletedEvent -= OnTransactionCompleted;
        _transactionManagementService.WithdrawalTransactionFailedEvent -= OnTransactionFailed;

        _transactionManagementService.InternalTransactionCompletedEvent -= OnTransactionCompleted;
        _transactionManagementService.InternalTransactionFailedEvent -= OnTransactionFailed;
    }

    private void OnTransactionCompleted(object? _, string e)
    {
        ShowInfo(e);

        this.Close();
    }

    private void OnTransactionFailed(object? _, string e)
    {
        ShowError(e);
    }
}
