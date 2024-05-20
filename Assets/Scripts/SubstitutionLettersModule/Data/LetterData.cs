using UnityEngine;

namespace SubstitutionLettersModule
{
    [CreateAssetMenu(fileName = "LetterData", menuName = "ScriptableObjects/LetterData", order = 1)]
    public class LetterData : ScriptableObject
    {
        [SerializeField] private Sprite letterSprite;
        [SerializeField] private Sprite itemSprite;
        [SerializeField] private char firstLetter;

        public Sprite LetterSprite => letterSprite;
        public Sprite ItemSprite => itemSprite;
        public string LetterValue => firstLetter.ToString().ToLower();
    }
}