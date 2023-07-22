
// Factory Method Design Pattern - Creational Category //


PizzaStore ankaraPizzaStore = new AnkaraPizzaStore();
PizzaStore istanbulPizzaStore = new IstanbulPizzaStore();

IPizza cheesePizza = ankaraPizzaStore.OrderPizza("cheese");
Console.WriteLine("Cheese pizza ordered in Ankara Store");

IPizza veggiePizza = istanbulPizzaStore.OrderPizza("veggi");
Console.WriteLine("Veggie pizza ordered in Istanbul Store");




interface IPizza
{
    void Prepare();
    void Bake();
    void Cut();
}

class CheesePizza : IPizza
{
    public void Prepare()
    {
        Console.WriteLine("Cheese Pizza Prepared");
    }

    public void Bake()
    {
        Console.WriteLine("Cheese Pizza Baked");
    }

    public void Cut()
    {
        Console.WriteLine("Cheese Pizza Cut");
    }
}

class VeggiPizza : IPizza
{
    public void Prepare()
    {
        Console.WriteLine("Veggi Pizza Prepared");
    }

    public void Bake()
    {
        Console.WriteLine("Veggi Pizza Baked");
    }

    public void Cut()
    {
        Console.WriteLine("Veggi Pizza Cut");
    }
}

abstract class PizzaStore
{
    protected abstract IPizza CreatePizza(string type);

    public IPizza OrderPizza(string type)
    {
        IPizza pizza = CreatePizza(type);

        pizza.Prepare();
        pizza.Bake();
        pizza.Cut();

        return pizza;
    }
}

class AnkaraPizzaStore : PizzaStore
{
    protected override IPizza CreatePizza(string type)
    {
        return type switch
        {
            "cheese" => new CheesePizza(),
            "veggi" => new VeggiPizza(),
            _ => throw new ArgumentException("Invalid pizza type", nameof(type))
        };
    }
}

class IstanbulPizzaStore : PizzaStore
{
    protected override IPizza CreatePizza(string type)
    {
        return type switch
        {
            "cheese" => new CheesePizza(),
            "veggi" => new VeggiPizza(),
            _ => throw new ArgumentException("Invalid pizza type", nameof(type))
        };
    }
}