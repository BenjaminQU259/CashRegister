namespace CashRegisterTest
{
	using CashRegister;
	using Moq;
	using Xunit;

	public class CashRegisterTest
	{
		[Fact]
		public void Should_process_execute_printing()
		{
			//given
			var printer = new SpyPrinter();
			var cashRegister = new CashRegister(printer);
			var purchase = new Purchase();
			//when
			cashRegister.Process(purchase);
			//then
			Assert.True(printer.HasPrinted);
		}

		[Fact]
		public void Should_print_purchase_content_when_run_process_given_stub_purchase()
    {
      //given
      var spyPrinter = new Mock<SpyPrinter>();
      var cashRegister = new CashRegister(spyPrinter.Object);
      var stubPurchase = new Mock<Purchase>();
      stubPurchase.Setup(x => x.AsString()).Returns("stub content");
      //when
      cashRegister.Process(stubPurchase.Object);
      //then
      spyPrinter.Verify(_ => _.Print("stub content"));
    }
  }
}
