using System;
using RpgBE.Core.Model.Abilities;
using RpgBE.Core.Model.Battles;
using RpgBE.Core.Model.Commons;
using RpgBE.Core.Model.Enums;

namespace RpgBE.Core.Model.Characters
{
    public abstract class Character : GameObject
    {
        private const int AttributeCap = 20;

        #region Fields
        private int _strength;
        private int _endurance;
        private int _intelligence;
        private int _agility;
        private int _healthPoints;
        private int _resourcePoints;
        private IBattle _battle;

        #endregion

        #region Properties
        public Guid Id { get; private set; }

        public string Name { get; protected set; }

        public int Strength
        {
            get { return _strength; }
            protected set { _strength = GetCappedAttribute(value); }
        }

        public int Endurance
        {
            get { return _endurance; }
            protected set { _endurance = GetCappedAttribute(value); }
        }

        public int Intelligence
        {
            get { return _intelligence; }
            protected set { _intelligence = GetCappedAttribute(value); }
        }

        public int Agility
        {
            get { return _agility; }
            protected set { _agility = GetCappedAttribute(value); }
        }

        public int HealthPoints
        {
            get { return _healthPoints; }
            protected set
            {
                if (value < 0)
                {
                    _healthPoints = 0;
                }
                else if (value > MaxHealthPoint)
                {
                    _healthPoints = MaxHealthPoint;
                }
                else
                {
                    _healthPoints = value;
                }
            }
        }

        public int ResourcePoints
        {
            get { return _resourcePoints; }
            protected set
            {
                if (value < 0)
                {
                    _resourcePoints = 0;
                }
                else if (value > MaxResourcePoints)
                {
                    _resourcePoints = MaxResourcePoints;
                }
                else
                {
                    _resourcePoints = value;
                }
            }
        }

        public int Level { get; private set; }

        public int ExpNextLevel { get; private set; }

        public int MaxHealthPoint
        {
            get { return Endurance * 100 + (Level * Endurance / 20); }
        }

        public Elements ElementyAffinity { get; set; }

        public abstract int MaxResourcePoints { get; }

        public abstract int DamageBase { get; }

        public abstract int AbilityDamageBase { get; }

        public abstract Attributes MainAttribute { get; }

        #endregion

        #region Constructor
        protected Character(CharacterDto initProperties)
            : base(initProperties)
        {
            if (Id == Guid.Empty)
            {
                Id = Guid.NewGuid();
            }


            if (Level == 0)
            {
                //TODO create leveling system
                Level = 1;
                ExpNextLevel = 1000;
            }

            if (string.IsNullOrWhiteSpace(Name))
            {
                Name = GetType().Name;
            }

        }
        #endregion

        public void SetBattle(IBattle battle, Team team)
        {
            _battle = battle;
            _battle.RegisterParticipant(this, team);
        }

        public void Attack(Guid target)
        {
            if (_battle == null) return;
            _battle.Attack(Id, target);
        }

        public void Cast(Guid target, Ability ability)
        {
            if (_battle == null) return;
            _battle.Cast(Id, target, ability);
        }

        internal void LoseHealth(int points)
        {
            HealthPoints -= points;
        }

        internal void RecoverHealth(int points)
        {
            HealthPoints += points;
        }

        internal void LoseResources(int points)
        {
            ResourcePoints -= points;
        }

        internal void RecoverResources(int points)
        {
            ResourcePoints += points;
        }

        #region Private Methods
        private static int GetCappedAttribute(int value)
        {
            return value < 1 ? 1 : (value > AttributeCap ? AttributeCap : value);
        }
        #endregion


    }
}
