using RpgBE.Core.Model.Enums;

namespace RpgBE.Core.Model.Battles.ElementModifierCalculator
{
    public class WaterModifierCalculator : ElementModifierBaseCalculator
    {
        public WaterModifierCalculator()
            : base(Elements.Water)
        {
            StrongAgainst = Elements.Fire;
            WeakAgainst = Elements.Wood;
        }
    }
}