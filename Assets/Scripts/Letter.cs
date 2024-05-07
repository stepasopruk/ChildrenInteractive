using System;
using UnityEngine;
using UnityEngine.UI;

public class Letter : MonoBehaviour
{
    public event Action<Letter, Collision2D> CollisionEnter;
    public event Action CollisionExit;

    [SerializeField] private Image letterImage;

    public Sprite LetterSprite { get => letterImage.sprite; set => letterImage.sprite = value; }
    public bool ActiveLetterImage { set { letterImage.gameObject.SetActive(value); } }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CollisionEnter?.Invoke(this, collision);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        CollisionExit?.Invoke();
    }
}
