using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroup : MonoBehaviour
{
    public bool isSpawn = false;
    public int level = 0;
    public EnemyShip[] enemies;
    void Start()
    {
        enemies = transform.GetComponentsInChildren<EnemyShip>();
        foreach(var enemy in enemies)
        {
            enemy.level = level;
            enemy.CalculateProperties();
        }
    }


    void Update()
    {
      
        if (AreAllEnemiesDestroyed())
        {
            SpawnManager.instance.SubtractSpawn(isSpawn);
            Destroy(gameObject);
        }
    }

    public bool AreAllEnemiesDestroyed()
    {
        foreach (var enemy in enemies)
        {
            if (enemy != null)
            {             
                return false;
            }
        }
        return true;
    }
}
