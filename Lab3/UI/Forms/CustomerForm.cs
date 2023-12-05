using UI.Models;
using UI.Services.Customers;
using UI.Services.Forms;
using UI.Utils;

namespace UI.Forms;

public partial class CustomerForm : Form
{
    private const int ColumnsCount = 4;

    private readonly IFormOpener _fromOpener;
    private readonly ICustomerManagementService _customerManagementService;

    private IList<DataGridViewTextBoxColumn>? _columns;

    private IList<CustomerDto> _customers = new List<CustomerDto>();

    public CustomerForm(IFormOpener fromOpener, ICustomerManagementService customerManagementService)
    {
        _fromOpener = fromOpener;
        _customerManagementService = customerManagementService;

        InitializeComponent();
        InitializeDataGridView();
    }

    private async void On_Load(object sender, EventArgs e)
    {
        await RefreshDataGridView();
    }

    private async void On_AddButton_Click(object sender, EventArgs e)
    {
        try
        {
            await AddCustomer(FirstNameBox.Text, LastNameBox.Text, PhoneNumberBox.Text, DateOfBirthPicker.Value);
        }
        catch (Exception ex)
        {
            FormUtils.ShowError(ex.Message);
        }
    }

    private async void On_DeleteToolStripMenuItem_Click(object sender, EventArgs e)
    {
        int rowIndex = DataGridView.SelectedRows[0].Index;

        CustomerDto customer;

        try
        {
            customer = _customers[rowIndex];
        }
        catch (ArgumentOutOfRangeException)
        {
            return;
        }

        DialogResult result = FormUtils.ConfirmAction("Delete Customer", "Are you sure you want to delete this record?");

        if (result is DialogResult.Yes)
        {
            try
            {
                await DeleteCustomer(customer);
            }
            catch (Exception ex)
            {
                FormUtils.ShowError(ex.Message);
            }
        }
    }

    private async void On_SeeDetailsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        int rowIndex = DataGridView.SelectedRows[0].Index;

        CustomerDto customer;

        try
        {
            customer = _customers[rowIndex];
        }
        catch (ArgumentOutOfRangeException)
        {
            return;
        }

        if (!customer.Id.HasValue)
        {
            FormUtils.ShowError("Customer id is not set");
            return;
        }

        await _fromOpener.ShowModelViewForm<CustomerDetailsForm>(customer.Id.Value);
    }

    private async Task AddCustomer(
        string firstName,
        string lastName,
        string phoneNumber,
        DateTime dateOfBirth)
    {
        var customer = new CustomerDto(firstName, lastName, phoneNumber, dateOfBirth);

        await _customerManagementService.Add(customer);

        ClearInputBoxes();
        await RefreshDataGridView();
    }

    private async Task DeleteCustomer(CustomerDto customer)
    {
        var removedSuccessfully = await _customerManagementService.Remove(customer);

        await RefreshDataGridView();

        if (!removedSuccessfully)
        {
            FormUtils.ShowError("Failed to remove the Customer");
        }
    }

    private void InitializeDataGridView()
    {
        DataGridView.DataSource = null;
        DataGridView.Columns.AddRange(GetCustomerColumns());
    }

    private async Task RefreshDataGridView()
    {
        DataGridView.Rows.Clear();

        _customers = await _customerManagementService.GetAll();

        var rows = _customers.Select(GetCustomerRow);
        DataGridView.Rows.AddRange(rows.ToArray());
    }

    private void ClearInputBoxes()
    {
        FirstNameBox.Text = string.Empty;
        LastNameBox.Text = string.Empty;
        PhoneNumberBox.Text = string.Empty;
        DateOfBirthPicker.Value = DateTime.UtcNow.Date;
    }

    private DataGridViewTextBoxColumn[] GetCustomerColumns()
    {
        if (_columns is null)
        {
            _columns = new List<DataGridViewTextBoxColumn>()
            {
                new DataGridViewTextBoxColumn
                {
                    Name = "FirstName",
                    HeaderText = "First Name",
                    ValueType = typeof(string),
                    Width = DataGridView.Width / ColumnsCount,
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "LastName",
                    HeaderText = "Last Name",
                    ValueType = typeof(string),
                    Width = DataGridView.Width / ColumnsCount,
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "PhoneNumber",
                    HeaderText = "Phone Number",
                    ValueType = typeof(string),
                    Width = DataGridView.Width / ColumnsCount,
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "DateOfBirth",
                    HeaderText = "Date of Birth",
                    ValueType = typeof(DateTime),
                    Width = DataGridView.Width / ColumnsCount,
                },
            };
        }

        return _columns.ToArray();
    }

    private DataGridViewRow GetCustomerRow(CustomerDto customer)
    {
        var cells = new DataGridViewCell[]
        {
            FormUtils.GetDataGridCell(customer.FirstName),
            FormUtils.GetDataGridCell(customer.LastName),
            FormUtils.GetDataGridCell(customer.PhoneNumber),
            FormUtils.GetDataGridCell(customer.DateOfBirth),
        };

        var row = new DataGridViewRow();

        row.Cells.AddRange(cells);

        return row;
    }
}
