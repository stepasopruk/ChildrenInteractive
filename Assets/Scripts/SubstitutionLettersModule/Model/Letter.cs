using System;
using UnityEngine;
using UnityEngine.UI;

namespace SubstitutionLettersModule
{
    public class Letter : MonoBehaviour
    {
        public event Action Approved;
        public event Action<Letter, Item> CorrectlyCollision;
        public event Action<Letter, Item> InCorrectlyCollision;
        public event Action CollisionExit;

        [SerializeField] private Image letterImage;

        public Sprite LetterSprite { get => letterImage.sprite; set => letterImage.sprite = value; }
        public bool ActiveLetterImage { get; private set; }
        public void ApprovedLetter()
        {
            ActiveLetterImage = true;
            letterImage.gameObject.SetActive(true);
            Approved?.Invoke();
        }

        private Item _item;
        public Item Item { get => _item; set => _item = value; }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            collision.gameObject.TryGetComponent(out Item collisionItem);

            if (collisionItem == null)
                return;

            if (collisionItem == _item)
                CorrectlyCollision?.Invoke(this, _item);
            else
                InCorrectlyCollision?.Invoke(this, collisionItem);
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            collision.gameObject.TryGetComponent(out Item collisionItem);

            if (collisionItem == null)
                return;

            CollisionExit?.Invoke();
        }
    }
}