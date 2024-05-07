using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SubstitutionController : MonoBehaviour
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
    private List<ItemLetterGroup> _itemLetterGroups = new();

    private Letter _currentLetter;
    private Item _currentItem;

    public void SubscriptionSubstitution(Letter letter, Item item)
    {
        _itemLetterGroups.Add(new ItemLetterGroup(letter, item));
        letter.CollisionEnter += Letter_CollisionEnter;
        letter.CollisionExit += Letter_CollisionExit;
        item.PointerUp += Item_PointerUp;
        item.PointerDown += Item_PointerDown;
    }

    public void UnsubscriptionSubstitution(Letter letter, Item item)
    {
        ItemLetterGroup itemLetterGroup = _itemLetterGroups.FirstOrDefault(x => x.Letter == letter);
        if(itemLetterGroup != null)
            _itemLetterGroups.Remove(itemLetterGroup);

        letter.CollisionEnter -= Letter_CollisionEnter;
        letter.CollisionExit -= Letter_CollisionExit;
        item.PointerUp -= Item_PointerUp;
        item.PointerDown -= Item_PointerDown;
    }

    private void Letter_CollisionEnter(Letter letter, Collision2D collision)
    {
        Item item = _itemLetterGroups.FirstOrDefault(x => x.Letter == letter).Item;
        if (item == null)
            return;

        if (collision.gameObject != item.gameObject)
            return;

        _currentLetter = letter;
        Substitution();
    }

    private void Letter_CollisionExit()
    {
        _currentLetter = null;
    }

    private void Item_PointerUp(Item item)
    {
        _currentItem = item;
        Substitution();
    }

    private void Item_PointerDown(Item item)
    {
        _currentItem = null;
    }

    private void Substitution()
    {
        if (_currentLetter == null || _currentItem == null)
            return;

        _currentLetter.ActiveLetterImage = true;
        Destroy(_currentItem.gameObject);
        Debug.Log("Substitution");
        _currentItem = null;
        _currentLetter = null;
    }
}

