using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Events
{
    public class EventIntermediatePanelClosing : MonoBehaviour
    {
        [SerializeField] private GameObject _intermediatePanel;
        [SerializeField] private PlaceInteractionOccurrence _placeInteractionsOccurrence;

        public void CloseEventIntermediatePanel()
        {
            _intermediatePanel.SetActive(false);
            if (StateBus.IsInPlaceInteractions)
            {
                _placeInteractionsOccurrence.ShowPlaceInteractions();
            }
        }
    }
}
