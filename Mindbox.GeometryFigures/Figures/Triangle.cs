namespace Mindbox.GeometryFigures.Figures;

public class Triangle : IFigure
{
    public double SideA { get; }
    public double SideB { get; }
    public double MaxSide { get; }
    private double Perimeter => SideA + SideB + MaxSide;
    private const double Accuracy = 0.001; 

    public Triangle(double side1, double side2, double side3)
    {
        if (side1 <= 0 || side2 <= 0 || side3 <= 0)
            throw new ArgumentException("All sides of the triangle must be greater than 0");

        var array = new[] { side1, side2, side3 };
        Array.Sort(array);

        SideA = array[0];
        SideB = array[1];
        MaxSide = array[2];

        if (Perimeter - MaxSide * 2 <= 0)
            throw new ArgumentException("Such a triangle cannot exist");
    }

    public double CalculateArea()
    {
        var p = Perimeter / 2;
        
        return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - MaxSide));
    }

    public bool IsRightAngled => 
        Math.Abs(Math.Pow(MaxSide, 2) - Math.Pow(SideA, 2) - Math.Pow(SideB, 2)) < Accuracy;
}