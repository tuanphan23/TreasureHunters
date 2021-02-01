using System.Collections.Generic;

using Game.Models;
using Game.ViewModels;

namespace Game.GameRules
{
    public static class DefaultData
    {
        /// <summary>
        /// Load the Default data
        /// </summary>
        /// <returns></returns>
        public static List<ItemModel> LoadData(ItemModel temp)
        {
            var datalist = new List<ItemModel>()
            {
                new ItemModel {
                    Name = "I1",
                    Description = "I1",
                    ImageURI = "item.png",
                    Range = 10,
                    Damage = 10,
                    Value = 9,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Name = "I2",
                    Description = "I2",
                    ImageURI = "item.png",
                    Range = 10,
                    Damage = 10,
                    Value = 9,
                    Location = ItemLocationEnum.Head,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Name = "I3",
                    Description = "I3",
                    ImageURI = "item.png",
                    Range = 10,
                    Damage = 10,
                    Value = 9,
                    Location = ItemLocationEnum.Necklass,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Name = "I4",
                    Description = "I4",
                    ImageURI = "item.png",
                    Range = 10,
                    Damage = 10,
                    Value = 9,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Name = "I5",
                    Description = "I5",
                    ImageURI = "item.png",
                    Range = 10,
                    Damage = 10,
                    Value = 9,
                    Location = ItemLocationEnum.Finger,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Name = "I6",
                    Description = "I6",
                    ImageURI = "item.png",
                    Range = 10,
                    Damage = 10,
                    Value = 9,
                    Location = ItemLocationEnum.Feet,
                    Attribute = AttributeEnum.Attack
                },
            };

            for (int i = 0; i < 20; i++)
            {
                var item = new ItemModel
                {
                    ImageURI = "item.png",
                    Range = 2,
                    Damage = 10,
                    Value = 9,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack
                };
                item.Name = "I" + (datalist.Count+1).ToString();
                item.Description = item.Name;

                datalist.Add(item);
            }

            return datalist;
        }

    /// <summary>
    /// Load Example Scores
    /// </summary>
    /// <param name="temp"></param>
    /// <returns></returns>
    public static List<ScoreModel> LoadData(ScoreModel temp)
    {
        var datalist = new List<ScoreModel>()
            {
                new ScoreModel {
                    Name = "First Score",
                    Description = "Test Data",
                },

                new ScoreModel {
                    Name = "Second Score",
                    Description = "Test Data",
                }
            };

        return datalist;
    }

