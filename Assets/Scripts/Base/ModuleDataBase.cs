using UnityEngine;

public class ModuleDataBase : ScriptableObject
{
    [SerializeField] private Sprite backGroundSprite;
    [SerializeField] private string taskText;
    public Sprite BackGroundSprite => backGroundSprite;
    public string TaskText => taskText;
}