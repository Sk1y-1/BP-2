using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab4;

public enum Query {Highest, Lowest, Oldest, Newest}
public class QueuePriority<T>
{
    public T Value {get; init;}
    public int Priority {get; init;}
    public int Id {get; init;}
}
public class BiDirectionalPriorityQueue<T>
{
public readonly List<QueuePriority<T>> _items = new();
private long _counter = 0L;

public void Enqueue(T value, int priority) 
{
    _items.Add (new QueuePriority<T>
    {
    Value = value,
    Priority = priority,
    Id = (int) _counter++ // (int) - _counter — це long, але я його преобразував у int для зручності
  });
}

public T Dequeue(Query type) 
    {
        if (_items.Count == 0) throw new InvalidOperationException("Queue is empty");

        var target = GetTarget(type);
        _items.Remove(target);
        return target.Value;
    }

    public T Peek(Query type)
    {
        if (_items.Count == 0) throw new InvalidOperationException("Queue is empty");

        return GetTarget(type).Value;
    }
private QueuePriority<T> GetTarget(Query type)
    {
        return type switch
        {
            Query.Highest => _items.OrderByDescending(x => x.Priority).ThenBy(x => x.Id).First(),
            Query.Lowest  => _items.OrderBy(x => x.Priority).ThenBy(x => x.Id).First(),
            Query.Oldest  => _items.OrderBy(x => x.Id).First(),
            Query.Newest  => _items.OrderByDescending(x => x.Id).First(),
            _ => throw new ArgumentException("Invalid query type")
        };
    }
}











