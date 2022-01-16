using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsKeeper : MonoBehaviour
{
    [SerializeField] private Button[] _eventButtons;
    [SerializeField] private Button[] _placeInteractionButtons;

    public Button[] GetEventButtons()
    {
        return _eventButtons;
    }

    public Button[] GetPlaceInteractionButtons()
    {
        return _placeInteractionButtons;
    }
}
