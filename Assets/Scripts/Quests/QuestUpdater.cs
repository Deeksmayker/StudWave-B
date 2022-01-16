using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Quests
{
    public class QuestUpdater : MonoBehaviour
    {
        [SerializeField] private List<Text> _questTexts;
        [SerializeField] private DateTimeInfo _dateTimeInfo;
        [SerializeField] private GameObject _dayEndPanel;

        void Update()
        {
            CheckTakenQuests();
            CheckCompletedQuests();
            CheckDayCompleted();
            CheckFailedQuests();
        }

        private void CheckTakenQuests()
        {
            if (StateBus.QuestChainTaken.Value != null)
            {
                var takenQuest = QuestsRepository.GetQuestChainById(StateBus.QuestChainTaken).GetFirstWaitingQuest();
                takenQuest.UpdateQuestStatus(Quest.EventStatus.Current);
                UpdateQuestLog();
            }
        }

        private void CheckCompletedQuests()
        {
            if (StateBus.QuestCompleted.Value != null)
            {
                var currentQuestChain = QuestsRepository.GetQuestChainById(StateBus.QuestCompleted);

                var completedQuest = currentQuestChain.GetCurrentQuest();
                completedQuest.UpdateQuestStatus(Quest.EventStatus.Done);
                completedQuest.EffectOnGoalComplete();

                if (currentQuestChain.GetFirstWaitingQuest() == null)
                    StateBus.QuestChainCompleted += StateBus.QuestCompleted;
                else
                    currentQuestChain.GetFirstWaitingQuest().UpdateQuestStatus(Quest.EventStatus.Current);

                UpdateQuestLog();
            }
        }

        private void CheckFailedQuests()
        {
            if (StateBus.QuestChainFailed.Value != null)
            {
                var currentQuestChain = QuestsRepository.GetQuestChainById(StateBus.QuestChainFailed);

                var failedQuest = currentQuestChain.GetCurrentQuest();
                failedQuest.UpdateQuestStatus(Quest.EventStatus.Failed);

                while (currentQuestChain.GetFirstWaitingQuest() != null)
                {
                    currentQuestChain.GetFirstWaitingQuest().UpdateQuestStatus(Quest.EventStatus.Failed);
                }

                UpdateQuestLog();
            }
        }

        private void CheckDayCompleted()
        {
            if (StateBus.DayCompleted)
            {
                foreach (var quest in QuestsRepository.GetCurrentQuests())
                {
                    if (quest.DeadlineWeek == _dateTimeInfo.Week)
                    {
                        quest.UpdateQuestStatus(Quest.EventStatus.Failed);
                    }
                }
                ShowDayEndPanel();
                UpdateQuestLog();
            }
        }

        async void ShowDayEndPanel()
        {
            _dayEndPanel.SetActive(true);
            var sleep = new Task(() => Thread.Sleep(3000));
            sleep.Start();
            await sleep;
            _dayEndPanel.SetActive(false);
        }

        private void UpdateQuestLog()
        {
            var currentQuests = QuestsRepository.GetCurrentQuests();
            for (var i = 0; i < _questTexts.Count; i++)
            {
                _questTexts[i].text = i >= currentQuests.Length ? "" : currentQuests[i].Name;
            }
        }
    }
}
