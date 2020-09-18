using NUnit.Framework;
using Library;

namespace Test.Library
{
    public class TestItem
    {
        private Item item;
        private Item item2;

        [SetUp]
        public void Setup()
        {
            item = new Item("Pantalones", 0, 5);
            item2 = new Item("Hacha", 33, 0);
        }
        
        [Test]
        public void nameValido()
        {
            const string expected = "Test";
            item.Name = expected;
            Assert.AreEqual(expected, item.Name);
        }

        [Test]
        public void defenseNegativo()
        {
            const int expected = 5;
            item.Defense = -5;
            Assert.AreEqual(expected, item.Defense);
        }

        [Test]
        public void damageNegativo()
        {
            const int expected = 33;
            item2.Damage = -32;
            Assert.AreEqual(expected, item2.Damage);
        }
    }
}
  