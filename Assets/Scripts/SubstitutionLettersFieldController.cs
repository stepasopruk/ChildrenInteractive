using UnityEngine;

public abstract class SubstitutionLettersFieldController : MonoBehaviour
{
    [SerializeField] protected Transform content;

    public abstract void Create(LetterData data);
}
