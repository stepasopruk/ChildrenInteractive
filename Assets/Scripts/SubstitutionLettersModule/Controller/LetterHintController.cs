using System.Collections.Generic;
using UnityEngine;

namespace SubstitutionLettersModule
{
    public class LetterHintController : MonoBehaviour
    {
        [SerializeField] private Hint hint;

        private List<Letter> _letters = new();
        private int _countCorrectly;
        private int _countInCorrectly;
        private bool _isIncorrectItem;

        public void AddLetter(Letter letter)
        {
            _letters.Add(letter);
            SubscriptionSubstitution(letter);
        }

        private void SubscriptionSubstitution(Letter letter)
        {
            letter.Approved += Letter_Approved;
            letter.InCorrectlyCollision += Letter_InCorrectlyCollision;
        }

        public void UnsubscriptionSubstitution(Letter letter)
        {
            letter.Approved -= Letter_Approved;
            letter.InCorrectlyCollision -= Letter_InCorrectlyCollision;
        }


        private void Letter_InCorrectlyCollision(Letter letter, Item item)
        {
            if (!_isIncorrectItem)
            {
                item.PointerUp += Item_PointerUp;
                _isIncorrectItem = true;
            }
        }

        private void Item_PointerUp(Item item)
        {
            item.PointerUp -= Item_PointerUp;
            _isIncorrectItem = false;
            _countInCorrectly++;

            if (_countInCorrectly == 2)
            {
                hint.ShowHint("Предметы должны быть расставлены в правильном алфавитном порядке по первой букве предмета",
                    HintType.Error);
            }
        }

        private void Letter_Approved(Letter letter)
        {
            _countCorrectly++;
            _countInCorrectly = 0;
            hint.HideHint();
            UnsubscriptionSubstitution(letter);

            if (_countCorrectly == _letters.Count)
            {
                hint.ShowHint("Ты все сделал правильно!", HintType.Correctly);
            }
        }
    }
}