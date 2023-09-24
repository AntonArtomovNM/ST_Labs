using Domain.Models.Exceptions;
using Domain.Models.ValueObjects;
using Domain.Services.ATMs;
using Domain.TestData;

namespace WinFormsApp;

public partial class ClosestAtmFrom : ExtendedForm
{
    private const string NoAtmsFoundErrorMessage = "No ATMs found nearby";

    private readonly IAtmManagementService _atmManagementService;

    private double _x;

    private double _y;

    public EventHandler<Guid>? ClosestAtmFoundEvent { get; set; }

    public ClosestAtmFrom()
    {
        InitializeComponent();

        _atmManagementService = FakeContainer.AtmManagementService;
    }

    private void XCoordinate_ValueChanged(object sender, EventArgs e)
    {
        _x = (double)XCoordinate.Value;
    }

    private void YCoordinate_ValueChanged(object sender, EventArgs e)
    {
        _y = (double)YCoordinate.Value;
    }

    private void FindClosestAtmButton_Click(object sender, EventArgs e)
    {
        Coordinates userCoordinates;

        try
        {
            userCoordinates = new Coordinates(_x, _y);
        }
        catch (ValidationException ex)
        {
            ShowError(ex.Message);
            return;
        }

        var closestAtm = _atmManagementService.GetClosestAtmByCoordinates(userCoordinates);

        if (closestAtm is null)
        {
            ShowError(NoAtmsFoundErrorMessage);
            return;
        }

        ShowInfo(closestAtm.ToString(), "Closest ATM");

        ClosestAtmFoundEvent?.Invoke(this, closestAtm.Id);
        
        this.Close();
    }
}
