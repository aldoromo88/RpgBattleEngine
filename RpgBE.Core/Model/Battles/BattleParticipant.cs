using RpgBE.Core.Model.Characters;
using RpgBE.Core.Model.Enums;

namespace RpgBE.Core.Model.Battles
{
    public class BattleParticipant
    {
        public Character Character { get; private set; }
        public Team Team { get; private set; }

        public bool IsAlive
        {
            get { return Character.HealthPoints > 0; }
        }

        public double TicksToAction { get; set; }
        public double Ticks { get; set; }

        public BattleParticipant(Character character, Team team)
        {
            Character = character;
            Team = team;
            TicksToAction = 100.0 / (Character.Agility + 1);
            Ticks = Character.Agility;
        }
    }
}