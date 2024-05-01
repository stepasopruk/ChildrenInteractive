using UnityEngine;

public class ItemFieldController : SubstitutionLettersFieldController
{
    [SerializeField] private Item itemPrefab;

    public override void Create(LetterData data)
    {
        Item item = Instantiate(itemPrefab, content);
        item.ItemSprite = data.ItemSprite;
    }

    public Item CreateItem(LetterData data)
    {
        Item item = Instantiate(itemPrefab, content);
        item.ItemSprite = data.ItemSprite;
        return item;
    }
}