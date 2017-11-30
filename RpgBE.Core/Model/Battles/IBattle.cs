using System;
using RpgBE.Core.Model.Abilities;
using RpgBE.Core.Model.Characters;
using RpgBE.Core.Model.Enums;

namespace RpgBE.Core.Model.Battles
{
    public interface IBattle
    {
        void RegisterParticipant(Character character, Team team);
        void Attack(Guid from, Guid to);
        void Cast(Guid from, Guid to, Ability ability);
    }
}
