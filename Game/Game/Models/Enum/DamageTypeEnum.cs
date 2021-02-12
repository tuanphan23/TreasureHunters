using System;
using System.Collections.Generic;
using System.Linq;
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


    /// <summary>
    /// Friendly strings for the Enum Class
    /// </summary>
    public static class DamageTypeEnumExtensions
    {
        /// <summary>
        /// Display a String for the Enums
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToMessage(this DamageTypeEnum value)
        {
            // Default String
            var Message = "None";

            switch (value)
            {
                case DamageTypeEnum.None:
                    Message = "None";
                    break;

                case DamageTypeEnum.Fire:
                    Message = "Fire";
                    break;

                case DamageTypeEnum.Electric:
                    Message = "Electric";
                    break;

                case DamageTypeEnum.Poison:
                    Message = "Poison";
                    break;

                case DamageTypeEnum.Heal:
                    Message = "Healing";
                    break;
            }

            return Message;
        }
    }

    /// <summary>
    /// Helper for the DamageTypeEnum Class
    /// </summary>
    public static class DamageTypeEnumHelper
    {
        /// <summary>
        /// Returns a list of strings of the enum for DamageType
        /// </summary>
        public static List<string> GetFullList
        {
            get
            {
                var myList = Enum.GetNames(typeof(DamageTypeEnum)).ToList();
                return myList;
            }
        }

        /// <summary>
        /// Given the String for an enum, return its value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static CharacterJobEnum ConvertStringToEnum(string value)
        {
            return (CharacterJobEnum)Enum.Parse(typeof(CharacterJobEnum), value);
        }
    }
}
