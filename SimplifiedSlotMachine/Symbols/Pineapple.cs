namespace SimplifiedSlotMachine.Symbols
{
    using SimplifiedSlotMachine.Symbols.Contracts;

    public class Pineapple : ISymbol
    {
        public string Symbol => "P";

        public decimal Coefficient => 0.8m;
    }
}
