using System.Collections.Generic;
using System.Linq;
using RpgBE.Core.Model.Enums;

namespace RpgBE.Core.Model.Battles.AttributeModifierCalculator
{
    internal static class AttributeModifierCalculatorFactory
    {
        private static readonly List<AttributeModifierBaseCalculator> _calculators;

        static AttributeModifierCalculatorFactory()
        {
            _calculators = new List<AttributeModifierBaseCalculator>
            {
                new AgilityModifierCalculator(),
                new IntelligenceModifierCalculator(),
                new StrengthModifierCalculator()
            };
        }

        public static AttributeModifierBaseCalculator GetCalculator(this Attributes attribute)
        {
            return _calculators.First(c => Equals(c.Base, attribute));
        }

        public static double GetModifier(this Attributes element, Attributes target)
        {
            return element.GetCalculator().GetModifier(target);
        }
    }
}
