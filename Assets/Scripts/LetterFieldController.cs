using System.Collections.Generic;
using UnityEngine;

public class LetterFieldController : SubstitutionLettersFieldController
{
    [SerializeField] private Letter letterPrefab;

    public override void Create(LetterData data)
    {
        Letter letter = Instantiate(letterPrefab, content);
        letter.LetterSprite = data.LetterSprite;
    }

    public Letter CreateLetter(LetterData data, Item item)
    {
        Letter letter = Instantiate(letterPrefab, content);
        letter.LetterSprite = data.LetterSprite;
        letter.Item = item;
        return letter;
    }
}
