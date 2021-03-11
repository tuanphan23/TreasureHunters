using System.Collections.Generic;

using Game.Models;
using Game.Engine.EngineInterfaces;
using Game.Engine.EngineModels;
using Game.Engine.EngineBase;
using System.Linq;
using Game.ViewModels;
using Game.Helpers;
using static Game.Models.ItemModel;
using System.Diagnostics;

namespace Game.Engine.EngineGame
{
    /* 
     * Need to decide who takes the next turn
     * Target to Attack
     * Should Move, or Stay put (can hit with weapon range?)
     * Death
     * Manage Round...
     * 
     */

    /// <summary>
    /// Engine controls the turns
    /// 
    /// A turn is when a Character takes an action or a Monster takes an action
    /// 
    /// </summary>
    public class TurnEngine : TurnEngineBase, ITurnEngineInterface
    {
        private Ability AbilityToUse;
        #region Algrorithm
        // Attack or Move
        // Roll To Hit
        // Decide Hit or Miss
        // Decide Damage
        // Death
        // Drop Items
        // Turn Over
        #endregion Algrorithm

        // Hold the BaseEngine
        public new EngineSettingsModel EngineSettings = EngineSettingsModel.Instance;

        /// <summary>
        /// CharacterModel Attacks...
        /// </summary>
        /// <param name="Attacker"></param>
        /// <returns></returns>
        public override bool TakeTurn(PlayerInfoModel Attacker)
        {
            // INFO: Teams, work out your turn logic
            // Choose Action.  Such as Move, Attack etc.

            // INFO: Teams, if you have other actions they would go here.

            bool result = false;

            // If the action is not set, then try to set it or use Attact
            if (EngineSettings.CurrentAction == ActionEnum.Unknown)
            {
                // Set the action if one is not set
                EngineSettings.CurrentAction = DetermineActionChoice(Attacker);

                // When in doubt, attack...
                if (EngineSettings.CurrentAction == ActionEnum.Unknown)
                {
                    EngineSettings.CurrentAction = ActionEnum.Attack;
                }
            }

            switch (EngineSettings.CurrentAction)
            {
                //case ActionEnum.Unknown:
                //    // Action already happened
                //    break;

                case ActionEnum.Attack:
                    result = Attack(Attacker);
                    break;

                case ActionEnum.Ability:
                    result = UseAbility(Attacker);
                    break;

                case ActionEnum.Move:
                    result = MoveAsTurn(Attacker);
                    break;
            }

            EngineSettings.BattleScore.TurnCount++;

            // Save the Previous Action off
            EngineSettings.PreviousAction = EngineSettings.CurrentAction;

            // Reset the Action to unknown for next time
            EngineSettings.CurrentAction = ActionEnum.Unknown;

            //character takes status effect damage at the end of their turn
            Attacker.TriggerStatusEffect();

            return result;
        }

        /// <summary>
        /// Determine what Actions to do
        /// </summary>
        /// <param name="Attacker"></param>
        /// <returns></returns>
        public override ActionEnum DetermineActionChoice(PlayerInfoModel Attacker)
        {
            // If it is the characters turn, and NOT auto battle, use what was sent into the engine
            if (Attacker.PlayerType == PlayerTypeEnum.Character)
            {
                if (EngineSettings.BattleScore.AutoBattle == false)
                {
                    return EngineSettings.CurrentAction;
                }
            }

            /*
             * The following is Used for Monsters, and Auto Battle Characters
             * 
             * Order of Priority
             * If can attack Then Attack
             * Next use Ability or Move
             */

            // Assume Move if nothing else happens
            EngineSettings.CurrentAction = ActionEnum.Move;

            // Check to see if ability is avaiable
            if (ChooseToUseAbility(Attacker))
            {
                EngineSettings.CurrentAction = ActionEnum.Ability;
                return EngineSettings.CurrentAction;
            }
            // See if Desired Target is within Range, and if so attack away
            if (EngineSettings.MapModel.IsTargetInRange(Attacker, AttackChoice(Attacker)))
            {
                EngineSettings.CurrentAction = ActionEnum.Attack;
            }

            return EngineSettings.CurrentAction;
        }

        /// <summary>
        /// Find a Desired Target
        /// Move close to them
        /// Get to move the number of Speed
        /// </summary>
        public override bool MoveAsTurn(PlayerInfoModel Attacker)
        {

            /*
             * TODO: TEAMS Work out your own move logic if you are implementing move
             * 
             * Mike's Logic
             * The monster or charcter will move to a different square if one is open
             * Find the Desired Target
             * Jump to the closest space near the target that is open
             * 
             * If no open spaces, return false
             * 
             */

            return base.MoveAsTurn(Attacker);
        }

