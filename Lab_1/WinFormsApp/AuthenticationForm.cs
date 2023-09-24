using Domain.Models.Exceptions;
using Domain.Models.ValueObjects;
using Domain.Services.Accounts;
using Domain.TestData;

namespace WinFormsApp;

public partial class AuthenticationForm : ExtendedFormWithEvents
{
    private readonly IAccountManagementService _accountManagementService;

    private string _cardNumberText = string.Empty;
    private string _pincodeText = string.Empty;

    public EventHandler<CardNumber>? AuthenticationCompletedEvent { get; set; }

    public AuthenticationForm()
    {
        InitializeComponent();

        _accountManagementService = FakeContainer.AccountManagementService;

        SubscribeToEvents();
    }

    protected override void SubscribeToEvents()
    {
        _accountManagementService.AuthenticationCompletedEvent += OnAuthenticationCompleted;
        _accountManagementService.AuthenticationFailedEvent += OnAuthenticationFailed;
    }

    protected override void UnsubscribeFromEvents()
    {
        _accountManagementService.AuthenticationCompletedEvent -= OnAuthenticationCompleted;
        _accountManagementService.AuthenticationFailedEvent -= OnAuthenticationFailed;
    }

    private void OnAuthenticationCompleted(object? _, string e)
    {
        var cardNumber = new CardNumber(_cardNumberText);

        ShowInfo(e);
        SendEmailNotification("Authentication has happened", e);

        AuthenticationCompletedEvent?.Invoke(this, cardNumber);

        this.Close();
    }

    private void OnAuthenticationFailed(object? _, string e)
    {
        ShowError(e);
        SendEmailNotification("Authentication attempt has failed", e);
    }

    private void AuthenticationForm_FormClosed(object sender, FormClosedEventArgs e)
    {
        UnsubscribeFromEvents();
    }

    private void CardNumberBox_TextChanged(object sender, EventArgs e)
    {
        _cardNumberText = CardNumberBox.Text;
    }

    private void PincodeBox_TextChanged(object sender, EventArgs e)
    {
        _pincodeText = PincodeBox.Text;
    }

    private void AuthenticateButton_Click(object sender, EventArgs e)
    {
        CardNumber cardNumber;
        Pincode pincode;

        try
        {
            cardNumber = new CardNumber(_cardNumberText);
            pincode = new Pincode(_pincodeText);
        }
        catch (ValidationException ex)
        {
            ShowError(ex.Message);
            return;
        }

        _accountManagementService.AuthenticateAccount(cardNumber, pincode);
    }
}
