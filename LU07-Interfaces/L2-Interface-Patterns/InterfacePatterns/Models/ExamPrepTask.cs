namespace InterfacePatterns.Models;

using InterfacePatterns.Types;

public sealed class ExamPrepTask : WorkItem
{
    public string ExamName { get; }

    public ExamPrepTask(string title, string examName, DateTime dueDate, PriorityLevel priority)
        : base(title, dueDate, priority)
    {
        ExamName = examName;
    }

    public override string Describe() =>
        $"Exam Prep | {Title} | Exam: {ExamName} | Due: {DueDate:d} | Priority: {Priority}";
}
