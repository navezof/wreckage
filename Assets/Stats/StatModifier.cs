using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatModifier
{
    private int value;
    private int duration;
    private object source;
    private string description;

    public int Value { get => value; }
    public object Source { get => source; }
    public int Duration { get => duration; set => duration = value; }
    public string Description { get => description; set => description = value; }

    public StatModifier(int value, int duration, object source, string description)
    {
        this.value = value;
        this.duration = duration;
        this.source = source;
        this.description = description;
    }

    public bool Update()
    {
        duration--;
        if (duration <= 0)
            return true;
        return false;
    }
}
