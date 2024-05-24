using System;
using System.Collections.Generic;
using UnityEngine;

namespace SubstitutionLettersModule
{
    public class ModuleSubstitutionLettersBootstrap : BaseModuleBootstrap
    {
        [SerializeField] private ModuleSubstitutionLettersData moduleData;

        [SerializeField] private SubstitutionController substitutionController;
        [SerializeField] private MoveItemController moveItemController;
        [SerializeField] private ItemFieldController itemFieldController;
        [SerializeField] private LetterFieldController letterFieldController;
        [SerializeField] private LetterHintController letterHintController;


        public override void InitializationModule()
        {
            InitializeLetters();
        }

        private void InitializeLetters()
        {
            foreach (LetterData data in moduleData.Letters)
            {
                Item item = itemFieldController.CreateItem(data);
                Letter letter = letterFieldController.CreateLetter(data, item);
                InitializeController(letter, item);
            }
        }

        private void InitializeController(Letter letter, Item item)
        {
            itemFieldController.Intermix();
            moveItemController.SubscriptionMove(item);
            substitutionController.SubscriptionSubstitution(letter);
            letterHintController.AddLetter(letter);
        }

        public override ModuleDataBase GetModuleData() => moduleData;
    }
}