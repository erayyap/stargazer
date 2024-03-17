using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Bullet bullet;
    public Vector2 direction;
    public int initShooterTimer = 30;
    public int shooterTimer = 0;
    public float damage = 1;
    public bool isEnemy = false;
    public bool isActive = false;

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

    public virtual void Shoot()
    {
            GameObject go = Instantiate(bullet.gameObject, transform.position, Quaternion.identity);
            Bullet goBullet = go.GetComponent<Bullet>();
            goBullet.direction = direction;
            goBullet.damage = damage;
            goBullet.isEnemy = isEnemy;
            shooterTimer = initShooterTimer;
    }

    public virtual void CalculateProperties(int level)
    {
        damage = 1f + (float)level * 0.1f;
        initShooterTimer = Mathf.Max(30 - level / 2, 5);
    }
}
