using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum Group
{
    CRUISER_4,
    BLASTER_1
}

public class SpawnManager : MonoBehaviour
{
    public GameObject[] groups;
    public int timer = 0;
    public int frequencyTimer = 0;
    public int index = 0;
    public LevelData levelData;
    public List<GroupData> cache;
    public static SpawnManager instance;
    public int spawnedGroupCount = 0;
    public int allGroupCount = 0;

    public StoredLevelData initData;

    void Start()
    {
        RefreshData(initData);
        timer = 0;
        cache = new List<GroupData>();
    }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one LevelSystem in scene!");
            return;
        }

        instance = this;

    }

    void FixedUpdate()
    {
        frequencyTimer++;
        if (index < levelData.spawns.Length)
        {
            if (timer < levelData.spawns[index].time && !LevelData.IsFlag(levelData.spawns[index].opCode))
            {
                timer++;
            }
            else
            {
                var s = levelData.spawns[index];
                switch (s.opCode)
                {
                    case DataOp.SPAWN:
                        SpawnEnemy(s);
                        index++;
                        break;
                    case DataOp.CACHE:
                        cache.Add(s);
                        index++;
                        break;
                    case DataOp.FLAG_ALL_ENEMIES_GONE:
                        if (allGroupCount <= 0)
                        {
                            ClearCache(s.vars["id"]);
                            index++;
                        }
                        break;
                    case DataOp.FLAG_ALL_SPAWNS_GONE:
                        if (spawnedGroupCount <= 0)
                        {
                            ClearCache(s.vars["id"]);
                            index++;
                        }
                        break;

                }
            }
        }
        RunCache();
    }

    public void RunCache()
    {
        foreach (var g in cache)
        {
            if (g.opCode == DataOp.CACHE && frequencyTimer % g.vars["frequency"] == 0) { 
                SpawnEnemy(g); 
            }
        }
    }

    public void SortSpawns()
    {
        Array.Sort(levelData.spawns, new GroupDataComparer());
    }

    public void RefreshData(StoredLevelData ld)
    {
        levelData = ld.ToLevelData();
        index = 0;
        timer = 0;
        cache = new List<GroupData>();
    }

    public void ClearCache(int triggerID)
    {
        cache = cache.Where(a => a.vars["trigger_id"] != triggerID).ToList();
    }

    public class GroupDataComparer : IComparer<GroupData>
    {
        public int Compare(GroupData x, GroupData y)
        {
            return x.time.CompareTo(y.time);
        }
    }

    public void SpawnEnemy(GroupData gD)
    {
        Vector2 spawnPos = new Vector2(gD.vars["posx"], gD.vars["posy"]);
        int level = gD.vars["level"];
        int ID = gD.vars["id"];
        bool isSpawn = gD.opCode == DataOp.SPAWN;
        GameObject go = Instantiate(groups[ID], spawnPos, Quaternion.identity);
        var spawn = go.GetComponent<EnemyGroup>();
        spawn.level = level;
        spawn.isSpawn = isSpawn;
        AddSpawn(isSpawn);
    }

    public void SubtractSpawn(bool isSpawn)
    {
        if (isSpawn) spawnedGroupCount--;
        allGroupCount--;
    }

    public void AddSpawn(bool isSpawn)
    {
        if (isSpawn) spawnedGroupCount++;
        allGroupCount++;
    }
}
