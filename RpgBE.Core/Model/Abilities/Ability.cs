using RpgBE.Core.Model.Commons;
using RpgBE.Core.Model.Enums;

namespace RpgBE.Core.Model.Abilities
{
    public abstract class Ability : GameObject
    {
        public string Name { get; protected set; }

        public int CastCost { get; protected set; }

        public PossibleTarget PossibleTarget { get; protected set; }

        public Attributes AttributeAffinity { get; protected set; }

        public Ability(AbilityDto initProperties)
            : base(initProperties)
        {
        }
    }

    public class AbilityDto
    {
    }

    public class DirectDamage : Ability
    {

        //public int 

        public DirectDamage(AbilityDto initProperties)
            : base(initProperties)
        {
        }
    }
}