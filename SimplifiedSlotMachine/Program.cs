// See https://aka.ms/new-console-template for more information

using SimplifiedSlotMachine;
using SimplifiedSlotMachine.Factory.Contracts;
using SimplifiedSlotMachine.Factory;

ISymbolFactory symbolFactory = new SymbolFactory();
SlotMachine slotMachine = new SlotMachine(symbolFactory);
SlotGame game = new SlotGame(slotMachine);

game.Play();