    /// <summary>
    /// Load Characters
    /// </summary>
    /// <param name="temp"></param>
    /// <returns></returns>
    public static List<CharacterModel> LoadData(CharacterModel temp)
    {
        var HeadString = ItemIndexViewModel.Instance.GetDefaultItemId(ItemLocationEnum.Head);
        var NecklassString = ItemIndexViewModel.Instance.GetDefaultItemId(ItemLocationEnum.Necklass);
        var PrimaryHandString = ItemIndexViewModel.Instance.GetDefaultItemId(ItemLocationEnum.PrimaryHand);
        var OffHandString = ItemIndexViewModel.Instance.GetDefaultItemId(ItemLocationEnum.OffHand);
        var FeetString = ItemIndexViewModel.Instance.GetDefaultItemId(ItemLocationEnum.Feet);
        var RightFingerString = ItemIndexViewModel.Instance.GetDefaultItemId(ItemLocationEnum.Finger);
        var LeftFingerString = ItemIndexViewModel.Instance.GetDefaultItemId(ItemLocationEnum.Finger);

        var datalist = new List<CharacterModel>()
            {
                new CharacterModel {
                    Name = "Benjamin Franklin Gates",
                    Description = "An American treasure hunter and cryptologist, famous for finding the Templar Treasure.",
                    Level = 1,
                    MaxHealth = 5,
                    ImageURI = "item.png",
                    Head = HeadString,
                    Necklass = NecklassString,
                    PrimaryHand = PrimaryHandString,
                    OffHand = OffHandString,
                    Feet = FeetString,
                    RightFinger = RightFingerString,
                    LeftFinger = LeftFingerString,
                    Ability = AbilityEnum.Curse,
                    Job = CharacterJobEnum.Fighter,
                },

                new CharacterModel {
                    Name = "Riley Poole",
                    Description = "A sarcastic computer expert, resident genius",
                    Level = 1,
                    MaxHealth = 5,
                    ImageURI = "item.png",
                    Head = HeadString,
                    Necklass = NecklassString,
                    PrimaryHand = PrimaryHandString,
                    OffHand = OffHandString,
                    Feet = FeetString,
                    RightFinger = RightFingerString,
                    LeftFinger = LeftFingerString,
                    Ability = AbilityEnum.Quick,
                    Job = CharacterJobEnum.Cleric,
                },

                new CharacterModel {
                    Name = "Abigail Chase",
                    Description = "An archivist at the National Archives",
                    Level = 1,
                    MaxHealth = 5,
                    ImageURI = "item.png",
                    Head = HeadString,
                    Necklass = NecklassString,
                    PrimaryHand = PrimaryHandString,
                    OffHand = OffHandString,
                    Feet = FeetString,
                    RightFinger = RightFingerString,
                    LeftFinger = LeftFingerString,
                    Ability = AbilityEnum.Heal,
                    Job = CharacterJobEnum.Cleric,
                },

                new CharacterModel {
                    Name = "Patrick Henry Gates",
                    Description = "A former treasure hunter and the father of Benjamin Franklin Gates",
                    Level = 1,
                    MaxHealth = 5,
                    ImageURI = "item.png",
                    Head = HeadString,
                    Necklass = NecklassString,
                    PrimaryHand = PrimaryHandString,
                    OffHand = OffHandString,
                    Feet = FeetString,
                    RightFinger = RightFingerString,
                    LeftFinger = LeftFingerString,
                    Ability = AbilityEnum.Focus,
                    Job = CharacterJobEnum.Cleric,
                },

                new CharacterModel {
                    Name = "Peter Sadusky",
                    Description = "An FBI Special Agent in charge of the theft of the Declaration of Independence",
                    Level = 1,
                    MaxHealth = 5,
                    ImageURI = "item.png",
                    Head = HeadString,
                    Necklass = NecklassString,
                    PrimaryHand = PrimaryHandString,
                    OffHand = OffHandString,
                    Feet = FeetString,
                    RightFinger = RightFingerString,
                    LeftFinger = LeftFingerString,
                    Ability = AbilityEnum.Toughness,
                    Job = CharacterJobEnum.Fighter,
                },

                new CharacterModel {
                    Name = "Ian Howe",
                    Description = "A currently imprisoned entrepreneur/treasure hunter who attempted to find the Templar Treasure",
                    Level = 1,
                    MaxHealth = 5,
                    ImageURI = "item.png",
                    Head = HeadString,
                    Necklass = NecklassString,
                    PrimaryHand = PrimaryHandString,
                    OffHand = OffHandString,
                    Feet = FeetString,
                    RightFinger = RightFingerString,
                    LeftFinger = LeftFingerString,
                    Ability = AbilityEnum.Barrier,
                    Job = CharacterJobEnum.Fighter,
                },

                new CharacterModel {
                    Name = "Mitchell Wilkinson",
                    Description = "An international arms dealer and black-market antiquities dealer ",
                    Level = 1,
                    MaxHealth = 5,
                    ImageURI = "item.png",
                    Head = HeadString,
                    Necklass = NecklassString,
                    PrimaryHand = PrimaryHandString,
                    OffHand = OffHandString,
                    Feet = FeetString,
                    RightFinger = RightFingerString,
                    LeftFinger = LeftFingerString,
                    Ability = AbilityEnum.Nimble,
                    Job = CharacterJobEnum.Fighter,
                },
            };

        return datalist;
    }

    /// <summary>
    /// Load Characters
    /// </summary>
    /// <param name="temp"></param>
    /// <returns></returns>
    public static List<MonsterModel> LoadData(MonsterModel temp)
    {
        var datalist = new List<MonsterModel>()
            {
                new MonsterModel {
                    Name = "M1",
                    Description = "M1",
                    ImageURI = "item.png",
                },

                new MonsterModel {
                    Name = "M2",
                    Description = "M2",
                    ImageURI = "item.png",
                },

                new MonsterModel {
                    Name = "M3",
                    Description = "M3",
                    ImageURI = "item.png",
                },

                new MonsterModel {
                    Name = "M4",
                    Description = "M4",
                    ImageURI = "item.png",
                },

                new MonsterModel {
                    Name = "M5",
                    Description = "M5",
                    ImageURI = "item.png",
                },

                new MonsterModel {
                    Name = "M6",
                    Description = "M6",
                    ImageURI = "item.png",
                },

                new MonsterModel {
                    Name = "M7",
                    Description = "M7",
                    ImageURI = "item.png",
                },
            };

        return datalist;
    }
}
}