using RpgBE.Core.Model.Enums;

namespace RpgBE.Core.Model.Battles.AttributeModifierCalculator
{
    public class IntelligenceModifierCalculator : AttributeModifierBaseCalculator
    {
        public IntelligenceModifierCalculator()
            : base(Attributes.Intelligence)
        {
            StrongAgainst = Attributes.Strength;
            WeakAgainst = Attributes.Agility;
        }
    }
}