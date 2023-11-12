namespace SimplifiedSlotMachine.Symbols
{
    using SimplifiedSlotMachine.Symbols.Contracts;

    public class Apple : ISymbol
    {
        public string Symbol => "A";

        public decimal Coefficient => 0.4m;
    }
}
