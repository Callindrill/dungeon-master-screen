using DungeonMasterScreen.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMasterScreen.Models
{
    public class Strength : Ability, IStrength
    {
        public override int Score { get; set; }
    }
}
