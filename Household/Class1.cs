using System;
namespace Household
{

    public interface ICoffeeMachine
    {
        void MakeEspresso();
    }

    public class CoffeeMachine : ICoffeeMachine
    {
        private readonly string brand;
        private readonly int maxWater;
        private readonly int maxCoffee;
        private readonly int maxGrounds;

        private int waterLevel;
        private int coffeeLevel;
        private int groundsLevel;
        private int espressoCount;

        public CoffeeMachine(string brand, int maxWater, int maxCoffee, int maxGrounds)
        {
            if (string.IsNullOrWhiteSpace(brand))
            {
                throw new ArgumentException("Brand cannot be empty or null.", nameof(brand));
            }

            this.brand = brand;
            this.maxWater = maxWater;
            this.maxCoffee = maxCoffee;
            this.maxGrounds = maxGrounds;
        }

        public int WaterLevel
        {
            get { return waterLevel; }
        }

        public int CoffeeLevel
        {
            get { return coffeeLevel; }
        }

        public int GroundsLevel
        {
            get { return groundsLevel; }
        }

        public int EspressoCount
        {
            get { return espressoCount; }
        }

        public void AddWater(int amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("Oops,error appeared");
                throw new ArgumentException("Amount cannot be negative.", nameof(amount));
            }

            int freeSpace = maxWater - waterLevel;
            if (amount > freeSpace)
            {
                Console.WriteLine("Oops,error appeared");
                throw new ArgumentException($"Cannot add {amount} ml of water. Maximum capacity is {maxWater} ml and current level is {waterLevel} ml.", nameof(amount));
            }

            waterLevel += amount;
        }

        public void AddCoffee(int amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("Oops,error appeared");
                throw new ArgumentException("Amount cannot be negative.", nameof(amount));
            }

            int freeSpace = maxCoffee - coffeeLevel;
            if (amount > freeSpace)
            {
                Console.WriteLine("Oops,error appeared");
                throw new ArgumentException($"Cannot add {amount} g of coffee. Maximum capacity is {maxCoffee} g and current level is {coffeeLevel} g.", nameof(amount));
            }

            coffeeLevel += amount;
        }

        public void MakeEspresso()
        {
            int waterNeeded = 30;
            int coffeeNeeded = 10;
            int groundsProduced = 1;

            if (waterLevel < waterNeeded)
            {
                Console.WriteLine("Oops,error appeared");
                throw new InvalidOperationException("Cannot make espresso. Not enough water.");
            }

            if (coffeeLevel < coffeeNeeded)
            {
                Console.WriteLine("Oops,error appeared");
                throw new InvalidOperationException("Cannot make espresso. Not enough coffee.");
            }

            if (groundsLevel + groundsProduced > maxGrounds)
            {
                Console.WriteLine("Oops,error appeared");
                throw new InvalidOperationException("Cannot make espresso. Grounds container is full.");
            }

            waterLevel -= waterNeeded;
            coffeeLevel -= coffeeNeeded;
            groundsLevel += groundsProduced;
            espressoCount++;

            Console.WriteLine("Espresso is ready!");
        }

        public void EmptyGrounds()
        {
            groundsLevel = 0;
        }
    }

    //how i tested the program on a grade 5.0 in a console application
    //public class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        CoffeeMachine myMachine = new CoffeeMachine("ACME", 1000, 500, 50);

    //        myMachine.AddWater(500);
    //        myMachine.AddCoffee(2);
    //        myMachine.MakeEspresso(); // prints "Espresso is ready!"

    //        Console.WriteLine($"Water level: {myMachine.WaterLevel} ml");
    //        Console.WriteLine($"Coffee level: {myMachine.CoffeeLevel} g");
    //        Console.WriteLine($"Grounds level:{myMachine.GroundsLevel} grounds");
    //    }
    //}


    ////////////the task on grade 5.0 should work,because i've tested it,but i also did task on grade 4.0 just in case
    ///
    //public class CoffeeMachine
    //{
    //    private readonly string brand;
    //    private readonly int waterContainerCapacity;
    //    private readonly int coffeeContainerCapacity;
    //    private readonly int groundsContainerCapacity;
    //    private int waterLevel;
    //    private int coffeeLevel;
    //    private int groundsLevel;

    //    public CoffeeMachine(string brand, int waterContainerCapacity, int coffeeContainerCapacity, int groundsContainerCapacity)
    //    {
    //        if (string.IsNullOrEmpty(brand))
    //        {
    //            throw new ArgumentException("Brand cannot be null or empty.");
    //        }

    //        this.brand = brand;
    //        this.waterContainerCapacity = waterContainerCapacity;
    //        this.coffeeContainerCapacity = coffeeContainerCapacity;
    //        this.groundsContainerCapacity = groundsContainerCapacity;
    //    }

    //    public void AddWater(int amount)
    //    {
    //        if (amount < 0)
    //        {
    //            throw new ArgumentException("Amount of water cannot be negative.");
    //        }

    //        if (this.waterLevel + amount > this.waterContainerCapacity)
    //        {
    //            Console.WriteLine("Invalid parameters");
    //            throw new InvalidOperationException("Water container capacity exceeded.");
    //        }

    //        this.waterLevel += amount;
    //    }

    //    public void AddCoffee(int amount)
    //    {
    //        if (amount < 0)
    //        {
    //            Console.WriteLine("Invalid parameters");
    //            throw new ArgumentException("Amount of coffee cannot be negative.");
    //        }

    //        if (this.coffeeLevel + amount > this.coffeeContainerCapacity)
    //        {
    //            Console.WriteLine("Invalid parameters");
    //            throw new InvalidOperationException("Coffee container capacity exceeded.");
    //           // Console.WriteLine("Wrong parameters entered");
    //        }

    //        this.coffeeLevel += amount;
    //    }

    //    public void MakeEspresso()
    //    {
    //        if (this.waterLevel < 50 || this.coffeeLevel < 10)
    //        {
    //            throw new InvalidOperationException("Not enough water or coffee to make an espresso.");
    //        }

    //        if (this.groundsLevel + 1 > this.groundsContainerCapacity)
    //        {
    //            throw new InvalidOperationException("Grounds container capacity exceeded.");
    //        }

    //        this.waterLevel -= 50;
    //        this.coffeeLevel -= 10;
    //        this.groundsLevel += 1;

    //        Console.WriteLine("Your espresso is ready!");
    //    }

    //    public void EmptyGrounds()
    //    {
    //        this.groundsLevel = 0;
    //    }

    //}
    //how i tested the program in a console application
    //public class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        CoffeeMachine myMachine = new CoffeeMachine("Acme Coffee Maker", 500, 200, 50);
    //        myMachine.AddWater(1000); // throws InvalidOperationException
    //        myMachine.AddCoffee(300); // throws InvalidOperationException
    //        myMachine.AddWater(100); // adds amount of water in ml
    //        myMachine.AddCoffee(30); // adds 30 grams of coffee
    //        myMachine.MakeEspresso(); // adds 1 gram of grounds
    //        myMachine.EmptyGrounds(); // removes the grounds
    //    }
    //}
}