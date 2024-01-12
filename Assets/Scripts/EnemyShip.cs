using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public int level = 1;
    public EnemyDestructible enemyDestructible;
    public Shooter[] guns;

    void Start()
    {
        guns = transform.GetComponentsInChildren<Shooter>();
    }

    public virtual void CalculateProperties()
    {
        enemyDestructible.maxHP = 10 + level;
        enemyDestructible.HP = enemyDestructible.maxHP;
        enemyDestructible.armor = (float)level * 0.1f;
        enemyDestructible.XP = level;
    }

    public virtual void CalculateGunProperties()
    {
        foreach(var gun in guns)
        {
            gun.CalculateProperties(level);
        }
    }
}
