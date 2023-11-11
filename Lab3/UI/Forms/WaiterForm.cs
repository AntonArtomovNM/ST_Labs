using Domain.Entities;
using UI.Components;
using UI.Models;
using UI.Services.Waiters;
using UI.Utils;

namespace UI.Forms;

public partial class WaiterForm : Form
{
    private readonly IWaiterManagementService _waiterManagementService;

    private readonly WaiterGrid _waiterGrid;

    private IList<WaiterDto> _waiters = new List<WaiterDto>();

    public WaiterForm(IWaiterManagementService waiterManagementService)
    {
        _waiterManagementService = waiterManagementService;

        InitializeComponent();

        _waiterGrid = new WaiterGrid(DataGridView);
    }

    private async void On_Load(object sender, EventArgs e)
    {
        await RefreshWaiterGrid();
    }

    private async void On_AddButton_Click(object sender, EventArgs e)
    {
        try
        {
            await AddWaiter(FirstNameBox.Text, LastNameBox.Text, PhoneNumberBox.Text, DateOfBirthPicker.Value, SalaryInput.Value, (byte)RatingInput.Value);
        }
        catch (Exception ex)
        {
            FormUtils.ShowError(ex.Message);
        }
    }

    private async void On_DeleteToolStripMenuItem_Click(object sender, EventArgs e)
    {
        int rowIndex = DataGridView.SelectedRows[0].Index;

        WaiterDto waiter;

        try
        {
            waiter = _waiters[rowIndex];
        }
        catch (ArgumentOutOfRangeException)
        {
            return;
        }

        DialogResult result = FormUtils.ConfirmAction("Delete Waiter", "Are you sure you want to delete this record?");

        if (result is DialogResult.Yes)
        {
            try
            {
                await DeleteWaiter(waiter);
            }
            catch (Exception ex)
            {
                FormUtils.ShowError(ex.Message);
            }
        }
    }

    private async Task AddWaiter(
        string firstName,
        string lastName,
        string phoneNumber,
        DateTime dateOfBirth,
        decimal salary,
        byte rating)
    {
        var waiter = new WaiterDto(firstName, lastName, phoneNumber, dateOfBirth, salary, rating);

        await _waiterManagementService.Add(waiter);

        ClearInputBoxes();
        await RefreshWaiterGrid();
    }

    private async Task DeleteWaiter(WaiterDto waiter)
    {
        var removedSuccessfully = await _waiterManagementService.Remove(waiter);

        await RefreshWaiterGrid();

        if (!removedSuccessfully)
        {
            FormUtils.ShowError("Failed to remove the Waiter");
        }
    }

    private void ClearInputBoxes()
    {
        FirstNameBox.Text = string.Empty;
        LastNameBox.Text = string.Empty;
        PhoneNumberBox.Text = string.Empty;
        DateOfBirthPicker.Value = DateTime.UtcNow.Date;
        SalaryInput.Value = default;
        RatingInput.Value = default;
    }

    private async Task RefreshWaiterGrid()
    {
        _waiters = await _waiterManagementService.GetAll();

        _waiterGrid.RefreshDataGridView(_waiters);
    }
}
