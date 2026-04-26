using System;

namespace Lab5;

public static async FindIndexAsync<T> (

IEnumerable<T> collection, 
Func<T, bool> predicate)
{
    return await Task.Run(() =>
    {
        int index = 0;
        foreach (var item in collection)
        {
            if (predicate(item)) return index;
            index++;
        }
        return -1;
    });
}

public static async FindIndexParallel<T>(

IEnumerable<T> collection,
Func<T, bool> predicate,
CancellationToken ct = default)      
{
    
}











