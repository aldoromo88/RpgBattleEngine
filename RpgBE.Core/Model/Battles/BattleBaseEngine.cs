using System;
using System.Collections.Generic;
using System.Linq;
using RpgBE.Core.Model.Abilities;
using RpgBE.Core.Model.Battles.AttributeModifierCalculator;
using RpgBE.Core.Model.Characters;
using RpgBE.Core.Model.Enums;

namespace RpgBE.Core.Model.Battles
{
    public abstract class BattleBaseEngine : IBattle
    {
        protected List<BattleParticipant> Participants { get; private set; }

        protected BattleStatus Status { get; private set; }

        public BattleBaseEngine()
        {
            Participants = new List<BattleParticipant>();
            Status = BattleStatus.NotStarted;
        }

        public void RegisterParticipant(Character character, Team team)
        {
            if (Status != BattleStatus.NotStarted)
            {
                throw new Exception("Participants only can be registered before battle begins!");
            }

            if (character == null)
            {
                throw new ArgumentNullException("character");
            }


            if (Participants.Any(p => p.Character.Id == character.Id))
            {
                return;
            }

            Participants.Add(new BattleParticipant(character, team));
        }

        public void Attack(Guid from, Guid to)
        {
            if (Status != BattleStatus.Started)
            {
                throw new Exception("Attacks can only by performed while battle is active");
            }

            var cFrom = GetParticipant(from);
            var cTo = GetParticipant(to);


            var damageBase = cFrom.Character.DamageBase;
            var attributeModifier = cFrom.Character.MainAttribute.GetModifier(cTo.Character.MainAttribute);
            
            //
            //var elementModifier = cFrom.Character.

            //TODO evaluate effects, weapons, armor and any other modifier
            var finalDamage = (damageBase * attributeModifier);

            //Make damage 
            cTo.Character.LoseHealth((int)finalDamage);

            //Reset tickts
            cFrom.Ticks = 0;
        }

        public void Cast(Guid from, Guid to, Ability ability)
        {
            if (Status != BattleStatus.Started)
            {
                throw new Exception("Ability casts can only by performed while battle is active");
            }

            throw new NotImplementedException();
        }

        public virtual void StartBattle()
        {
            if (Status != BattleStatus.NotStarted)
            {
                throw new Exception("Battle is already started or even finished!");
            }

            Status = BattleStatus.Started;

            //TODO apply modifiers from battle field?
        }

        public virtual void EndBattle()
        {
            if (Status != BattleStatus.Started)
            {
                throw new Exception("Battle is not started yet!");
            }

            Status = BattleStatus.Started;
        }

        protected BattleParticipant GetParticipant(Guid id)
        {
            var participant = Participants.FirstOrDefault(c => c.Character.Id == id);

            if (participant == null)
            {
                throw new Exception(string.Format("Participant with Id {0} not found", id));
            }
            return participant;
        }
    }
}