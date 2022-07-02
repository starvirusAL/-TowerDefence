using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Castle : MonoBehaviour
{
    [SerializeField] int hitPointCastle = 10;


    [SerializeField] ParticleSystem ParticleSystemCastle;

    public int GetHitPoint()
    {
        return hitPointCastle;
    }
    public void DamageForCastle()
    {
        hitPointCastle--;
        if (hitPointCastle == 0)
        {
            SceneManager.LoadScene(0);
        }

    }


}
