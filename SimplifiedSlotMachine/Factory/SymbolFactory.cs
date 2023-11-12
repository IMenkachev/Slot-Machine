namespace SimplifiedSlotMachine.Factory
{
    using SimplifiedSlotMachine.Factory.Contracts;
    using SimplifiedSlotMachine.Symbols;
    using SimplifiedSlotMachine.Symbols.Contracts;

    public class SymbolFactory : ISymbolFactory
    {
        private static Random Random = new Random();

        public ISymbol CreateSymbol()
        {
            double probability = Random.NextDouble(); // Generate a random probability between 0 and 1

            switch (probability)
            {
                case var p when p <= 0.45:
                    return new Apple(); // 45% probability for Apple

                case var p when p <= 0.80:
                    return new Banana(); // 35% probability for Banana (0.45 + 0.35 = 0.80)

                case var p when p <= 0.95:
                    return new Pineapple(); // 15% probability for Pineapple (0.80 + 0.15 = 0.95)

                default:
                    return new Wildcard(); // 5% probability for Wildcard (0.95 + 0.05 = 1.00)
            }
        }
    }
}
