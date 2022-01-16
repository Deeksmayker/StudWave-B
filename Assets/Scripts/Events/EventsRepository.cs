using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Quests;
using UnityEngine;

public class EventsRepository : MonoBehaviour
{
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private StudCouncil _studCouncil;

    void Start()
    {
        FillRepository();
    }

    private static Dictionary<string, List<Event>> _events = new Dictionary<string, List<Event>>();

    public static Dictionary<string, List<Event>> GetEvents()
    {
        return _events;
    }

    private void FillRepository()
    {
        var UNIlist = new List<Event>()
        {
            new Event("�����?", () => true)
            {
                Choices =
                {
                    new Choice("SDF", "SFDSDF", "EWQR", () => _playerStats.KnowledgeLevel >= 3, b => _playerStats.Mood += 20),
                    new Choice("SDF", "SFDSDF", "EWQR", () => _playerStats.KnowledgeLevel >= 3, b => _playerStats.Mood += 20),
                    new Choice("SDF", "SFDSDF", "EWQR", () => _playerStats.KnowledgeLevel >= 3, b => _playerStats.Mood += 20),
                    new Choice("SDF", "SFDSDF", "EWQR", () => _playerStats.KnowledgeLevel >= 3, b => _playerStats.Mood += 20),
                }
            }
        };


        var ABOBAlist = new List<Event>()
        {
            new Event(
                "Ну пришел ты к этому абобе и говоришь: Тоси боси, есть вопросики, пошли поможешь. Он, в свою очередь, был непреклонен и сказал: только за банку адреналин раша.",
                () => QuestsRepository.GetQuestChainById(QuestChainIds.Aboba).GetCurrentQuest()?.Id ==
                      QuestIds.AskAboba)
            {
                Choices =
                {
                    new Choice("ЛАдно, паря, схожу спрошу как у них с такими жесткими условиями обстоит вопрос",
                        "Ну и иди", "",
                        () => true,
                        b => StateBus.QuestCompleted += QuestChainIds.Aboba),
                    new Choice("Ты хуйни то не неси, давай отсюдова, нам такие хуйноносы не нужны", "Э", "",
                        () => true,
                        b => StateBus.QuestChainFailed += QuestChainIds.Aboba)
                }
            },

            new Event(
                "Абоба стоит и ждет хороших вестей",
                () => QuestsRepository.GetQuestChainById(QuestChainIds.Aboba).GetCurrentQuest()?.Id == QuestIds.ReturnToAboba)
            {
                Choices =
                {
                    new Choice("ХОрошие вести, абоба, будет тебе этот адреналин",
                        "Абоба очень рад и присоединяется к вашей хуйне", "",
                        () => true,
                        b =>
                        {
                            StateBus.ActiveCharacters.Add(QuestCharacters.Aboba);
                            StateBus.QuestCompleted += QuestChainIds.Aboba;
                            _studCouncil.AddMembersCount();
                        })
                }
            }
        };

        var LEXAlist = new List<Event>()
        {
            new Event(
                "Леха: Меня скоро отчислят, я вроде слышал, что можно остаться если учавствовать в Студсовете, можешь спросить про меня?",
                () => QuestsRepository.GetQuestChainById(QuestChainIds.Lexa).GetCurrentQuest()?.Id == QuestIds.TalkWithLexa)
            {
                Choices =
                {
                    new Choice("Хорошо, я спрошу, как только узнаю, расскажу тебе.",
                    "Леха: Отлично, спасибо большое!", "",
                    () => true,
                    b => StateBus.QuestCompleted += QuestChainIds.Lexa),

                    new Choice("Не, Леха, я сейчас занят и в целом очень мало времени, извини",
                    "Понимаю, ну ладно, удачи", "",
                    () => true,
                    b => StateBus.QuestChainFailed += QuestChainIds.Lexa),

                }
            },

            new Event(
                "Леха: Спасибо большое еще раз, ты меня спас, если что-то нужно будет обращайся, обязательно помогу!",
                () => QuestsRepository.GetQuestChainById(QuestChainIds.Lexa).GetCurrentQuest()?.Id == QuestIds.TellLexa)
            {
                Choices =
                {
                    new Choice("Да не за что, если встретишь кого-нибудь кто тоже захочет вступить, веди ко мне.",
                    "Понял, договорились", "",
                    () => true,
                    b =>
                    {
                        StateBus.QuestCompleted += QuestChainIds.Lexa;
                        StateBus.ActiveCharacters.Add(QuestCharacters.Lexa);
                        _studCouncil.AddMembersCount();
                    })
                }
            }
        };

        var CHELList = new List<Event>()
        {
            new Event(
                "Подошел знакомый и попросил зайти сегодня в спортзал, нужно чем то помочь",
                () => true)
            {
                Choices =
                {
                    new Choice("Хорошо, обязательно зайду", "Вот и договорились", "",
                    () => true,
                    b =>
                    {
                        StateBus.QuestChainTaken += QuestChainIds.Chel;
                    }),
                    new Choice("Нет, сегодня не получится", "", "",
                    () => true,
                    b => StateBus.QuestChainTaken += QuestChainIds.Chel)
                }
            }
        };

        _events.Add(TriggerPlaces.University, UNIlist);
        _events.Add(QuestChainIds.Aboba, ABOBAlist);
        _events.Add(QuestChainIds.Lexa, LEXAlist);
        _events.Add(QuestChainIds.Chel, CHELList);
    }
}