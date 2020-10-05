using UnityEngine;

namespace GreenPandaAssets.Scripts
{
    public abstract class AUpgradableBulldozer : MonoBehaviour
    {
        protected int _level = 1;

        public int Level => _level;

        [SerializeField] protected int _maxLevel = 15;
        [SerializeField] protected float _startPrice = 150;
        [SerializeField] protected float _priceStepFactor = 2f;
        
        private void Update()
        {
        
        }
        
        public virtual void Upgrade()
        {
            _level++;
        }

        public bool IsMax()
        {
            return _level >= _maxLevel;
        }

        public float GetPrice()
        {
            return _startPrice * Mathf.Pow(_priceStepFactor, _level - 1);
        }
    }
}