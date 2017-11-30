namespace RpgBE.Core.Model.Commons
{
    public abstract class EffectivenessBaseCalculator<T> : IEffectiveness<T>
    {
        private readonly double _amountModified;

        protected EffectivenessBaseCalculator(T baseAttribute, double amountModified)
        {
            Base = baseAttribute;
            _amountModified = amountModified;
        }


        public T Base { get; private set; }
        public T StrongAgainst { get; protected set; }
        public T WeakAgainst { get; protected set; }

        public double GetModifier(T target)
        {
            if (Equals(target, StrongAgainst))
            {
                return 1 + _amountModified;
            }

            if (Equals(target, WeakAgainst))
            {
                return 1 - _amountModified;
            }

            return 1;
        }
    }
}