        //TODO ability uses
        /// <summary>
        /// Decide to use an Ability or not
        /// 
        /// Set the Ability
        /// </summary>
        public override bool ChooseToUseAbility(PlayerInfoModel Attacker)
        {
            // See if healing is needed.
            EngineSettings.CurrentActionAbility = Attacker.SelectHealingAbility();
            if (HasHealingAbility(Attacker))
            {
                EngineSettings.CurrentAction = ActionEnum.Ability;
                return true;
            }

            // If not needed, then role dice to see if other ability should be used
            // <30% chance
            if (DiceHelper.RollDice(1, 10) < 3)
            {
                EngineSettings.CurrentActionAbility = Attacker.SelectAbilityToUse();
                AbilityToUse = SelectAbilityToUse(Attacker);

                if (AbilityToUse != null && EngineSettings.CurrentActionAbility != AbilityEnum.Unknown)
                {
                    // Ability can , switch to unknown to exit
                    EngineSettings.CurrentAction = ActionEnum.Ability;
                    return true;
                }

                // No ability available
                return true;
            }

            // Don't try
            return false;
        }

        //TODO null abilities?
        //TODO ability count
        /// <summary>
        /// Selects an ability to be used by the player
        /// </summary>
        /// <param name="Attacker"></param>
        /// <returns></returns>
        public Ability SelectAbilityToUse(PlayerInfoModel Attacker)
        {
            List<string> items = Attacker.GetAllItems();
            List<Ability> abilities = new List<Ability>();
            foreach (string id in items)
            {
                var item = ItemIndexViewModel.Instance.GetItem(id);
                //if the item has an ability and if its not healing
                if (item != null && item.itemAbility != null && item.itemAbility.AttackType != DamageTypeEnum.Heal)
                {
                    abilities.Add(item.itemAbility);
                }
            }
            //if not valid abilities return null
            if(abilities.Count == 0)
            {
                return default(Ability);
            }
            //pick a random ability to return
            var myReturn = abilities[DiceHelper.RollDice(1, abilities.Count - 1)];
            return myReturn;
        }

        //TODO ability count
        /// <summary>
        /// returns true if the player has a healing ability it can use
        /// </summary>
        /// <param name="player"></param>
        /// <returns>true if there is a healing ability that can be used, false if not</returns>
        public bool HasHealingAbility(PlayerInfoModel player)
        {
            //check every item to see if it has a healing ability
            List<string> items = player.GetAllItems();
            foreach(string id in items)
            {
                var item = ItemIndexViewModel.Instance.GetItem(id);
                if (item != null && item.itemAbility.AttackType == DamageTypeEnum.Heal)
                {
                    AbilityToUse = item.itemAbility;
                    return true;
                }
            }
            return false;
        }

        //TODO calculate damage
        /// <summary>
        /// Use the Ability
        /// </summary>
        public override bool UseAbility(PlayerInfoModel Attacker)
        {
            //EngineSettings.BattleMessagesModel.TurnMessage = Attacker.Name + " Uses Ability " + EngineSettings.CurrentActionAbility.ToMessage();
            EngineSettings.BattleMessagesModel.TurnMessage = Attacker.Name + " Uses Ability ";
            //get the targets
            List<PlayerInfoModel> targets = ChooseAbilityTarget(Attacker);
            //do the turn
            TurnAsAbility(Attacker, targets);
            return (Attacker.UseAbility(EngineSettings.CurrentActionAbility));
        }


