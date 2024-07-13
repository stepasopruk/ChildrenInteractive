using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PathSyllablesModule 
{
    public class StoneMatrixController : MonoBehaviour
    {
        [SerializeField] private Transform contentMatrix;
        [SerializeField] private Sprite[] stoneSprites;
        [SerializeField] private StoneColumn stoneColumnPrefab;
        [SerializeField] private int countColumn;
        [SerializeField] private int maxCountStone;
        [SerializeField] private int chanceSpawnStone;

        private List<StoneColumn> _stoneColumns = new();

        public void Initialize()
        {
            for (int i = 0; i < countColumn; i++)
            {
                StoneColumn stoneColumn = Instantiate(stoneColumnPrefab, contentMatrix);
                stoneColumn.Initialize(stoneSprites, maxCountStone, chanceSpawnStone);
                _stoneColumns.Add(stoneColumn);
            }
        }
    }
}