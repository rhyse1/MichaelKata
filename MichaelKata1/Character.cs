namespace MichaelKata1
{
    public class Character
    {
        public int Health { get; set; }
        public int Level { get; set; }
        public bool Alive { get; set; }

        public Character()
        {
            Health = 1000;
            Level = 1;
            Alive = true;
        }

        public void Attack(Character character)
        {
            if (character.Equals(this))
                return;
            
            var levelDifference = Level - character.Level;
            var isHigher = Level > character.Level;
            if (isHigher)
            {
                var modifier = levelDifference >= 5 ? 1.5 : 0.5;
                character.Health -= 100.0 * modifier;
                return;
            }

            character.Health -= 100;
            
            if (character.Health <= 0)
                character.Alive = false;
        }

        public void Heal()
        {
            if (!Alive || Health == 1000)
                return;

            Health += 100;
        }
    }
}