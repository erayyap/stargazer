using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestructible : Destructible
{
    public int XP = 0;

    private new void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet bullet = collision.GetComponent<Bullet>();

        if (bullet != null && !bullet.isEnemy)
        {
            if (bullet.damage > armor)
            {
                DamageHealth(bullet.damage);
            }
            Destroy(bullet.gameObject);
            if (HP <= 0)
            {
                LevelManager.instance.AddXP(XP);
                Destroy(gameObject);
            }
        }
    }
}
