using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum DataOp
{
    SPAWN, //id -> Group ID, level-> Group Level, (posx,posy) -> Spawn Position
    CACHE, //id -> Group ID, level-> Group Level, (posx,posy) -> Spawn Position, trigger_id-> Flag To Destroy, frequency-> Time To Spawn 
    FLAG_ALL_ENEMIES_GONE, //id-> Flag To Trigger (When No Enemies Exist In Screen)
    FLAG_ALL_SPAWNS_GONE //id-> Flag To Trigger (When No Spawns Exist In Screen)
}

public class GroupData
{
    public DataOp opCode;
    public int time;
    [SerializeField]
    public Dictionary<string, int> vars;
}

public class LevelData : ScriptableObject
{
    [SerializeField]
    public GroupData[] spawns;

    public static bool IsFlag(DataOp op)
    {
        return op == DataOp.FLAG_ALL_ENEMIES_GONE || op == DataOp.FLAG_ALL_SPAWNS_GONE;
    }
}
