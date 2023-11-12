namespace SimplifiedSlotMachineTests.SlotGameTests
{
    using SimplifiedSlotMachine;
    using SimplifiedSlotMachine.Factory.Contracts;
    using SimplifiedSlotMachine.Factory;

    public class TryParseAndValidateInputTests
    {
        SlotGame slotGame;

        public TryParseAndValidateInputTests()
        {
            ISymbolFactory symbolFactory = new SymbolFactory();
            SlotMachine slotMachine = new SlotMachine(symbolFactory);
            slotGame = new SlotGame(slotMachine);
        }

        decimal deposit;
        decimal stake;
        string userInput;
        string fieldNameDeposit = "Deposit";
        string fieldNameStake = "Stake";
        Func<decimal, bool> validateFuncDeposit = d => d > 0;
        Func<decimal, bool> validateFuncStake = d => d > 0 && d <= 20;
        string throwInvalidInputException = "Please enter a valid numeric value with only one decimal place. For example, you can use '10.5' to represent ten and a half. Please try again.";


        #region Deposit tests
        [Fact]
        public void TryParseAndValidateInput_ValidDepositAmount_ReturnsTrue()
        {
            // Arrange
            userInput = "20";

            // Act
            var result = slotGame.TryParseAndValidateInput(userInput, fieldNameDeposit, out deposit, validateFuncDeposit);

            // Assert
            Assert.True(result);
            Assert.Equal(20, deposit);
        }

        [Fact]
        public void TryParseAndValidateInput_InvalidDepositInputLetters_ThrowArgumentException()
        {
            // Arrange
            userInput = "qwerty";

            // Act and Assert
            ArgumentException ex = Assert.Throws<ArgumentException>(() => slotGame.TryParseAndValidateInput(userInput, fieldNameDeposit, out deposit, validateFuncDeposit));
            Assert.Equal($"Invalid {fieldNameDeposit} input. {throwInvalidInputException}", ex.Message);
        }

        [Fact]
        public void TryParseAndValidateInput_InvalidDepositInputZero_ThrowArgumentException()
        {
            // Arrange
            userInput = "0";

            // Act and Assert
            ArgumentException ex = Assert.Throws<ArgumentException>(() => slotGame.TryParseAndValidateInput(userInput, fieldNameDeposit, out deposit, validateFuncDeposit));
            Assert.Equal($"Invalid {fieldNameDeposit} input. {throwInvalidInputException}", ex.Message);
        }

        [Fact]
        public void TryParseAndValidateInput_InvalidDepositInputNegativeNumber_ThrowArgumentException()
        {
            // Arrange
            userInput = "-10";

            // Act and Assert
            ArgumentException ex = Assert.Throws<ArgumentException>(() => slotGame.TryParseAndValidateInput(userInput, fieldNameDeposit, out deposit, validateFuncDeposit));
            Assert.Equal($"Invalid {fieldNameDeposit} input. {throwInvalidInputException}", ex.Message);
        }
        #endregion

        #region Stake tests
        [Fact]
        public void TryParseAndValidateInput_ValidStakeAmount_ReturnsTrue()
        {
            // Arrange
            userInput = "20";

            // Act
            var result = slotGame.TryParseAndValidateInput(userInput, fieldNameStake, out stake, validateFuncStake);

            // Assert
            Assert.True(result);
            Assert.Equal(20, stake);
        }

        [Fact]
        public void TryParseAndValidateInput_InvalidStakeInputLetters_ThrowArgumentException()
        {
            // Arrange
            userInput = "qwerty";

            // Act and Assert
            ArgumentException ex = Assert.Throws<ArgumentException>(() => slotGame.TryParseAndValidateInput(userInput, fieldNameStake, out stake, validateFuncStake));
            Assert.Equal($"Invalid {fieldNameStake} input. {throwInvalidInputException}", ex.Message);
        }

        [Fact]
        public void TryParseAndValidateInput_InvalidStakeInputZero_ThrowArgumentException()
        {
            // Arrange
            userInput = "0";

            // Act and Assert
            ArgumentException ex = Assert.Throws<ArgumentException>(() => slotGame.TryParseAndValidateInput(userInput, fieldNameStake, out stake, validateFuncStake));
            Assert.Equal($"Invalid {fieldNameStake} input. {throwInvalidInputException}", ex.Message);
        }

        [Fact]
        public void TryParseAndValidateInput_InvalidStakeInputNegativeNumber_ThrowArgumentException()
        {
            // Arrange
            userInput = "-10";

            // Act and Assert
            ArgumentException ex = Assert.Throws<ArgumentException>(() => slotGame.TryParseAndValidateInput(userInput, fieldNameStake, out stake, validateFuncStake));
            Assert.Equal($"Invalid {fieldNameStake} input. {throwInvalidInputException}", ex.Message);
        }

        [Fact]
        public void TryParseAndValidateInput_InvalidStakeInputGreaterThanTheBalance_ThrowArgumentException()
        {
            // Arrange
            userInput = "22";

            // Act and Assert
            ArgumentException ex = Assert.Throws<ArgumentException>(() => slotGame.TryParseAndValidateInput(userInput, fieldNameStake, out stake, validateFuncStake));
            Assert.Equal($"Invalid {fieldNameStake} input. {fieldNameStake} amount can not be greater than the Balance. Please try again.", ex.Message);
        }
        #endregion
    }
}
