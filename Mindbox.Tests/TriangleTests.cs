using FluentAssertions;
using Mindbox.GeometryFigures.Figures;

namespace Mindbox.Tests;

public class TriangleTests
{
    private const string InvalidTriangle = "Such a triangle cannot exist";
    private const string LessThanOrEqualToZero = "All sides of the triangle must be greater than 0";
    
    [Theory]
    [InlineData(1, 2, 3, InvalidTriangle)]
    [InlineData(-1, 1, 1, LessThanOrEqualToZero)]
    [InlineData(1, -1, 1, LessThanOrEqualToZero)]
    [InlineData(1, 1, -1, LessThanOrEqualToZero)]
    [InlineData(1, 2, 0, LessThanOrEqualToZero)]
    public void TriangleConstructor_WithInvalidParams_ShouldThrowException(
        double side1, double side2, double side3, string errMsg)
    {
        Action act = () => new Triangle(side1, side2, side3);

        act.Should().Throw<ArgumentException>().WithMessage(errMsg);
    }

    [Theory]
    [InlineData(42, 42, 42, 763.834)]
    [InlineData(1.01, 1.01, 1.01, 0.441)]
    [InlineData(123.12, 432.43, 321.32, 9860.244)]
    public void CalculateArea_WithValidParams_ShouldReturnExpectedArea(
        double side1, double side2, double side3, double expectedArea)
    {
        var triangle = new Triangle(side1, side2, side3);

        triangle.CalculateArea().Should().BeApproximately(expectedArea, 0.001);
    }
    
    [Theory]
    [InlineData(3, 4, 5, true)]
    [InlineData(42, 42, 42, false)]
    public void IsRightAngled_WithValidParams_ShouldReturnExpectedValue(
        double side1, double side2, double side3, bool expectedValue)
    {
        var triangle = new Triangle(side1, side2, side3);

        triangle.IsRightAngled.Should().Be(expectedValue);
    }
}