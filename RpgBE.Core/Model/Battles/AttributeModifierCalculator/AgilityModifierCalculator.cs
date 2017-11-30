using RpgBE.Core.Model.Enums;

namespace RpgBE.Core.Model.Battles.AttributeModifierCalculator
{
    public class AgilityModifierCalculator:AttributeModifierBaseCalculator
    {
        public AgilityModifierCalculator() : base(Attributes.Agility)
        {
            StrongAgainst = Attributes.Intelligence;
            WeakAgainst = Attributes.Strength;
        }
    }
}
