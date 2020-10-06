using System;
using TMPro;
using UnityEngine;

namespace GreenPandaAssets.Scripts
{
    public class TopUI : MonoBehaviour
    {
        private float _coins = 10000;
        public static TopUI Instance;
        

        private void Update()
        {
        
        }
        
        public float Coins
        {
            get { return _coins; }
            set
            {
                _coins = value;
                CoinsText.text = "x" + _coins;
            }
        }

        public TextMeshProUGUI CoinsText;

        private void Awake()
        {
            Instance = this;
            
            CoinsText.text = "x" + _coins;
        }
    }
}