using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    public StoredLevelData level;

    public void Load()
    {
        Debug.Log("clicked");
        SpawnManager.instance.RefreshData(level);
    }
}
