using UnityEngine;

namespace GreenPandaAssets.Scripts
{
    public abstract class AUpgradable : MonoBehaviour
    {
        [SerializeField] protected int _maxLevel = 15;
        [SerializeField] protected float _startPrice = 100;
        [SerializeField] protected float _priceStepFactor = 2f;
        public static AUpgradable upgrade;
        public int _level = 1;

        public int Level => _level;

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