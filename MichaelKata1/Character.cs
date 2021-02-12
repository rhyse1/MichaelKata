using System;
namespace MichaelKata1
{
    public class Character
    {
        public int Health { get; }
        public int Level { get; }
        public bool Alive => Health > 0;
        public Character() : this(1)
        {}
        public Character(int level) : this(1000, level)
        {
        }
        public Character(int health, int level)
        {
            Health = health;
            Level = level;
        }
        public Character Heal()
        {
            if (!Alive || Health == 1000)
                return this;
            return new Character(Health + 100, Level);
        }
    }
    public static class CharacterExtensions
    {
        public static Character Attack(this Character attacker, Character target)
        {
            const int baseDamage = 100;
            if (attacker.Equals(target))
                return target;
            var levelDifference = attacker.Level - target.Level;
            var damage = levelDifference switch
            {
                var diff when diff <= -5 => 0.5 * baseDamage,
                var diff when diff >= 5 => 1.5 * baseDamage,
                _ => baseDamage
            };
            var h = target.Health - Convert.ToInt16(damage);
            return new Character(h, target.Level);
        }
    }
}