using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManeger : MonoBehaviour
{
   [SerializeField] Text life, money, wave;

   public bool isActiveCourotine = true;

    void Start()
    {
        
        
        

    }

    public void OnButtonClick()
    {
        
        EnemySpawner spawner = FindObjectOfType<EnemySpawner>();
        if (isActiveCourotine)
        {
            
            StartCoroutine(spawner.SpawnEnemyEasy());
        }
    }

    void SetTextArea()
    {
        Castle getLife = FindObjectOfType<Castle>();
        Money getMoney = FindObjectOfType<Money>();
        EnemySpawner getWave = FindObjectOfType<EnemySpawner>();

        life.text = ("Life:" + getLife.GetHitPoint());
        wave.text = "Wave:" + getWave.GetWave( ) + " (" +getWave.GetLimit()+" / "+ (getWave.GetNumOfEnemy() ) + ")";
        money.text = ("Money: " + getMoney.GetMoney());
    }
    void Update()
    {
        SetTextArea();
    }
}
