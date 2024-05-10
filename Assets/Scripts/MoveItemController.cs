using JetBrains.Annotations;
using System;
using System.Collections;
using UnityEngine;

public class MoveItemController : MonoBehaviour
{
    [SerializeField] private RectTransform canvasTransform;
    [SerializeField] private float speedReturnPosition = 2f;

    private Transform _parentTransform;
    private int _parentChildIndex;
    private Item _tempItem;

    private Coroutine _movingRoutine;
    private Coroutine _movingReturnRoutine;
    private WaitForEndOfFrame _waitForEndOfFrame = new();

    public void SubscriptionMove(Item item)
    {
        item.PointerDown += Item_OnPointerDown;
        item.PointerUp += Item_OnPointerUp;
        item.PointerDrag += Item_PointerDrag;
    }

    public void UnSubscriptionMove(Item item)
    {
        item.PointerDown -= Item_OnPointerDown;
        item.PointerUp -= Item_OnPointerUp;
        item.PointerDrag -= Item_PointerDrag;
    }

    private void Item_OnPointerDown(Item item)
    {
        _parentChildIndex = item.transform.GetSiblingIndex();
        _parentTransform = item.transform.parent;
        item.transform.SetParent(canvasTransform);
        CreateTempObject(item);
    }

    private void Item_OnPointerUp(Item item)
    {
        if (_movingRoutine != null)
        {
            StopCoroutine(_movingRoutine);
            _movingRoutine = null;
        }

        StartCoroutine(MovingReturnPosition(item));
        _parentTransform = null;
    }

    private void Item_PointerDrag(Item item)
    {
        if (_movingRoutine == null)
            _movingRoutine = StartCoroutine(Moving(item));
    }

    private IEnumerator Moving(Item item)
    {
        Vector3 offset = item.transform.position - new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);
        while (true)
        {
            yield return _waitForEndOfFrame;
            Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);
            item.transform.position = newPosition + offset;
        }
    }

    private IEnumerator MovingReturnPosition(Item item)
    {
        UnSubscriptionMove(item);
        Item tempItem = _tempItem;
        Transform tempParentTransform = _parentTransform;
        int tempParentChildIndex = _parentChildIndex;

        while (Vector2.Distance(item.transform.position, tempItem.transform.position) > 0.1f)
        {
            yield return _waitForEndOfFrame;

            if (item == null)
                break;

            item.transform.position = 
                Vector2.MoveTowards(item.transform.position, tempItem.transform.position, speedReturnPosition);
        }

        DeleteTempObject(tempItem);

        if (item != null)
        {
            item.transform.SetParent(tempParentTransform);
            item.transform.SetSiblingIndex(tempParentChildIndex);
            SubscriptionMove(item);
        }
    }

    private void CreateTempObject(Item item)
    {
        _tempItem = Instantiate(item, _parentTransform);
        _tempItem.transform.SetSiblingIndex(_parentChildIndex);
        float r = _tempItem.ItemImage.color.r;
        float g = _tempItem.ItemImage.color.g;
        float b = _tempItem.ItemImage.color.b;
        float a = _tempItem.ItemImage.color.a;
        _tempItem.ItemImage.color = new Color(r, g, b, a / 4);
    }

    private void DeleteTempObject(Item item)
    {
        if (item != null)
            Destroy(item.gameObject);
    }
}

