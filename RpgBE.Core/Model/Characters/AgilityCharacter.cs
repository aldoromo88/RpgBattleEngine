using RpgBE.Core.Model.Enums;

namespace RpgBE.Core.Model.Characters
{
    public class AgilityCharacter : Character
    {
        public override int MaxResourcePoints
        {
            get { return 20 + (Agility * 5 * Level); }
        }

        public override int DamageBase
        {
            get { return 2 + (Agility * 2 * Level); }
        }

        public override int AbilityDamageBase
        {
            get { return DamageBase; }
        }

        public override Attributes MainAttribute
        {
            get { return Attributes.Agility; }
        }

        #region Constructor
        public AgilityCharacter(CharacterDto initProperties)
            : base(initProperties)
        {
        }
        #endregion
    }
}
