using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int level = 1;
    public int XP = 0;
    public int neededXP;
    public Ship player;

    public static LevelManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one LevelSystem in scene!");
            return;
        }

        instance = this;

        SetLevel(1);
    }

    public void CalculateLevelXP()
    {
        neededXP = (int)Mathf.Pow(level, 2.5f);
    }

    public void AddXP(int amount)
    {
        XP += amount;
        if (XP >= neededXP)
        {
            level++;
            CalculateLevelXP();
            player.CalculateProperties(level);
        }
    }

    public void SetLevel(int lvl)
    {
        level = lvl;
        CalculateLevelXP();
    }
}
