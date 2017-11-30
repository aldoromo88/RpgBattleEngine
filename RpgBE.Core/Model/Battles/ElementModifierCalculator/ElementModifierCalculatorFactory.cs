using System.Collections.Generic;
using System.Linq;
using RpgBE.Core.Model.Enums;

namespace RpgBE.Core.Model.Battles.ElementModifierCalculator
{

    internal static class ElementModifierCalculatorFactory
    {
        private static readonly List<ElementModifierBaseCalculator> _calculators;

        static ElementModifierCalculatorFactory()
        {
            _calculators = new List<ElementModifierBaseCalculator>
            {
                 new EarthModifierCalculator(),
                 new FireModifierCalculator(),
                 new MetalModifierCalculator(),
                 new WaterModifierCalculator(),
                 new WoodModifierCalculator()
            };
        }

        public static ElementModifierBaseCalculator GetCalculator(this Elements element)
        {
            return _calculators.First(c => Equals(c.Base, element));
        }

        public static double GetModifier(this Elements element, Elements target)
        {
            return element.GetCalculator().GetModifier(target);
        }
    }
}
