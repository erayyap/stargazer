using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public int level = 1;
    public EnemyDestructible enemyDestructible;
    public Shooter[] guns;
    public LevelScaling healthScaling;
    public LevelScaling armorScaling;
    public LevelScaling xpScaling;

    void Awake()
    {
        guns = transform.GetComponentsInChildren<Shooter>();
    }

    void Start()
    {
        
    }

    public virtual void CalculateProperties()
    {
        enemyDestructible.maxHP = healthScaling.CalculateProperty(level);
        enemyDestructible.HP = enemyDestructible.maxHP;
        enemyDestructible.armor = armorScaling.CalculateProperty(level);
        enemyDestructible.XP = (int) xpScaling.CalculateProperty(level);
        CalculateGunProperties();
    }

    public virtual void CalculateGunProperties()
    {
        foreach(var gun in guns)
        {
            Debug.Log("here");
            gun.CalculateProperties(level);
        }
    }
}
