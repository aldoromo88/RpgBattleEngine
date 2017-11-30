using RpgBE.Core.Model.Enums;

namespace RpgBE.Core.Model.Battles.ElementModifierCalculator
{
    public class MetalModifierCalculator : ElementModifierBaseCalculator
    {
        public MetalModifierCalculator()
            : base(Elements.Metal)
        {
            StrongAgainst = Elements.Wood;
            WeakAgainst = Elements.Water;
        }
    }
}