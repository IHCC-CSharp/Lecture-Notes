namespace InheritanceExample;

public class Dog : Animal
{
    public string Breed { get; set; }

    //Meat eater is true for all Dogs
    public Dog(int age, string name, string breed) : base(age, name, true)
    {
        Breed = breed;
    }

    public override string Eat()
    {
        return "Chomp Chomp";
    }
}