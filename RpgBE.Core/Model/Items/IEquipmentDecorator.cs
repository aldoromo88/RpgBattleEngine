using RpgBE.Core.Model.Characters;

namespace RpgBE.Core.Model.Items
{
    public interface IEquipmentDecorator
    {
        string Name { get; }

        int Strength { get; }
        int Endurance { get; }
        int Intelligence { get; }
        int Agility { get; }
        int HealthPoints { get; }
        int ResourcePoints { get; }
        int MaxHealthPoint { get; }
        int MaxResourcePoints { get; }
        int DamageBase { get; }
        int AbilityDamageBase { get; }


    }



    public abstract class Equipment : IEquipmentDecorator
    {
        protected Character Character { get; private set;}

        public string Name { get; protected set;}

        public virtual int Strength{get { return Character.Strength; }}
        public virtual int Endurance{get { return Character.Endurance; }}
        public virtual int Intelligence { get { return Character.Intelligence; } }
        public virtual int Agility { get { return Character.Agility; } }
        public virtual int HealthPoints { get { return Character.HealthPoints; } }
        public virtual int ResourcePoints { get { return Character.ResourcePoints; } }
        public virtual int MaxHealthPoint { get { return Character.MaxHealthPoint; } }
        public virtual int MaxResourcePoints { get { return Character.MaxResourcePoints; } }
        public virtual int DamageBase { get { return Character.DamageBase; } }
        public virtual int AbilityDamageBase { get { return Character.AbilityDamageBase; } }

        protected Equipment(Character character)
        {
            Character = character;
        }
    }

    public abstract class Sword : Equipment
    {
        protected Sword(Character character) : base(character)
        {
        }
    }
}