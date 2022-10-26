using CashRegister;

namespace CashRegisterTest
{
  public class StubPrinter : Printer
  {
    public override void Print(string content)
    {
      throw new PrinterOutOfPaperException();
    }
  }
}