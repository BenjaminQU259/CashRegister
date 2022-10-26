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
    public void Should_throw_HardwareException_when_process_given_stub_printer_throw_out_of_paper_exception()
    {
      // given
      StubPrinter printer = new StubPrinter();
      var cashRegister = new CashRegister(printer);
      var purchase = new Purchase();
      // when
      // then
      HardwareException hardwareException = Assert.Throws<HardwareException>(() => cashRegister.Process(purchase));
      Assert.Equal("Printer is out of paper.", hardwareException.Message);
    }

    [Fact]
    public void Should_print_call_when_run_process_given_spy_printer()
    {
      // Given
      var printer = new Mock<Printer>();
      var cashRegister = new CashRegister(printer.Object);
      var purchase = new Purchase();
      // when
      cashRegister.Process(purchase);
      // then
      printer.Verify(_ => _.Print(It.IsAny<string>()));
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
