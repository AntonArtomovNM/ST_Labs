using System.ComponentModel.DataAnnotations;

namespace Domain.Models.ValueObjects;

public record struct Coordinates
{
    private const double MinX = -90;

    private const double MaxX = 90;

    private const double MinY = -180;

    private const double MaxY = 180;

    /// <summary>
    /// Latitude
    /// </summary>
    public double X { get; }

    /// <summary>
    /// Longitude
    /// </summary>
    public double Y { get; }

    public Coordinates(double x, double y)
    {
        if (x < MinX || x > MaxX)
        {
            throw new ValidationException($"X coordinate must be a value in range ({MinX}; {MaxX}");
        }

        if (y < MinY || x > MaxY)
        {
            throw new ValidationException($"Y coordinate must be a value in range ({MinY}; {MaxY}");
        }

        X = x;
        Y = y;
    }

    public double GetDistanceTo(Coordinates coords2)
    {
        double deltaX = coords2.X - X;
        double deltaY = coords2.Y - Y;

        // Use the Pythagorean theorem to calculate the distance
        double distance = Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY));

        return distance;
    }
}