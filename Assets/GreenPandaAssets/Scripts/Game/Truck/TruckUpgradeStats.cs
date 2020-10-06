using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GreenPandaAssets.Scripts;

public class TruckUpgradeStats : MonoBehaviour
{
   [SerializeField] AUpgradable upgradeManager;
   [SerializeField] TruckMechanics truckSpeed;
   private int checkUpgrade=1;
    // Update is called once per frame
    void Update()
    {
        UpdateSpeed();
    }
    void UpdateSpeed()
    {
        if(upgradeManager.Level-1==checkUpgrade)
        {
            truckSpeed.truckSpeed+=2;
            checkUpgrade+=1;
        }
    }
}
