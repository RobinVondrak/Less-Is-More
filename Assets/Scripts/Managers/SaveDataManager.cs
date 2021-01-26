using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class SaveDataManager : MonoBehaviour
{
    private string saveFileName = "gamedata";
    private SaveComponent saveComp;

    private void Start()
    {
        saveComp = gameObject.AddComponent<SaveComponent>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            SaveData();
            Debug.Log("Saving done!");
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            LoadFromFile();
            Debug.Log("Loading done!");
        }
    }

    private void SaveData()
    {
        SaveData playerSaveData = new SaveData();
        //Player data
        playerSaveData.lastCheckpointReached = 5;
        playerSaveData.playerPosition = new Vector2(13, 37);
        //Items
        playerSaveData.playerItems = new List<ItemData>();
        playerSaveData.playerItems.Add(new ItemData() { id = 2, name = "Apple", value = 15});
        playerSaveData.playerItems.Add(new ItemData() { id = 13, name = "Glock-19", value = 9200});

        //Timestamp and write file
        playerSaveData.timeStamp = DateTime.Now.ToString();
        WriteToFile(JsonUtility.ToJson(playerSaveData));
    }

    private void WriteToFile(string _jsonData)
    {
        using (FileStream writer = File.OpenWrite(Application.persistentDataPath + $"/{saveFileName}.lsm"))
        {
            byte[] bytes = Encoding.UTF8.GetBytes(_jsonData);
            writer.Write(bytes, 0, bytes.Length);
        }
        Debug.Log($"Saved to {Application.persistentDataPath}");
    }

    private void LoadFromFile()
    {
        using (StreamReader reader = File.OpenText(Application.persistentDataPath + $"/{saveFileName}.lsm"))
        {
            string jsonData = reader.ReadToEnd();
            saveComp.data = JsonUtility.FromJson<SaveData>(jsonData);
            Debug.Log($"Loaded {jsonData}");
        }
    }
}
