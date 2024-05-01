using System;
using System.Collections;
using UnityEngine;

public class MoveItemController : MonoBehaviour
{
    [SerializeField] private RectTransform canvasTransform;

    private Transform _parentTransform;

    private Coroutine _movingRoutine;
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
        _parentTransform = item.transform.parent;
        item.transform.SetParent(canvasTransform);
    }

    private void Item_OnPointerUp(Item item)
    {
        item.transform.SetParent(_parentTransform);
        _parentTransform = null;

        if (_movingRoutine != null)
        {
            StopCoroutine(_movingRoutine);
            _movingRoutine = null;
        }
    }

    private void Item_PointerDrag(Item item)
    {
        if (_movingRoutine == null)
            _movingRoutine = StartCoroutine(Moving(item));
    }

    private IEnumerator Moving(Item item)
    {
        Vector3 startMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 offset = item.transform.position - new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
        while (true)
        {
            yield return _waitForEndOfFrame;
            Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
            item.transform.position = newPosition + offset;
        }
    }
}

