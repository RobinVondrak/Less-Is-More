using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveData
{
    public Vector2 playerPosition;
    public int lastCheckpointReached;
    public string timeStamp;
    public List<ItemData> playerItems;

}

[Serializable]
public class ItemData
{
    public int id;
    public string name;
    public int value;
}