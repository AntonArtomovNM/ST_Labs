using System.Collections.Generic;
using UI.Components;
using UI.Forms.Contracts;
using UI.Models;
using UI.Services.Customers;
using UI.Services.Waiters;
using UI.Utils;

namespace UI.Forms;

public partial class WaiterSelectionForm : Form, IModelViewForm
{
    private readonly IWaiterManagementService _waiterManagementService;
    private readonly ICustomerManagementService _customerManagementService;

    private readonly WaiterGrid _waiterGrid;

    private IList<WaiterDto> _waiters = new List<WaiterDto>();

    private CustomerDto? _model;

    public WaiterSelectionForm(IWaiterManagementService waiterManagementService, ICustomerManagementService customerManagementService)
    {
        _waiterManagementService = waiterManagementService;
        _customerManagementService = customerManagementService;

        InitializeComponent();

        _waiterGrid = new WaiterGrid(DataGridView);
    }

    private async void On_Load(object sender, EventArgs e)
    {
        await RefreshWaiterGrid();
    }

    private async void On_SelectToolStripMenuItem_Click(object sender, EventArgs e)
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

        try
        {
            await SetWaiter(waiter);
        }
        catch (Exception ex)
        {
            FormUtils.ShowError(ex.Message);
        }

        Close();
    }

    public async Task SetModel(int id)
    {
        _model = await _customerManagementService.GetDetails(id);
    }

    private async Task SetWaiter(WaiterDto waiter)
    {
        if (_model is null)
        {
            FormUtils.ShowError("Customer is not set");
            return;
        }

        _model.SetWaiter(waiter);

        await _customerManagementService.Update(_model);
    }

    private async Task RefreshWaiterGrid()
    {
        _waiters = await _waiterManagementService.GetAll();

        _waiterGrid.RefreshDataGridView(_waiters);
    }
}
