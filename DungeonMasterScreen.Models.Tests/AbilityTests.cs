using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FakeItEasy;

namespace DungeonMasterScreen.Models.Tests
{
    [TestClass()]
    public class AbilityTest
    {
        [TestMethod()]
        public void WhenScoreIsSet_ModifierIsCalculated()
        {
            var Ability = A.Fake<Ability>((x) => { x.ConfigureFake((i) => { i.Score = new Random().Next(); }); });
            Assert.IsTrue(Ability.Modifier == (Ability.Score - 10) / 2);
        }
    }
}