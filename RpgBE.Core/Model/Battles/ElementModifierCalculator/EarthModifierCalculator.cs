using RpgBE.Core.Model.Enums;

namespace RpgBE.Core.Model.Battles.ElementModifierCalculator
{
    public class EarthModifierCalculator : ElementModifierBaseCalculator
    {
        public EarthModifierCalculator()
            : base(Elements.Earth)
        {
            StrongAgainst = Elements.Water;
            WeakAgainst = Elements.Metal;
        }
    }
}