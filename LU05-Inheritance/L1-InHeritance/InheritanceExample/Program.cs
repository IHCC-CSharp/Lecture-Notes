//https://www.w3schools.com/cs/cs_polymorphism.php

using InheritanceExample;

var fred = new Animal(4, "fred", false);
Console.WriteLine(fred.Eat());

var myDog = new Dog(5, "Spot", "Beagle");
Console.WriteLine(myDog.Eat());
Console.WriteLine(myDog.Breed);

