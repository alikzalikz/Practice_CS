using static PrimeFactorsLib.PrimeFactors;

namespace PrimeFactorsTests;

public class TestFactors
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

public class TestPrime
{

    [Fact]
    public void Test0()
    {
        // Arrange
        bool expected = false;

        // Act
        bool actual = Prime(0);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        bool expected = true;

        // Act
        bool actual = Prime(1);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Test2()
    {
        // Arrange
        bool expected = true;

        // Act
        bool actual = Prime(2);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Test20()
    {
        // Arrange
        bool expected = false;

        // Act
        bool actual = Prime(20);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Test29()
    {
        // Arrange
        bool expected = true;

        // Act
        bool actual = Prime(29);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Test30()
    {
        // Arrange
        bool expected = false;

        // Act
        bool actual = Prime(30);

        // Assert
        Assert.Equal(expected, actual);
    }
}