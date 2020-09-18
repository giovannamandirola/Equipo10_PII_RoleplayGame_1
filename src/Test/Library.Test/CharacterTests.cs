using NUnit.Framework;
using Library;

namespace Test.Library
{


    public class CharacterTest
    {
        private Character character;


        [SetUp]
        public void Setup()
        {
            character = new Character("Test Character", 0, 0, "mago");
        }

        [Test]
        public void SetNegativeDamage()
        {
            character.Damage = -100;
            Assert.AreEqual(character.Damage, 0);
        }

        [Test]
        public void SetNegativeHealth()
        {
            character.Health = -100;
            Assert.AreEqual(character.Health, 0);
        }

        [Test]
        public void CheckAddItem()
        {
            Item item = new Item("Test Item", 50, 0);
            character.AddItem(item);
            bool hasItem = character.ExistItem(item);
            Assert.IsTrue(hasItem);
        }

        [Test]
        public void CheckItemAddDamage()
        {
            Item item = new Item("Test Item", 0, 50);
            character.AddItem(item);
            Assert.AreEqual(item.Damage, this.character.Damage);
        }

        [Test]
        public void CheckItemAddHealth()
        {
            Item item = new Item("Test Item", 50, 0);
            character.AddItem(item);
            Assert.AreEqual(item.Defense, this.character.Defense);
        }

    }


}