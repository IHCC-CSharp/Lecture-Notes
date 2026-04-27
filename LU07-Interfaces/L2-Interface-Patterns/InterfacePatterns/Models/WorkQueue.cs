using System.Collections;

namespace InterfacePatterns.Models;

public sealed class WorkQueue : IEnumerable<WorkItem>
{
    private readonly List<WorkItem> _items = [];

    public void Add(WorkItem item) => _items.Add(item);

    // Why do we need this?
    public List<WorkItem> ToSortedList()
    {
        var sorted = _items.ToList();
        sorted.Sort();
        return sorted;
    }

    public IEnumerator<WorkItem> GetEnumerator() => _items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
