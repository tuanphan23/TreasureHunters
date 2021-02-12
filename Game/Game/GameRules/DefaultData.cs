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
                    Name = "Ocular Device",
                    Description = "A glass to help the wearer see the hidden symbols ",
                    ImageURI = "item.png",
                    Damage = 5,
                    Value = 7,
                    Location = ItemLocationEnum.Head,
                    Attribute = AttributeEnum.Defense,
                    DamageType = DamageTypeEnum.Electric
                },
                new ItemModel {
                    Name = "Meerschaum Pipe",
                    Description = "A million-dollar pipe ",
                    ImageURI = "item.png",
                    Damage = 8,
                    Value = 6,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack,
                    DamageType = DamageTypeEnum.None
                },
                new ItemModel {
                    Name = "President’s book",
                    Description = "A book holds all the secrets to the history of the World ",
                    ImageURI = "item.png",
                    Damage = 5,
                    Value = 9,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.CurrentHealth,
                    DamageType = DamageTypeEnum.Heal
                },
                new ItemModel {
                    Name = "Flaming gun",
                    Description = "A magical gun that can cause enemies to explode with solar energy ",
                    ImageURI = "item.png",
                    Damage = 9,
                    Value = 7,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack,
                    DamageType = DamageTypeEnum.Fire
                },
                new ItemModel {
                    Name = "Blink boots",
                    Description = "Speedy boots that increase your running speed ",
                    ImageURI = "item.png",
                    Damage = 3,
                    Value = 6,
                    Location = ItemLocationEnum.Feet,
                    Attribute = AttributeEnum.Speed,
                    DamageType = DamageTypeEnum.Electric
                },
                new ItemModel {
                    Name = "Cape",
                    Description = "A marvelous cape with the ability to reduce the damage of the enemies. ",
                    ImageURI = "item.png",
                    Damage = 5,
                    Value = 8,
                    Location = ItemLocationEnum.Unknown,
                    Attribute = AttributeEnum.Defense,
                    DamageType = DamageTypeEnum.Poison
                },
                new ItemModel {
                    Name = "Map",
                    Description = "Map to your next clue, increases confidence making you feel stronger. ",
                    ImageURI = "item.png",
                    Damage = 4,
                    Value = 8,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.MaxHealth,
                    DamageType = DamageTypeEnum.Heal
                },
            };

            //for (int i = 0; i < 20; i++)
            //{
            //    var item = new ItemModel
            //    {
            //        ImageURI = "item.png",
            //        Range = 2,
            //        Damage = 10,
            //        Value = 9,
            //        Location = ItemLocationEnum.PrimaryHand,
            //        Attribute = AttributeEnum.Attack
            //    };
            //    item.Name = "I" + (datalist.Count+1).ToString();
            //    item.Description = item.Name;

            //    datalist.Add(item);
            //}

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