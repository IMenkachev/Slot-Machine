namespace SimplifiedSlotMachineTests.SlotGameTests
{
    using SimplifiedSlotMachine;
    using SimplifiedSlotMachine.Factory.Contracts;
    using SimplifiedSlotMachine.Factory;

    public class IsValidNonNegativeNumericInputTests
    {
        SlotGame slotGame;

        public IsValidNonNegativeNumericInputTests()
        {
            ISymbolFactory symbolFactory = new SymbolFactory();
            SlotMachine slotMachine = new SlotMachine(symbolFactory);
            slotGame = new SlotGame(slotMachine);
        }

        string userInput;

        [Fact]
        public void IsValidNonNegativeNumericInput_ValidInput_ReturnsTrue()
        {
            // Arrange
            userInput = "20";

            // Act
            var result = slotGame.IsValidNonNegativeNumericInput(userInput);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsValidNonNegativeNumericInput_InvalidInputTwoDecimalPlaces_ReturnsFalse()
        {
            // Arrange
            userInput = "20.20";

            // Act
            var result = slotGame.IsValidNonNegativeNumericInput(userInput);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsValidNonNegativeNumericInput_InvalidInputNegativeNumber_ReturnsFalse()
        {
            // Arrange
            userInput = "-20";

            // Act
            var result = slotGame.IsValidNonNegativeNumericInput(userInput);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsValidNonNegativeNumericInput_InvalidInputZero_ReturnsFalse()
        {
            // Arrange
            userInput = "0";

            // Act
            var result = slotGame.IsValidNonNegativeNumericInput(userInput);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsValidNonNegativeNumericInput_InvalidInputLetters_ReturnsFalse()
        {
            // Arrange
            userInput = "qwerty";

            // Act
            var result = slotGame.IsValidNonNegativeNumericInput(userInput);

            // Assert
            Assert.False(result);
        }
    }
}