        //TODO current health communication?
        /// <summary>
        /// Takes the turn as an ability
        /// </summary>
        /// <param name="Attacker"></param>
        /// <param name="Target"></param>
        /// <returns></returns>
        public bool TurnAsAbility(PlayerInfoModel Attacker, List<PlayerInfoModel> Target)
        {
            if (Attacker == null)
            {
                return false;
            }

            if (Target == null || Target.Count  <= 0)
            {
                return false;
            }

            // Set Messages to empty
            EngineSettings.BattleMessagesModel.ClearMessages();

            // Do the Attack

            // Remember Current Player
            EngineSettings.BattleMessagesModel.PlayerType = PlayerTypeEnum.Monster;
            EngineSettings.BattleMessagesModel.AttackerName = Attacker.Name;
            EngineSettings.BattleMessagesModel.TargetName = "";
            EngineSettings.BattleMessagesModel.CurrentHealth = 0;

            var damageInf = Attacker.GetDamageRollValue();
            damageInf.DamageAmount = (int)(damageInf.DamageAmount * AbilityToUse.DmgMulti + AbilityToUse.DmgBoost);
            damageInf.element = AbilityToUse.AttackType;
            damageInf.StatusChance = AbilityToUse.StatusChance;
            damageInf.StatusAttack = true;
            
            foreach (var target in Target)
            {
                // Choose who to attack
                EngineSettings.BattleMessagesModel.TargetName += (target.Name + " ");


                EngineSettings.BattleMessagesModel.HitStatus = HitStatusEnum.Hit;

                // Apply the Damage
                EngineSettings.BattleMessagesModel.CurrentHealth += target.GetCurrentHealthTotal;
                EngineSettings.BattleMessagesModel.TurnMessageSpecial = EngineSettings.BattleMessagesModel.GetCurrentHealthMessage();

                EngineSettings.BattleMessagesModel.DamageAmount = 0;
                //if healing adjust the health manually
                if (AbilityToUse.AttackType == DamageTypeEnum.Heal) {
                    target.CalculateDamage(damageInf);
                    target.TakeDamage(damageInf.DamageAmount);
                } else
                {
                    //if damage ask the player for how much damage they take and deal it to them
                    var damage = target.CalculateDamage(damageInf);
                    EngineSettings.BattleMessagesModel.DamageAmount = damage;
                    target.TakeDamage(damage);
                }

                // Check if Dead and Remove
                RemoveIfDead(target);

                // If it is a character apply the experience earned
                CalculateExperience(Attacker, target);
            }
            EngineSettings.BattleMessagesModel.TurnMessage = Attacker.Name + EngineSettings.BattleMessagesModel.AttackStatus + EngineSettings.BattleMessagesModel.TargetName + EngineSettings.BattleMessagesModel.TurnMessageSpecial + EngineSettings.BattleMessagesModel.ExperienceEarned;
            Debug.WriteLine(EngineSettings.BattleMessagesModel.TurnMessage);

            return true;
        }

        /// <summary>
        /// Choose the targets of an ability
        /// </summary>
        /// <param name="Attacker"></param>
        /// <returns></returns>
        public List<PlayerInfoModel> ChooseAbilityTarget(PlayerInfoModel Attacker)
        {
            //list of targets to return
            List<PlayerInfoModel> myReturn = new List<PlayerInfoModel>();
            //list that will containt the list of targets by priority
            List<PlayerInfoModel> sortedList = null;
            //if healing choose the same playerType as a target
                if (AbilityToUse.AttackType == DamageTypeEnum.Heal)
                {
                    //find the lowest health targets first
                    if(Attacker.PlayerType == PlayerTypeEnum.Character)
                    {
                        //sort characters by health
                         sortedList = (List<PlayerInfoModel>)EngineSettings.PlayerList
                        .Where(m => m.Alive && m.PlayerType == PlayerTypeEnum.Character)
                        .OrderBy(m => m.MaxHealth).ToList();
                    } else {
                        //sort monsters by health
                        sortedList = (List<PlayerInfoModel>)EngineSettings.PlayerList
                        .Where(m => m.Alive && m.PlayerType == PlayerTypeEnum.Monster)
                        .OrderBy(m => m.MaxHealth).ToList();
                    }        
                } else
                {
                    //find the targets that would have been targeted by regular attacks
                    if (Attacker.PlayerType == PlayerTypeEnum.Character)
                    {
                        //sort monsters by health
                        sortedList = (List<PlayerInfoModel>)EngineSettings.PlayerList
                       .Where(m => m.Alive && m.PlayerType == PlayerTypeEnum.Monster)
                       .OrderBy(m => m.Level).ToList();
                    }
                    else
                    {
                        //sort characters by health
                        sortedList = (List<PlayerInfoModel>)EngineSettings.PlayerList
                        .Where(m => m.Alive && m.PlayerType == PlayerTypeEnum.Character)
                        .OrderBy(m => m.MaxHealth).ToList();
                    }
                }
            //copy over the first numTarget characters
            for (int i = 0; i < AbilityToUse.NumTargets && i < sortedList.Count; i++)
            {
                myReturn.Add(sortedList[i]);
            }
            return myReturn;
        }

        /// <summary>
        /// Attack as a Turn
        /// 
        /// Pick who to go after
        /// 
        /// Determine Attack Score
        /// Determine DefenseScore
        /// 
        /// Do the Attack
        /// 
        /// </summary>
        public override bool Attack(PlayerInfoModel Attacker)
        {
            // INFO: Teams, AttackChoice will auto pick the target, good for auto battle
            if (EngineSettings.BattleScore.AutoBattle)
            {
                // For Attack, Choose Who
                EngineSettings.CurrentDefender = AttackChoice(Attacker);

                if (EngineSettings.CurrentDefender == null)
                {
                    return false;
                }
            }

            // Do Attack
            TurnAsAttack(Attacker, EngineSettings.CurrentDefender);

            return true;
        }

        /// <summary>
        /// Decide which to attack
        /// </summary>
        public override PlayerInfoModel AttackChoice(PlayerInfoModel data)
        {
            switch (data.PlayerType)
            {
                case PlayerTypeEnum.Monster:
                    return SelectCharacterToAttack();

                case PlayerTypeEnum.Character:
                default:
                    return SelectMonsterToAttack();
            }
        }

