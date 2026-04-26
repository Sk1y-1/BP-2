using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Lab5;

public static class AsyncArray
{

    public static async Task<int> FindIndexAsync<T>(
        IEnumerable<T> collection, 
        Func<T, bool> predicate)
    {
        return await Task.Run(() =>
        {
            int index = 0;
            foreach (var item in collection)
            {
                if (predicate(item)) 
                    return index;
                index++;
            }
            return -1;
        });
    }

    public static async Task<int> FindParallelAsync<T>(
        IEnumerable<T> collection,
        Func<T, bool> predicate,
        CancellationToken ct = default
        )      
    {
        int index = 0;
        foreach (var item in collection)
        {

            ct.ThrowIfCancellationRequested();
            await Task.Delay(50, ct); 
            
            if (predicate(item)) 
            return index;
            index++;
        }
        return -1;
    }
}












