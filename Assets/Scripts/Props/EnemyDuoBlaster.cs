using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDuoBlaster : EnemyShip
{
    public int shooterTimer = 30;
    public int burstPeriod = 5;
    public int burstTimer = 20;
    public Sprite firstForm;
    public Sprite secondForm;
    public SpriteRenderer spriteRenderer;
    private int timer = 0;

    void Start()
    {
        guns = transform.GetComponentsInChildren<Shooter>();
    }

    public override void CalculateProperties()
    {
        shooterTimer  = Mathf.Max(30 - level / 3, 10);
        burstTimer = Mathf.Max(22 - level / 2, 2);
        burstPeriod = Mathf.Max(4 - level / 5, 1);
        //spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        base.CalculateProperties();
    }

    void FixedUpdate()
    {
        if(enemyDestructible.HP < enemyDestructible.maxHP / 2)
        {
            spriteRenderer.sprite = secondForm;
            if(timer >= burstTimer && timer % burstPeriod == 0)
            {
                foreach (var g in guns)
                {
                    g.Shoot();
                }
            }
        } else
        {
            spriteRenderer.sprite = firstForm;
            if (timer >= shooterTimer)
            {
                foreach (var g in guns)
                {
                    g.Shoot();
                }
            }
        }
        timer = (timer + 1) % shooterTimer;

    }
}
