using System;
using System.Collections.Generic;

// Starting point or base class for all goals
public abstract class Goal
{
    public string Name { get; set; }
    public bool IsComplete { get; set; }

    public Goal(string name)
    {
        Name = name;
        IsComplete = false;
    }

    public abstract int CalculatePoints();
    public abstract string GetProgress();
}