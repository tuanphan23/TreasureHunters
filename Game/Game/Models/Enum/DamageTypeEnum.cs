using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Models
{
    /// <summary>
    /// The elemental types of damage
    /// Used by DamageInfo to specify what element of damage is being dealt
    /// </summary>
    public enum DamageTypeEnum
    {
        //No element
        None = 0,

        //Fire damage
        Fire = 1,

        //Electric damage
        Electric = 2,

        //Poison damage
        Poison = 3,

        //Healing rather than damage
        Heal = 10
    }
}
