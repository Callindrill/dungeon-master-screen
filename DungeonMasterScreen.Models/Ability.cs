using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonMasterScreen.Interfaces;

namespace DungeonMasterScreen.Models
{
    public abstract class Ability : IAbility
    {
        public abstract int Score { get; set; }
        public int Modifier => (int)Math.Floor((Score - 10) / 2.0);
    }
}
