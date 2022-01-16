using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTriggerKeyHandler : MonoBehaviour
{
    [SerializeField] private EventOccurrence _eventOccurrence;
    [SerializeField] private string _key;

    void OnTriggerEnter()
    {
        Debug.Log("Вошел в триггер " + _key);
        _eventOccurrence.ShowEventPanel(_key);
    }
}
