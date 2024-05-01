using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item : MonoBehaviour/*, IPointerDownHandler, IPointerUpHandler*/
{
    public event Action<Item, Collision2D> Collision;
    public event Action<Item> PointerDown;
    public event Action<Item> PointerUp;

    [SerializeField] private Image itemImage;

    private EventTrigger _eventTrigger;
    private BoxCollider2D _boxCollider;

    private EventTrigger.Entry _entryPointerDown = new();
    private EventTrigger.Entry _entryPointerUp = new();

    public Sprite ItemSprite { get => itemImage.sprite; set => itemImage.sprite = value; }

    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        _eventTrigger = GetComponent<EventTrigger>();

        InitializeEntry(_entryPointerDown, EventTriggerType.PointerDown);
        InitializeEntry(_entryPointerUp, EventTriggerType.PointerUp);

        _entryPointerDown.callback.AddListener(OnPointerDown);
        _entryPointerUp.callback.AddListener(OnPointerUp);
    }

    private void OnDestroy()
    {
        _entryPointerDown.callback.RemoveListener(OnPointerDown);
        _entryPointerUp.callback.RemoveListener(OnPointerUp);
    }

    private void InitializeEntry(EventTrigger.Entry entry, EventTriggerType eventTriggerType)
    {
        entry.eventID = eventTriggerType;
        entry.callback = new EventTrigger.TriggerEvent();
        _eventTrigger.triggers.Add(entry);
    }

    private void OnPointerDown(BaseEventData arg0) =>
    PointerDown?.Invoke(this);

    private void OnPointerUp(BaseEventData arg0) => 
        PointerUp?.Invoke(this);

    //void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    //{
    //    PointerDown?.Invoke(this);
    //}

    //void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    //{
    //    PointerUp?.Invoke(this);
    //}
}