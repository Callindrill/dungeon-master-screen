using DungeonMasterScreen.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMasterScreen.Models
{
    class Dexterity : Ability, IDexterity
    {
        public override int Score { get; set; }
    }
}
