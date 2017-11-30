using RpgBE.Core.Model.Enums;

namespace RpgBE.Core.Model.Battles.ElementModifierCalculator
{
    public class FireModifierCalculator : ElementModifierBaseCalculator
    {
        public FireModifierCalculator()
            : base(Elements.Fire)
        {
            StrongAgainst = Elements.Metal;
            WeakAgainst = Elements.Earth;
        }
    }
}