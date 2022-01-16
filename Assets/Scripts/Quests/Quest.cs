using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Quests
{
    public class Quest
    {
        public enum EventStatus
        {
            Waiting,
            Current,
            Done,
            Failed
        }

        public Quest(string name, string description, string id, int deadlineWeek = 0, int deadlineHour = -1, Action effectOnGoalComplete = null)
        {
            Name = name;
            Description = description;
            DeadlineWeek = deadlineWeek;
            DeadlineHour = deadlineHour;
            Id = id;
            //Goal = goal;
            EffectOnGoalComplete = effectOnGoalComplete;
            Status = EventStatus.Waiting;
        }

        public EventStatus Status { get; private set; }
        public string Name { get; }
        public string Id { get; }
        public string Description { get; }
        public int DeadlineWeek { get; }
        public int DeadlineHour { get; }

        //public Func<bool> Goal { get; }
        public Action EffectOnGoalComplete { get; }

        public void UpdateQuestStatus(EventStatus updatedStatus)
        {
            Status = updatedStatus;
        }
    }
}
