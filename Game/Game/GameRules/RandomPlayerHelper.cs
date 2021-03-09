using System;
using System.Collections.Generic;
using System.Linq;

using Game.Helpers;
using Game.Models;
using Game.ViewModels;


namespace Game.GameRules
{
    public static class RandomPlayerHelper
    {
        /// <summary>
        /// Get Health
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public static int GetHealth(int level)
        {
            // Roll the Dice and reset the Health
            return DiceHelper.RollDice(level, 10);
        }

        /// <summary>
        /// Get A Random Difficulty
        /// </summary>
        /// <returns></returns>
        public static string GetMonsterUniqueItem()
        {
            var itemIndex = DiceHelper.RollDice(1, ItemIndexViewModel.Instance.Dataset.Count()) - 1;
            // Check to see if there are enough items, if not, then just use the first one...
            var result = ItemIndexViewModel.Instance.Dataset.First().Id;

            if (itemIndex < ItemIndexViewModel.Instance.Dataset.Count)
            {
                result = ItemIndexViewModel.Instance.Dataset.ElementAt(itemIndex).Id;
            }

            return result;
        }

        /// <summary>
        /// Get A Random Unique Item for Characters
        /// Only use for Unit Testing
        /// </summary>
        /// <returns></returns>
        public static string GetCharacterUniqueItem()
        {
            var itemIndex = DiceHelper.RollDice(1, ItemIndexViewModel.Instance.Dataset.Count()) - 1;
            // Check to see if there are enough items, if not, then just use the first one...
            var result = ItemIndexViewModel.Instance.Dataset.First().Name;

            if (itemIndex < ItemIndexViewModel.Instance.Dataset.Count)
            {
                result = ItemIndexViewModel.Instance.Dataset.ElementAt(itemIndex).Name;
            }

            return result;
        }

        /// <summary>
        /// Get A Random Difficulty
        /// </summary>
        /// <returns></returns>
        public static DifficultyEnum GetMonsterDifficultyValue()
        {
            var DifficultyList = DifficultyEnumHelper.GetListMonster;

            var RandomDifficulty = DifficultyList.ElementAt(DiceHelper.RollDice(1, DifficultyList.Count()) - 1);

            var result = DifficultyEnumHelper.ConvertStringToEnum(RandomDifficulty);

            return result;
        }

        /// <summary>
        /// Get Random Image
        /// </summary>
        /// <returns></returns>
        public static string GetMonsterImage()
        {

            List<String> StringList = new List<String> { "Agent1.png", "Agent2.png", "Agent3.png", "Agent4.png" };

            var index = DiceHelper.RollDice(1, StringList.Count()) - 1;

            var result = StringList.First();

            if (index < StringList.Count)
            {
                result = StringList.ElementAt(index);
            }

            return result;
        }

        /// <summary>
        /// Get Random Image
        /// </summary>
        /// <returns></returns>
        public static string GetCharacterImage()
        {

            List<String> StringList = new List<String> { "Abigail.png", "BenPic.png", "OldBen.png", "RileyPic.png" };

            var index = DiceHelper.RollDice(1, StringList.Count()) - 1;

            var result = StringList.First();

            if (index < StringList.Count)
            {
                result = StringList.ElementAt(index);
            }

            return result;
        }

        /// <summary>
        /// Get Name
        /// 
        /// Return a Random Name
        /// </summary>
        /// <returns></returns>
        public static string GetMonsterName()
        {

            List<String> StringList = new List<String> { "Shaw", "Ian", "Mitchell", "MIB1", "MIB2" };

            var index = DiceHelper.RollDice(1, StringList.Count()) - 1;

            var result = StringList.First();

            if (index < StringList.Count)
            {
                result = StringList.ElementAt(index);
            }

            return result;
        }

        /// <summary>
        /// Get Description
        /// 
        /// Return a random description
        /// </summary>
        /// <returns></returns>
        public static string GetMonsterDescription()
        {
            List<String> StringList = new List<String> { "Angry Agent", "Serious Agent", "Treasure destoryer", "Treasure Hunter", "Treasure Killer", "The Theft" };

            var index = DiceHelper.RollDice(1, StringList.Count()) - 1;

            var result = StringList.First();

            if (index < StringList.Count)
            {
                result = StringList.ElementAt(index);
            }

            return result;
        }

