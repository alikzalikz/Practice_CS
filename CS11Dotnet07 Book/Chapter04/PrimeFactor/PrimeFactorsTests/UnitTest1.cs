using static PrimeFactorsLib.PrimeFactors;

namespace PrimeFactorsTests;

public class UnitTest1
{
    [Fact]
    public void Test4()
    {
        // Arrange
        string expected = "Prime factors of 4 are: 2 x 2";

        // Act
        string actual = Factor(4);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Test7()
    {
        // Arrange
        string expected = "Prime factors of 7 are: 7";

        // Act
        string actual = Factor(7);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Test30()
    {
        // Arrange
        string expected = "Prime factors of 30 are: 5 x 3 x 2";

        // Act
        string actual = Factor(30);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Test40()
    {
        // Arrange
        string expected = "Prime factors of 40 are: 5 x 2 x 2 x 2";

        // Act
        string actual = Factor(40);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Test50()
    {
        // Arrange
        string expected = "Prime factors of 50 are: 5 x 5 x 2";

        // Act
        string actual = Factor(50);

        // Assert
        Assert.Equal(expected, actual);
    }

}