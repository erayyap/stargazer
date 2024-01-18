using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearLevelScaling : LevelScaling
{

    public override float CalculateProperty(int level)
    {
        return baseValue + level * valueIncrement;
    }
}
