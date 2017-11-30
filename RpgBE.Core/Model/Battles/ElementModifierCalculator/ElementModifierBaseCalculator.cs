using RpgBE.Core.Model.Commons;
using RpgBE.Core.Model.Enums;

namespace RpgBE.Core.Model.Battles.ElementModifierCalculator
{
    public class ElementModifierBaseCalculator : EffectivenessBaseCalculator<Elements>
    {
        private const double AmountModified = 0.2;

        protected ElementModifierBaseCalculator(Elements baseAttribute)
            : base(baseAttribute, AmountModified)
        {
        }
    }
}