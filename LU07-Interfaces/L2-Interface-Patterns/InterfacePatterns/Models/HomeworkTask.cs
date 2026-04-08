namespace InterfacePatterns.Models;

using InterfacePatterns.Types;

public sealed class HomeworkTask : WorkItem
{
    public string Course { get; }

    public HomeworkTask(string title, string course, DateTime dueDate, PriorityLevel priority)
        : base(title, dueDate, priority)
    {
        Course = course;
    }

    public override string Describe() =>
        $"Homework | {Title} | Course: {Course} | Due: {DueDate:d} | Priority: {Priority}";
}
