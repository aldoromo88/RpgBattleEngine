using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;
using RpgBE.Core.Model.Battles;
using RpgBE.Core.Model.Characters;
using RpgBE.Core.Model.Enums;

namespace RpgBE.Core.Test.UnitTests
{
    [TestFixture]
    public class BattleTest
    {
        [Test]
        public void SimpleAttack1vs1Test()
        {
            const int battlesToPeform = 1000;

            var strengthCharacter = new StrengthCharacter(new CharacterDto
            {
                Level = 13,

                Agility = 13,
                Endurance = 13,
                Intelligence = 13,
                Strength = 8,

                Id = Guid.NewGuid()
            });


            var agilityCharacter = new AgilityCharacter(new CharacterDto
            {
                Level = 21,

                Agility = 10,
                Endurance = 17,
                Intelligence = 13,
                Strength = 13,

                Id = Guid.NewGuid()
            });

            var intelligenceCharacter = new IntelligenceCharacter(new CharacterDto
            {
                Level = 26,

                Agility = 15,
                Endurance = 19,
                Intelligence = 19,
                Strength = 14,

                Id = Guid.NewGuid()
            });


            var strVsAgl = SimulteBattles(battlesToPeform, strengthCharacter, agilityCharacter);
            var intVsStr = SimulteBattles(battlesToPeform, intelligenceCharacter, strengthCharacter);
            var aglVsInt = SimulteBattles(battlesToPeform, agilityCharacter, intelligenceCharacter);

            Debug.WriteLine("Str wins {0} times vs over Agl with avg Hp remaining of {1}", strVsAgl.Count(c => c.WinningTeam == Team.Blue), strVsAgl.Average(c => c.HpRemaining));
            Debug.WriteLine("Int wins {0} times vs over Str with avg Hp remaining of {1}", intVsStr.Count(c => c.WinningTeam == Team.Blue), intVsStr.Average(c => c.HpRemaining));
            Debug.WriteLine("Agl wins {0} times vs over Ing with avg Hp remaining of {1}", aglVsInt.Count(c => c.WinningTeam == Team.Blue), aglVsInt.Average(c => c.HpRemaining));


        }

        private static List<BattleResult> SimulteBattles(int battlesToPeform, Character blueCharacter, Character redCharacter)
        {
            List<BattleResult> winningTeam = new List<BattleResult>();
            for (int i = 0; i < battlesToPeform; i++)
            {
                BattleSimulationEngine engine = new BattleSimulationEngine();

                blueCharacter.SetBattle(engine, Team.Blue);
                redCharacter.SetBattle(engine, Team.Red);

                engine.StartBattle();

                do
                {
                    var nextParticipant = engine.GetNextParticipant();

                    if (nextParticipant == null)
                    {
                        break;
                    }

                    var enemiesAlive = engine.GetEnemiesAlive(nextParticipant.Team);

                    if (enemiesAlive.Count == 0)
                    {
                        winningTeam.Add(new BattleResult
                        {
                            WinningTeam = nextParticipant.Team,
                            HpRemaining = nextParticipant.Character.HealthPoints
                        });
                        break;
                    }


                    nextParticipant.Character.Attack(enemiesAlive.OrderBy(c => c.HealthPoints).First().Id);
                } while (true);
            }

            return winningTeam;
        }

        private class BattleResult
        {
            public Team WinningTeam { get; set; }
            public int HpRemaining { get; set; }
        }
    }
}
