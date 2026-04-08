using InterfacePatterns.Models;
using InterfacePatterns.Types;

var queue = new WorkQueue();

queue.Add(new HomeworkTask(
    title: "Read Chapter 4",
    course: "C# Fundamentals",
    dueDate: DateTime.Today.AddDays(2),
    priority: PriorityLevel.Medium));

queue.Add(new ExamPrepTask(
    title: "Review Practice Problems",
    examName: "Midterm",
    dueDate: DateTime.Today.AddDays(-1),
    priority: PriorityLevel.Low));

Console.WriteLine("ALL TASKS (IEnumerable)");
foreach (var item in queue)
{
    Console.WriteLine(item.Describe());
}

Console.WriteLine();
Console.WriteLine("SORTED TASKS (IComparable)");
foreach (var item in queue.ToSortedList())
{
    Console.WriteLine(item.Describe());
}

Console.WriteLine();
Console.WriteLine("OVERDUE TASKS");
foreach (var item in queue.Where(w => w.IsOverdue(DateTime.Today)))
{
    Console.WriteLine(item.Describe());
}
