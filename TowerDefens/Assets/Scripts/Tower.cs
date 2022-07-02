using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform towerTop;

    [SerializeField] Transform targetEnemy;

    [SerializeField] float shotableRange;

    [SerializeField] ParticleSystem bullet;

    public Waypoint baseWaypoint;

    void Update()
    {
        SetTargetEnemies();
        if (targetEnemy != null) 
        {
            
            Fire(); 
        } 
        else 
        {
            Shoot(false); 
        }

    }
   

    private void SetTargetEnemies()
    {
        var sceneEnemies = FindObjectsOfType<DamageEnemy>();//получить всех врагов

        if (sceneEnemies.Length == 0) { return; }
        Transform closesEnemy = sceneEnemies[0].transform; // ближайший враг

        foreach (DamageEnemy enemy in sceneEnemies) // Сравнить всех врагов и указать ближайшего
        {
            closesEnemy = GetClosesEnemy(closesEnemy.transform, enemy.transform);
        }
        targetEnemy = closesEnemy; //Ближайший враг

    }

    private Transform GetClosesEnemy(Transform enemyA_pos, Transform enemyB_pos) //Поиск ближайшего врага
    {
        var distToA = Vector3.Distance(enemyA_pos.position, transform.position);
        var distToB = Vector3.Distance(enemyB_pos.position, transform.position);

        if (distToA < distToB)
        {
            return enemyA_pos;
        }
        return enemyB_pos;
    }

    private void Fire()
    {


        float distanceToEnemy = Vector3.Distance(targetEnemy.position, transform.position);

        if (distanceToEnemy <= shotableRange && targetEnemy != null)
        {
            towerTop.LookAt(targetEnemy);
            Shoot(true);


        }
        else
        {
            Shoot(false);

        }
    }

    private void Shoot(bool isActive)
    {
        var emission = bullet.emission;
        emission.enabled = isActive;

    }


}
