using CalculatorTest;

namespace CalculatorTests
{
    public class SimpleCalculatorTests
    {
        [Fact]
        public void Add_ValidInput_ReturnsSum()
        {
            // Arrange
            SimpleCalculator calculator = new SimpleCalculator();
            int start = 7;
            int amount = 4;

            // Act
            int result = calculator.Add(start, amount);

            // Assert
            Assert.Equal(11, result);
        }

        [Fact]
        public void Subtract_ValidInput_ReturnsDifference()
        {
            SimpleCalculator calculator = new SimpleCalculator();
            int start = 12;
            int amount = 7;

            int result = calculator.Subtract(start, amount);

            Assert.Equal(5, result);
        }
    }
}