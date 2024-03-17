using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterHomingEnemy : Shooter
{
    // Start is called before the first frame update
    void Start()
    {
        direction = (transform.localRotation * Vector2.up).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        shooterTimer--;
        if(isActive && shooterTimer <= 0)
        {
            Shoot();
        }
    }

    public override void Shoot()
    {
            direction = (Ship.instance.transform.position - transform.position).normalized;
            GameObject go = Instantiate(bullet.gameObject, transform.position, Quaternion.identity);
            Bullet goBullet = go.GetComponent<Bullet>();
            goBullet.direction = direction;
            goBullet.damage = damage;
            goBullet.isEnemy = isEnemy;
            shooterTimer = initShooterTimer;
    }

}
