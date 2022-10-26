using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPatternReview
{

    //DECORATOR PATTERN
    //Use Case: Base class can be optionally modified at runtime, possibly multiple times
    //DESIGN
    //Need a abstract class that declares abstract methods tha we expect to have on the base class
    // and be modified by decorators.
    //Need a concrete class that at least implements the abstract base clas methods.
    //Need an Abstract decorator class which has aproperty referring to an instance of the base Abstract
    // class, and overrides of the base abstract class methods.

    //When using this, we need to first instantiate a concrete class.
    //We can then redefine the reference to that instance of the concrete class as an instance of the decorator,
    // with reference back to the previously referred instance.
        
     
    public abstract class Car
    {
        public abstract double GetTotal();
        public abstract string GetDescription();
    }

    public class BaseVehicle : Car
    {
        public DateTime Year { get; set; } //year wont change
        public void SetYear(DateTime time)
        {
            Year = time;
        }

        public string Model { get; set; }
        public double BasePrice { get; set; }
        public string Colour { get; set; }
        public string BodyType { get; set; }

        public override double GetTotal()
        {
            return BasePrice;
        }

        public BaseVehicle(int year, string model, double baseprice,string colour, string bodyType)
        {
            Year = new DateTime(year, 1,1);
            Model = model;
            BasePrice = baseprice;
            BodyType = bodyType;
            Colour = colour;
        }

        public override string GetDescription()
        {
            return $"{Colour} {Year.Year} Honda {Model} {BodyType}";
        }
    }

    public abstract class UpgradeDecorator: Car
    {
        public Car Car;
        public double Cost;
        public string Description;

        public override double GetTotal()
        {
            return Car.GetTotal() + Cost;
        }
        public override string GetDescription()
        {
            return $"{Car.GetDescription()}, {Description}";
        }
    }

    public class HeatedSeats : UpgradeDecorator
    {
        public HeatedSeats(Car car)
        {
            Car = car;
            Cost = 3000;
            Description = "Heated Seats";
        }

    }

    public class RemoteStart : UpgradeDecorator
    {
        public RemoteStart(Car car)
        {
            Car = car;
            Cost = 2000;
            Description = "Remote Start";
        }
    }

    public class AlloyRims : UpgradeDecorator
    {
        public AlloyRims(Car car)
        {
            Car = car;
            Cost = 1000;
            Description = "Alloy Rims";
        }
    }
}
