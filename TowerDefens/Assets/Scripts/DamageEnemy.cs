using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    [SerializeField] int damage = 1;
    [SerializeField] int hp = 2;
    [SerializeField] ParticleSystem hitParticle;
    [SerializeField] ParticleSystem dethParticle;
    [SerializeField] int CostEnemy = 5;
    Money money;

    private void Start()
    {

    }
    private void OnParticleCollision(GameObject other)
    {
        DamageForEnemy();
        if (hp <= 0)
        {

            DethEnemy(true);

        }
    }
    void DamageForEnemy()
    {
        hitParticle.Play();
        hp -= damage;
    }

    public void DethEnemy(bool getMoney)
    {

        var destroyFx = Instantiate(dethParticle, transform.position, Quaternion.identity);
        destroyFx.Play();
        Destroy(destroyFx.gameObject, 2f);
        if (getMoney)
        {
            money = FindObjectOfType<Money>();
            money.GetMoneyPlayer(CostEnemy);
        }
        Destroy(gameObject);

    }
}
