using StrategyPatternReview;
// abstract beverage class
//Beverage testCoffeee = new DripCoffee();
//Console.WriteLine(testCoffeee.GetDescription());
//Console.WriteLine(testCoffeee.Cost());

//testCoffeee = new Sugar(testCoffeee);
//Console.WriteLine(testCoffeee.GetDescription());
//Console.WriteLine(testCoffeee.Cost());

//testCoffeee = new Sugar(testCoffeee);
//Console.WriteLine(testCoffeee.GetDescription());
//Console.WriteLine(testCoffeee.Cost());

//testCoffeee = new MilkCondiment(testCoffeee);
//Console.WriteLine(testCoffeee.GetDescription());
//Console.WriteLine(testCoffeee.Cost());

//Beverage milk = new MilkBeverage();
//milk = new MilkCondiment(milk);

//Console.WriteLine(milk.GetDescription());
//milk = new Sugar(milk);
//milk = new Sugar(milk);
//Console.WriteLine(milk.GetDescription());
//Console.WriteLine(milk.Cost());


///last tested calls.
//Beverage CoffeeBeverage = new DripCoffee();
//CoffeeBeverage = new Sugar(CoffeeBeverage);
//CoffeeBeverage = new Sugar(CoffeeBeverage);

//Beverage SecondCoffee = CoffeeBeverage;
//Beverage ThirdCoffee = CoffeeBeverage;

//ThirdCoffee = new Sugar(ThirdCoffee);

//Console.WriteLine(CoffeeBeverage.GetDescription());
//Console.WriteLine(SecondCoffee.GetDescription());
//Console.WriteLine(ThirdCoffee.GetDescription());

//CoffeeBeverage = new Sugar(CoffeeBeverage);


//Console.WriteLine(SecondCoffee.Cost());
//Console.WriteLine(CoffeeBeverage.Cost());
//Console.WriteLine(ThirdCoffee.Cost());

Car HondaAccord = new BaseVehicle(2020, "Accord", 30000, "Sedan", "Blue");
Console.WriteLine(HondaAccord.GetTotal());
Console.WriteLine(HondaAccord.GetDescription());

HondaAccord = new HeatedSeats(HondaAccord);
HondaAccord = new RemoteStart(HondaAccord);

HondaAccord = new AlloyRims(HondaAccord);
Console.WriteLine(HondaAccord.GetTotal());
Console.WriteLine(HondaAccord.GetDescription());

public abstract class Beverage
{
    protected string _description { get; set; }
    public virtual string GetDescription()
    {
        return _description;
    }

    protected double _cost { get; set; }
    public virtual double Cost()
    {
        return _cost;
    }
}

public class DripCoffee : Beverage
{
    public DripCoffee()
    {
        _cost = 1.00;
        _description = "Columbia Coffee";
    }
}

public class Tea : Beverage
{
    public Tea()
    {
        _cost = 0.50;
        _description = "English Tea";
    }
}

public class MilkBeverage : Beverage
{
    public MilkBeverage()
    {
        _description = "Milk that you drink";
        _cost = 2.00;
    }
}

public abstract class CondimentDecorator : Beverage
{
    public Beverage Beverage { get; set; }
    public abstract override string GetDescription();
    public abstract override double Cost();
}

public class Sugar: CondimentDecorator
{
    public override double Cost()
    {
        return Beverage.Cost() + _cost;
    }
    public override string GetDescription()
    {
        return $"{Beverage.GetDescription()}, {_description}";
    }

    public Sugar(Beverage beverage)
    {
        Beverage = beverage;
        _cost = 0.2;
        _description = "Sugar";
    }
}

public class MilkCondiment : CondimentDecorator
{
    public override double Cost()
    {
        return Beverage.Cost() + _cost;
    }
    public override string GetDescription()
    {
        return $"{Beverage.GetDescription()}, {_description}";
    }

    public MilkCondiment(Beverage beverage)
    {
        Beverage = beverage;
        _cost = 0.15;
        _description = "Milk";
    }
}