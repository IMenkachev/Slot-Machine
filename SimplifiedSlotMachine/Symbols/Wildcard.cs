namespace SimplifiedSlotMachine.Symbols
{
    using SimplifiedSlotMachine.Symbols.Contracts;

    public class Wildcard : ISymbol
    {
        public string Symbol => "*";

        public decimal Coefficient => 0;
    }
}
