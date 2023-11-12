namespace SimplifiedSlotMachine.Symbols.Contracts
{
    public interface ISymbol
    {
        string Symbol { get; }
        decimal Coefficient { get; }
    }
}
