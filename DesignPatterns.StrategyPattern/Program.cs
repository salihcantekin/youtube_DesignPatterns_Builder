
// Strategy Design Pattern - Behavioral Category //

var paymentOptions = new PaymentOptions()
{
    CardNumber = "1234123412341234",
    CardHolderName = "Salih Cantekin",
    ExpirationDate = "12/25",
    Cvv = "123",
    Amount = 1000
};

var paymentService = new PaymentService();

do
{
    Console.Write("Ödeme yapılacak bankayı seçiniz (1: Garanti, 2: Yapı Kredi, 3: İş Bankası): ");
    var bank = Console.ReadLine();

    IPaymentService bankPaymentService = null;

    switch (bank)
    {
        case "1":
            bankPaymentService = new GarantiBankPaymentService();
            break;
        case "2":
            bankPaymentService = new YapiKrediBankPaymentService();
            break;
        case "3":
            bankPaymentService = new IsBankasiBankPaymentService();
            break;
        default:
            Console.WriteLine("Geçersiz banka seçimi.");
            break;
    }

    paymentService.SetPaymentService(bankPaymentService);
    paymentService.PayViaStrategy(paymentOptions);

} while (Console.ReadKey().Key != ConsoleKey.Escape);



class PaymentService
{
    private IPaymentService paymentService;

    public PaymentService()
    {
        
    }
    public PaymentService(IPaymentService paymentService)
    {
        this.paymentService = paymentService;
    }

    public void SetPaymentService(IPaymentService paymentService)
    {
        this.paymentService = paymentService;
    }

    public bool PayViaStrategy(PaymentOptions options)
    {
        return paymentService.Pay(options);
    }
}


public class GarantiBankPaymentService : IPaymentService
{
    public bool Pay(PaymentOptions paymentOptions)
    {
        Console.WriteLine("Garanti Bankası ile ödeme yapıldı.");
        return true;
    }
}

public class YapiKrediBankPaymentService : IPaymentService
{
    public bool Pay(PaymentOptions paymentOptions)
    {
        Console.WriteLine("Yapı Kredi Bankası ile ödeme yapıldı.");
        return true;
    }
}

public class IsBankasiBankPaymentService : IPaymentService
{
    public bool Pay(PaymentOptions paymentOptions)
    {
        Console.WriteLine("İş Bankası ile ödeme yapıldı.");
        return true;
    }
}



interface IPaymentService
{
    bool Pay(PaymentOptions paymentOptions);
}


public class PaymentOptions
{
    public string CardNumber { get; set; }
    public string CardHolderName { get; set; }
    public string ExpirationDate { get; set; }
    public string Cvv { get; set; }
    public decimal Amount { get; set; }
}


