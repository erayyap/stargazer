using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class LevelManager : MonoBehaviour
{
    public int level = 1;
    public int XP = 0;
    public int neededXP;
    public Ship player;
    public Image XPFill;
    public TMP_Text levelText;
    public TMP_Text xpText;

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
        while (XP >= neededXP)
        {
            level++;
            XP -= neededXP;
            CalculateLevelXP();
            player.CalculateProperties(level);
            levelText.text = $"Level {level}";
        }
        XPFill.fillAmount = ((float)XP / (float)neededXP);
        xpText.text = $"{XP} / {neededXP}";

    }

    public void SetLevel(int lvl)
    {
        level = lvl;
        CalculateLevelXP();
    }
}
