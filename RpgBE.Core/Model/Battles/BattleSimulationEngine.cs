using System.Collections.Generic;
using System.Linq;
using RpgBE.Core.Model.Characters;
using RpgBE.Core.Model.Enums;

namespace RpgBE.Core.Model.Battles
{
    public class BattleSimulationEngine : BattleBaseEngine
    {
        public override void StartBattle()
        {
            base.StartBattle();
            foreach (var participant in Participants)
            {
                participant.Character.RecoverHealth(participant.Character.MaxHealthPoint);
                participant.Character.RecoverResources(participant.Character.MaxResourcePoints);
            }
        }

        public List<Character> GetEnemiesAlive(Team team)
        {
            return Participants.Where(c => c.IsAlive && c.Team != team).Select(c => c.Character).ToList();
        }

        public List<Character> GetTeamMembersAlive(Team team)
        {
            return Participants.Where(c => c.IsAlive && c.Team == team).Select(c => c.Character).ToList();
        }

        public BattleParticipant GetNextParticipant()
        {
            var participant = Participants.Where(c => c.IsAlive).OrderBy(c => c.TicksToAction - c.Ticks).FirstOrDefault();

            if (participant == null) return null;



            foreach (var p in Participants.Where(c => c.IsAlive && c.Character.Id != participant.Character.Id))
            {
                p.Ticks += participant.TicksToAction - participant.Ticks;
            }

            //TODO apply turn modifiers to participant character?


            return participant;
        }
    }
}