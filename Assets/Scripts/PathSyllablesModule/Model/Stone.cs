using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PathSyllablesModule
{
    public class Stone : MonoBehaviour
    {
        [SerializeField] private Image stoneImage;

        public Sprite StoneSprite { get; set; }

        private bool _active;
        public bool Active 
        { 
            get => _active;
            set
            {
                _active = value;
                gameObject.SetActive(value);
            }
        }
    }
}