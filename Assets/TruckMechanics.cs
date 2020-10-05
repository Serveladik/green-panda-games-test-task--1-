using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using GreenPandaAssets.Scripts;

public class TruckMechanics : MonoBehaviour
{
    [SerializeField] float truckSpeed;
    [SerializeField] int currentLap=1;
    [SerializeField] TopUI moneyManager;
    [SerializeField] AUpgradable upgradeManager;
    private Vector3 tempCord;
    public NavMeshAgent ai;
    //public MeshRenderer truckRock;
    public GameObject bulldozerSpot;
    public GameObject factorySpot;
    public GameObject midSpot;


    void Awake()
    {
        ai = GetComponent<NavMeshAgent>();
        ai.speed = truckSpeed;
        tempCord = factorySpot.transform.position;
        ai.SetDestination(bulldozerSpot.transform.position);
    }

    IEnumerator PathChecker()
    {

        if(transform.position.x == factorySpot.transform.position.x)
        {
            bulldozerSpot.SetActive(true);
            tempCord = bulldozerSpot.transform.position;
            yield return new WaitForSecondsRealtime(2f);

            factorySpot.SetActive(false);
            ai.SetDestination(tempCord);
        }
        else if(transform.position.x - bulldozerSpot.transform.position.x >= 0)
        {   
            
            factorySpot.SetActive(true);
            tempCord = midSpot.transform.position;
            yield return new WaitForSecondsRealtime(2f);

            bulldozerSpot.SetActive(false);
            ai.SetDestination(tempCord);
        }
        else if(transform.position.x == midSpot.transform.position.x)
        {
            bulldozerSpot.SetActive(true);
            tempCord = factorySpot.transform.position;
            midSpot.SetActive(false);
            ai.SetDestination(tempCord);
        }
    }
    void CheckLap()
    {
        if(currentLap>=5)
        {
            Debug.Log(moneyManager.Coins);
            //Debug.Log(AUpgradable._level);
            moneyManager.Coins+=upgradeManager.Level;
            currentLap=1;
            return;
        }
    }
    void OnTriggerEnter(Collider player)
    {
        if(player.transform.tag == "Start")
        {
            currentLap+=1;
        }
    }
    void Update()
    {
        Debug.Log(transform.position.x - bulldozerSpot.transform.position.x);
        CheckLap();
        StartCoroutine("PathChecker");
    }
}
