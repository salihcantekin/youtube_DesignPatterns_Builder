
// State Design Pattern - Behavioral Category //


/*
Yeni Sipariş
İşleniyor/Hazırlanıyor
Yolda/Gönderimde
Teslim Edildi 
 */


var order = new Order();
order.PrintOrderState();

order.NextState();
order.PrintOrderState();

order.NextState();
order.PrintOrderState();

Console.ReadLine();

interface IOrderState
{
    void Next(Order order);
    void Previous(Order order);
    void PrintStatus();
}

record DeliveredState : IOrderState
{
    public void Next(Order order)
    {
        Console.WriteLine("This is the final state");
    }

    public void Previous(Order order)
    {
        order.State = new OnTheWayState();
    }

    public void PrintStatus()
    {
        Console.WriteLine("Order is delivered");
    }
}

record OnTheWayState : IOrderState
{
    public void Next(Order order)
    {
        order.State = new DeliveredState();
    }

    public void Previous(Order order)
    {
        order.State = new ProcessingState();
    }

    public void PrintStatus()
    {
        Console.WriteLine("Order is on the way");
    }
}

record ProcessingState : IOrderState
{
    public void Next(Order order)
    {
        order.State = new OnTheWayState();
    }

    public void Previous(Order order)
    {
        order.State = new NewOrderState();
    }

    public void PrintStatus()
    {
        Console.WriteLine("Order is being proccessed");
    }
}

record NewOrderState : IOrderState
{
    public void Next(Order order)
    {
        order.State = new ProcessingState();
    }

    public void Previous(Order order)
    {
        Console.WriteLine("This is the initial state");
    }

    public void PrintStatus()
    {
        Console.WriteLine("Order is placed");
    }
}

class Order
{
    public IOrderState State { get; set; }

    public Order()
    {
        State = new NewOrderState();   
    }

    public void NextState()
    {
        State.Next(this);
    }

    public void PreviousState() 
    {
        State.Previous(this);
    }

    public void PrintOrderState()
    {
        State.PrintStatus();
    }
}