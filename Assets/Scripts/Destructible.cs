using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public float HP = 20;
    public float maxHP = 20;
    public float armor = 0;
    public Transform healthBar;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet bullet = collision.GetComponent<Bullet>();
       

        if(bullet != null && bullet.isEnemy)
        {
            if (bullet.damage > armor)
            {
                DamageHealth(bullet.damage);
            }
            Destroy(bullet.gameObject);
            if (HP <= 0)
            {
                Destroy(gameObject);
            }
        }

        EnemyDestructible enemy = collision.GetComponent<EnemyDestructible>();
        if (enemy != null)
        {
            DamageHealth(enemy.HP / 5);
            Destroy(enemy.gameObject);
        }

        if(HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void DamageHealth(float amount)
    {
        HP -= amount;
        if (healthBar != null)
        {
            float scale = HP / maxHP;
            if (HP > 0)
            {
                healthBar.localScale = new Vector3(scale, healthBar.localScale.y, healthBar.localScale.z);
                Vector3 pos = healthBar.localPosition;
                pos.x = (scale - 1) / 2;
                healthBar.localPosition = pos;
            }
        }
    }
}
