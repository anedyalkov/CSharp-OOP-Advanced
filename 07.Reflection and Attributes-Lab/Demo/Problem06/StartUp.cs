using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

[SoftUni("Ventsi")]
public class StartUp
{
    [SoftUni("Gosho")]
    public static void Main(string[] args)
    {
        var tracker = new Tracker();
        tracker.PrintMethodsByAuthor();
    }
}



