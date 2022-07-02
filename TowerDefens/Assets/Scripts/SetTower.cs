using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTower : MonoBehaviour
{

    Waypoint waypoint;

    [SerializeField] Tower towerPrefab;

    [SerializeField] int limit=4;

    Queue<Tower> queueTower = new Queue<Tower>();

    [SerializeField] int towerCost = 15;

    Money money;

    public void InstantiateTower(Waypoint baseWaipoint)
    {
        money = FindObjectOfType<Money>();
        if (queueTower.Count < limit && money.GetMoney()>=15)
        {
            AddTower(baseWaipoint);
            money.GetMoneyPlayer(-towerCost);
            
        }
        else
           MoveTowerToNewPos(baseWaipoint);

    }

   void AddTower(Waypoint baseWaypoint) {

        var newTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        newTower.transform.parent = transform;
        baseWaypoint.isPlaceble = false;
        newTower.transform.parent = transform;

        newTower.baseWaypoint = baseWaypoint;

        queueTower.Enqueue(newTower);

        
    }

   
    private  void MoveTowerToNewPos(Waypoint baseWaypoint)
    {
        Tower oldTower = queueTower.Dequeue();
        oldTower.transform.position = baseWaypoint.transform.position;
        oldTower.baseWaypoint.isPlaceble = true;
        baseWaypoint.isPlaceble=false;
        oldTower.baseWaypoint = baseWaypoint;
        ChangePosTower();

        queueTower.Enqueue(oldTower);
    }

    private void ChangePosTower()
    {
        print("переместить башню");
    }
}
