using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Quests
{
    public class QuestsRepository : MonoBehaviour
    {
        void Start()
        {
            FillRepository();
        }

        private static Dictionary<string, QuestChain> _questChainsDictionary = new Dictionary<string, QuestChain>();
        [SerializeField] private PlayerStats _playerStats;

        private void FillRepository()
        {
            var lexa = new QuestChain(QuestChainIds.Lexa, new Quest[]
            {
                new Quest(
                    "Нужно поговорить с каким-то Лехой на улице",
                    "Я не знаю кто это был, но какой то парень хочет у меня что-то узнать, возможно это как-то связано со студсоветом.",
                    QuestIds.TalkWithLexa,
                    3,
                    0,
                    () => _playerStats.StudWaveXP += 3),
                 new Quest(
                    "Нужно спросить насчет Лехи в студсовете, можно ли его принять",
                    "Мой новый знакомый - Леха, просит помощи, чтобы мы его зачислили в студсовет, тогда возможно у него появится больше времени чтобы закрыть долги",
                    QuestIds.AskAboutLexa,
                    4,
                    0,
                    () => _playerStats.StudWaveXP += 3),
            });
            var chel = new QuestChain(QuestChainIds.Chel, new Quest[]
            {
                new Quest(
                    "Нужно сегодня зайти в спортзал", "Нужно торопиться, я опаздываю на пары",
                    QuestIds.Chelik,
                    1,
                    9,
                    () => _playerStats.StudWaveXP += 3),
            });

            _questChainsDictionary.Add(QuestChainIds.Lexa, lexa);
            _questChainsDictionary.Add(QuestChainIds.Chel, chel);

        }

        public static QuestChain GetQuestChainById(string id)
        {
            return _questChainsDictionary[id];
        }

        public static Quest[] GetCurrentQuests()
        {
            return _questChainsDictionary.Values.ToList()
                .FindAll(qc => qc.GetCurrentQuest() != null)
                .Select(qc => qc.GetCurrentQuest())
                .ToArray();
        }
    }
}
