namespace SimplifiedSlotMachine
{
    using System.Text.RegularExpressions;

    public class SlotGame
    {
        // Regex pattern to validate input is digits, not negative, greater than 0 and contains only one decimal place.
        private static string pattern = @"^(?!0(?:\.0)?$)\d+(\.\d{1})?$";

        private readonly SlotMachine _slotMachine;
        private decimal deposit;
        private decimal stake;
        private decimal winAmount;
        private decimal balance;

        public SlotGame(SlotMachine slotMachine)
        {
            _slotMachine = slotMachine;
        }

        public void Play()
        {
            Console.WriteLine("Welcome to the Slot Game!");

            AddDeposit();

            while (balance > 0)
            {
                AddStake();
                _slotMachine.Spin();
                CalculateWinAmount();
                UpdateBalance();
                DisplayReels();
            }

            Console.WriteLine("Game Over");
        }

        private void AddDeposit()
        {
            Console.WriteLine("Please deposit money you would like to play with:");
            while (true)
            {
                try
                {
                    string depositInput = Console.ReadLine();
                    if (TryParseAndValidateInput(depositInput, "Deposit", out deposit, d => d > 0))
                    {
                        balance = deposit;
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void AddStake()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter Stake amount:");
                    string stakeInput = Console.ReadLine();
                    if (TryParseAndValidateInput(stakeInput, "Stake", out stake, d => d > 0 && d <= balance))
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public bool TryParseAndValidateInput(string userInput,
                                              string fieldName,
                                              out decimal result,
                                              Func<decimal, bool> validationFunc)
        {
            if (IsValidNonNegativeNumericInput(userInput))
            {
                decimal.TryParse(userInput, out result);

                if (validationFunc(result))
                {
                    return true;
                }
                else
                {
                    ThrowInvalidInputException(fieldName, $"{fieldName} amount can not be greater than the Balance.");
                }
            }
            else
            {
                ThrowInvalidInputException(fieldName, "Please enter a valid numeric value with only one decimal place. For example, you can use '10.5' to represent ten and a half.");
            }

            result = 0;
            return false;
        }

        private void ThrowInvalidInputException(string fieldName, string errorMessage)
        {
            throw new ArgumentException($"Invalid {fieldName} input. {errorMessage} Please try again.");
        }

        public bool IsValidNonNegativeNumericInput(string input)
        {
            return Regex.IsMatch(input, pattern);
        }

        private void CalculateWinAmount()
        {
            winAmount = Math.Round(_slotMachine.WinningCoefficient * stake, 1);
        }

        private void UpdateBalance()
        {
            balance = (balance - stake) + winAmount;
        }

        private void DisplayReels()
        {
            Console.WriteLine();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"{_slotMachine.Reels[i][j].Symbol}");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine($"You have won: {winAmount}");
            Console.WriteLine($"Current balance is: {balance}");
            Console.WriteLine();
        }
    }
}
