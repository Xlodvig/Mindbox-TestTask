namespace Mindbox.GeometryFigures.Figures;

public class Circle : IFigure
{
    public double Radius { get; }

    public Circle(double radius)
    {
        if (radius <= 0)
            throw new ArgumentException("Radius of the circle must be greater than 0");
        
        Radius = radius;
    }

    public double CalculateArea() => 
        Math.PI * Math.Pow(Radius, 2);
}