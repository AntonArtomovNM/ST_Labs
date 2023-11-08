using Domain.Models.Enums;
using Domain.Models.Exceptions;
using Domain.Models.ValueObjects;
using Domain.Options;
using Domain.Services.Accounts;
using Domain.Services.ATMs;
using Domain.Services.EmailSending;
using Domain.Services.Transactions;
using Domain.TestData;

internal class Program
{
    private static readonly IAccountManagementService _accountManagementService = FakeContainer.AccountManagementService;
    private static readonly IAtmManagementService _atmManagementService = FakeContainer.AtmManagementService;
    private static readonly ITransactionManagementService _transactionManagementService = FakeContainer.TransactionManagementService;

    private static readonly IEmailSendingService _emailSendingService = FakeContainer.EmailSendingService;

    private static void Main()
    {
        SubscribeToEvents();

        RunApplication();

        Console.WriteLine("Exiting the program. Press any key to close the application.");
        Console.ReadKey();
    }

    private static void SubscribeToEvents()
    {
        _accountManagementService.AuthenticationCompletedEvent += OnReceivedEvent;
        _accountManagementService.AuthenticationFailedEvent += OnReceivedEvent;
        _accountManagementService.BalanceRetrivalCompletedEvent += OnReceivedEvent;
        _accountManagementService.BalanceRetrivalFailedEvent += OnReceivedEvent;

        _atmManagementService.BalanceRetrivalCompletedEvent += OnReceivedEvent;
        _atmManagementService.BalanceRetrivalFailedEvent += OnReceivedEvent;

        _transactionManagementService.DepositTransactionCompletedEvent += OnReceivedEvent;
        _transactionManagementService.DepositTransactionFailedEvent += OnReceivedEvent;
        _transactionManagementService.WithdrawalTransactionCompletedEvent += OnReceivedEvent;
        _transactionManagementService.WithdrawalTransactionFailedEvent += OnReceivedEvent;
        _transactionManagementService.InternalTransactionCompletedEvent += OnReceivedEvent;
        _transactionManagementService.InternalTransactionFailedEvent += OnReceivedEvent;

        static void OnReceivedEvent(object? _, string e)
        {
            Console.WriteLine(e);

            if (EmailOptions.IsEmailSendingEnabled)
            {
                var emailMessage = new EmailMessage("[Lab1 - Console] Notification received", e);

                _emailSendingService.SendEmail(emailMessage);
            }
        }
    }

