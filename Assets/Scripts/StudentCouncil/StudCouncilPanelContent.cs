using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StudCouncilPanelContent : MonoBehaviour
{
    [SerializeField] private GameObject _studPanel;

    [SerializeField] private StudCouncil _studCouncil;

    [SerializeField] private Text _mainText;
    [SerializeField] private Text _power;
    [SerializeField] private Text _membersCount;
    [SerializeField] private Text _nextEvent;
    [SerializeField] private Text _nextEventRequirements;

    public void ShowStudPanelContent()
    {
        _studPanel.SetActive(true);

        SetMainText();

        _power.text = _studCouncil.Power.ToString();
        _membersCount.text = _studCouncil.MembersCount.ToString();
        _nextEvent.text = StateBus.NextEvent;
        _nextEventRequirements.text = StateBus.NextEventRequirements;
    }

    private void SetMainText()
    {
        _mainText.text = "Всё как обычно. Все сидят, отдыхают";
    }
}
