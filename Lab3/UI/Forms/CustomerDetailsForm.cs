using Domain.Entities;
using UI.Forms.Contracts;
using UI.Models;
using UI.Services.Customers;
using UI.Services.Forms;
using UI.Utils;

namespace UI.Forms;
public partial class CustomerDetailsForm : Form, IModelViewForm
{
    private readonly IFormOpener _formOpener;
    private readonly ICustomerManagementService _customerManagementService;

    private int _customerId;
    private CustomerDto? _model;

    public CustomerDetailsForm(IFormOpener formOpener, ICustomerManagementService customerManagementService)
    {
        _formOpener = formOpener;
        _customerManagementService = customerManagementService;

        InitializeComponent();
    }

    private async void On_UpdateButton_Click(object sender, EventArgs e)
    {
        try
        {
            await UpdateCustomer(Customer_FirstNameBox.Text, Customer_LastNameBox.Text, Customer_PhoneNumberBox.Text, Customer_DateOfBirthPicker.Value);
        }
        catch (Exception ex)
        {
            FormUtils.ShowError(ex.Message);
        }
    }

    private async void On_DeleteButton_Click(object sender, EventArgs e)
    {
        if (_model is null)
        {
            FormUtils.ShowError("Customer is not set");
            return;
        }

        DialogResult result = FormUtils.ConfirmAction("Delete Customer", "Are you sure you want to delete this record?");

        if (result is DialogResult.Yes)
        {
            try
            {
                await DeleteCustomer(_model);
            }
            catch (Exception ex)
            {
                FormUtils.ShowError(ex.Message);
            }
        }

        Close();
    }

    private async void On_SelectWaiterButton_Click(object sender, EventArgs e)
    {
        await _formOpener.ShowModelViewForm<WaiterSelectionForm>(_customerId);
    }

    private async void On_RefreshButton_Click(object sender, EventArgs e)
    {
        await RefreshData();
    }

    public async Task SetModel(int id)
    {
        _customerId = id;

        await RefreshData();
    }

    private async Task UpdateCustomer(
        string firstName,
        string lastName,
        string phoneNumber,
        DateTime dateOfBirth)
    {
        var customer = new CustomerDto(firstName, lastName, phoneNumber, dateOfBirth);

        customer.SetId(_customerId);

        await _customerManagementService.Update(customer);

        await RefreshData();
    }

    private async Task DeleteCustomer(CustomerDto customer)
    {
        var removedSuccessfully = await _customerManagementService.Remove(customer);

        if (!removedSuccessfully)
        {
            FormUtils.ShowError("Failed to remove the Customer");
            return;
        }
    }

    private async Task RefreshData()
    {
        _model = await _customerManagementService.GetDetails(_customerId);

        if (_model is null)
        {
            return;
        }

        Customer_FirstNameBox.Text = _model.FirstName;
        Customer_LastNameBox.Text = _model.LastName;
        Customer_PhoneNumberBox.Text = _model.PhoneNumber;
        Customer_DateOfBirthPicker.Value = _model.DateOfBirth;

        var waiterData = _model.Waiter;

        if (waiterData is null)
        {
            return;
        }

        Waiter_FirstNameBox.Text = waiterData.FirstName;
        Waiter_LastNameBox.Text = waiterData.LastName;
        Waiter_PhoneNumberBox.Text = waiterData.PhoneNumber;
        Waiter_DateOfBirthPicker.Value = waiterData.DateOfBirth;
        Waiter_SalaryInput.Value = waiterData.Salary;
        Waiter_RatingInput.Value = waiterData.Rating;
    }
}
