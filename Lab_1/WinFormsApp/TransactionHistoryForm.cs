using Domain.Models.Entities;
using Domain.Models.Enums;
using Domain.Models.ValueObjects;
using Domain.Services.Transactions;
using Domain.TestData;

namespace WinFormsApp;

public partial class TransactionHistoryForm : ExtendedForm
{
    private const string InvalidOperationErrorMessage = "Invalid option selected";

    private readonly ITransactionManagementService _transactionManagementService;

    private CardNumber _cardNumber;

    public TransactionHistoryForm(CardNumber cardNumber)
    {
        InitializeComponent();

        _transactionManagementService = FakeContainer.TransactionManagementService;

        _cardNumber = cardNumber;
    }

    private void TimeRangeRadioButton_CheckedChanged(object sender, EventArgs e)
    {
        RadioButton? radionButton = sender as RadioButton;

        if (radionButton is null || !radionButton.Checked)
        {
            return;
        }

        bool isParsedSuccessfully = Enum.TryParse(radionButton.Text, out TimeRangeOption timeRangeOption);

        if (!isParsedSuccessfully)
        {
            ShowError(InvalidOperationErrorMessage);
            return;
        }

        List<Transaction> transactions = _transactionManagementService.GetTransactionsForAccountWithTimeRange(_cardNumber, timeRangeOption);

        object[] listItems = transactions.ToArray();

        TransactionHistoryList.Items.Clear();
        TransactionHistoryList.Items.AddRange(listItems);
    }
}
