namespace InheritanceExample
{
    public class Animal(int age, string name, bool meatEater)
    {
        public int Age = age;
        public string Name = name;
        public bool MeatEater = meatEater;


        //https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/virtual
        public virtual string Eat()
        {
            return ("Nibble Nibble");
        }
    }
}
