using RpgBE.Core.Model.Enums;

namespace RpgBE.Core.Model.Characters
{
    public class StrengthCharacter : Character
    {
        public override int MaxResourcePoints
        {
            get { return 10 + (Strength * 3 * Level); }
        }

        public override int DamageBase
        {
            get { return 3 + (Strength * 3 * Level); }
        }

        public override int AbilityDamageBase
        {
            get { return Strength * (Level / 3); }
        }

        public override Attributes MainAttribute
        {
            get { return Attributes.Strength; }
        }

        #region Constructor
        public StrengthCharacter(CharacterDto initProperties)
            : base(initProperties)
        {
        }
        #endregion
    }
}
