namespace SimplifiedSlotMachineTests.SlotMachineTests
{
    using SimplifiedSlotMachine;
    using SimplifiedSlotMachine.Symbols;
    using SimplifiedSlotMachine.Symbols.Contracts;

    public class AreSymbolsMatchingTests
    {
        [Fact]
        public void AreSymbolsMatching_WithNullFirstSymbol_ReturnsFalse()
        {
            // Arrange
            List<ISymbol> symbols = new List<ISymbol> { null, new Apple(), new Apple() };

            // Act
            bool result = SlotMachine.AreSymbolsMatching(symbols);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void AreSymbolsMatching_WithMatchingSymbols_ReturnsTrue()
        {
            // Arrange
            List<ISymbol> symbols = new List<ISymbol> { new Apple(), new Apple(), new Apple() };

            // Act
            bool result = SlotMachine.AreSymbolsMatching(symbols);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void AreSymbolsMatching_WithWildcardSymbolAtStart_ReturnsTrue()
        {
            // Arrange
            List<ISymbol> symbols = new List<ISymbol> { new Wildcard(), new Apple(), new Apple() };

            // Act
            bool result = SlotMachine.AreSymbolsMatching(symbols);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void AreSymbolsMatching_WithTwoWildcardSymbolsAtStart_ReturnsTrue()
        {
            // Arrange
            List<ISymbol> symbols = new List<ISymbol> { new Wildcard(), new Wildcard(), new Apple() };

            // Act
            bool result = SlotMachine.AreSymbolsMatching(symbols);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void AreSymbolsMatching_WithWildcardSymbolAtEnd_ReturnsTrue()
        {
            // Arrange
            List<ISymbol> symbols = new List<ISymbol> { new Apple(), new Apple(), new Wildcard() };

            // Act
            bool result = SlotMachine.AreSymbolsMatching(symbols);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void AreSymbolsMatching_WithTwoWildcardSymbolsAtEnd_ReturnsTrue()
        {
            // Arrange
            List<ISymbol> symbols = new List<ISymbol> { new Apple(), new Wildcard(), new Wildcard() };

            // Act
            bool result = SlotMachine.AreSymbolsMatching(symbols);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void AreSymbolsMatching_WithWildcardSymbolsAtStartAndAtEnd_ReturnsTrue()
        {
            // Arrange
            List<ISymbol> symbols = new List<ISymbol> { new Wildcard(), new Apple(), new Wildcard() };

            // Act
            bool result = SlotMachine.AreSymbolsMatching(symbols);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void AreSymbolsMatching_WithMismatchedSymbols_ReturnsFalse()
        {
            // Arrange
            List<ISymbol> symbols = new List<ISymbol> { new Apple(), new Banana(), new Pineapple() };

            // Act
            bool result = SlotMachine.AreSymbolsMatching(symbols);

            // Assert
            Assert.False(result);
        }
    }
}