namespace RpgBE.Core.Model.Commons
{
    interface IEffectiveness<T>
    {

        T Base { get; }
        T StrongAgainst { get; }
        T WeakAgainst { get; }
        double GetModifier(T target);
    }
}
