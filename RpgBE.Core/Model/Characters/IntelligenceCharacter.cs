using RpgBE.Core.Model.Enums;

namespace RpgBE.Core.Model.Characters
{
    public class IntelligenceCharacter : Character
    {
        public override int MaxResourcePoints
        {
            get { return 50 + (Intelligence * 10 * Level); }
        }

        public override int DamageBase
        {
            get { return Intelligence * (Level / 3); }
        }

        public override int AbilityDamageBase
        {
            get { return 3 + (Intelligence * 3 * Level); }
        }

        public override Attributes MainAttribute
        {
            get { return Attributes.Intelligence; }
        }

        #region Constructor
        public IntelligenceCharacter(CharacterDto initProperties)
            : base(initProperties)
        {
        }
        #endregion
    }
}
