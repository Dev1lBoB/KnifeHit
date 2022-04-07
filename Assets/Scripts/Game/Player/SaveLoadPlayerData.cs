using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[RequireComponent(typeof(PlayerData))]
public class SaveLoadPlayerData : MonoBehaviour
{
    private PlayerData playerData;

    private int[] data = new int[3];

    private void Awake()
    {
        playerData = GetComponent<PlayerData>();
        Load();
        playerData.bestScore = data[0];
        playerData.bestStage = data[1];
        playerData.balance = data[2];
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    public void Save()
    {
        // Serialize and save all the necessary data into the file named "PlayerData.gd"
        data[0] = playerData.bestScore;
        data[1] = playerData.bestStage;
        data[2] = playerData.balance;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/PlayerData.gd");
        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        // Deseialize file "PlayerData.gd" and extract all the data
        if (File.Exists(Application.persistentDataPath + "/PlayerData.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/PlayerData.gd", FileMode.Open);
            data = (int[])bf.Deserialize(file);
            file.Close();
        }
    }
}
