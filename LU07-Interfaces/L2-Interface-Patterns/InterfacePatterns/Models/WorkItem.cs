using InterfacePatterns.Interfaces;
using InterfacePatterns.Types;

namespace InterfacePatterns.Models;

public abstract class WorkItem : ITrackableWork, IComparable<WorkItem>, IEquatable<WorkItem>
{
    public Guid Id { get; }
    public string Title { get; }
    public DateTime DueDate { get; }
    public PriorityLevel Priority { get; }

    protected WorkItem(string title, DateTime dueDate, PriorityLevel priority)
    {
        Id = Guid.NewGuid();
        Title = title;
        DueDate = dueDate;
        Priority = priority;
    }

    public bool IsOverdue(DateTime today) => DueDate.Date < today.Date;

    public int CompareTo(WorkItem? other)
    {
        if (other is null)
        {
            return 1;
        }

        var dueDateComparison = DueDate.CompareTo(other.DueDate);
        if (dueDateComparison != 0)
        {
            return dueDateComparison;
        }

        return other.Priority.CompareTo(Priority);
    }

    public bool Equals(WorkItem? other)
    {
        if (other is null)
        {
            return false;
        }

        return Id == other.Id;
    }

    public override bool Equals(object? obj) => Equals(obj as WorkItem);

    public override int GetHashCode() => Id.GetHashCode();

    public abstract string Describe();
}
