using System.Collections.Generic;
using UnityEngine;

public class ModuleSubstitutionLettersBootstrap : MonoBehaviour
{
    private class ItemLetterGroup
    {
        public Letter Letter { get; private set; }
        public Item Item { get; private set; }

        public ItemLetterGroup(Letter letter, Item item)
        {
            Letter = letter;
            Item = item;
        }
    }

    [SerializeField] private SubstitutionController substitutionController;
    [SerializeField] private MoveItemController moveItemController;
    [SerializeField] private ItemFieldController itemFieldController;
    [SerializeField] private LetterFieldController letterFieldController;

    [SerializeField] private ModuleSubstitutionLettersData substitutionLettersData;

    private List<ItemLetterGroup> _itemLetterGroups = new();

    private void Awake()
    {
        foreach (LetterData data in substitutionLettersData.Letters)
        {
            Item item = itemFieldController.CreateItem(data);
            Letter letter = letterFieldController.CreateLetter(data);
            _itemLetterGroups.Add(new ItemLetterGroup(letter, item));
            moveItemController.SubscriptionMove(item);
        }
    }

}