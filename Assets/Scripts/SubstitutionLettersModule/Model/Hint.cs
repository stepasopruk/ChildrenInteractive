using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hint : MonoBehaviour
{
    [SerializeField] private Image imageFrame;
    [SerializeField] private Text textHint;

    private Dictionary<HintType, Color> _hintColors = new() 
    {
        { HintType.Default, Color.white },
        { HintType.Correctly, Color.green },
        {HintType.Warning, Color.yellow },
        {HintType.Error, Color.red },
    };

    public void ShowHint(string text, HintType hintType)
    {
        Color colorFrame = _hintColors[hintType];
        Show(text, colorFrame);
    }

    public void ShowHint(string text, Color colorFrame)
    {
        Show(text, colorFrame);
    }

    public void HideHint()
    {
        gameObject.SetActive(false);
    }

    private void Show(string text, Color colorFrame)
    {
        textHint.text = text;
        imageFrame.color = colorFrame;
        gameObject.SetActive(true);
    }
}

public enum HintType
{
    Default = 0,
    Correctly = 1,
    Warning = 2,
    Error = 3
}