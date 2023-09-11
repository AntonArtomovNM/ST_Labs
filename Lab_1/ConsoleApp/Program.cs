using System.Net;
using System.Text;
using Domain.Models.Entities;
using Domain.Models.Enums;
using Domain.Models.Exceptions;
using Domain.Models.ValueObjects;
using Domain.Services.Accounts;
using Domain.Services.ATMs;
using Domain.Services.Transactions;
using Domain.TestData;

internal class Program
{
    private static readonly IAccountManagementService _accountManagementService = FakeContainer.AccountManagementService;
    private static readonly IAtmManagementService _atmManagementService = FakeContainer.AtmManagementService;
    private static readonly ITransactionManagementService _transactionManagementService = FakeContainer.TransactionManagementService;

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
            DisplayTransaction(t);
        });
    }

    private static Guid? GetClosestAtmId()
    {
        Console.Clear();
        
        Console.Write("Enter your country (leave empty to skip): ");
        string country = Console.ReadLine() ?? string.Empty;
        
        Console.Write("Enter your state (leave empty to skip): ");
        string state = Console.ReadLine() ?? string.Empty;

        Console.Write("Enter your city (leave empty to skip): ");
        string city = Console.ReadLine() ?? string.Empty;

        Console.Write("Enter your street address part 1 (leave empty to skip): ");
        string street1 = Console.ReadLine() ?? string.Empty;
        
        Console.Write("Enter your street address part 2 (leave empty to skip): ");
        string street2 = Console.ReadLine() ?? string.Empty;

        var userAddress = new Address(street1, street2, city, state, country);

        var closestAtms = _atmManagementService.GetClosestAtmsByAddress(userAddress);

        if (!closestAtms.Any())
        {
            Console.WriteLine();
            Console.WriteLine("No ATMs found near by");
            return null;
        }

        Console.Clear();
        Console.WriteLine("Closest ATMs:");

        for (var i = 0; i < closestAtms.Count; i++)
        {
            Console.WriteLine();
            Console.WriteLine($"  {i + 1}. ATM #{i + 1}");
            DisplayAtm(closestAtms[i]);
        }

        Console.WriteLine();
        Console.WriteLine("  0. Go back");
        Console.WriteLine();
        Console.Write("Enter your choice: ");

        string? input = Console.ReadLine();
        int.TryParse(input, out int option);

        if (option < 1 || option > closestAtms.Count)
        {
            Console.WriteLine("Exiting ATMs list");
            return null;
        }

        var chosenAtm = closestAtms[option - 1];

        Console.WriteLine();
        Console.WriteLine("Your chosen ATM:");
        DisplayAtm(chosenAtm);

        return chosenAtm.Id;
    }

    private static void ProcessInternalTransfer(CardNumber cardNumberFrom)
    {
        Console.Clear();

        int transferAttempts = 0;
        bool wasTransferExecuted = false;

        do
        {
            transferAttempts++;

            CardNumber cardNumberTo = default;

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

    private static void DisplayTransaction(Transaction transaction)
    {
        var stringBuilder = new StringBuilder();

        stringBuilder.AppendLine(transaction.Purpose);
        stringBuilder.Append('-', transaction.Purpose.Length);
        stringBuilder.AppendLine();
        stringBuilder.AppendLine($"Type: {transaction.Type}");
        stringBuilder.AppendLine($"Amount: {transaction.Amount}");
        stringBuilder.AppendLine($"Status: {transaction.Status}");

        if (!string.IsNullOrWhiteSpace(transaction.FailReason))
        {
            stringBuilder.AppendLine($"Failed reason: \"{transaction.FailReason}\"");
        }

        stringBuilder.AppendLine($"Executed at: {transaction.ExecutedAtUtc:R}");

        Console.WriteLine(stringBuilder.ToString());
    }

    private static void DisplayAtm(AutomatedTellerMachine atm)
    {
        var stringBuilder = new StringBuilder();

        stringBuilder.AppendLine($"Id: {atm.Id}");
        stringBuilder.AppendLine($"Balance: {atm.CurrentBalance}");
        stringBuilder.Append("Address: ");

        atm.Address.Deconstruct(
            out string street1,
            out string street2,
            out string city,
            out string state,
            out string country);

        stringBuilder.AppendJoin(", ", street1, street2, city, state, country);

        Console.WriteLine(stringBuilder.ToString());
    }
}