        /// <summary>
        /// Get Name
        /// 
        /// Return a Random Name
        /// </summary>
        /// <returns></returns>
        public static string GetCharacterName()
        {

            List<String> StringList = new List<String> { "Ben", "Riley", "Patrick", "Abigail", "Peter", "Daren", "Dani", "Mami", "Mari", "Ryu", "Hucky", "Peanut", "Sumi", "Apple", "Ami", "Honami", "Sonomi", "Pat", "Sakue", "Isamu" };

            var index = DiceHelper.RollDice(1, StringList.Count()) - 1;

            var result = StringList.First();

            if (index < StringList.Count)
            {
                result = StringList.ElementAt(index);
            }

            return result;
        }

        /// <summary>
        /// Get Description
        /// 
        /// Return a random description
        /// </summary>
        /// <returns></returns>
        public static string GetCharacterDescription()
        {
            List<String> StringList = new List<String> { "the hunter", "the awesome", "the computer expert", "the old", "the younger", "the archivist", "the loud", "the helpless", "the happy", "the sleepy", "the angry", "the clever" };

            var index = DiceHelper.RollDice(1, StringList.Count()) - 1;

            var result = StringList.First();

            if (index < StringList.Count)
            {
                result = StringList.ElementAt(index);
            }

            return result;
        }

        /// <summary>
        /// Get A Random Job
        /// </summary>
        /// <returns></returns>
        public static CharacterJobEnum GetCharacterJob()
        {
            var JobList = CharacterJobEnumHelper.GetFullList;

            var RandomJob = JobList.ElementAt(DiceHelper.RollDice(1, JobList.Count()) - 1);

            var result = CharacterJobEnumHelper.ConvertStringToEnum(RandomJob);

            return result;
        }

        /// <summary>
        /// Get Random Ability Number
        /// </summary>
        /// <returns></returns>
        public static int GetAbilityValue()
        {
            // 0 to 9, not 1-10
            return DiceHelper.RollDice(1, 10) - 1;
        }

        /// <summary>
        /// Get a Random Level
        /// </summary>
        /// <returns></returns>
        public static int GetLevel()
        {
            // 1-20
            return DiceHelper.RollDice(1, 20);
        }

        /// <summary>
        /// Get a Random Item for the Location
        /// 
        /// Return the String for the ID
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public static string GetItem(ItemLocationEnum location)
        {
            var ItemList = ItemIndexViewModel.Instance.GetLocationItems(location);
            if (ItemList.Count == 0)
            {
                return null;
            }

            // Add None to the list
            ItemList.Add(new ItemModel { Id = null, Name = "None" });

            var result = ItemList.First().Id;

            var index = DiceHelper.RollDice(1, ItemList.Count()) - 1;
            if (index < ItemList.Count)
            {
                result = ItemList.ElementAt(index).Id;
            }

            return result;
        }

        /// <summary>
        /// Create Random Character for the battle
        /// </summary>
        /// <param name="MaxLevel"></param>
        /// <returns></returns>
        public static CharacterModel GetRandomCharacter(int MaxLevel)
        {
            var result = new CharacterModel()
            {
                Level = DiceHelper.RollDice(1, MaxLevel),

                // Randomize Name
                Name = GetCharacterName(),
                Description = GetCharacterDescription(),

                // Randomize the Attributes
                Attack = GetAbilityValue(),
                Speed = GetAbilityValue(),
                Defense = GetAbilityValue(),

                // Randomize an Item for Location
                Head = GetItem(ItemLocationEnum.Head),
                Necklass = GetItem(ItemLocationEnum.Necklass),
                PrimaryHand = GetItem(ItemLocationEnum.PrimaryHand),
                OffHand = GetItem(ItemLocationEnum.OffHand),
                RightFinger = GetItem(ItemLocationEnum.Finger),
                LeftFinger = GetItem(ItemLocationEnum.Finger),
                Feet = GetItem(ItemLocationEnum.Feet),

                // Only use for Unit Testing
                UniqueItem = GetCharacterUniqueItem(),

                Job = GetCharacterJob(),
                ImageURI = GetCharacterImage()
            };

            result.MaxHealth = DiceHelper.RollDice(MaxLevel, 10);

            // Level up to the new level
            result.LevelUpToValue(result.Level);

            // Enter Battle at full health
            result.CurrentHealth = result.MaxHealth;

            return result;
        }

