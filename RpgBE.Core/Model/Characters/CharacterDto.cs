using System;

namespace RpgBE.Core.Model.Characters
{
    public class CharacterDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Strength { get; set; }

        public int Endurance { get; set; }

        public int Intelligence { get; set; }

        public int Agility { get; set; }

        public int HealthPoints { get; set; }

        public int ResourcePoints { get; set; }

        public int Level { get; set; }

        public int ExpNextLevel { get; set; }
    }
}
