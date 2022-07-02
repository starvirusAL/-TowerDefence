using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement : MonoBehaviour
{
    [SerializeField] ParticleSystem PSCastle;


    DamageEnemy destroyEnemy;

    PathFinder pathFinder;

    [SerializeField] float speedMove = 2f;

    [SerializeField] float moveStep = 1f;

    Vector3 targetPosition ;

    Castle castle;
    void Start()
    {
        castle = FindObjectOfType<Castle>();

        destroyEnemy = FindObjectOfType<DamageEnemy>();
        pathFinder = FindObjectOfType<PathFinder>();
        var path = pathFinder.GetPath();
        StartCoroutine(EnemyMove(path));
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * moveStep);
    }
    IEnumerator EnemyMove(List<Waypoint> path)
    {
        
        foreach (Waypoint waypoint in path)
        {
            transform.LookAt(waypoint.transform);
            targetPosition = waypoint.transform.position;
            yield return new WaitForSeconds(speedMove);

           
            
            

        }
         castle.DamageForCastle();

        destroyEnemy.DethEnemy(false);


    }
}

