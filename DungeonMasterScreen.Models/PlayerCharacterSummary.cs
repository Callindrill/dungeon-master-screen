using DungeonMasterScreen.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMasterScreen.Models
{
    class PlayerCharacterSummary
    {
        string PlayerName { get; set; }
        string CharacterName { get; set; }
        IAbilities AbilityScores { get; set; }
        string Test { get; set; }

    }
}
