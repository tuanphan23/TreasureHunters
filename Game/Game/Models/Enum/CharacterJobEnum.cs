using System;
using System.Collections.Generic;
using System.Linq;

namespace Game.Models
{
    /// <summary>
    /// The Types of Jobs a character can have
    /// Used in Character Crudi, and in Battles.
    /// </summary>
    public enum CharacterJobEnum
    {
        // Not specified
        Unknown = 0,

        // Fighters hit hard and have fight abilities
        Fighter = 10,

        // Clerics defend well and have buff abilities
        Cleric = 12,

        //Finder is adept at is quick to initaiate attack
        Finder = 18,

        //Adventurers have an extra sense of agression while they search for treasure
        Adventurer = 26,

        //Treasure Hunters have a solid defense and attack 
        TreasureHunter = 34,

        //A seeker covers themselves and defends while searching for treasure
        Seeker = 40,

    }

    /// <summary>
    /// Friendly strings for the Enum Class
    /// </summary>
    public static class CharacterJobEnumExtensions
    {
        /// <summary>
        /// Display a String for the Enums
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToMessage(this CharacterJobEnum value)
        {
            // Default String
            var Message = "Player";

            switch (value)
            {
                case CharacterJobEnum.Fighter:
                    Message = "";
                    break;

                case CharacterJobEnum.Cleric:
                    Message = "";
                    break;

                case CharacterJobEnum.Finder:
                    Message = "Finder";
                    break;

                case CharacterJobEnum.Adventurer:
                    Message = "Adventurer";
                    break;

                case CharacterJobEnum.TreasureHunter:
                    Message = "Treasure Hunter";
                    break;

                case CharacterJobEnum.Seeker:
                    Message = "Seeker";
                    break;

                case CharacterJobEnum.Unknown:
                default:
                    break;
            }

            return Message;
        }
    }

    /// <summary>
    /// Helper for the Ability Enum Class
    /// </summary>
    public static class CharacterJobEnumHelper
    {
        /// <summary>
        /// Returns a list of strings of the enum for Ability
        /// Removes the Abilitys that are not changable by Items such as Unknown, MaxHealth
        /// </summary>
        public static List<string> GetFullList
        {
            get
            {
                var myList = Enum.GetNames(typeof(CharacterJobEnum)).ToList();
                return myList;
            }
        }

        /// <summary>
        /// Given the String for an enum, return its value.  That allows for the enums to be numbered 2,4,6 rather than 1,2,3
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static CharacterJobEnum ConvertStringToEnum(string value)
        {
            return (CharacterJobEnum)Enum.Parse(typeof(CharacterJobEnum), value);
        }
    }
}