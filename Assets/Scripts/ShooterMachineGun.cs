using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterMachineGun : Shooter
{
    
    public float spread = 0.6f;


    public override void Shoot()
    {
            GameObject go = Instantiate(bullet.gameObject, transform.position, Quaternion.identity);

            float spreadAngle = Random.Range(-spread, spread);
            Quaternion spreadRotation = Quaternion.Euler(0f, 0f, spreadAngle);

            Bullet goBullet = go.GetComponent<Bullet>();
            goBullet.transform.rotation = goBullet.transform.rotation * spreadRotation;
            goBullet.direction = spreadRotation * direction;
            goBullet.damage = damage;
            goBullet.isEnemy = isEnemy;
            shooterTimer = initShooterTimer;

    }



    public override void CalculateProperties(int level)
    {
        damage = 0.7f + (float)level * 0.07f;
        initShooterTimer = Mathf.Max(6 - level / 4, 1);
    }
}
