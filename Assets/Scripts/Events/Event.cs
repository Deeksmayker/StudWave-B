using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event 
{
    public Event(string text, Func<bool> appearanceCriteria)
    {
        Text = text;
        AppearanceCriteria = appearanceCriteria;
        Choices = new List<Choice>();
    }

    public string Text { get; }

    public List<Choice> Choices { get; private set; }

    public Func<bool> AppearanceCriteria { get; private set; }
}
