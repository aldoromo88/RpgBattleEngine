using RpgBE.Core.Model.Commons;
using RpgBE.Core.Model.Enums;

namespace RpgBE.Core.Model.Battles.AttributeModifierCalculator
{
    public class AttributeModifierBaseCalculator : EffectivenessBaseCalculator<Attributes>
    {
        private const double AmountModified = 0.1;

        protected AttributeModifierBaseCalculator(Attributes baseAttribute)
            : base(baseAttribute, AmountModified)
        {
        }
    }
}