    private static void RunApplication()
    {
        CardNumber? cardNumber = Authenticate();

        if (!cardNumber.HasValue)
        {
            Console.WriteLine("Authentication failed");
            return;
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();

        DisplayMainMenu(cardNumber.Value);
    }

    private static CardNumber? Authenticate()
    {
        int authenticationAttempts = 0;
        bool didAuthenticationSucceed = false;
        CardNumber cardNumber = default;

        do
        {
            authenticationAttempts++;

            try
            {
                Console.Write("Please enter your card number: ");
                string inputCardNumber = Console.ReadLine() ?? string.Empty;
                cardNumber = new CardNumber(inputCardNumber);

                Console.Write("Please enter your pincode: ");
                string inputPincode = Console.ReadLine() ?? string.Empty;
                Pincode pincode = new Pincode(inputPincode);

                didAuthenticationSucceed = _accountManagementService.AuthenticateAccount(cardNumber, pincode);
            }
            catch (ValidationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();

        } while (!didAuthenticationSucceed && authenticationAttempts < 5);

        return didAuthenticationSucceed ? cardNumber : null;
    }

    private static void DisplayMainMenu(CardNumber cardNumber)
    {
        bool exit = false;
        int invalidEnters = 0;
        Guid? atmId = null;

        do
        {
            Console.Clear();
            Console.WriteLine("Main menu");
            Console.WriteLine("  1. Show Balance");
            Console.WriteLine("  2. Transaction history");
            Console.WriteLine("  3. Closest ATM");
            Console.WriteLine("  4. Internal Transfer");

            if (atmId.HasValue)
            {
                Console.WriteLine("  5. Deposit Transfer");
                Console.WriteLine("  6. Withdrawal Transfer");

            }

            Console.WriteLine("  0. Exit");
            Console.WriteLine();
            Console.Write("Enter your choice: ");

            string? input = Console.ReadLine();

            Console.WriteLine();

            switch (input)
            {
                case "1":
                    DisplayBalance(cardNumber, atmId);
                    break;

                case "2":
                    DisplayTransactionHistory(cardNumber);
                    break;

                case "3":
                    atmId = GetClosestAtmId();
                    break;

                case "4":
                    ProcessInternalTransfer(cardNumber);
                    break;

                case "5" when atmId.HasValue:
                    ProcessDepositTransfer(cardNumber, atmId.Value);
                    break;

                case "6" when atmId.HasValue:
                    ProcessWithdrawalTransfer(cardNumber, atmId.Value);
                    break;

                case "0":
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    if (++invalidEnters > 5)
                    {
                        exit = true;
                    }
                    break;
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        } while (!exit);
    }

    private static void DisplayBalance(CardNumber cardNumber, Guid? atmId)
    {
        _accountManagementService.GetAccountBalance(cardNumber);

        if (atmId.HasValue)
        {
            _atmManagementService.GetAtmBalance(atmId.Value);
        }
    }

    private static void DisplayTransactionHistory(CardNumber cardNumber)
    {
        Console.Clear();
        Console.WriteLine("Time Range");
        Console.WriteLine("  1. All");
        Console.WriteLine("  2. Current Day");
        Console.WriteLine("  3. Current Week");
        Console.WriteLine("  4. Current Month");
        Console.WriteLine("  0. Go back");
        Console.WriteLine();
        Console.Write("Enter your choice: ");

        string? input = Console.ReadLine();

        TimeRangeOption? timeRange = input switch
        {
            "1" => TimeRangeOption.None,
            "2" => TimeRangeOption.Day,
            "3" => TimeRangeOption.Week,
            "4" => TimeRangeOption.Month,
            _ => null,
        };

        if (!timeRange.HasValue)
        {
            Console.WriteLine("Exiting transaction history");
            return;
        }

        var transactions = _transactionManagementService.GetTransactionsForAccountWithTimeRange(cardNumber, timeRange.Value);
        transactions.ForEach(t =>
        {
            Console.WriteLine();
            Console.WriteLine(t.ToStringDetailed());
        });
    }

    private static Guid? GetClosestAtmId()
    {
        Console.Clear();

        bool isInputValid = true;
        int inputAttempts = 0;
        Coordinates? userCoords = null;

        do
        {
            Console.Write("Enter your latitude (from -90  to 90): ");
            var xInput = Console.ReadLine()
                ?.Replace('.', ',')
                ?? string.Empty;
            isInputValid &= double.TryParse(xInput, out double x);

            Console.Write("Enter your longitude (from -180 to 180): ");
            var yInput = Console.ReadLine()
                ?.Replace('.', ',')
                ?? string.Empty;
            isInputValid &= double.TryParse(yInput.Replace('.', ','), out double y);

            try
            {
                userCoords = new Coordinates(x, y);
            }
            catch (ValidationException)
            {
                isInputValid = false;
            }

            if (!isInputValid)
            {
                Console.WriteLine("Coordinates are invalid, please try again");
                Console.WriteLine();
            }

            inputAttempts++;

        } while(!isInputValid && inputAttempts < 5);

        if (userCoords is null)
        {
            Console.WriteLine("Reached the limit on the number of retries");
            Console.WriteLine();
            return null;
        }

        var closestAtm = _atmManagementService.GetClosestAtmByCoordinates(userCoords.Value);

        if (closestAtm is null)
        {
            Console.WriteLine();
            Console.WriteLine("No ATMs found nearby");
            return null;
        }

        Console.Clear();
        Console.WriteLine("Closest ATM:");
        Console.WriteLine(closestAtm);

        return closestAtm.Id;
    }

    private static void ProcessInternalTransfer(CardNumber cardNumberFrom)
    {
        Console.Clear();

        int transferAttempts = 0;
        bool wasTransferExecuted = false;

        do
        {
            transferAttempts++;

            CardNumber cardNumberTo;

            try
            {
                Console.Write("Please enter destination card number: ");
                string inputCardNumber = Console.ReadLine() ?? string.Empty;
                cardNumberTo = new CardNumber(inputCardNumber);
            }
            catch (ValidationException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine();
                continue;
            }

            Console.Write("Please enter transaction amount: ");
            string inputAmount = Console.ReadLine() ?? string.Empty;

            var isParsed = decimal.TryParse(inputAmount, out decimal amount);

            if (!isParsed)
            {
                Console.WriteLine("Please enter valid amount");
                Console.WriteLine();
                continue;
            }

            Console.WriteLine();

            _transactionManagementService.CreateInternalTransaction(cardNumberFrom, cardNumberTo, amount);

            wasTransferExecuted = true;

        } while(!wasTransferExecuted && transferAttempts < 5);
    }

    private static void ProcessDepositTransfer(CardNumber cardNumber, Guid atmId)
    {
        Console.Clear();

        int transferAttempts = 0;
        bool wasTransferExecuted = false;

        do
        {
            transferAttempts++;

            Console.Write("Please enter transaction amount: ");
            string inputAmount = Console.ReadLine() ?? string.Empty;

            var isParsed = decimal.TryParse(inputAmount, out decimal amount);

            if (!isParsed)
            {
                Console.WriteLine("Please enter valid amount");
                Console.WriteLine();
                continue;
            }

            Console.WriteLine();

            _transactionManagementService.CreateDepositTransaction(cardNumber, atmId, amount);

            wasTransferExecuted = true;

        } while (!wasTransferExecuted && transferAttempts < 5);
    }

    private static void ProcessWithdrawalTransfer(CardNumber cardNumber, Guid atmId)
    {
        Console.Clear();

        int transferAttempts = 0;
        bool wasTransferExecuted = false;

        do
        {
            transferAttempts++;

            Console.Write("Please enter transaction amount: ");
            string inputAmount = Console.ReadLine() ?? string.Empty;

            var isParsed = decimal.TryParse(inputAmount, out decimal amount);

            if (!isParsed)
            {
                Console.WriteLine("Please enter valid amount");
                Console.WriteLine();
                continue;
            }

            Console.WriteLine();

            _transactionManagementService.CreateWithdrawalTransaction(cardNumber, atmId, amount);

            wasTransferExecuted = true;

        } while (!wasTransferExecuted && transferAttempts < 5);
    }
}
