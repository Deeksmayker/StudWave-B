using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.PlaceInteraction
{
    public class PlaceInteractionsClosing : MonoBehaviour
    {
        [SerializeField] private GameObject _placeInteractionsPanel;

        public void ClosePlaceInteractions()
        {
            StateBus.IsInPlaceInteractions = false;
            _placeInteractionsPanel.gameObject.SetActive(false);
        }
    }
}
