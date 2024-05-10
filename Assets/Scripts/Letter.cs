﻿using System;
using UnityEngine;
using UnityEngine.UI;

public class Letter : MonoBehaviour
{
    public event Action<Letter, Item> CorrectlyCollision;
    public event Action<Letter, Item> InCorrectlyCollision;
    public event Action CollisionExit;

    [SerializeField] private Image letterImage;

    public Sprite LetterSprite { get => letterImage.sprite; set => letterImage.sprite = value; }
    public bool ActiveLetterImage { set { letterImage.gameObject.SetActive(value); } }

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
            InCorrectlyCollision?.Invoke(this, _item);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        CollisionExit?.Invoke();
    }
}
