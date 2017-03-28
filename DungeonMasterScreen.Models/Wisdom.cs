using DungeonMasterScreen.Interfaces;
using System;

namespace DungeonMasterScreen.Models
{
    internal class Wisdom : Ability, IWisdom
    {
        public override int Score { get; set; }
    }
}