using System.Collections.Generic;
using UnityEngine;

namespace SubstitutionLettersModule
{
    [CreateAssetMenu(fileName = "SubstitutionLettersData", menuName = "ScriptableObjects/SubstitutionLettersData", order = 1)]
    public class ModuleSubstitutionLettersData : ModuleDataBase
    {
        [SerializeField] private List<LetterData> letters;

        public List<LetterData> Letters => letters;
    }
}