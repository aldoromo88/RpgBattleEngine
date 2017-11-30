using System;
using Newtonsoft.Json;
using NUnit.Framework;
using RpgBE.Core.Model.Characters;

namespace RpgBE.Core.Test.UnitTests
{
    [TestFixture]
    public class CharacterTests
    {

        [Test]
        public void InstantiationTest()
        {
            CharacterDto dto = new CharacterDto
            {
                Level = 10,
                ResourcePoints = 1,
                Agility = 1,
                Endurance = 1,
                HealthPoints = 1,
                ExpNextLevel = 100,
                Intelligence = 1,
                Strength = 1,
                Id = Guid.NewGuid()
            };

            var intelligenceCharacter = new IntelligenceCharacter(dto);
            var strengthCharacter = new StrengthCharacter(dto);
            var agilityCharacter = new AgilityCharacter(dto);


            Assert.AreEqual(intelligenceCharacter.MaxHealthPoint, strengthCharacter.MaxHealthPoint);

            Assert.Greater(intelligenceCharacter.MaxResourcePoints, agilityCharacter.MaxResourcePoints);
            Assert.Greater(agilityCharacter.MaxResourcePoints, strengthCharacter.MaxResourcePoints);

        }


        [Test]
        public void SeralizationTest()
        {

            CharacterDto dto = new CharacterDto
            {
                Level = 10,
                ResourcePoints = 3,
                Agility = 3,
                Endurance = 3,
                HealthPoints = 3,
                ExpNextLevel = 100,
                Intelligence = 3,
                Strength = 3,
                Id = Guid.NewGuid()
            };

            var intelligenceCharacter = new IntelligenceCharacter(dto);
            var maxResourcePointsBefore = intelligenceCharacter.MaxResourcePoints;

            var intJson = intelligenceCharacter.ToJson();
            dynamic deserializedObject = intJson.ToGameObject();

            var maxResourcePointsAfter = deserializedObject.MaxResourcePoints;
            Assert.AreEqual(maxResourcePointsAfter, maxResourcePointsBefore);
        }
    }
}
