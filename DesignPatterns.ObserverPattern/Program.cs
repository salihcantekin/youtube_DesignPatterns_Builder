
// Observer Design Pattern - Behavioral Category //

var samsung = new Product("Samsung S23", 1000);
var apple = new Product("iPhone 14", 1000);

var amazon = new Amazon();
var salihObserver = new SalihObserver("Salih Cantekin");
var cantekinObserver = new CantekinObserver("Cantekin Salih");

amazon.Register(salihObserver, samsung);
amazon.Register(cantekinObserver, apple);

//amazon.NotifyForProductName("iPhone 14");
amazon.NotifyAll();

Console.ReadLine();


class Amazon
{
    private Dictionary<IObserver, Product> observers = new();

    public void Register(IObserver observer, Product product)
    {
        observers.TryAdd(observer, product);
    }

    public void UnRegister(IObserver observer) 
    {
        observers.Remove(observer);
    }

    public void NotifyAll()
    {
        foreach (var kv in observers)
        {
            kv.Key.Notify(kv.Value);
        }
    }

    public void NotifyForProductName(string productName)
    {
        foreach (var kv in observers)
        {
            if (kv.Value.Name == productName)
                kv.Key.Notify(kv.Value);
        }
    }
}

interface IObserver
{
    string FullName { get; set; }
    void Notify(Product product);
}

class CantekinObserver : IObserver
{
    public string FullName { get; set; }

    public CantekinObserver(string fullName)
    {
        FullName = fullName;
    }

    public void Notify(Product product)
    {
        Console.WriteLine($"{FullName}, Product {product.Name} in stock now!");
    }
}

class SalihObserver: IObserver
{
    public string FullName { get; set; }

    public SalihObserver(string fullName)
    {
        FullName = fullName ?? throw new ArgumentNullException(nameof(fullName));
    }

    public void Notify(Product product)
    {
        Console.WriteLine($"{FullName}, Product {product.Name} in stock now!");
    }
}

class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    
    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
    }
}