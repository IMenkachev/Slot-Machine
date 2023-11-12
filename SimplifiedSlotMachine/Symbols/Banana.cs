namespace SimplifiedSlotMachine.Symbols
{
    using SimplifiedSlotMachine.Symbols.Contracts;

    public class Banana : ISymbol
    {
        public string Symbol => "B";

        public decimal Coefficient => 0.6m;
    }
}
