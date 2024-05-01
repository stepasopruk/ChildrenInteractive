using UnityEngine;
using UnityEngine.UI;

public class Letter : MonoBehaviour
{
    [SerializeField] private Image letterImage;

    public Sprite LetterSprite { get => letterImage.sprite; set => letterImage.sprite = value; }
}
