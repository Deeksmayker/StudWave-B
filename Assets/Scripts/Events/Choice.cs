using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choice 
{
    public Choice(string text, string successText, string failText, Func<bool> successCriteria,
        Action<bool> effect)
    {
        Text = text;
        SuccessText = successText;
        FailText = failText;
        SuccessCriteria = successCriteria;
        Effect = effect;
    }

    public string Text { get; }
    public string SuccessText {get;}
    public string FailText { get; }

    public Func<bool> SuccessCriteria {get;}
    public Action<bool> Effect {get;}
}
