using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float spawnInterval = 2;
    int countEnemy = 0;
   [SerializeField] int limit = 5;

    [SerializeField] EnemyMovement EnemyEasy;
    [SerializeField] EnemyMovement EnemyMedium;

     

    int wave = 0;

    void Update()
    {
        

    }

   

    public int GetWave()
    {
        return wave;
    }

    public int GetLimit()
    {
        return limit;
    }

   public IEnumerator SpawnEnemyEasy()
    {
        UIManeger uiMeneger =FindObjectOfType<UIManeger>();
        uiMeneger.isActiveCourotine = false;
        wave++;
        limit = limit + 5;
        while (countEnemy < limit)
        {

            var enemy = Instantiate(EnemyEasy, transform.position, Quaternion.identity);
            enemy.transform.parent = transform;
            yield return new WaitForSeconds(spawnInterval);
            countEnemy++;
            

        }
        if (wave == 5) { SceneManager.LoadScene(0); }
        countEnemy = 0;
        uiMeneger.isActiveCourotine = true;
        yield break;

    }


}
