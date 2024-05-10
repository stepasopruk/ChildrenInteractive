using System.Collections.Generic;
using UnityEngine;

public class ItemFieldController : SubstitutionLettersFieldController
{
    [SerializeField] private Item itemPrefab;

    private List<Transform> _itemsPos = new();

    public override void Create(LetterData data)
    {
        Item item = Instantiate(itemPrefab, content);
        item.ItemImage.sprite = data.ItemSprite;
    }

    public Item CreateItem(LetterData data)
    {
        Item item = Instantiate(itemPrefab, content);
        item.ItemImage.sprite = data.ItemSprite;
        _itemsPos.Add(item.transform);
        return item;
    }

    public void Intermix()
    {
        for (int i = 0; i < _itemsPos.Count; i++)
        {
            int randomIndex = UnityEngine.Random.Range(0, _itemsPos.Count);
            _itemsPos[i].SetSiblingIndex(randomIndex);
        }
    }
}