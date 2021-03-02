using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Models
{
    /// <summary>
    /// Example of Battle Settings Control
    /// </summary>
    public class BattleSettingsModel
    {
        // The Battle Model (Simple, Map, etc.)
        public BattleModeEnum BattleModeEnum = BattleModeEnum.SimpleNext;

        // Monster always Hit or Miss or Default
        public HitStatusEnum MonsterHitEnum = HitStatusEnum.Default;

        // Characters always Hit or Miss or Default
        public HitStatusEnum CharacterHitEnum = HitStatusEnum.Default;

        // Are Critical Hits Allowed?
        public bool AllowCriticalHit = false;

        // Are Critical Misses Allowed?
        public bool AllowCriticalMiss = false;

        // Can monsters have Items and weapons?
        public bool AllowMonsterItems = false;

        // Are players impervious to damage?
        public bool ImmunePlayers = false;
        
        // Are monsters impervious to damage?
        public bool ImmuneMonsters = false;

        // Are abilities allowed?
        public bool AllowAbilities = true;

        // Are abilities required to be used if possible
        public bool ForceAbilities = false;
    }
}