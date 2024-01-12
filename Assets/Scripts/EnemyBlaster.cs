using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlaster : EnemyShip
{

    public override void CalculateProperties()
    {
        enemyDestructible.maxHP = 20 + level * 3;
        enemyDestructible.HP = enemyDestructible.maxHP;
        enemyDestructible.armor = (float)level * 0.2f;
        enemyDestructible.XP = level * 3;
        CalculateGunProperties();
    }
}
