using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestCharacterVisibility : MonoBehaviour
{
    private List<GameObject> _characters;
    private List<String> _charactersQuestChainsIds;

    void Start()
    {
        _charactersQuestChainsIds = new List<string>();
        _characters = new List<GameObject>();

        for (var i = 0; i < transform.childCount; i++)
        {
            _characters.Add(transform.GetChild(i).gameObject);
            _charactersQuestChainsIds.Add(transform.GetChild(i).gameObject.GetComponent<Text>().text);

            _characters[i].SetActive(false);
        }
    }

    void Update()
    {
        CheckQuestChainAppearance();
        CheckQuestChainCompletion();
    }

    private void CheckQuestChainAppearance()
    {
        if (_charactersQuestChainsIds.Contains(StateBus.QuestChainTaken.Value))
        {
            var childIndex = _charactersQuestChainsIds.IndexOf(StateBus.QuestChainTaken.Value);
            _characters[childIndex].SetActive(true);
        }
    }

    private void CheckQuestChainCompletion()
    {
        if (_charactersQuestChainsIds.Contains(StateBus.QuestChainCompleted.Value) ||
            _charactersQuestChainsIds.Contains(StateBus.QuestChainFailed.Value))
        {
            var childIndex = StateBus.QuestChainCompleted.Value != null
                ? _charactersQuestChainsIds.IndexOf(StateBus.QuestChainCompleted.Value)
                : _charactersQuestChainsIds.IndexOf(StateBus.QuestChainFailed.Value);

            _characters[childIndex].SetActive(false);
        }
    }
}
