using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Class: ExtensionMethods
    Visibility: Public 
    Output: N/A
    Attributes: 

    a. N/A

    Methods: 

    a. IsOdd()
    b. Shuffle()

*/

public static class ExtensionMethods
{
    /*
	    Method: IsOdd()
        Visibility: Public 
        Output: N/A
        Purpose: 

        a. Returns Boolean Value if passed integer is Odd

    */

    public static bool IsOdd(this int value)
    {
        return value % 2 != 0;
    }

    /*
	    Method: Shuffle()
        Visibility: Public 
        Output: N/A
        Purpose: 

        a. Shuffles Passed List 
        
    */

    public static void Shuffle<T>(this IList<T> ts) 
    {
        var count = ts.Count;
        var last = count - 1;

        for (var i = 0; i < last; ++i) 
        {
            var r = UnityEngine.Random.Range(i, count);
            var tmp = ts[i];
            ts[i] = ts[r];
            ts[r] = tmp;
        }
    }
}