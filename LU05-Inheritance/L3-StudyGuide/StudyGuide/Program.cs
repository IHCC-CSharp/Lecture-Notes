using StudyGuide;

string[] topics =
[
    "1. Collections",
    "2. Looping",
    "3. Classes, objects, and access modifiers",
    "4. Constants and static members",
    "5. Enums",
    "6. Records",
    "7. Inheritance",
    "8. Model to SQL Mapping",
    "0. Exit",
];

Console.WriteLine("C# Midterm Study Guide");
bool keepGoing = true;
while (keepGoing)
{
    DisplayMenu();
    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            TopicDemo.Collections();
            break;
        case "2":
            TopicDemo.Looping();
            break;
        case "3":
            TopicDemo.ClassesAndAccess();
            break;
        case "4":
            TopicDemo.ConstantsAndStatic();
            break;
        case "5":
            TopicDemo.Enums();
            break;
        case "6":
            TopicDemo.Records();
            break;
        case "7":
            TopicDemo.Inheritance();
            break;
        case "8":
            TopicDemo.ModelToSqlMapping();
            break;
        case "0":
            keepGoing = false;
            break;
        default:
            Console.WriteLine("Please choose one of the listed options.");
            break;
    }
}

void DisplayMenu()
{
    foreach (string t in topics)
    {
        Console.WriteLine(t);
    }
}

