namespace SimplifiedSlotMachine
{
    using SimplifiedSlotMachine.Factory.Contracts;
    using SimplifiedSlotMachine.Symbols;
    using SimplifiedSlotMachine.Symbols.Contracts;

    public class SlotMachine
    {
        private readonly ISymbolFactory _symbolFactory;

        public ISymbol[][] Reels { get; private set; } = new ISymbol[4][];
        public decimal WinningCoefficient { get; private set; }

        public SlotMachine(ISymbolFactory symbolFactory)
        {
            _symbolFactory = symbolFactory;

            for (int i = 0; i < 4; i++)
            {
                Reels[i] = new ISymbol[3];
            }
        }

        public void Spin()
        {
            ResetWinningCoefficient();
            List<ISymbol> currentRowSymbolsList = new List<ISymbol>();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Reels[i][j] = _symbolFactory.CreateSymbol();
                }

                ISymbol[] currentRow = Reels[0];
                for (int r = 0; r < currentRow.Length; r++)
                {
                    currentRowSymbolsList.Add(Reels[i][r]);
                }

                if (AreSymbolsMatching(currentRowSymbolsList))
                {
                    WinningCoefficient += SumWinningSymbolsCoefficients(currentRowSymbolsList);
                }

                currentRowSymbolsList.Clear();
            }
        }

        public static bool AreSymbolsMatching(List<ISymbol> symbols)
        {
            ISymbol firstSymbol = symbols[0];
            if (firstSymbol == null)
            {
                return false;
            }

            Wildcard wildcard = new Wildcard();

            for (int i = 1; i < symbols.Count; i++)
            {
                bool isFirstSymbolWildcard = firstSymbol.Symbol == wildcard.Symbol;
                bool isCurrentSymbolWildcard = symbols[i].Symbol == wildcard.Symbol;
                bool isLastSymbolWildcard = symbols[symbols.Count - 1].Symbol == wildcard.Symbol;

                if ((isFirstSymbolWildcard && symbols[i].Symbol == symbols[i + 1].Symbol) ||
                    (isFirstSymbolWildcard && isCurrentSymbolWildcard) ||
                    (isFirstSymbolWildcard && isLastSymbolWildcard))
                {
                    return true;
                }

                if (symbols[i].Symbol != firstSymbol.Symbol && !isCurrentSymbolWildcard)
                {
                    return false;
                }
            }

            return true;
        }

        public decimal SumWinningSymbolsCoefficients(List<ISymbol> symbols)
        {
            return symbols.Sum(symbol => symbol.Coefficient);
        }

        private void ResetWinningCoefficient()
        {
            WinningCoefficient = 0.0m;
        }
    }
}
