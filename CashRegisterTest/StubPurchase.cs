using CashRegister;

namespace CashRegisterTest
{
	public class StubPurchase : Purchase
	{
		public override string AsString()
		{
			return "stub content";
		}
	}
}