        /// <summary>
        /// Create Random Character for the battle
        /// </summary>
        /// <param name="MaxLevel"></param>
        /// <returns></returns>
        public static MonsterModel GetRandomMonster(int MaxLevel, bool Items= false)
        {
            var result = new MonsterModel()
            {
                Level = DiceHelper.RollDice(1, MaxLevel),

                // Randomize Name
                Name = GetMonsterName(),
                Description = GetMonsterDescription(),

                // Randomize the Attributes
                Attack = GetAbilityValue(),
                Speed = GetAbilityValue(),
                Defense = GetAbilityValue(),

                ImageURI = GetMonsterImage(),

                Difficulty = GetMonsterDifficultyValue(),
                UniqueItem = GetMonsterUniqueItem()
            };

            // Adjust values based on Difficulty
            result.Attack = result.Difficulty.ToModifier(result.Attack);
            result.Defense = result.Difficulty.ToModifier(result.Defense);
            result.Speed = result.Difficulty.ToModifier(result.Speed);
            result.Level = result.Difficulty.ToModifier(result.Level);

            // Get the new Max Health
            result.MaxHealth = DiceHelper.RollDice(result.Level, 10);

            // Adjust the health, If the new Max Health is above the rule for the level, use the original
            var MaxHealthAdjusted = result.Difficulty.ToModifier(result.MaxHealth);
            if (MaxHealthAdjusted < result.Level * 10)
            {
                result.MaxHealth = MaxHealthAdjusted;
            }

            // Level up to the new level
            result.LevelUpToValue(result.Level);

            // Set ExperienceRemaining so Monsters can both use this method
            var temp = result.Level;
            if (result.Level != LevelTableHelper.MaxLevel) { temp = result.Level + 1; }
            result.ExperienceRemaining = LevelTableHelper.LevelDetailsList[temp].Experience;

            // Enter Battle at full health
            result.CurrentHealth = result.MaxHealth;

            // Monsters can have weapons too....
            if (Items)
            {
                result.Head = GetItem(ItemLocationEnum.Head);
                result.Necklass = GetItem(ItemLocationEnum.Necklass);
                result.PrimaryHand = GetItem(ItemLocationEnum.PrimaryHand);
                result.OffHand = GetItem(ItemLocationEnum.OffHand);
                result.RightFinger = GetItem(ItemLocationEnum.Finger);
                result.LeftFinger = GetItem(ItemLocationEnum.Finger);
                result.Feet = GetItem(ItemLocationEnum.Feet);
            }

            return result;
        }

        /// <summary>
        /// Create Random Character for the battle
        /// </summary>
        /// <param name="MaxLevel"></param>
        /// <returns></returns>
        public static MonsterModel GetRandomBossMonster(int MaxLevel, bool Items = false)
        {
            var result = new MonsterModel()
            {
                Level =  MaxLevel,

                // Randomize Name
                Name = GetMonsterName(),
                Description = GetMonsterDescription(),

                // Randomize the Attributes
                Attack = GetAbilityValue(),
                Speed = GetAbilityValue(),
                Defense = GetAbilityValue(),

                ImageURI = GetMonsterImage(),

                Difficulty = GetMonsterDifficultyValue(),
                UniqueItem = GetMonsterUniqueItem()
            };

            // Adjust values based on Difficulty
            result.Attack = result.Difficulty.ToModifier(result.Attack);
            result.Defense = result.Difficulty.ToModifier(result.Defense);
            result.Speed = result.Difficulty.ToModifier(result.Speed);
            result.Level = result.Difficulty.ToModifier(result.Level);

            // Get the new Max Health
            result.MaxHealth = DiceHelper.RollDice(result.Level, 10);

            // Adjust the health, If the new Max Health is above the rule for the level, use the original
            var MaxHealthAdjusted = result.Difficulty.ToModifier(result.MaxHealth);
            if (MaxHealthAdjusted < result.Level * 10)
            {
                result.MaxHealth = MaxHealthAdjusted;
            }

            // Level up to the new level
            result.LevelUpToValue(result.Level);

            // Set ExperienceRemaining so Monsters can both use this method
            result.ExperienceRemaining = LevelTableHelper.LevelDetailsList[result.Level + 1].Experience;

            // Enter Battle at full health
            result.CurrentHealth = result.MaxHealth;

            // Monsters can have weapons too....
            if (Items)
            {
                result.Head = GetItem(ItemLocationEnum.Head);
                result.Necklass = GetItem(ItemLocationEnum.Necklass);
                result.PrimaryHand = GetItem(ItemLocationEnum.PrimaryHand);
                result.OffHand = GetItem(ItemLocationEnum.OffHand);
                result.RightFinger = GetItem(ItemLocationEnum.Finger);
                result.LeftFinger = GetItem(ItemLocationEnum.Finger);
                result.Feet = GetItem(ItemLocationEnum.Feet);
            }

            return result;
        }
    }
}