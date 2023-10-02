
// Chain of Responsibility Design Pattern - Behavioral Category //

// StockControl -> Payment -> Invoice -> Shipping

var order = new Order();

var stockControl = new StockControl();
var paymentControl = new PaymentControl();
var invoiceControl = new InvoiceControl();
var shippingControl = new ShippingControl();

stockControl.SetNext(paymentControl);
paymentControl.SetNext(invoiceControl);
invoiceControl.SetNext(shippingControl);

stockControl.Handle(order);


public class StockControl : IOrderHandler
{
    private IOrderHandler next;
    public void SetNext(IOrderHandler next)
    {
        this.next = next;
    }

    public bool Handle(Order order)
    {
        bool stockAvailable = true; // Check stock service

        if (next is not null && stockAvailable)
        {
            return next.Handle(order);
        }

        return stockAvailable;
    }
}


public class PaymentControl : IOrderHandler
{
    private IOrderHandler next;
    public void SetNext(IOrderHandler next)
    {
        this.next = next;
    }

    public bool Handle(Order order)
    {
        bool paymentSuccess = true; // Check payment service

        if (next is not null && paymentSuccess)
        {
            return next.Handle(order);
        }

        return paymentSuccess;
    }
}


public class InvoiceControl : IOrderHandler
{
    private IOrderHandler next;

    public void SetNext(IOrderHandler next)
    {
        this.next = next;
    }

    public bool Handle(Order order)
    {
        bool invoiceCreated = true;

        if (invoiceCreated && next != null)
        {
            return next.Handle(order);
        }

        return invoiceCreated;
    }
}

public class ShippingControl : IOrderHandler
{
    private IOrderHandler next;

    public void SetNext(IOrderHandler next)
    {
        this.next = next;
    }

    public bool Handle(Order order)
    {
        bool shippingSuccess = true;

        if (shippingSuccess && next != null)
        {
            return next.Handle(order);
        }

        return shippingSuccess;
    }
}



public interface IOrderHandler
{
    void SetNext(IOrderHandler next);
    bool Handle(Order order);
}


public class Order
{
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
