using DungeonMasterScreen.Interfaces;
using System;

namespace DungeonMasterScreen.Models
{
    internal class Charisma : Ability, ICharisma
    {
        public override int Score { get; set; }
    }
}