using MichaelKata1;
using NUnit.Framework;
namespace Kata.Test
{
    [TestFixture]
    public class CharacterTests
    {
        private Character _character;
        private Character _enemy;
        [SetUp]
        public void Setup()
        {
            _character = new Character();
            _enemy = new Character();
        }
        [Test]
        public void CharacterShouldStartWithDefaultValues()
        {
            Assert.That(_character.Health, Is.EqualTo(1000));
            Assert.That(_character.Level, Is.EqualTo(1));
            Assert.That(_character.Alive, Is.EqualTo(true));
        }
        [Test]
        public void CharactersHealthShouldBeSubtractedAfterDamage()
        {
            _enemy.Attack(_character);
            Assert.That(_character.Health, Is.EqualTo(900));
        }
        [Test]
        public void WhenCharacterHealthBecomes0TheyShouldDie()
        {
            for (var i = 0; i < 10; i++)
                _enemy.Attack(_character);
            Assert.That(_character.Alive, Is.EqualTo(false));
        }
        [Test]
        public void DeadCharactersCannotBeHealed()
        {
            for (var i = 0; i < 10; i++)
                _enemy.Attack(_character);
            _character.Heal();
            Assert.That(_character.Alive, Is.EqualTo(false));
            Assert.That(_character.Health, Is.EqualTo(0));
        }   
        [Test]
        public void CharactersShouldNotBeHealedAbove1000()
        {
            _character.Heal();
            Assert.That(_character.Health, Is.EqualTo(1000));
        }
        [Test]
        public void CharacterShouldNotDoDamageToItself()
        {
            _character.Attack(_character);
            Assert.That(_character.Health, Is.EqualTo(1000));
        }
        [Test]
        public void CharacterCanOnlyHealItself()
        {
            _enemy.Attack(_character);
            _character.Heal();
            Assert.That(_character.Health, Is.EqualTo(1000));
        }
        [TestCase(6)]
        [TestCase(7)]
        public void WhenAttackerLevelIs5AboveDamageShouldIncreaseBy50Percent(int characterLevel)
        {
            var character = new Character(characterLevel);
            character.Attack(_enemy);
            Assert.That(_enemy.Health, Is.EqualTo(850));
        }
        [Test]
        public void Should()
        {
            var target = new Character();
            var attacker = new Character();
            attacker.Attack(target).Attack(target);
            Assert.That(target.Health == 800);
        }
    }
}