using RpgBE.Core.Model.Enums;

namespace RpgBE.Core.Model.Battles.ElementModifierCalculator
{
    public class WoodModifierCalculator : ElementModifierBaseCalculator
    {
        public WoodModifierCalculator()
            : base(Elements.Wood)
        {
            StrongAgainst = Elements.Earth;
            WeakAgainst = Elements.Fire;
        }
    }
}