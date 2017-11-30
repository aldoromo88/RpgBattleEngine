using RpgBE.Core.Model.Enums;

namespace RpgBE.Core.Model.Battles.AttributeModifierCalculator
{
    public class StrengthModifierCalculator : AttributeModifierBaseCalculator
    {
        public StrengthModifierCalculator()
            : base(Attributes.Strength)
        {
            StrongAgainst = Attributes.Agility;
            WeakAgainst = Attributes.Intelligence;
        }
    }
}