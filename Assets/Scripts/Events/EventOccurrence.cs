using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventOccurrence : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private GameObject _intermediatePanel;

    [SerializeField] private ButtonsKeeper _buttonsKeeper;

    public void ShowEventPanel(string key)
    {
        var currentEvent = GetEventByKey(key);
        if (currentEvent == null)
            return;
        var buttons = _buttonsKeeper.GetEventButtons();

        _panel.SetActive(true);

        _panel.GetComponentInChildren<Text>().text = currentEvent.Text;

        foreach (var button in buttons)
        {
            button.gameObject.SetActive(false);
            button.onClick.RemoveAllListeners();
        }

        for (var i = 0; i < currentEvent.Choices.Count; i++)
        {
            var currentButton = buttons[i];
            var choice = currentEvent.Choices[i];
            
            currentButton.onClick.AddListener(() =>
            {
                choice.Effect(choice.SuccessCriteria());
                _intermediatePanel.GetComponentInChildren<Text>().text =
                    choice.SuccessCriteria() ? choice.SuccessText : choice.FailText;
                _panel.gameObject.SetActive(false);
                _intermediatePanel.gameObject.SetActive(true);
            });

            currentButton.GetComponentInChildren<Text>().text = choice.Text;
            currentButton.gameObject.SetActive(true);
        }
    }

    private Event GetEventByKey(string key)
    {
        foreach (var e in EventsRepository.GetEvents()[key])
        {
            if (e.AppearanceCriteria())
                return e;
        }

        return null;
    }
}
