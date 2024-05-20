using System.Collections.Generic;
using UnityEngine;

namespace SubstitutionLettersModule
{
    public class LetterFieldController : MonoBehaviour
    {
        [SerializeField] protected Transform content;
        [SerializeField] private Letter letterPrefab;

        public Letter CreateLetter(LetterData data, Item item)
        {
            Letter letter = Instantiate(letterPrefab, content);
            letter.LetterSprite = data.LetterSprite;
            letter.Item = item;
            return letter;
        }
    }
}