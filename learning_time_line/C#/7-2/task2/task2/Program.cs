interface ISound
{
    void MakeSound();
}

public abstract class Animal
{
    public string Name { get; set; }  

    public Animal(string name)
    {
        Name = name;  
    }

    public abstract void Eat();

    public void Sleep()
    {
        Console.WriteLine($"{Name} is sleeping.");
    }
}

public class Cat : Animal, ISound
{
    public Cat(string name) : base(name) { }

    public override void Eat()
    {
        Console.WriteLine($"{Name} is eating Tuna");
    }

    public void MakeSound()
    {
        Console.WriteLine($"{Name} says: kefak ya 8araba!");
    }
}

public class Dog : Animal, ISound
{
    public Dog(string name) : base(name) { }

    public override void Eat()
    {
        Console.WriteLine($"{Name} is eating chicken");
    }

    public void MakeSound()
    {
        Console.WriteLine($"{Name} says: Kefak m3lm!");
    }
}

class Program
{
    static void Main(string[] args)
    {
       
        Dog myDog = new Dog("Dog1");
        Cat myCat = new Cat("BussBuss");

        
        myDog.Eat();         
        myDog.Sleep();        
        myDog.MakeSound();    

        myCat.Eat();         
        myCat.Sleep();        
        myCat.MakeSound();    
    }
}