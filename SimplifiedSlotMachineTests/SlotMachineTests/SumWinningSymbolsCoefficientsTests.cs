namespace SimplifiedSlotMachineTests.SlotMachineTests
{
    using SimplifiedSlotMachine;
    using SimplifiedSlotMachine.Factory.Contracts;
    using SimplifiedSlotMachine.Factory;
    using SimplifiedSlotMachine.Symbols;
    using SimplifiedSlotMachine.Symbols.Contracts;

    public class SumWinningSymbolsCoefficientsTests
    {
        SlotMachine slotMachine;

        public SumWinningSymbolsCoefficientsTests()
        {
            ISymbolFactory symbolFactory = new SymbolFactory();
            slotMachine = new SlotMachine(symbolFactory);
        }

        Apple apple = new Apple();
        Banana banana = new Banana();
        Pineapple pineapple = new Pineapple();
        Wildcard wildcard = new Wildcard();

        [Fact]
        public void SumWinningSymbolsCoefficients_WithMultipleAppleSymbols_ReturnsSumOfCoefficients()
        {
            // Arrange
            List<ISymbol> symbols = new List<ISymbol> { new Apple(), new Apple(), new Apple() };
            decimal winningCoefficient = apple.Coefficient + apple.Coefficient + apple.Coefficient;

            // Act
            decimal result = slotMachine.SumWinningSymbolsCoefficients(symbols);

            // Assert
            Assert.Equal(winningCoefficient, result);
        }

        [Fact]
        public void SumWinningSymbolsCoefficients_WithMultipleBananaSymbols_ReturnsSumOfCoefficients()
        {
            // Arrange
            List<ISymbol> symbols = new List<ISymbol> { new Banana(), new Banana(), new Banana() };
            decimal winningCoefficient = banana.Coefficient + banana.Coefficient + banana.Coefficient;

            // Act
            decimal result = slotMachine.SumWinningSymbolsCoefficients(symbols);

            // Assert
            Assert.Equal(winningCoefficient, result);
        }

        [Fact]
        public void SumWinningSymbolsCoefficients_WithMultiplePineappleSymbols_ReturnsSumOfCoefficients()
        {
            // Arrange
            List<ISymbol> symbols = new List<ISymbol> { new Pineapple(), new Pineapple(), new Pineapple() };
            decimal winningCoefficient = pineapple.Coefficient + pineapple.Coefficient + pineapple.Coefficient;

            // Act
            decimal result = slotMachine.SumWinningSymbolsCoefficients(symbols);

            // Assert
            Assert.Equal(winningCoefficient, result);
        }

        [Fact]
        public void SumWinningSymbolsCoefficients_WithMultipleWildcardSymbols_ReturnsSumOfCoefficients()
        {
            // Arrange
            List<ISymbol> symbols = new List<ISymbol> { new Wildcard(), new Wildcard(), new Wildcard() };
            decimal winningCoefficient = wildcard.Coefficient + wildcard.Coefficient + wildcard.Coefficient;

            // Act
            decimal result = slotMachine.SumWinningSymbolsCoefficients(symbols);

            // Assert
            Assert.Equal(winningCoefficient, result);
        }

        [Fact]
        public void SumWinningSymbolsCoefficients_WithWildcardSymbolAtStart_ReturnsSumOfCoefficients()
        {
            // Arrange
            List<ISymbol> symbols = new List<ISymbol> { new Wildcard(), new Apple(), new Apple() };
            decimal winningCoefficient = wildcard.Coefficient + apple.Coefficient + apple.Coefficient;

            // Act
            decimal result = slotMachine.SumWinningSymbolsCoefficients(symbols);

            // Assert
            Assert.Equal(winningCoefficient, result);
        }

        [Fact]
        public void SumWinningSymbolsCoefficients_WithTwoWildcardSymbolsAtStart_ReturnsSumOfCoefficients()
        {
            // Arrange
            List<ISymbol> symbols = new List<ISymbol> { new Wildcard(), new Wildcard(), new Apple() };
            decimal winningCoefficient = wildcard.Coefficient + wildcard.Coefficient + apple.Coefficient;

            // Act
            decimal result = slotMachine.SumWinningSymbolsCoefficients(symbols);

            // Assert
            Assert.Equal(winningCoefficient, result);
        }

        [Fact]
        public void SumWinningSymbolsCoefficients_WithWildcardSymbolAtEnd_ReturnsSumOfCoefficients()
        {
            // Arrange
            List<ISymbol> symbols = new List<ISymbol> { new Pineapple(), new Pineapple(), new Wildcard() };
            decimal winningCoefficient = pineapple.Coefficient + pineapple.Coefficient + wildcard.Coefficient;

            // Act
            decimal result = slotMachine.SumWinningSymbolsCoefficients(symbols);

            // Assert
            Assert.Equal(winningCoefficient, result);
        }

        [Fact]
        public void SumWinningSymbolsCoefficients_WithTwoWildcardSymbolsAtEnd_ReturnsSumOfCoefficients()
        {
            // Arrange
            List<ISymbol> symbols = new List<ISymbol> { new Pineapple(), new Wildcard(), new Wildcard() };
            decimal winningCoefficient = pineapple.Coefficient + wildcard.Coefficient + wildcard.Coefficient;

            // Act
            decimal result = slotMachine.SumWinningSymbolsCoefficients(symbols);

            // Assert
            Assert.Equal(winningCoefficient, result);
        }

        [Fact]
        public void SumWinningSymbolsCoefficients_WithWildcardSymbolsAtStartAndAtEnd_ReturnsSumOfCoefficients()
        {
            // Arrange
            List<ISymbol> symbols = new List<ISymbol> { new Wildcard(), new Pineapple(), new Wildcard() };
            decimal winningCoefficient = wildcard.Coefficient + pineapple.Coefficient + wildcard.Coefficient;

            // Act
            decimal result = slotMachine.SumWinningSymbolsCoefficients(symbols);

            // Assert
            Assert.Equal(winningCoefficient, result);
        }
    }
}
