namespace InterfacePatterns.Interfaces;

using InterfacePatterns.Types;

public interface ITrackableWork
{
    string Title { get; }
    DateTime DueDate { get; }
    PriorityLevel Priority { get; }

    string Describe();
    bool IsOverdue(DateTime today);
}
