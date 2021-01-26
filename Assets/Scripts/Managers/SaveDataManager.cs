using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class SaveDataManager : MonoBehaviour
{
    private string saveFileName = "gamedata";
    private string saveFileNameDatabase = "gamedata8080";
    private string localhost = @"http://localhost:8080/";
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
        else if (Input.GetKeyDown(KeyCode.I))
        {
            SaveData(true);
            Debug.Log("Saving done on database!");
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            LoadFromFileOnDatabase();
            Debug.Log("Loading done from database!");
        }
    }

    private void SaveData(bool onDatabase = false)
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
        string data = JsonUtility.ToJson(playerSaveData);

        if (onDatabase)
            WriteToFileOnDatabase(data);
        else
            WriteToFile(data);
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

    private void LoadFromFileOnDatabase()
    {
        HttpWebRequest request = (HttpWebRequest) WebRequest.Create($"http://localhost:8080/{saveFileNameDatabase}");
        HttpWebResponse response = (HttpWebResponse) request.GetResponse();

        using (Stream stream = response.GetResponseStream())
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                string content = reader.ReadToEnd();
                saveComp.data = JsonUtility.FromJson<SaveData>(content);
            }
        }
    }

    private void WriteToFileOnDatabase(string _jsonData)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"http://localhost:8080/{saveFileNameDatabase}");
        request.ContentType = "application/json";
        request.Method = "PUT";

        using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
        {
            writer.Write(_jsonData);
        }

        HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
        {
            string result = reader.ReadToEnd();
            Debug.Log($"Data wrote to server: {result}");
        }
    }
}
