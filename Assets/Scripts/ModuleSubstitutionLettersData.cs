using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SubstitutionLettersData", menuName = "ScriptableObjects/SubstitutionLettersData", order = 1)]
public class ModuleSubstitutionLettersData : ScriptableObject
{
    [SerializeField]
    private List<LetterData> letters;

    public List<LetterData> Letters => letters;
}