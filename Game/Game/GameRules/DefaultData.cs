using System.Collections.Generic;
using System;

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
                    ImageURI = "glasses.png",
                    Value = 7,
                    Location = ItemLocationEnum.Head,
                    Attribute = AttributeEnum.Defense,
                    DamageType = DamageTypeEnum.Electric
                },
                new ItemModel {
                    Name = "Meerschaum Pipe",
                    Description = "A million-dollar pipe ",
                    ImageURI = "pipe.png",
                    Value = 6,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack,
                    DamageType = DamageTypeEnum.None
                },
                new ItemModel {
                    Name = "President’s book",
                    Description = "A book holds all the secrets to the history of the World ",
                    ImageURI = "book.png",
                    Value = 9,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.CurrentHealth,
                    DamageType = DamageTypeEnum.Heal
                },
                new ItemModel {
                    Name = "Flaming gun",
                    Description = "A magical gun that can cause enemies to explode with solar energy ",
                    ImageURI = "flaregun.png",
                    Value = 7,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack,
                    DamageType = DamageTypeEnum.Fire
                },
                new ItemModel {
                    Name = "Blink boots",
                    Description = "Speedy boots that increase your running speed ",
                    ImageURI = "boot.png",
                    Value = 6,
                    Location = ItemLocationEnum.Feet,
                    Attribute = AttributeEnum.Speed,
                    DamageType = DamageTypeEnum.Electric
                },
                new ItemModel {
                    Name = "Cape",
                    Description = "A marvelous cape with the ability to reduce the damage of the enemies. ",
                    ImageURI = "cape.png",
                    Value = 8,
                    Location = ItemLocationEnum.Unknown,
                    Attribute = AttributeEnum.Defense,
                    DamageType = DamageTypeEnum.Poison
                },
                new ItemModel {
                    Name = "Map",
                    Description = "Map to your next clue, increases confidence making you feel stronger. ",
                    ImageURI = "map2.png",
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
                    TurnCount = 5,
                    RoundCount = 3,
                    ExperienceGainedTotal = 350,
                    MonsterSlainNumber = 5,
                    ScoreTotal = 19,
                    GameDate = DateTime.Now,
        },

                new ScoreModel {
                    Name = "Second Score",
                    Description = "Test Data",
                    TurnCount = 4,
                    RoundCount = 2,
                    ExperienceGainedTotal = 250,
                    MonsterSlainNumber = 4,
                    ScoreTotal = 19,
                    GameDate = DateTime.Now,
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
                    Name = "Benjamin Gates",
                    Description = "An American treasure hunter and cryptologist, famous for finding the Templar Treasure.",
                    Level = 1,
                    MaxHealth = 5,
                    ImageURI = "BenPic.png",
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
                    ImageURI = "RileyPic.png",
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
                    ImageURI = "Abigail.png",
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
                    Name = "Patrick Gates",
                    Description = "A former treasure hunter and the father of Benjamin Franklin Gates",
                    Level = 1,
                    MaxHealth = 5,
                    ImageURI = "OldBen.png",
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
                    ImageURI = "Agent1.png",
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
                    Name = "Mitchell Wilkinson",
                    Description = "An international arms dealer and black-market antiquities dealer ",
                    ImageURI = "Agent1.png",
                },

                new MonsterModel {
                    Name = "Ian Howe",
                    Description = "A currently imprisoned entrepreneur/treasure hunter who attempted to find the Templar Treasure",
                    ImageURI = "Agent2.png",
                },

                new MonsterModel {
                    Name = "Shaw",
                    Description = "Ian Howe's right-hand man and best friend",
                    ImageURI = "Agent3.png",
                },

                new MonsterModel {
                    Name = "Man In Black 1",
                    Description = "FBI Special Agent ",
                    ImageURI = "Agent2.png",
                },

                new MonsterModel {
                    Name = "Man In Black 2",
                    Description = "FBI Special Agent ",
                    ImageURI = "Agent4.png",
                },
            };

        return datalist;
    }
}
}