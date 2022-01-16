using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;

namespace Assets.Scripts.Home
{
    public class HomeFood : MonoBehaviour
    {
        [SerializeField] private GameObject _foodIncreacePanel;
        [SerializeField] private PlayerStats _playerStats;

        private static int _foodCount;
        public static int FoodCount { get => _foodCount; }

        void Update()
        {
            CheckFoodIncreace();
            CheckFoodDecreace();
        }

        private void CheckFoodIncreace()
        {
            if (!StateBus.FoodIncreace.Value) return;

            _foodCount++;
            ShowFoodPanel();
        }

        private void CheckFoodDecreace()
        {
            if (!StateBus.FoodDecreace.Value) return;

            _foodCount--;
            if (_playerStats.Hunger != 100)
                _playerStats.Health += 10;
            _playerStats.Hunger += 100;

            ShowFoodPanel();
        }

        async private void ShowFoodPanel(int time = 2000)
        {
            _foodIncreacePanel.GetComponentInChildren<TMP_Text>().text = $"Еды дома - {FoodCount}";
            _foodIncreacePanel.SetActive(true);
            var sleep = new Task(() => Thread.Sleep(time));
            sleep.Start();
            await sleep;
            _foodIncreacePanel.SetActive(false);
        }
    }
}
