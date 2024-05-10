using UnityEngine;

public class SubstitutionController : MonoBehaviour
{
    private Letter _currentLetter;
    private Item _currentItem;

    public void SubscriptionSubstitution(Letter letter)
    {
        letter.CorrectlyCollision += Letter_CorrectlyCollision;
    }

    public void UnsubscriptionSubstitution(Letter letter)
    {
        letter.CorrectlyCollision -= Letter_CorrectlyCollision;
    }

    private void Letter_CorrectlyCollision(Letter letter, Item item)
    {
        _currentLetter = letter;
        _currentItem = item;
        letter.CollisionExit += Letter_CollisionExit;
        item.PointerUp += Item_PointerUp;
    }

    private void Letter_CollisionExit()
    {
        _currentLetter.CollisionExit -= Letter_CollisionExit;
        _currentLetter = null;
    }

    private void Item_PointerUp(Item item)
    {
        item.PointerUp -= Item_PointerUp;
        Substitution();
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

