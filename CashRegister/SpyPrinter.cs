namespace CashRegister
{
	public class SpyPrinter : Printer
	{
		public bool HasPrinted { get; set; }
		public override void Print(string content)
		{
			base.Print(content);
			HasPrinted = true;
      // send message to a real printer
    }
	}
}
