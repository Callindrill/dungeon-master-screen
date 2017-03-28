using DungeonMasterScreen.Interfaces;
using System;

namespace DungeonMasterScreen.Models
{
    internal class Intelligence : Ability, IIntelligence
    {
        public override int Score { get; set; }
    }
}