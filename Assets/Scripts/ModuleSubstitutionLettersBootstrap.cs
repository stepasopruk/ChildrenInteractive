using System.Collections.Generic;
using UnityEngine;

public class ModuleSubstitutionLettersBootstrap : MonoBehaviour
{
    [SerializeField] private SubstitutionController substitutionController;
    [SerializeField] private MoveItemController moveItemController;
    [SerializeField] private ItemFieldController itemFieldController;
    [SerializeField] private LetterFieldController letterFieldController;

    [SerializeField] private ModuleSubstitutionLettersData substitutionLettersData;

    private void Awake()
    {
        foreach (LetterData data in substitutionLettersData.Letters)
        {
            Item item = itemFieldController.CreateItem(data);
            itemFieldController.Intermix();
            Letter letter = letterFieldController.CreateLetter(data, item);
            moveItemController.SubscriptionMove(item);
            substitutionController.SubscriptionSubstitution(letter);
        }
    }

}