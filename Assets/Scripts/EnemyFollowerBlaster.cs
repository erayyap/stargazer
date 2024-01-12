using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowerBlaster : EnemyShip
{

    public override void CalculateProperties()
    {
        enemyDestructible.maxHP = 40 + level * 5;
        enemyDestructible.HP = enemyDestructible.maxHP;
        enemyDestructible.armor = (float)level * 0.15f;
        enemyDestructible.XP = level * 4;
        CalculateGunProperties();
    }
}
