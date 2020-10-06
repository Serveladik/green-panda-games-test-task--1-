using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using GreenPandaAssets.Scripts;

public class MoneyPerMinute : MonoBehaviour
{
    [SerializeField] private float money;
    [SerializeField] AUpgradable factoryManager;
    public TextMeshProUGUI moneyPerMinute;
    // Start is called before the first frame update
    void Awake()
    {
        money = factoryManager.Level;
        moneyPerMinute.text = money.ToString() + "/min";
    }

    // Update is called once per frame
    void Update()
    {
        money = factoryManager.Level;
        moneyPerMinute.text = money.ToString() + "/min";
    }
}
