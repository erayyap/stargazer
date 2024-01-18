using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScaling : MonoBehaviour
{
    public float baseValue = 0;
    public float valueIncrement = 0;

    public virtual float CalculateProperty(int level)
    {
        return baseValue * level * valueIncrement;
    }
}
