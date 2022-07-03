using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float spawnInterval = 2;
    int countEnemy = 0;
    [SerializeField] int limit = 5;

    [SerializeField] int waveLast;
    [SerializeField] int waveNow = 0;

    [SerializeField] EnemyMovement EnemyEasy;
    [SerializeField] EnemyMovement EnemyMedium;
   
     

    

    void Update()
    {
        

    }

   

    public int GetWave()
    {
        return waveNow;
    }

    public int GetLimit()
    {
        
        return limit;
    }
public int  GetNumOfEnemy()
    {
        return countEnemy;
    }
   public IEnumerator SpawnEnemyEasy()
    {
        if (waveNow == waveLast) { SceneManager.LoadScene(3); } else { 
        countEnemy = 0;
        UIManeger uiMeneger =FindObjectOfType<UIManeger>();
        uiMeneger.isActiveCourotine = false;
        waveNow++;
        limit = limit + 5;
        while (countEnemy < limit)
        {

            countEnemy++;
            var enemy = Instantiate(EnemyEasy, transform.position, Quaternion.identity);
            enemy.transform.parent = transform;
            yield return new WaitForSeconds(spawnInterval);
            
            

        }
        
        uiMeneger.isActiveCourotine = true;
        }


        yield break;

    }


}
