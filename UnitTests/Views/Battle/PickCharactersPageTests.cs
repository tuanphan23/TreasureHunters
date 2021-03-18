﻿using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using Xamarin.Forms.Mocks;
using Xamarin.Forms;

using Game;
using Game.Views;
using Game.ViewModels;
using Game.Models;

namespace UnitTests.Views
{
    [TestFixture]
    public class PickCharactersPageTests : PickCharactersPage
    {
        App app;
        PickCharactersPage page;

        public PickCharactersPageTests() : base(true) { }

        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            // For now, set the engine to the Koenig Engine, change when ready 
            BattleEngineViewModel.Instance.SetBattleEngineToGame();

            page = new PickCharactersPage();
        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

        [Test]
        public void PickCharactersPage_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }
        
        [Test]
        public void PickCharactersPage_Constructor_UT_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new PickCharactersPage(false);

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void PickCharactersPage_BattleButton_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.BattleButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void PickCharactersPage_CreateEngineCharacterList_Default_Should_Pass()
        {
            // Arrange
            BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList = new List<PlayerInfoModel>();
            BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(new CharacterModel()));

            BattleEngineViewModel.Instance.Engine.EngineSettings.MonsterList = new List<PlayerInfoModel>();
            BattleEngineViewModel.Instance.Engine.EngineSettings.MonsterList.Add(new PlayerInfoModel(new MonsterModel()));

            BattleEngineViewModel.Instance.PartyCharacterList = new ObservableCollection<CharacterModel>();
            BattleEngineViewModel.Instance.PartyCharacterList.Add(new CharacterModel());

            // Act
            page.CreateEngineCharacterList();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        //This test uses EngineViewModel Which is unimplemented
        //[Test]
        //public void PickCharactersPage_OnApperaing_Default_Should_Pass()
        //{
        //    // Arrange
        //    BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList = new List<PlayerInfoModel>();
        //    BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(new CharacterModel()));

        //    BattleEngineViewModel.Instance.Engine.EngineSettings.MonsterList = new List<PlayerInfoModel>();
        //    BattleEngineViewModel.Instance.Engine.EngineSettings.MonsterList.Add(new PlayerInfoModel(new MonsterModel()));

        //    BattleEngineViewModel.Instance.PartyCharacterList = new ObservableCollection<CharacterModel>();
        //    BattleEngineViewModel.Instance.PartyCharacterList.Add(new CharacterModel());

        //    var temp = page.EngineViewModel.Engine;

        //    page.UpdateNextButtonState();

        //    // Act
        //    OnAppearing();

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(false); // Got to here, so it happened...
        //}

        [Test]
        public void PickCharactersPage_UpdateButtonState_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.UpdateNextButtonState();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void PickCharactersPage_OnPartyCharacterItemSelected_Default_Should_Pass()
        {
            // Arrange
            CollectionView cv = new CollectionView
            {
                SelectionMode = SelectionMode.Single
            };


            CharacterModel cm = Game.GameRules.DefaultData.LoadData(new CharacterModel()).FirstOrDefault();

            // Act
            cv.SelectionChanged += (OnPartyCharacterItemSelected);
            cv.SelectedItem = cm;

            // Reset

            //Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void PickCharactersPage_OnPartyCharacterItemSelected_InValid_Should_Pass()
        {
            // Arrange
            CollectionView cv = new CollectionView
            {
                SelectionMode = SelectionMode.Single
            };

            List<CharacterModel> selectedCharacter = Game.GameRules.DefaultData.LoadData(new CharacterModel());

            // Act
            cv.SelectionChanged += (OnDatabaseCharacterItemSelected);
            cv.SelectedItem = selectedCharacter;

            // Reset

            //Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void PickCharactersPage_OnDatabaseCharacterItemSelected_Default_Should_Pass()
        {
            // Arrange
            CollectionView cv = new CollectionView
            {
                SelectionMode = SelectionMode.Single
            };

            List<CharacterModel> selectedCharacter = Game.GameRules.DefaultData.LoadData(new CharacterModel());

            // Act
            cv.SelectionChanged += (OnDatabaseCharacterItemSelected);
            cv.SelectedItem = selectedCharacter;

            // Reset

            //Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void PickCharactersPage_OnDatabaseCharacterItemSelected_InValid_Should_Pass()
        {
            // Arrange
            CollectionView cv = new CollectionView
            {
                SelectionMode = SelectionMode.Single
            };

            CharacterModel cm = Game.GameRules.DefaultData.LoadData(new CharacterModel()).FirstOrDefault();

            // Act
            cv.SelectionChanged += (OnDatabaseCharacterItemSelected);
            cv.SelectedItem = cm;

            // Reset

            //Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }
    }
}