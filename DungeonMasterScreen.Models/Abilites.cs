﻿using DungeonMasterScreen.Interfaces;

namespace DungeonMasterScreen.Models
{
    public class Abilities : IAbilities
    {
        public IStrength Strength { get; set; }
        public IDexterity Dexterity { get; set; }
        public IConstitution Constitution { get; set; }
        public IIntelligence Intelligence { get; set; }
        public IWisdom Wisdom { get; set; }
        public ICharisma Charisma { get; set; }

        static public Abilities GetAbilities(IStrength strength, IDexterity dexterity, IConstitution constitution, IIntelligence intelligence, IWisdom wisdom, ICharisma charisma)
        {
            return new Abilities()
            {
                Strength = strength,
                Dexterity = dexterity,
                Constitution = constitution,
                Intelligence = intelligence,
                Wisdom = wisdom,
                Charisma = charisma
            };
        }
    }
}