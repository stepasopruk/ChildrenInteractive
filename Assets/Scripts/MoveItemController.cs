using UnityEngine;

public class MoveItemController : MonoBehaviour
{
    [SerializeField] private Transform canvasTransform;

    private Transform _parentTransform;

    public void SubscriptionMove(Item item)
    {
        item.PointerDown += Item_OnPointerDown;
        item.PointerUp += Item_OnPointerUp;
    }
    
    public void UnSubscriptionMove(Item item)
    {
        item.PointerDown -= Item_OnPointerDown;
        item.PointerUp -= Item_OnPointerUp;
    }

    private void Item_OnPointerDown(Item item)
    {
        _parentTransform = item.transform.parent;
        item.transform.parent = canvasTransform;
    }

    private void Item_OnPointerUp(Item item)
    {
        item.transform.parent = _parentTransform;
        _parentTransform = null;
    }
}

