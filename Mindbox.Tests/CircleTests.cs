using FluentAssertions;
using Mindbox.GeometryFigures.Figures;

namespace Mindbox.Tests;

public class CircleTests
{
    private const string InvalidCircle = "Radius of the circle must be greater than 0";
    
    [Theory]
    [InlineData(0, InvalidCircle)]
    [InlineData(-1, InvalidCircle)]
    [InlineData(-1.5, InvalidCircle)]
    public void CircleConstructor_WithInvalidParams_ShouldThrowException(double radius, string errMsg)
    {
        Action act = () => new Circle(radius);

        act.Should().Throw<ArgumentException>().WithMessage(errMsg);
    }
    
    [Theory]
    [InlineData(0.1, 0.031)]
    [InlineData(1, 3.141)]
    [InlineData(42.42, 5653.159)]
    public void CircleConstructor_WithValidParams_ShouldReturnExpectedValue(double radius, double expectedArea)
    {
        var circle = new Circle(radius);

        circle.CalculateArea().Should().BeApproximately(expectedArea, 0.001);
    }
}