using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Home;
using Assets.Scripts.Quests;
using UnityEngine;

namespace Assets.Scripts.PlaceInteraction
{
    public class PlaceInteractionsRepository : MonoBehaviour
    {
        [SerializeField] private StudCouncilPanelContent _studCouncil;
        [SerializeField] private EventOccurrence _eventOccurrence;

        [SerializeField] private DateTimeInfo _dateTimeInfo;
        [SerializeField] private PlayerStats _player;

        private Dictionary<string, List<Interaction>> _interactions = new Dictionary<string, List<Interaction>>();

        void Start()
        {
            FillRepository();
        }

        public List<Interaction> GetInteractionsByKey(string key)
        {
            return _interactions[key];
        }

        public void FillRepository()
        {
            var UNIInteractions = new List<Interaction>()
            {
                new Interaction("Студсовет",
                    () => true,
                    () => _studCouncil.ShowStudPanelContent(),
                    "",
                    false),

                new Interaction("На пары",
                    () => true,
                    () => _eventOccurrence.ShowEventPanel(TriggerPlaces.University),
                    "",
                    false),

                new Interaction("Сходить в столовку",
                    () => _dateTimeInfo.Hour >= 8 && _dateTimeInfo.Hour <= 18,
                    () =>
                    {
                        _player.Money -= 500;
                        _player.Hunger += 20;
                    },

                    "Поел, попил и теперь доволен"),
                new Interaction("[ДЕБАГ] Скипнуть 6 часов",
                    () => false,
                    () => _dateTimeInfo.Hour +=6,
                    "Ты обязательно справишься...."),
                new Interaction("[КВЕСТ] Тебя подзывает странный человек у автомата с едой",
                () => QuestsRepository.GetQuestChainById(QuestChainIds.Lexa).GetFirstWaitingQuest()?.Id == QuestIds.TalkWithLexa,
                () => StateBus.QuestChainTaken += QuestChainIds.Lexa,
                "Здарова, меня Леха зовут кстати, давай через 20мин на улице встретимся, есть вопрос один"),

                new Interaction("[КВЕСТ] Спросить насчет Лехи в Студсовете",
                () => QuestsRepository.GetQuestChainById(QuestChainIds.Lexa).GetCurrentQuest()?.Id == QuestIds.AskAboutLexa,
                () =>
                {
                    StateBus.QuestCompleted += QuestChainIds.Lexa;
                },
                "Нам разрешили приглосить Леху, а так же любых других желающих. Надо найти его и обрадовать. Наверное он на улице."),
                new Interaction("Посидеть в студсовете",
                () => true,
                () => {
                StateBus.NextEvent = "Знакомство первокурсников"; StateBus.NextEventRequirements = "Влияние: 3 \n Участников: 3";
                    _dateTimeInfo.Hour += 2; _player.StudWaveXP += 2; _player.Mood += 10;
                },
                "Ты помог сделать в студсовете некоторые небольшие дела \n Стало известно мероприятие этого месяца и его требования."),
            };

            var FOODInteractions = new List<Interaction>()
            {
                new Interaction($"Купить еды (500)",
                    () => true,
                    () => {
                        StateBus.FoodIncreace += true;
                        StateBus.MoneySpend += 500;
                    },
                    "Ты купил чутка еды"
                    )
            };

            var HOMEInteractions = new List<Interaction>()
            {
                new Interaction("Приготовить поесть",
                () => HomeFood.FoodCount > 0,
                () => StateBus.FoodDecreace += true,
                "Приготовил поесть, хорошооо...."),
                new Interaction("Заняться учебой (1 час)",
                () => true,
                () => {_player.KnowledgeXP += 1; StateBus.TimeSkip += 1; },
                "Учеба это жизнь..."),
                new Interaction("Спать 9 часов",
                () => true,
                () => StateBus.TimeSkip += 9,
                "Постпал так поспал"),
                new Interaction("Спать 8 часов",
                () => true,
                () => StateBus.TimeSkip += 8,
                "Постпал так поспал"),
                new Interaction("Спать 7 часов",
                () => true,
                () => StateBus.TimeSkip += 7,
                "Постпал так поспал"),
                new Interaction("Спать 6 часов",
                () => true,
                () => StateBus.TimeSkip += 6,
                "Постпал так поспал"),
                new Interaction("Спать 5 часов",
                () => true,
                () => StateBus.TimeSkip += 5,
                "Постпал так поспал"),
                new Interaction("Отдохнуть часок",
                () => true,
                () => StateBus.TimeSkip += 1,
                "Постпал так поспал")
            };

            _interactions.Add(TriggerPlaces.University, UNIInteractions);
            _interactions.Add(TriggerPlaces.Food, FOODInteractions);
            _interactions.Add(TriggerPlaces.Home, HOMEInteractions);
        }
    }
}