        /// <summary>
        /// Pick the Character to Attack
        /// </summary>
        public override PlayerInfoModel SelectCharacterToAttack()
        {
            if (EngineSettings.PlayerList == null)
            {
                return null;
            }

            if (EngineSettings.PlayerList.Count < 1)
            {
                return null;
            }

            // Select the character with the lowest max health to bully first

            var Defender = EngineSettings.PlayerList
                .Where(m => m.Alive && m.PlayerType == PlayerTypeEnum.Character)
                .OrderBy(m => m.MaxHealth).FirstOrDefault();

            return Defender;
        }

        /// <summary>
        /// Pick the Monster to Attack
        /// </summary>
        public override PlayerInfoModel SelectMonsterToAttack()
        {
            if (EngineSettings.PlayerList == null)
            {
                return null;
            }

            if (EngineSettings.PlayerList.Count < 1)
            {
                return null;
            }

            // Select first one to hit in the list for now...
            // Attack the newest (lowest Level) MonsterModel first 

            var Defender = EngineSettings.PlayerList
                .Where(m => m.Alive && m.PlayerType == PlayerTypeEnum.Monster)
                .OrderBy(m => m.Level).FirstOrDefault();

            return Defender;
        }

        /// <summary>
        /// // MonsterModel Attacks CharacterModel
        /// </summary>
        public override bool TurnAsAttack(PlayerInfoModel Attacker, PlayerInfoModel Target)
        {
            return base.TurnAsAttack(Attacker, Target);
        }

        /// <summary>
        /// See if the Battle Settings will Override the Hit
        /// Return the Override for the HitStatus
        /// </summary>
        public override HitStatusEnum BattleSettingsOverride(PlayerInfoModel Attacker)
        {
            return base.BattleSettingsOverride(Attacker);
        }

        /// <summary>
        /// Return the Override for the HitStatus
        /// </summary>
        public override HitStatusEnum BattleSettingsOverrideHitStatusEnum(HitStatusEnum myEnum)
        {
            return base.BattleSettingsOverrideHitStatusEnum(myEnum);
        }

        /// <summary>
        /// Apply the Damage to the Target
        /// </summary>
        public override int ApplyDamage(PlayerInfoModel Target)
        {
            return base.ApplyDamage(Target);
        }

        /// <summary>
        /// Apply the Reflect Damage to the Target
        /// </summary>
        public override int ApplyReflectDamage(PlayerInfoModel Target)
        {
            return base.ApplyReflectDamage(Target);
        }

        /// <summary>
        /// Calculate the Attack, return if it hit or missed.
        /// </summary>
        public override HitStatusEnum CalculateAttackStatus(PlayerInfoModel Attacker, PlayerInfoModel Target)
        {
            return base.CalculateAttackStatus(Attacker, Target);
        }

        /// <summary>
        /// Calculate Experience
        /// Level up if needed
        /// </summary>
        public override bool CalculateExperience(PlayerInfoModel Attacker, PlayerInfoModel Target)
        {
            return base.CalculateExperience(Attacker, Target);
        }

        /// <summary>
        /// If Dead process Target Died
        /// </summary>
        public override bool RemoveIfDead(PlayerInfoModel Target)
        {
            return base.RemoveIfDead(Target);
        }

        /// <summary>
        /// Target Died
        /// 
        /// Process for death...
        /// 
        /// Returns the count of items dropped at death
        /// </summary>
        public override bool TargetDied(PlayerInfoModel Target)
        {
            // INFO: Teams, Hookup your Boss if you have one...
            return base.TargetDied(Target);
        }

        /// <summary>
        /// Drop Items
        /// </summary>
        public override int DropItems(PlayerInfoModel Target)
        {
            // INFO: Teams, work out how you want to drop items.
            return base.DropItems(Target);
        }

        /// <summary>
        /// Roll To Hit
        /// </summary>
        /// <param name="AttackScore"></param>
        /// <param name="DefenseScore"></param>
        public override HitStatusEnum RollToHitTarget(int AttackScore, int DefenseScore)
        {
            return base.RollToHitTarget(AttackScore, DefenseScore);
        }

        /// <summary>
        /// Will drop between 1 and 4 items from the ItemModel set...
        /// </summary>
        public override List<ItemModel> GetRandomMonsterItemDrops(int round)
        {
            // TODO: Teams, You need to implement your own modification to the Logic cannot use mine as is.
            return base.GetRandomMonsterItemDrops(round);
        }

        /// <summary>
        /// Critical Miss Problem
        /// </summary>
        public override bool DetermineCriticalMissProblem(PlayerInfoModel attacker)
        {
            return base.DetermineCriticalMissProblem(attacker);
        }
    }
}
