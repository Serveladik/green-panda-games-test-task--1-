using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using GreenPandaAssets.Scripts;

public class TruckMechanics : MonoBehaviour
{
    [SerializeField] public float truckSpeed;
    [SerializeField] int currentLap=1;
    [SerializeField] TopUI moneyManager;
    [SerializeField] AUpgradable upgradeManager;
    [SerializeField] AUpgradable bulldozerManager;
    private Vector3 tempCord;
    private int temp=1;
    public float loadingTime = 4f;
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
        //Wait some time at factory
        if(transform.position.x == factorySpot.transform.position.x)
        {
            bulldozerSpot.SetActive(true);
            tempCord = bulldozerSpot.transform.position;
            yield return new WaitForSecondsRealtime(2f);

            factorySpot.SetActive(false);
            ai.SetDestination(tempCord);
        }
        //Wait some time at Bulldozer 
        else if(transform.position.x - bulldozerSpot.transform.position.x >= 0)
        {   
            factorySpot.SetActive(true);
            tempCord = midSpot.transform.position;
            yield return new WaitForSecondsRealtime(loadingTime);

            bulldozerSpot.SetActive(false);
            ai.SetDestination(tempCord);
        }
        //Wait some time in mid
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
    void CheckForLvlUp()
    {
        if(temp<bulldozerManager.Level)
        {
            temp++;
            loadingTime-=0.15f;
        }
    }
   
    void Update()
    {
        CheckForLvlUp();
        CheckLap();
        StartCoroutine("PathChecker");
    }
}
