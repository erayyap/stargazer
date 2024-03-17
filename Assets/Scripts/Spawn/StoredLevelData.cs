using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class StoredGroupData
{
    public DataOp opCode;
    public int time;
    [SerializeField]
    public StringIntPair[] vars;
}

[Serializable]
public class StringIntPair
{
    public string ident;
    public int val;
}



[CreateAssetMenu(fileName = "LevelData", menuName = "Custom/LevelData", order = 1)]
[Serializable]
public class StoredLevelData : ScriptableObject
{
    [SerializeField]
    public StoredGroupData[] spawns;

    public static bool IsFlag(DataOp op)
    {
        return op == DataOp.FLAG_ALL_ENEMIES_GONE || op == DataOp.FLAG_ALL_SPAWNS_GONE;
    }

    public LevelData ToLevelData()
    {
        GroupData[] gD = new GroupData[spawns.Length];
        for (int i = 0; i < gD.Length; i++)
        {
            StoredGroupData storedGroupData = spawns[i];
            Dictionary<string, int> dict = new Dictionary<string, int>();
            foreach (var element in storedGroupData.vars)
            {
                dict.Add(element.ident, element.val);
            }
            gD[i] = new GroupData()
            {
                opCode = storedGroupData.opCode,
                time = storedGroupData.time,
                vars = dict
            };
        }
        return new LevelData()
        {
            spawns = gD
        };
    }
}
