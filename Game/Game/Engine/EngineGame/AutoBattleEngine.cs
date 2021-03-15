﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Game.Engine.EngineBase;
using Game.Engine.EngineInterfaces;
using Game.GameRules;
using Game.Models;
using Game.Services;
using Game.ViewModels;
using Xamarin.Forms;

namespace Game.Engine.EngineGame
{
    /// <summary>
    /// AutoBattle Engine
    /// 
    /// Runs the engine simulation with no user interaction
    /// 
    /// </summary>
    public class AutoBattleEngine : AutoBattleEngineBase, IAutoBattleInterface
    {
        #region Algrorithm
        // Prepare for Battle
        // Pick 6 Characters
        // Initialize the Battle
        // Start a Round

        // Fight Loop
        // Loop in the round each turn
        // If Round is over, Start New Round
        // Check end state of round/game

        // Wrap up
        // Get Score
        // Save Score
        // Output Score
        #endregion Algrorithm

        /// <summary>
        /// Define the Battle variable 
        /// </summary>
        //public new IBattleEngineInterface Battle
        //{
        //    get
        //    {
        //        if (base.Battle == null)
        //        {
        //            base.Battle = new BattleEngine
        //            {
        //                Round = new RoundEngine()
        //                {
        //                    Turn = new TurnEngine()
        //                }
        //            };
        //        }
        //        return base.Battle;
        //    }
        //    set { base.Battle = Battle; }
        //}

        public AutoBattleEngine()
        {
            Battle = new BattleEngine();
        }


        /// <summary>
        /// Create character list and monster list
        /// </summary>
        /// <returns></returns>
        public override bool CreateCharacterParty()
        {
            // Picks 6 Characters

            // To use your own characters, populate the List before calling RunAutoBattle

            //// Will first pull from existing characters
            foreach (var data in CharacterIndexViewModel.Instance.Dataset)
            {
                if (Battle.EngineSettings.CharacterList.Count() >= Battle.EngineSettings.MaxNumberPartyCharacters)
                {
                    break;
                }

                // Start off with max health if adding a character in
                data.CurrentHealth = data.GetMaxHealthTotal;
                Battle.PopulateCharacterList(data);
            }

            //If there are not enough will add random ones
            for (int i = Battle.EngineSettings.CharacterList.Count(); i < Battle.EngineSettings.MaxNumberPartyCharacters; i++)
            {
                Battle.PopulateCharacterList(RandomPlayerHelper.GetRandomCharacter(1));
            }

            return true;
        }

        /// <summary>
        /// detect if there's infinite rounds (no game end)
        /// </summary>
        /// <returns></returns>
        public override bool DetectInfinateLoop()
        {
            return base.DetectInfinateLoop();
            ////throw new System.NotImplementedException();
        }

        /// <summary>
        /// Start the automatic battle
        /// </summary>
        /// <returns></returns>
        public override async Task<bool> RunAutoBattle()
        {
            var BattleResult = await base.RunAutoBattle();

            // Add the result to score
            var data = Battle.EngineSettings.BattleScore;
            data.Name = "Auto Battle @ " + DateTime.Now.ToString("G");
            var Score = await ScoreIndexViewModel.Instance.CreateAsync(data);

            return (BattleResult && Score);
        }
    }
}