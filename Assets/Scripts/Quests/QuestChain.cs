using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Quests
{
    public class QuestChain
    {
        private Quest[] _quests;

        public QuestChain(string id, Quest[] quests)
        {
            Id = id;
            _quests = quests;
        }

        public string Id { get; }

        public Quest GetCurrentQuest()
        {
            return _quests.ToList().Find(q => q.Status == Quest.EventStatus.Current);
        }

        public Quest GetFirstWaitingQuest()
        {
            return _quests.ToList().Find(q => q.Status == Quest.EventStatus.Waiting);
        }
    }
}
