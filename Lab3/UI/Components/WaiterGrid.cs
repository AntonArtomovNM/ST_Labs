using UI.Models;
using UI.Utils;

namespace UI.Components;

public class WaiterGrid
{
    private const int ColumnsCount = 6;

    private DataGridView _dataGrid;

    private IList<DataGridViewTextBoxColumn>? _columns;

    public WaiterGrid(DataGridView dataGrid)
    {
        _dataGrid = dataGrid;

        InitializeDataGridView();
    }

    public void RefreshDataGridView(IEnumerable<WaiterDto> waiters)
    {
        _dataGrid.Rows.Clear();

        var rows = waiters.Select(GetWaiterRow);
        _dataGrid.Rows.AddRange(rows.ToArray());
    }

    private void InitializeDataGridView()
    {
        _dataGrid.DataSource = null;
        _dataGrid.Columns.AddRange(GetWaiterColumns());
    }

    private DataGridViewTextBoxColumn[] GetWaiterColumns()
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
                    Width = _dataGrid.Width / ColumnsCount,
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "LastName",
                    HeaderText = "Last Name",
                    ValueType = typeof(string),
                    Width = _dataGrid.Width / ColumnsCount,
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "PhoneNumber",
                    HeaderText = "Phone Number",
                    ValueType = typeof(string),
                    Width = _dataGrid.Width / ColumnsCount,
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "DateOfBirth",
                    HeaderText = "Date of Birth",
                    ValueType = typeof(DateTime),
                    Width = _dataGrid.Width / ColumnsCount,
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Salary",
                    HeaderText = "Salary ($)",
                    ValueType = typeof(decimal),
                    Width = _dataGrid.Width / ColumnsCount,
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Rating",
                    HeaderText = "Rating",
                    ValueType = typeof(byte),
                    Width = _dataGrid.Width / ColumnsCount,
                },
            };
        }

        return _columns.ToArray();
    }

    private DataGridViewRow GetWaiterRow(WaiterDto waiter)
    {
        var cells = new DataGridViewCell[]
        {
            FormUtils.GetDataGridCell(waiter.FirstName),
            FormUtils.GetDataGridCell(waiter.LastName),
            FormUtils.GetDataGridCell(waiter.PhoneNumber),
            FormUtils.GetDataGridCell(waiter.DateOfBirth),
            FormUtils.GetDataGridCell(waiter.Salary),
            FormUtils.GetDataGridCell(waiter.Rating),
        };

        var row = new DataGridViewRow();

        row.Cells.AddRange(cells);

        return row;
    }
}
