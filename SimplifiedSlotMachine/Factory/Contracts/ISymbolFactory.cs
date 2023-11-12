namespace SimplifiedSlotMachine.Factory.Contracts
{
    using SimplifiedSlotMachine.Symbols.Contracts;

    public interface ISymbolFactory
    {
        ISymbol CreateSymbol();
    }
}
