using Extension;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace PathSyllablesModule
{
    public class StoneColumn : MonoBehaviour
    {
        [SerializeField] private Stone[] stones;
        public Stone[] Stones => stones;

        private List<Stone> _activeStones = new();

        public void Initialize(Sprite[] stoneSprites, int maxCountRow, int chance)
        {
            ActiveStones(maxCountRow, chance);
            SetRandomSpriteStones(stoneSprites);
            SetRandomPositionStones();
        }

        private void SetRandomPositionStones()
        {
            RectTransform rectTransform = GetComponent<RectTransform>();
            float width = rectTransform.rect.width;

            foreach (var stone in _activeStones)
            {
                float randPos = UnityEngine.Random.Range(-(width / 4), width / 4);
                stone.transform.localPosition = new Vector2(randPos, stone.transform.localPosition.y);
            }
        }

        private void SetRandomSpriteStones(Sprite[] stoneSprites)
        {
            foreach (var stone in _activeStones)
            {
                int randomIndex = UnityEngine.Random.Range(0, stoneSprites.Length);
                Sprite randomSprite = stoneSprites[randomIndex];
                stone.StoneSprite = randomSprite;
            }
        }

        private void ActiveStones(int maxCountRow, int chance)
        {
            int activeStonesCount = 1;
            for (int i = 0; i < maxCountRow - 1; i++)
            {
                int chanceSpawn = UnityEngine.Random.Range(0, 100);
                if (chanceSpawn <= chance)
                    activeStonesCount++;
            }

            foreach (var stone in stones)
                stone.Active = false;

            Shuffle.ShuffleArray(stones);

            for (int i = 0; i < activeStonesCount; i++)
            {
                stones[i].Active = true;
                _activeStones.Add(stones[i]);
            }
        }
    }
}
